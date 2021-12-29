using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Domain.Models;

namespace TourManager.Domain.Abstract
{
    public interface ITourManager
    {
        public int Save(Tour tour);
        public Task<List<Tour>> AllTours();
        public Task<DateTime> GetTourStartDate(Guid tourId);
    }
}
