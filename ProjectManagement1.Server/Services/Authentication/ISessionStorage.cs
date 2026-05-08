namespace ProjectManagement1.Core.Services.Authentication;

public interface ISessionStorage
{
    Task SetAsync<T>(string key, T value);
    Task<T?> GetAsync<T>(string key);
    Task DeleteAsync(string key);
}