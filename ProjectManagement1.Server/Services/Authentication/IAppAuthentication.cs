using ProjectManagement1.Models;

namespace ProjectManagement1.Core.Services.Authentication;

public interface IAppAuthentication
{
    Task<bool> SignInAsync(string displayName, string password);
    Task SignOutAsync();
    Task<Account?> GetCurrentAccountAsync();
    Task<bool> IsAuthenticatedAsync();
    Task<ManagerInfo> GetManagerInfoAsync();
}