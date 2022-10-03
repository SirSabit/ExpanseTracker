using ExpanseTracker.Bll.Repositories.ExpanseRepositories;
using ExpanseTracker.Bll.Repositories.StatisticsRepository;
using ExpanseTracker.Dal.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace ExpanseTracker.Bll.Extensions
{
    public static class BllExtensions
    {
        public static void BllServiceExtensions(this IServiceCollection services)
        {
            services.DalServiceExtension();
            services.AddScoped<IExpanseBllRepository, ExpanseBllRepository>();
            services.AddScoped<IStatisticsBllRepository, StatisticsBllRepository>();
        }
    }
}
