using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Domain.Models.AboutColumn;
using TourManager.Storage.Models;

namespace TourManager.Domain.Abstract
{
    public interface IColumnManager
    {
        public Task<int> IncludeStandardColumnsToTour(Guid tourId);
        public Task<SplittedColumns> GetColumnsCode(Guid tourId);
        public Task<List<StandardColumn>> StandardColumns();
        public Task<int> CreateStandardColumn(StandardColumn standardColumn);
    }
}
