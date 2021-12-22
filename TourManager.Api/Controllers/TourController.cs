using Microsoft.AspNetCore.Mvc;
using TourManager.Domain.Abstract;
using TourManager.Domain.Models;

namespace TourManager.Api.Controllers
{
    [Route("api/Tour")]
    [ApiController]
    public class TourController : Controller
    {
        private readonly ITourManager tourManager;

        public TourController(ITourManager tourManager)
        {
            this.tourManager = tourManager;
        }

        [HttpPost]
        public ActionResult Save([FromBody] Tour tour)
        {
            var savingResult = tourManager.Save(tour);

            if (savingResult < 1)
            {
                return Conflict();
            }
            return Ok();
        }

        
    }
}
