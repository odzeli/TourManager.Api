using System;

namespace TourManager.Storage.Models
{
    public class Tourist
    {
        public Guid Id { get; set; }
        public Guid TourId { get; set; }
        public string Name { get; set; }
    }
}
