using ProjectManagement1.Models;

namespace ProjectManagement1.Core.Services;

public interface IAppServices
{
    (List<Project> Projects, List<Developer> Developers, List<WorkItem> WorkItems) LoadAllDataSource();
}
