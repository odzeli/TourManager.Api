using System;

namespace TourManager.Domain.Models
{
    public class Tour
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public string Guides { get; set; }
        public string Drivers { get; set; }
        public int TouristNumber { get; set; }
        public DateTime EndDate { get; set; }
        public bool IncludeStandardColums { get; set; }
    }
}
