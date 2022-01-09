using System;
using TourManager.Storage.Enums;

namespace TourManager.Domain.Models.Abstract
{
    public interface ITourist
    {
        public Guid Id { get; set; }
        public Guid TourId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string PassportNumber { get; set; }
        public DateTime ArrivalDateAndTime { get; set; }
        public string ArrivalTransportType { get; set; }
        public DateTime DepartureDateAndTime { get; set; }
        public string DepartureTransportType { get; set; }
        public int TourDays { get; set; }
        public int HotelNights { get; set; }
        public int Stars { get; set; }
        public Storage.Enums.ColumnValueType ApartmentType { get; set; }
        public string PhoneNumber { get; set; }
        public string Hotel { get; set; }
        public decimal ClosePrice { get; set; }
        public string Addition { get; set; }
        public string Comment { get; set; }
    }
}
