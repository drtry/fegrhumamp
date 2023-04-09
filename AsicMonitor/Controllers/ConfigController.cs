using BLL.Entities;
using BLL.Managers;
using Microsoft.AspNetCore.Mvc;

namespace AsicMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly ISettingsService configService;

        public ConfigController(ISettingsService configService)
        {
            this.configService = configService;
        }

        [HttpGet("Settings")]
        public Task<Result<Settings>> GetSettings()
        {
            return configService.GetSettingsFromConfigAsync();
        }
    }
}
