using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Storage.Models;

namespace TourManager.Domain.Abstract
{
    public interface IColumnManager
    {
        public Task<int> IncludeStandardColumnsToTour(Guid tourId);
    }
}
