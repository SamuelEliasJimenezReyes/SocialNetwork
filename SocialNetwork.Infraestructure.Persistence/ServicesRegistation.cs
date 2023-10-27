using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Core.Application.Interfaces.Repositories;
using SocialNetwork.Infraestructure.Persistence.Contexts;
using SocialNetwork.Infraestructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infraestructure.Persistence
{
    public static class ServicesRegistation
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Contexts 
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ConnectionString"),
                m => m.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName)));
            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(BaseRepository<>));
            #endregion 
        }

    }
}
