using BLL.Managers;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Services
{
    public static class BLLServices
    {
        public static IServiceCollection AddBLLServices(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IInnosiliconService,InnosiliconService>();
            services.AddSingleton<ISettingsService, SettingsService>();
            return services;
        }
    }
}
