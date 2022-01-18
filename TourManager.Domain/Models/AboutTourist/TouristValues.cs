﻿using System;
using System.Collections.Generic;

namespace TourManager.Domain.Models.AboutTourist
{
    public class TouristValues
    {
        public Guid TourId { get; set; }
        public string Name { get; set; }
        public List<ColumnValue> ColumnValues { get; set; }
    }
}
