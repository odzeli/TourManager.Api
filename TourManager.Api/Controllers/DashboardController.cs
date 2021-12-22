﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Domain.Abstract;
using TourManager.Domain.Models;

namespace TourManager.Api.Controllers
{
    [Route("api/Dashboard/")]
    [ApiController]
    public class DashboardController : Controller
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