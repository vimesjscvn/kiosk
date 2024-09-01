using System.Threading.Tasks;

namespace Core.Common.Interfaces
{
    public interface IHttpService
    {
        Task<int> GetUrlResponseStatusCodeAsync(string url);
    }
}