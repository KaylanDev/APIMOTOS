namespace Motos.Application.Service
{
    public interface ICacheService
    {
        Task<T> GetOrCreate<T>(string key, Func<Task<T>> createItem);
        void Remove(string key);
    }
}
