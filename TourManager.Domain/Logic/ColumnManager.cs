using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Domain.Abstract;
using TourManager.Domain.Models.AboutColumn;
using TourManager.Storage;
using TourManager.Storage.Models;
using ColumnDb = TourManager.Storage.Models.Column;


namespace TourManager.Domain.Logic
{
    public class ColumnManager : BaseManager, IColumnManager
    {
        public ColumnManager(TourManagerDbContext dbContext)
            : base(dbContext)
        {

        }

        public async Task<int> IncludeStandardColumnsToTour(Guid tourId)
        {
            var standardColumns = await dbContext.Set<StandardColumn>().ToListAsync();
            standardColumns.ForEach(c =>
            {
                dbContext.Set<ColumnDb>().Add(new ColumnDb
                {
                    Name = c.Name,
                    Code = c.Code,
                    TourId = tourId,
                    ValueType = c.ValueType,
                    DefaultAccess = c.DefaultAccess,
                    SortOrder = c.SortOrder,
                    Options = c.Options
                });
            });

            var saved = await dbContext.SaveChangesAsync();
            return saved;
        }

        public async Task<SplittedColumns> GetColumnsCode(Guid tourId)
        {
            var columnsFromDb = await dbContext.Set<ColumnDb>().Where(c => c.TourId == tourId).ToListAsync();
            var splittedColumns = new SplittedColumnsSetter(columnsFromDb);
            splittedColumns.SplitColumns();

            return splittedColumns;
        }
    }
}
