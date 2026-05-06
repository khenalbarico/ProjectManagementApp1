//using ProjectManagement1.Core.Repository;
//using ProjectManagement1.Core.Utilities;
//using ProjectManagement1.Models;
//using ProjectManagement1.Models.Constants;
//using ProjectManagement1.Models.Enums;
//using TestProject1.TestTools;
//using Xunit.Abstractions;

//namespace TestProject1;

//public class PatchFacts (ITestOutputHelper _ctx)
//{
//    [Fact] public void Patch_Project()
//    {
//        var payload = new Project()
//        {
//            Uid       = "PRJ-66558",
//            Title     = "Conflict Check1",
//            Priority  = ProjectPriorityStatus.NotPriority,
//            Activity  = ProjectActivityStatus.LowActivity,
//            KeyPerson = KeyPersons.Liza

//        };

//        var _sut = _ctx.Get<IAppRepository>();

//        _sut.PatchProject(payload);
//    }

//    [Fact] public void Patch_Developer()
//    {
//        var payload = new Developer()
//        {
//            Uid             = "DEV-27857",
//            Name            = "Marcus",
//            Workload        = DeveloperWorkloadStatus.Standby,
//            Health          = DeveloperHealthStatus.Unhealthy,
//            Project         = ["PRJ-12345"],
//            ProjectExposure = DeveloperProjectExposureStatus.UnderExposed
//        };

//        var _sut = _ctx.Get<IAppRepository>();

//        _sut.PatchDeveloper(payload);
//    }

//    [Fact] public void Patch_WorkItem()
//    {
//        var payload = new WorkItem()
//        {
//            Uid       = "WRK-64934",
//            Reference = "https://dev.azure.com/RouseCo/Conflict%20Check%20AI/_workitems/edit/14228",
//            Developer = "DEV-12345",
//            Status    = WorkItemStatus.WaitingForConfirmation
//        };

//        var _sut = _ctx.Get<IAppRepository>();

//        _sut.PatchWorkItem(payload);
//    }
//}
