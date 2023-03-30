using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Domain.Models.AboutColumn;
using CellDb = TourManager.Storage.Models.Cell;
using ColumnDb = TourManager.Storage.Models.Column;

namespace TourManager.Domain.Abstract
{
    public interface IRowProvider
    {
        public List<Row> GenerateRows(List<CellDb> cells, Dictionary<Guid, ColumnDb> columnIdToColumnMap);
    }
}
