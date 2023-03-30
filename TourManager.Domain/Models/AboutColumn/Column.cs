using System;
using TourManager.Storage.Enums;

namespace TourManager.Domain.Models.AboutColumn
{
    public class Column
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Guid TourId { get; set; }
        public ColumnValueType ValueType { get; set; }
        public int SortOrder { get; set; }
        public bool DisplayInGrid { get; set; }
        public bool DisplayInPersonalPanel { get; set; }
    }
}
