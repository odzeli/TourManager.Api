using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Domain.Models;
using TourManager.Domain.Models.Abstract;


namespace TourManager.Domain.Abstract
{
    public interface ITouristManager
    {
        public ITourist Get(Guid id);
        public Task<int> Set(ITourist tourist);
        public void SetMany(List<Tourist> tourists);
        public void Delete(Guid id);
    }
}
