using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManager.Domain.Abstract;
using TourManager.Storage;
using TourDb = TourManager.Storage.Models.Tour;
using ColumnDb = TourManager.Storage.Models.Column;
using Tour = TourManager.Domain.Models.Tour;
using System.Text.Json;
using TourManager.Domain.Models.TourExpense;

namespace TourManager.Domain.Logic
{
    public class TourManager : BaseManager, ITourManager
    {

        public readonly IColumnManager columnManager;

        public TourManager(TourManagerDbContext dbContext, IColumnManager columnManager)
            : base(dbContext)
        {
            this.columnManager = columnManager;
        }

        public async Task<int> Add(Tour tour)
        {
            var storageTour = new TourDb()
            {
                Id = Guid.NewGuid(),
                StartDate = tour.StartDate,
                Guides = tour.Guides,
                Drivers = tour.Drivers
            };

            dbContext.Add(storageTour);
            var saved = await dbContext.SaveChangesAsync();

            await columnManager.IncludeStandardColumnsToTour(storageTour.Id);
            return saved;
        }

        public async Task SaveTour(Tour tour, bool editMode)
        {
            Guid savedTourId;

            if (editMode) savedTourId = await EditTour();
            else savedTourId = await CreateTour();


            await columnManager.IncludeStandardColumnsToTour(savedTourId);

            #region local methods
            async Task<Guid> EditTour()
            {
                var tourDb = await dbContext.Set<TourDb>().Where(t => t.Id == tour.Id).SingleAsync();
                tourDb.StartDate = tour.StartDate;
                tourDb.Drivers = tour.Drivers;
                tourDb.Guides = tour.Guides;
                await dbContext.SaveChangesAsync();

                return tourDb.Id;
            }

            async Task<Guid> CreateTour()
            {
                var tourDb = new TourDb()
                {
                    StartDate = tour.StartDate,
                    Guides = tour.Guides,
                    Drivers = tour.Drivers
                };
                await dbContext.AddAsync(tourDb);
                await dbContext.SaveChangesAsync();

                return tourDb.Id;
            }
            #endregion 
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
                    //tour.EndDate = tourists.Max(t => t.CheckOutDate);

                    tour.TouristNumber = dbContext.Set<Storage.Models.Tourist>().Where(t => t.TourId == tour.Id).Count();
            });
            return tours;
        }

        public async Task<Tour> TourMainInfo(Guid tourId)
        {
            return await dbContext.Set<TourDb>().Where(t => t.Id == tourId).Select(t => new Tour { Drivers = t.Drivers, Guides = t.Guides, StartDate = t.StartDate }).SingleOrDefaultAsync();
        }

        public async Task<List<ColumnDb>> GetColumns(Guid tourId)
        {
            var columns = await dbContext.Set<ColumnDb>().AsNoTracking().Where(c => c.TourId == tourId).ToListAsync();
            return columns;
        }

        public async Task<Tour> InitializeTourEditing(Guid tourId)
        {
            //todo check rights
            return await dbContext.Set<TourDb>().AsNoTracking().Where(t => t.Id == tourId).Select(t => new Tour
            {
                Id = t.Id,
                Guides = t.Guides,
                Drivers = t.Drivers,
                StartDate = t.StartDate
            }).SingleAsync();
        }

        public async Task DeleteTour(Guid tourId)
        {
            //todo access check
            var tourDb = await dbContext.Set<TourDb>().Where(t => t.Id == tourId).SingleAsync();

            dbContext.Remove(tourDb);

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<TourExpenseGroup>> TourExpenses(Guid tourId)
        {
            var tour = await dbContext.Set<TourDb>().Where(t => t.Id == tourId).SingleAsync();

            if (tour.Expenses == null) return null;

            var expenses = JsonSerializer.Deserialize<List<TourExpenseGroup>>(tour.Expenses);
            return expenses;
        }

        public async Task SaveTourExpenses(Guid tourId, List<TourExpenseGroup> tourExpenseGroups)
        {
            var tour = await dbContext.Set<TourDb>().Where(t => t.Id == tourId).SingleAsync();

            tour.Expenses = tourExpenseGroups.ToString();

            await dbContext.SaveChangesAsync();
        }
    }
}
