using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetwork.Core.Application.Interfaces.Services;
using SocialNetwork.Core.Domain.Settings;
using SocialNetwork.Infraestructure.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Infraestructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IEmailServices, EmailService>();
        }
    }
}
