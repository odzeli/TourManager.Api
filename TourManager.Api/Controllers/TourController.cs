using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TourManager.Domain.Abstract;
using TourManager.Domain.Models;

namespace TourManager.Api.Controllers
{
    [Authorize]
    [Route("api/Tour")]
    [ApiController]
    public class TourController : ControllerBase
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

        [Route("getTourStartDate/{tourId}")]
        [HttpGet]
        public async Task<ActionResult<DateTime>> GetTourStartDate(Guid tourId)
        {
            var startDate = await tourManager.GetTourStartDate(tourId);
            if (startDate == null)
            {
                return NotFound();
            }
            return Ok(startDate);
        }


    }
}
