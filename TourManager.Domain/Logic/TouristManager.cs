using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManager.Domain.Abstract;
using TourManager.Domain.Models.Abstract;
using TourManager.Domain.Models.AboutTourist;
using TourManager.Storage;
using TourManager.Storage.Models;
using Cell = TourManager.Domain.Models.AboutColumn.Cell;
using CellDb = TourManager.Storage.Models.Cell;
using Tourist = TourManager.Domain.Models.AboutTourist.Tourist;
using TourManager.Domain.Models.AboutColumn;
using ColumnDb = TourManager.Storage.Models.Column;
using TouristDb = TourManager.Storage.Models.Tourist;

namespace TourManager.Domain.Logic
{
    public class TouristManager : BaseManager, ITouristManager
    {
        private readonly IRowProvider rowProvider;
        public TouristManager(TourManagerDbContext dbContext, IRowProvider rowProvider)
            : base(dbContext)
        {
            this.rowProvider = rowProvider;
        }
        public async Task<ITourist> Get(Guid id)
        {
            var touristStorage = await dbContext.Set<TouristDb>().Where(t => t.Id == id).SingleOrDefaultAsync();

            var tourist = new Tourist()
            {
                Name = touristStorage.Name,
                TourId = touristStorage.TourId,
            };
            return tourist;
        }

        public async Task<int> Add(TouristValues touristValues)
        {
            using (var transaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    var tourColumns = await dbContext.Set<ColumnDb>().Where(c => c.TourId == touristValues.TourId).ToListAsync();
                    var newTouristId = Guid.NewGuid();
                    var newTourist = new TouristDb
                    {
                        Id = newTouristId,
                        TourId = touristValues.TourId,
                    };
                    dbContext.Add(newTourist);
                    await dbContext.SaveChangesAsync();

                    touristValues.ColumnValues.ForEach(cv =>
                    {
                        var column = tourColumns.Where(tc => tc.Code == cv.ColumnCode).Single();
                        var cell = new CellSetter(newTourist.Id, column.Id, column.ValueType);
                        cell.SetValue(cv.Value);
                        var cellDb = new CellDb()
                        {
                            TouristId = cell.TouristId,
                            ColumnId = cell.ColumnId,
                            StringValue = cell.StringValue,
                            DecimalValue = cell.DecimalValue,
                            IntValue = cell.IntValue,
                            DateTimeValue = cell.DateTimeValue,
                            BoolValue = cell.BoolValue,
                            GuidValue = cell.GuidValue
                        };
                        dbContext.Add(cellDb);
                    });

                    var result = await dbContext.SaveChangesAsync();
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public async Task<IEnumerable<Row>> RowList(Guid tourId)
        {
            var tourists = await dbContext.Set<TouristDb>().Where(t => t.TourId == tourId).Select(t => t.Id).ToListAsync();
            var cells = await dbContext.Set<CellDb>().Where(c => tourists.Contains(c.TouristId)).ToListAsync();
            var columnIdToColumnMap = await dbContext.Set<ColumnDb>().Where(c => c.TourId == tourId).ToDictionaryAsync(c => c.Id, c => c);
            var rows = rowProvider.GenerateRows(cells, columnIdToColumnMap);
            return rows;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
