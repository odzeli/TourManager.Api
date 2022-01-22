using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Domain.Abstract;
using TourManager.Domain.Models.AboutColumn;
using TourManager.Storage.Models;

namespace TourManager.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]/")]
    [ApiController]
    public class ColumnController : ControllerBase
    {
        private readonly IColumnManager columnManager;
        public ColumnController(IColumnManager columnManager)
        {
            this.columnManager = columnManager;
        }

        [HttpGet, Route("tour/{tourId}/columnsCode")]
        public async Task<SplittedColumns> GetColumnCode(Guid tourId)
        {
            return await columnManager.GetColumnsCode(tourId);
        }

        [HttpGet, Route("standardColumns")]
        public async Task<List<StandardColumn>> StandardColumns()
        {
            return await columnManager.StandardColumns();
        }

        [HttpPost, Route("standardColumn/create")]
        public async Task<int> CreateStandardColumn([FromBody] StandardColumn standardColumn)
        {
            return await columnManager.CreateStandardColumn(standardColumn);
        }
    }
}
