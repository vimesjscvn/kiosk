using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Core.Service.Interfaces
{
    public interface IUploadService
    {
        Task<string> SingleUpload(IFormFile file);
    }
}