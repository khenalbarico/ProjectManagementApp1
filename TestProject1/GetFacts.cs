using ProjectManagement1.Core.Repository;
using ProjectManagement1.Models;
using TestProject1.TestTools;
using Xunit.Abstractions;

namespace TestProject1;

public class GetFacts (ITestOutputHelper _ctx)
{
    [Fact] public void Load_Projects()
    {
        var _sut = _ctx.Get<IAppRepository>();

        var res = _sut.LoadDatasource<List<Project>>();
    }

    [Fact] public void Load_Developers()
    {
        var _sut = _ctx.Get<IAppRepository>();

        var res = _sut.LoadDatasource<List<Developer>>();
    }

    [Fact] public void Load_WorkItems()
    {
        var _sut = _ctx.Get<IAppRepository>();

        var res = _sut.LoadDatasource<List<WorkItem>>();
    }
}
