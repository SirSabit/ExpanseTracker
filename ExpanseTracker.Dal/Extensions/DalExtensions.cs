using ExpanseTracker.Dal.DataAccess.PostgreDataAccess;
using ExpanseTracker.Dal.Repositories.ExpanseRepositories;
using ExpanseTracker.Dal.Repositories.StatisticsRepository;
using Microsoft.Extensions.DependencyInjection;

namespace ExpanseTracker.Dal.Extensions
{
    public static class DalExtensions
    {
        public static void DalServiceExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPGDataAccess<>), typeof(PGDataAccess<>));
            services.AddScoped<IExpanseRepository, ExpanseRepository>();
            services.AddScoped<IStatisticsRepository, StatisticsRepository>();
        }
    }
}
