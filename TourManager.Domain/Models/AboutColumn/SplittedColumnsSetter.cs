using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Storage.Enums;
using ColumnDb = TourManager.Storage.Models.Column;

namespace TourManager.Domain.Models.AboutColumn
{
    internal class SplittedColumnsSetter : SplittedColumns
    {
        private List<ColumnDb> columns;
        public SplittedColumnsSetter(List<ColumnDb> columns)
        {
            this.columns = columns;
            StringColumns = new List<string>();
            IntegerColumns = new List<string>();
            DecimalColumns = new List<string>();
            DateColumns = new List<string>();
            BoolColumns = new List<string>();
            GuidColumns = new List<string>();
        }
        public void SplitColumns()
        {
            this.columns.ForEach(column =>
            {
                switch (column.ValueType)
                {
                    case ColumnValueType.Int:
                        IntegerColumns.Add(column.Code);
                        break;
                    case ColumnValueType.Decimal:
                        DecimalColumns.Add(column.Code);
                        break;
                    case ColumnValueType.String:
                        StringColumns.Add(column.Code);
                        break;
                    case ColumnValueType.DateTime:
                        DateColumns.Add(column.Code);
                        break;
                    case ColumnValueType.Bool:
                        BoolColumns.Add(column.Code);
                        break;
                    case ColumnValueType.Guid:
                        GuidColumns.Add(column.Code);
                        break;
                    default:
                        throw new DataException("There is no such column type to add into a list");
                }

            });
        }
    }
}
