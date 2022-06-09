
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace NET105.Interfaces

{
    public interface IUploadHelper 
    {
        public Task<bool?> UploadFileAsync(IFormFile file);

        public void DeleteFile(string fileName);
    }
}