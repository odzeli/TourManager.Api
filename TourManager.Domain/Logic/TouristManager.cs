using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManager.Domain.Abstract;
using TourManager.Domain.Models.Abstract;
using TourManager.Storage;

using Tourist = TourManager.Domain.Models.Tourist;

namespace TourManager.Domain.Logic
{
    public class TouristManager : BaseManager, ITouristManager
    {

        public TouristManager(TourManagerDbContext dbContext)
            : base(dbContext)
        {

        }
        public ITourist Get(Guid id)
        {
            var touristStorage = dbContext.Set<Storage.Models.Tourist>().Where(t => t.Id == id).SingleOrDefault();

            var tourist = new Tourist()
            {
                Name = touristStorage.Name,
                Birthday = touristStorage.Birthday,
                PassportNumber = touristStorage.PassportNumber,
                ArrivalDateAndTime = touristStorage.ArrivalDateAndTime,
                ArrivalTransportType = touristStorage.ArrivalTransportType,
                DepartureDateAndTime = touristStorage.DepartureDateAndTime,
                DepartureTransportType = touristStorage.DepartureTransportType,
                TourDays = touristStorage.TourDays,
                HotelNights = touristStorage.HotelNights,
                Stars = touristStorage.Stars,
                ApartmentType = touristStorage.ApartmentType,
                PhoneNumber = touristStorage.PhoneNumber,
                Hotel = touristStorage.Hotel,
                ClosePrice = touristStorage.ClosePrice,
                Addition = touristStorage.Addition,
                Comment = touristStorage.Comment
            };
            return tourist;
        }

        public async Task<int> Set(ITourist tourist)
        {
            var touristStorage = new Storage.Models.Tourist()
            {
                TourId = tourist.TourId,
                Name = tourist.Name,
                Birthday = tourist.Birthday,
                PassportNumber = tourist.PassportNumber,
                ArrivalDateAndTime = tourist.ArrivalDateAndTime,
                ArrivalTransportType = tourist.ArrivalTransportType,
                DepartureDateAndTime = tourist.DepartureDateAndTime,
                DepartureTransportType = tourist.DepartureTransportType,
                TourDays = tourist.TourDays,
                HotelNights = tourist.HotelNights,
                Stars = tourist.Stars,
                ApartmentType = tourist.ApartmentType,
                PhoneNumber = tourist.PhoneNumber,
                Hotel = tourist.Hotel,
                ClosePrice = tourist.ClosePrice,
                Addition = tourist.Addition,
                Comment = tourist.Comment
            };
            dbContext.Add(touristStorage);
            return await dbContext.SaveChangesAsync();
        }
        public void SetMany(List<Tourist> tourists)
        {
            throw new NotImplementedException();
        }
        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
