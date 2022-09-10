using ExpanseTracker.Bll.Repositories.ExpanseRepositories;
using ExpanseTracker.Dal.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpanseTracker.Bll.Extensions
{
    public static class BllExtensions
    {
        public static void BllServiceExtensions(this IServiceCollection services)
        {
            services.DalServiceExtension();
            services.AddScoped<IExpanseBllRepository, ExpanseBllRepository>();            
        }
    }
}
