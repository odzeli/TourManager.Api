using Microsoft.EntityFrameworkCore;
using System;
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
            : base(dbContext)
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
                 .Select(t => new Tour
                 {
                     Drivers = t.Drivers,
                     Guides = t.Guides,
                     Id = t.Id,
                     StartDate = t.StartDate
                 }).ToListAsync();

            tours.ForEach(tour =>
            {
                var tourists = dbContext.Set<Storage.Models.Tourist>().Where(t => t.TourId == tour.Id).ToList();
                if (tourists.Count() > 0)
                    tour.EndDate = tourists.Max(t => t.CheckOutDate);

                tour.TouristNumber = dbContext.Set<Storage.Models.Tourist>().Where(t => t.TourId == tour.Id).Count();
            });
            return tours;
        }

        public async Task<DateTime> GetTourStartDate(Guid tourId)
        {
            var tourStartDate = await dbContext.Set<TourDb>().Where(t => t.Id == tourId).Select(t => t.StartDate).SingleOrDefaultAsync();
            return tourStartDate;
        }
    }
}
