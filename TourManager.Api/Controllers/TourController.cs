using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TourManager.Domain.Abstract;
using Microsoft.AspNetCore.Authorization;
using Tour = TourManager.Domain.Models.Tour;
using ColumnDb = TourManager.Storage.Models.Column;
using TourManager.Domain.Models.TourExpense;

namespace TourManager.Api.Controllers
{
    [Authorize]
    [Route("api/Tour/{tourId}")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly ITourManager tourManager;

        public TourController(ITourManager tourManager)
        {
            this.tourManager = tourManager;
        }

        [HttpPost, Route("editMode/{editMode}")]
        public Task TaskSaveTour([FromBody] Tour tour, bool editMode)
        {
            return tourManager.SaveTour(tour, editMode);
        }

        [HttpGet, Route("tourMainInfo")]
        public async Task<ActionResult<Tour>> TourMainInfo(Guid tourId)
        {
            var tour = await tourManager.TourMainInfo(tourId);

            return Ok(tour);
        }

        [HttpGet, Route("getColumns")]
        public async Task<ActionResult<ColumnDb>> GetColumns(Guid tourId)
        {
            var columns = await tourManager.GetColumns(tourId);

            return Ok(columns);
        }

        [HttpGet, Route("initialize-tour-editing")]
        public Task<Tour> InitializeTourEditing(Guid tourId)
        {
            return tourManager.InitializeTourEditing(tourId);
        }

        [HttpDelete, Route("delete-tour")]
        public Task DeleteTour(Guid tourId)
        {
            return tourManager.DeleteTour(tourId);
        }

        [HttpGet, Route("tour-expenses")]
        public Task<List<TourExpenseGroup>> TourExpenses(Guid tourId)
        {
            return tourManager.TourExpenses(tourId);
        }

        [HttpGet, Route("save-tour-expenses")]
        public Task SaveTourExpenses(Guid tourId, [FromBody]List<TourExpenseGroup> tourExpenses)
        {
            return tourManager.SaveTourExpenses(tourId, tourExpenses);
        }
    }
}
