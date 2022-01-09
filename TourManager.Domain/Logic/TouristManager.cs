using Microsoft.EntityFrameworkCore;
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
        public async Task<ITourist> Get(Guid id)
        {
            var touristStorage = await dbContext.Set<Storage.Models.Tourist>().Where(t => t.Id == id).SingleOrDefaultAsync();

            var tourist = new Tourist()
            {
                Name = touristStorage.Name,
                TourId = touristStorage.TourId,
            };
            return tourist;
        }

        public async Task<int> Set(ITourist tourist)
        {
            var touristStorage = new Storage.Models.Tourist()
            {
                TourId = tourist.TourId,
                Name = tourist.Name
            };
            dbContext.Add(touristStorage);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tourist>> TouristsList(Guid tourId)
        {
            var touristsStorage = await dbContext.Set<Storage.Models.Tourist>().Where(t => t.TourId == tourId).ToListAsync();
            var tourists = new List<Tourist>();

            touristsStorage.ForEach(touristStorage =>
            {
                var tourist = new Tourist()
                {
                    Name = touristStorage.Name,
                    TourId = touristStorage.TourId
                };
                tourists.Add(tourist);
            });

            return tourists;
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
