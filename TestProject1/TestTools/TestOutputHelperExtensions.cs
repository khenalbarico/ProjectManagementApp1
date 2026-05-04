using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjectManagement1.Core.Repository;
using Xunit.Abstractions;

namespace TestProject1.TestTools;

internal static class TestOutputHelperExtensions
{
    static IHost? Host;
    public static T Get<T>(this ITestOutputHelper ctx) where T : class
    {
        Host ??= new HostBuilder().ConfigureServices(services =>
        {
            services.AddSingleton<IAppRepository, AppRepository>();

        }).Build();

        return Host.Services.GetRequiredService<T>();
    }
}
