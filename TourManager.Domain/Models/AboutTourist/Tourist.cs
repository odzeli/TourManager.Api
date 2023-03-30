using System;
using TourManager.Domain.Models.Abstract;
using TourManager.Storage.Enums;

namespace TourManager.Domain.Models.AboutTourist
{
    public class Tourist : ITourist
    {
        public Guid Id { get; set; }
        public Guid TourId { get; set; }
        public string Name { get; set; }
    }
}
