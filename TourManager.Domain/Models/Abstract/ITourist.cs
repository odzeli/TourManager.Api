using System;

namespace TourManager.Domain.Models.Abstract
{
    public interface ITourist
    {
        public Guid Id { get; set; }
        public Guid TourId { get; set; }
        public string Name { get; set; }
    }
}
