using Microsoft.Extensions.DependencyInjection;
using ProjectManagement1.Core.Repository;
using ProjectManagement1.Core.Services;
using ProjectManagement1.Core.Services.Authentication;

namespace ProjectManagement1.Core;

public static class ServiceRegistry
{
    public static void RegisterServices(this IServiceCollection svc)
    {
        svc.AddMemoryCache();
        svc.AddScoped<IAppRepository, AppRepository>();
        svc.AddScoped<IAppServices, AppServices>();
        svc.AddScoped<IAppAuthentication, AppAuthentication>();
    }
}
