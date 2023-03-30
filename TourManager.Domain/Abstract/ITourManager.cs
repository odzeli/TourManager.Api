using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Domain.Models;
using ColumnDb = TourManager.Storage.Models.Column;

namespace TourManager.Domain.Abstract
{
    public interface ITourManager
    {
        public Task<int> Add(Tour tour);
        public Task<List<Tour>> AllTours();
        public Task<DateTime> GetTourStartDate(Guid tourId);
        public Task<List<ColumnDb>> GetColumns(Guid tourId);
    }
}
