using BLL.Services;

namespace AsicMonitor.Services
{
    public static class Services
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddBLLServices();
            return services;
        }
    }
}
