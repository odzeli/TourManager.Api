using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Domain.Models.AboutColumn;
using TourManager.Domain.Models.AboutTourist;
using TourManager.Domain.Models.Abstract;


namespace TourManager.Domain.Abstract
{
    public interface ITouristManager
    {
        public Task<ITourist> Get(Guid id);
        public Task<int> Add(TouristValues touristValues);
        public Task<IEnumerable<Row>> RowList(Guid tourId);
        public void Delete(Guid id);
    }
}
