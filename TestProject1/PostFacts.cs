//using ProjectManagement1.Core.Repository;
//using ProjectManagement1.Core.Utilities;
//using ProjectManagement1.Models;
//using ProjectManagement1.Models.Constants;
//using ProjectManagement1.Models.Enums;
//using TestProject1.TestTools;
//using Xunit.Abstractions;

//namespace TestProject1;

//public class PostFacts (ITestOutputHelper _ctx)
//{
//    [Fact] public void Post_Project()
//    {
//        var payload = new Project()
//        {
//            Uid       = Prefixes.ProjectPrefix.Generate(),
//            Title     = "Conflict Check",
//            Priority  = ProjectPriorityStatus.NotPriority,
//            Activity  = ProjectActivityStatus.LowActivity,
//            KeyPerson = KeyPersons.Liza

//        };

//        var _sut = _ctx.Get<IAppRepository>();

//        _sut.PostProject(payload);
//    }

//    [Fact] public void Post_Developer()
//    {
//        var payload = new Developer()
//        {
//            Uid             = Prefixes.DeveloperPrefix.Generate(),
//            Name            = "Marcus",
//            Workload        = DeveloperWorkloadStatus.Standby,
//            Health          = DeveloperHealthStatus.Healthy,
//            Project         = ["PRJ-12345"],
//            ProjectExposure = DeveloperProjectExposureStatus.UnderExposed
//        };

//        var _sut = _ctx.Get<IAppRepository>();

//        _sut.PostDeveloper(payload);
//    }

//    [Fact] public void Post_WorkItem()
//    {
//        var payload = new WorkItem()
//        {
//            Uid       = Prefixes.ProjectPrefix.Generate(),
//            Reference = "https://dev.azure.com/RouseCo/Conflict%20Check%20AI/_workitems/edit/14228",
//            Developer = "DEV-12345",
//            Status    = WorkItemStatus.Investigating
//        };

//        var _sut = _ctx.Get<IAppRepository>();

//        _sut.PostWorkItem(payload);
//    }
//}
