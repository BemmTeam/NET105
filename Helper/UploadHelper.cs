using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace NET105.Helper
{

    public class UploadHelper : Interfaces.IUploadHelper
    {
        private readonly IWebHostEnvironment environment;

        public UploadHelper(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public void DeleteFile(string fileName)
        {
            var filePath = Path.Combine(environment.WebRootPath, "Images", "Products", fileName??="null");
            if (File.Exists(filePath))
            {
               File.Delete(filePath);
            }
        }

        public async Task<bool?> UploadFileAsync(IFormFile file)
        {
            if (file != null)
            {
                try
                {
                    var filePath = Path.Combine(environment.WebRootPath, "Images", "Products", file.FileName);

                    if (File.Exists(filePath))
                    {
                        return null; // null = đã tồn tại
                    }
                    using var filestream = new FileStream(filePath, FileMode.Create);
                    await file.CopyToAsync(filestream);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}