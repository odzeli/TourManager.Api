using TourManager.Storage.Enums;

namespace TourManager.Domain.Models.AboutColumn
{
    public class ColumnValue<T> : IValue
    {
        public ColumnValueType ValueType { get; set; }
        public string ColumnCode { get; set; }
        public T Value { get; set; }

        public string SerializeValue()
        {
            if (Value != null)
            {
                return Value.ToString();
            }
            return null;
        }
    }
}
