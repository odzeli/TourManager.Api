using System;
using TourManager.Storage.Enums;

namespace TourManager.Storage.Models
{
    public class StandardColumn
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public ColumnValueType ValueType { get; set; }
        public DefaultAccess DefaultAccess { get; set; }
        public int SortOrder { get; set; }
        public ColumnOptions Options { get; set; }
    }
}
