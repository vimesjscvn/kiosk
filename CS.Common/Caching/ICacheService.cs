using System;
using System.Threading.Tasks;

namespace CS.Common.Caching
{
    public interface ICacheService
    {
        T Get<T>(string key, Func<T> func, TimeSpan? timeout = null);
        Task<T> GetAsync<T>(string key, Func<Task<T>> func, TimeSpan? timeout = null);
    }
}