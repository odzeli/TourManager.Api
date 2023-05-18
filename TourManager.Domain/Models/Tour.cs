using System;
using System.Collections.Generic;
using TourManager.Domain.Models.TourExpense;

namespace TourManager.Domain.Models
{
    public class Tour
    {
        public Guid Id { get; set; }
        public string StartDate { get; set; }
        public string Guides { get; set; }
        public string Drivers { get; set; }
        public int TouristNumber { get; set; }
        public DateTime EndDate { get; set; }
        public bool IncludeStandardColums { get; set; }
        public List<TourExpenseGroup> Expenses { get; set; }
    }
}
