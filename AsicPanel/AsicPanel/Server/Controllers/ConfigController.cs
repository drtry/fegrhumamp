using AsicPanel.Shared.Entities;
using AsicPanel.Shared.Entities.Innosilicon;
using AsicPanel.Shared.Managers;
using Microsoft.AspNetCore.Mvc;

namespace AsicPanel.Server.Controllers
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
