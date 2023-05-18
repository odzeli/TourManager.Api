using System.Collections.Generic;
using System.Text.Json;

namespace TourManager.Domain.Models.TourExpense
{
    public class TourExpenseGroup
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public decimal Sum { get; set; }
        public List<TourExpense> TourExpenses { get; set; }

        override public string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
