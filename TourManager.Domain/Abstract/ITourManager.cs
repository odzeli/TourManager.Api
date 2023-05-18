using System;
using System.Threading.Tasks;
using TourManager.Domain.Models;
using System.Collections.Generic;
using ColumnDb = TourManager.Storage.Models.Column;
using TourManager.Domain.Models.TourExpense;

namespace TourManager.Domain.Abstract
{
    public interface ITourManager
    {
        public Task SaveTour(Tour tour, bool editMode);
        public Task<List<Tour>> AllTours();
        public Task<Tour> TourMainInfo(Guid tourId);
        public Task<List<ColumnDb>> GetColumns(Guid tourId);
        public Task<Tour> InitializeTourEditing(Guid tourId);
        public Task DeleteTour(Guid tourId);
        public Task<List<TourExpenseGroup>> TourExpenses(Guid tourId);
        public Task SaveTourExpenses(Guid tourId, List<TourExpenseGroup> tourExpenses);
    }
}
