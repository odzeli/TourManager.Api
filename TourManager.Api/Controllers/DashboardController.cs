using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Domain.Abstract;
using TourManager.Domain.Models;

namespace TourManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]/")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ITourManager tourManager;

        public DashboardController(ITourManager tourManager)
        {
            this.tourManager = tourManager;
        }

        [Route("AllTours")]
        [HttpGet]
        public async Task<ActionResult<List<Tour>>> AllTours()
        {
            var tours = await tourManager.AllTours();

            return Ok(tours);
        }
    }
}
