using BLL.Core;
using BLL.Managers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public static class BLLServices
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<IInnosiliconService,InnosiliconService>();
            services.AddScoped<ISettingsService, SettingsService>();
            return services;
        }
    }
}
