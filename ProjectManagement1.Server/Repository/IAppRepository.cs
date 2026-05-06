using ProjectManagement1.Models;

namespace ProjectManagement1.Core.Repository;

public interface IAppRepository
{
    void PostDeveloper(Developer payload);
    void PostProject(Project payload);
    void PostWorkItem(WorkItem payload);
    void PatchDeveloper(Developer payload);
    void PatchProject(Project payload);
    void PatchWorkItem(WorkItem payload);
    void DeleteProject(string uid);
    void DeleteDeveloper(string uid);
    void DeleteWorkItem(string uid);
    TResult LoadDatasource<TResult>();
}
