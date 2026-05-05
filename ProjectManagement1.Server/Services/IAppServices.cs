using ProjectManagement1.Models;

public interface IAppServices
{
    (List<Project> Projects, List<Developer> Developers, List<WorkItem> WorkItems) LoadAllDataSource();
    List<Project> LoadProjects();
    List<Developer> LoadDevelopers();
    List<WorkItem> LoadWorkItems();
    void InvalidateCache();
    void InvalidateProjectsCache();
    void InvalidateDevelopersCache();
    void InvalidateWorkItemsCache();
}