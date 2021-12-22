using TourManager.Storage;

namespace TourManager.Domain
{
    public class BaseManager
    {
        protected readonly TourManagerDbContext dbContext;

        public BaseManager(TourManagerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
