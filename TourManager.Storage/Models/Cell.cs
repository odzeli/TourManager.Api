using System;

namespace TourManager.Storage.Models
{
    public class Cell
    {
        public Guid TouristId { get; set; }
        public Guid ColumnId { get; set; }
        public string StringValue { get; set; }
        public decimal DecimalValue { get; set; }
        public int IntValue { get; set; }
        public DateTime DateTimeValue { get; set; }
        public bool BoolValue { get; set; }
        public Guid GuidValue { get; set; }
    }
}
