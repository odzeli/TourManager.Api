using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Domain.Models;
using TourManager.Domain.Models.Abstract;


namespace TourManager.Domain.Abstract
{
    public interface ITouristManager
    {
        public Task<ITourist> Get(Guid id);
        public Task<int> Set(ITourist tourist);
        public Task<IEnumerable<Tourist>> TouristsList(Guid tourId);
        public void Delete(Guid id);
    }
}
