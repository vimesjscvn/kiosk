using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TEK.Core.Service.Interfaces;

namespace Admin.API.Domain.Services
{
    public class UploadService : IUploadService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UploadService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> SingleUpload(IFormFile file)
        {
            if (file == null)
                return string.Empty;

            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var folderName = @"uploads/";
            var pathToSave = Path.Combine("wwwroot/", folderName);
            Directory.CreateDirectory(pathToSave);
            var fullPath = Path.Combine(pathToSave, fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var scheme = _httpContextAccessor.HttpContext.Request.Scheme;
            var host = _httpContextAccessor.HttpContext.Request.Host;
            var pathBase = _httpContextAccessor.HttpContext.Request.PathBase;
            return $"{scheme}://{host}{pathBase}/{folderName}{fileName}";
        }
    }
}
