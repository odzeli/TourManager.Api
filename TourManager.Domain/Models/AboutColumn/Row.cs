using System;
using System.Collections.Generic;

namespace TourManager.Domain.Models.AboutColumn
{
    public class Row
    {
        public Row()
        {
            Values = new List<IValue>();
        }
        public Guid TouristId { get; set; }
        public List<IValue> Values { get; set; }
    }
}
