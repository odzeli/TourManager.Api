using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TourManager.Domain.Abstract;
using ColumnDb = TourManager.Storage.Models.Column;
using Tour = TourManager.Domain.Models.Tour;

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
        public async Task<IActionResult> Add([FromBody] Tour tour)
        {
            var savingResult = await tourManager.Add(tour);

            if (savingResult < 1)
            {
                return Conflict();
            }
            return Ok();
        }

        [HttpGet, Route("getTourStartDate/{tourId}")]
        public async Task<ActionResult<DateTime>> GetTourStartDate(Guid tourId)
        {
            var startDate = await tourManager.GetTourStartDate(tourId);

            return Ok(startDate);
        }

        [HttpGet, Route("getColumns/{tourId}")]
        public async Task<ActionResult<ColumnDb>> GetColumns(Guid tourId)
        {
            var columns = await tourManager.GetColumns(tourId);

            return Ok(columns);
        }

    }
}
