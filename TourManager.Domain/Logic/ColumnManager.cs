using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TourManager.Domain.Abstract;
using TourManager.Domain.Models.AboutColumn;
using TourManager.Domain.Models.Abstract;
using TourManager.Storage;
using TourManager.Storage.Models;
using ColumnDb = TourManager.Storage.Models.Column;


namespace TourManager.Domain.Logic
{
    public class ColumnManager : BaseManager, IColumnManager
    {
        private readonly IImportManager importManager;
        public ColumnManager(
            TourManagerDbContext dbContext,
            IImportManager importManager
            )
            : base(dbContext)
        {
            this.importManager = importManager;
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
            var columnsFromDb = await dbContext.Set<ColumnDb>().Where(c => c.TourId == tourId).OrderBy(c => c.SortOrder).ToListAsync();
            var splittedColumns = new SplittedColumnsSetter(columnsFromDb);
            splittedColumns.SplitColumns();

            return splittedColumns;
        }

        public async Task<List<StandardColumn>> StandardColumns()
        {
            return await dbContext.Set<StandardColumn>().ToListAsync();
        }

        public async Task CreateStandardColumn(StandardColumn standardColumn)
        {

            var codeIsNotUnique = await dbContext.Set<StandardColumn>().AnyAsync(c => c.Code == standardColumn.Code);
            if (codeIsNotUnique) throw new HttpListenerException(400, "Bad request. Such column code already exist.");

            var all = await dbContext.Set<StandardColumn>().ToListAsync();
            standardColumn.SortOrder = all.Count + 1;
            await dbContext.Set<StandardColumn>().AddAsync(standardColumn);

            await dbContext.SaveChangesAsync();
        }

    }
}
