using BLL.Managers;
using Microsoft.Extensions.DependencyInjection;

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
