using ProjectManagement1.Models;

namespace ProjectManagement1.Core.Services;

public interface IAppServices
{
    (List<Project> Projects, List<Developer> Developers, List<WorkItem> WorkItems) LoadAllDataSource();
    List<Project> LoadProjects();
    List<Developer> LoadDevelopers();
    List<WorkItem> LoadWorkItems();
    List<Account> LoadAccounts();
    void InvalidateCache();
    void InvalidateProjectsCache();
    void InvalidateDevelopersCache();
    void InvalidateWorkItemsCache();
}