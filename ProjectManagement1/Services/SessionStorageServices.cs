using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using ProjectManagement1.Core.Services.Authentication;

namespace ProjectManagement1.Services;

public class SessionStorageService(ProtectedSessionStorage _storage) : ISessionStorage
{
    public async Task SetAsync<T>(string key, T value)
    {
        if (value is null) return;
        await _storage.SetAsync(key, value);
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        try
        {
            var result = await _storage.GetAsync<T>(key);
            return result.Success ? result.Value : default;
        }
        catch
        {
            return default;
        }
    }

    public async Task DeleteAsync(string key)
        => await _storage.DeleteAsync(key);
}