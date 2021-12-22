using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManager.Domain.Abstract;
using TourManager.Domain.Models;
using TourManager.Storage;
using TourDb = TourManager.Storage.Models.Tour;

namespace TourManager.Domain.Logic
{
    public class TourManager : BaseManager, ITourManager
    {

        public TourManager(TourManagerDbContext dbContext)
            :base(dbContext)
        {

        }

        public int Save(Tour tour)
        {
            var storageTour = new TourDb()
            {
                StartDate = tour.StartDate,
                Guides = tour.Guides,
                Drivers = tour.Drivers
            };
            dbContext.Add(storageTour);
            return dbContext.SaveChanges();
        }

        public async Task<List<Tour>> AllTours()
        {
           var tours = await dbContext.Set<TourDb>()
                .Select(t => new Tour { Drivers = t.Drivers, Guides = t.Guides, Id = t.Id, StartDate = t.StartDate }).ToListAsync();
            return tours;
        }
    }
}
