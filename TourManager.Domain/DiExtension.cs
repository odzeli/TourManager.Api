using Microsoft.Extensions.DependencyInjection;
using TourManager.Domain.Abstract;
using TourManager.Domain.Logic;
using TourManager.Domain.Models.AboutColumn;
using TourManager.Domain.Models.Abstract;

namespace TourManager.Domain
{
    public class DiExtension
    {
        public static void AddDI(IServiceCollection services)
        {
            services.AddScoped<ITouristManager, TouristManager>();
            services.AddScoped<ITourManager, Logic.TourManager>();
            services.AddScoped<IColumnManager, ColumnManager>();
            services.AddScoped<IRowProvider, RowProvider>();
            services.AddScoped<IImportManager, ImportManager>();
        }
    }
}
