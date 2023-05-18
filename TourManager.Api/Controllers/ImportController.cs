using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using TourManager.Domain.Models.Abstract;

namespace TourManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]/")]
    [ApiController]
    public class ImportController : ControllerBase
    {

        //private readonly IWebHostEnvironment appEnv;
        private readonly IImportManager importManager;

        public ImportController(
            //IWebHostEnvironment appEnv,
            IImportManager importManager
            )
        {
            //this.appEnv = appEnv;
            this.importManager = importManager;
        }


        [HttpPost, Route("upload-and-import-tours")]
        public async Task UploadAndImport([FromForm] IFormFile uploadedFile, [FromServices] IWebHostEnvironment appEnv)
        {
            await importManager.UploadToursFile(uploadedFile, appEnv.WebRootPath);
        }
    }
}
