using System;
using System.Text.Json;

namespace TourManager.Domain.Models.TourExpense
{
    public class TourExpense
    {
        public Guid TourId { get; set; }
        public string ExpenseName { get; set; }
        public decimal Amount { get; set; }

        override public string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
