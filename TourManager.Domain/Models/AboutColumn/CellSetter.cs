using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Storage.Enums;

namespace TourManager.Domain.Models.AboutColumn
{
    public class CellSetter : Cell
    {
        private readonly ColumnValueType valueType;
        public CellSetter(Guid touristId, Guid columnId, ColumnValueType valueType)
            : base(touristId, columnId)
        {
            this.valueType = valueType;
        }

        public void SetValue(dynamic value)
        {
            var converted = value.ToString();
            switch (this.valueType)
            {
                case ColumnValueType.Int:
                    IntValue = converted != string.Empty ? int.Parse(converted) : null;
                    break;
                case ColumnValueType.String:
                    StringValue = converted;
                    break;
                case ColumnValueType.Decimal:
                    DecimalValue = converted != string.Empty ? decimal.Parse(converted) : null;
                    break;
                case ColumnValueType.DateTime:
                    DateTimeValue = converted != string.Empty ? DateTime.Parse(converted) : null;
                    break;
                case ColumnValueType.Bool:
                    BoolValue = converted != string.Empty ? (bool)converted : null;
                    break;
                case ColumnValueType.Guid:
                    GuidValue = converted != string.Empty ? Guid.Parse(converted) : null;
                    break;
                default:
                    throw new DataException($"Such type doesn't supported by the system valueType: {this.valueType}");
            }
        }
    }
}
