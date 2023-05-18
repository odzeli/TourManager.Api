using System;

namespace TourManager.Storage.Models
{
    public class Tour
    {
        public Guid Id { get; set; }
        public string StartDate { get; set; }
        public string Guides { get; set; }
        public string Drivers { get; set; }
        public string Expenses { get; set; }
    }
}
