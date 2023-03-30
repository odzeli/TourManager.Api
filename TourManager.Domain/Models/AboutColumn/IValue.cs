using TourManager.Storage.Enums;

namespace TourManager.Domain.Models.AboutColumn
{
    public interface IValue
    {
        public ColumnValueType ValueType { get; set; }
        public string ColumnCode { get; set; }
        public string ColumnName { get; set; }
        public string SerializeValue();
        
    }
}
