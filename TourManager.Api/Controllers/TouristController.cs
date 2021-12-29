using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourManager.Domain.Abstract;
using TourManager.Domain.Models;
using TourManager.Domain.Models.Abstract;

namespace TourManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TouristController : ControllerBase
    {
        private readonly ITouristManager touristManager;

        public TouristController(ITouristManager touristManager)
        {
            this.touristManager = touristManager;
        }

        // GET: api/Tourist/5
        [HttpGet("{id}")]
        public ActionResult<ITourist> GetTourist(Guid id)
        {
            var tourist = touristManager.Get(id);

            if (tourist == null)
            {
                return NotFound();
            }

            return Ok(tourist);
        }


        [HttpPost]
        public async Task<ActionResult> SetTourist([FromBody]Tourist tourist)
        {
            var saveChangesResult = await touristManager.Set(tourist);
            if (saveChangesResult > 0)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Route("TouristsList/{tourId}")]
        [HttpGet]
        public async Task<IEnumerable<Tourist>> TouristsList(Guid tourId)
        {
            var tourists = await touristManager.TouristsList(tourId);

            return tourists;
        }
    }
}
