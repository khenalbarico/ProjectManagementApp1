using ProjectManagement1.Models;
using ProjectManagement1.Models.Constants;

namespace ProjectManagement1.Core.Services.Authentication;

public class AppAuthentication(IAppServices _appServices, ISessionStorage _session) : IAppAuthentication
{
    private const string SessionKey = "auth_account";

    public async Task<bool> SignInAsync(string displayName, string password)
    {
        var accounts = _appServices.LoadAccounts();
        var match = accounts.FirstOrDefault(a =>
            a.DisplayName == displayName &&
            a.Password == password);

        if (match is null)
            return false;

        await _session.SetAsync(SessionKey, match.Uid);
        return true;
    }

    public async Task SignOutAsync()
        => await _session.DeleteAsync(SessionKey);

    public async Task<Account?> GetCurrentAccountAsync()
    {
        var uid = await _session.GetAsync<string>(SessionKey);
        if (string.IsNullOrEmpty(uid))
            return null;

        var accounts = _appServices.LoadAccounts();
        return accounts.FirstOrDefault(a => a.Uid == uid);
    }

    public async Task<bool> IsAuthenticatedAsync()
        => await GetCurrentAccountAsync() is not null;

    public async Task<ManagerInfo> GetManagerInfoAsync()
    {
        var account = await GetCurrentAccountAsync();
        if (account is null)
            return new ManagerInfo("Manager", DeveloperImagePaths.Khen, "Project Management Dashboard");

        return ManagerInfo.FromDisplayName(account.DisplayName);
    }
}
