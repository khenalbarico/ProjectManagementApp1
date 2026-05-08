using Microsoft.Extensions.Caching.Memory;
using ProjectManagement1.Core.Repository;
using ProjectManagement1.Core.Utilities;
using ProjectManagement1.Models;
using ProjectManagement1.Models.Constants;

namespace ProjectManagement1.Core.Services;

public class AppServices(IAppRepository _appRepos, IMemoryCache _memCache) : IAppServices
{
    public (List<Project> Projects, List<Developer> Developers, List<WorkItem> WorkItems) LoadAllDataSource()
    {
        var projects = _memCache.GetOrCreate(MemoryCacheKeys.ProjectsCacheKey, _ => LoadProjects())!;
        var workItems = _memCache.GetOrCreate(MemoryCacheKeys.WorkItemsCacheKey, _ => LoadWorkItems())!;
        var developers = _memCache.GetOrCreate(MemoryCacheKeys.DevelopersCacheKey, _ => LoadDevelopers())!;

        foreach (var dev in developers)
            dev.Workload = dev.CalculateWorkload(workItems, projects);

        return (projects, developers, workItems);
    }

    public List<Project> LoadProjects() => _appRepos.LoadDatasource<List<Project>>();
    public List<Developer> LoadDevelopers() => _appRepos.LoadDatasource<List<Developer>>();
    public List<WorkItem> LoadWorkItems() => _appRepos.LoadDatasource<List<WorkItem>>();
    public List<Account> LoadAccounts() => _appRepos.LoadDatasource<List<Account>>();

    public void InvalidateCache()
    {
        _memCache.Remove(MemoryCacheKeys.ProjectsCacheKey);
        _memCache.Remove(MemoryCacheKeys.DevelopersCacheKey);
        _memCache.Remove(MemoryCacheKeys.WorkItemsCacheKey);
    }

    public void InvalidateProjectsCache() => _memCache.Remove(MemoryCacheKeys.ProjectsCacheKey);
    public void InvalidateDevelopersCache() => _memCache.Remove(MemoryCacheKeys.DevelopersCacheKey);
    public void InvalidateWorkItemsCache() => _memCache.Remove(MemoryCacheKeys.WorkItemsCacheKey);
}