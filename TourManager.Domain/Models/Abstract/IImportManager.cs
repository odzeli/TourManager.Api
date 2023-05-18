using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace TourManager.Domain.Models.Abstract
{
    public interface IImportManager
    {

        public Task UploadToursFile(IFormFile uploadedFile, string webRootPath);

        public Task ImportProcess(string path);
    }
}
