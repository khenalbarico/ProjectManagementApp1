using Microsoft.Extensions.DependencyInjection;
using ProjectManagement1.Core.Repository;
using ProjectManagement1.Core.Services;

namespace ProjectManagement1.Core;

public static class ServiceRegistry
{
    public static void RegisterServices(this IServiceCollection svc)
    {
        svc.AddMemoryCache();
        svc.AddSingleton<IAppRepository, AppRepository>();
        svc.AddSingleton<IAppServices, AppServices>();
    }
}
