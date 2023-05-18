using Microsoft.AspNetCore.Http;

namespace TourManager.Domain.Models.ImportProcess
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
    }
}
