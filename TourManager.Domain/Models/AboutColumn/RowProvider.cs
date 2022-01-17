using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Storage.Enums;
using TourManager.Domain.Abstract;
using CellDb = TourManager.Storage.Models.Cell;
using ColumnDb = TourManager.Storage.Models.Column;

namespace TourManager.Domain.Models.AboutColumn
{
    internal class RowProvider : IRowProvider
    {
        public RowProvider()
        {
        }

        public List<Row> GenerateRows(List<CellDb> cells, Dictionary<Guid, ColumnDb> columnIdToColumnMap)
        {
            var rows = new List<Row>();
            var touristToRowMap = new Dictionary<Guid, List<CellDb>>();

            foreach (var cell in cells)
            {
                if (!touristToRowMap.ContainsKey(cell.TouristId))
                {
                    var newList = new List<CellDb>();
                    newList.Add(cell);
                    touristToRowMap.Add(cell.TouristId, newList);
                }
                else
                {
                    touristToRowMap[cell.TouristId].Add(cell);
                }
            }

            foreach (var map in touristToRowMap)
            {
                var row = new Row();
                row.TouristId = map.Key;
                foreach (var cell in touristToRowMap[map.Key])
                {
                    var value = SetValue(cell, columnIdToColumnMap[cell.ColumnId]);
                    row.Values.Add(value);
                }
                rows.Add(row);
            }
            return rows;
        }

        private IValue SetValue(CellDb cell, ColumnDb column)
        {
            switch (column.ValueType)
            {
                case ColumnValueType.String:
                    {
                        var value = new ColumnValue<string>();
                        value.ValueType = column.ValueType;
                        value.ColumnCode = column.Code;
                        value.Value = cell.StringValue;
                        return value;
                    }
                case ColumnValueType.Decimal:
                    {
                        var value = new ColumnValue<decimal?>();
                        value.ValueType = column.ValueType;
                        value.ColumnCode = column.Code;
                        value.Value = cell.DecimalValue;
                        return value;
                    }
                case ColumnValueType.Int:
                    {
                        var value = new ColumnValue<int?>();
                        value.ValueType = column.ValueType;
                        value.ColumnCode = column.Code;
                        value.Value = cell.IntValue;
                        return value;
                    }
                case ColumnValueType.DateTime:
                    {
                        var value = new ColumnValue<DateTime?>();
                        value.ValueType = column.ValueType;
                        value.ColumnCode = column.Code;
                        value.Value = cell.DateTimeValue;
                        return value;
                    }
                case ColumnValueType.Bool:
                    {
                        var value = new ColumnValue<bool?>();
                        value.ValueType = column.ValueType;
                        value.ColumnCode = column.Code;
                        value.Value = cell.BoolValue;
                        return value;
                    }
                case ColumnValueType.Guid:
                    {
                        var value = new ColumnValue<Guid?>();
                        value.ValueType = column.ValueType;
                        value.ColumnCode = column.Code;
                        value.Value = cell.GuidValue;
                        return value;
                    }
                default:
                    throw new DataException($"Such type doesn't supported by the system");
            }

        }
    }
}
