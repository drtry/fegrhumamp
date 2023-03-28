using AsicPanel.Shared.Entities;
using AsicPanel.Shared.Entities.Innosilicon;
using AsicPanel.Shared.Managers;
using Microsoft.AspNetCore.Mvc;
using EmptyResult = AsicPanel.Shared.Entities.EmptyResult;

namespace AsicPanel.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IInnosiliconService service;

        public DeviceController(IInnosiliconService service)
        {
            this.service = service;
        }

        [HttpPost("Auth")]
        public Task<EmptyResult> AuthAsync([FromBody]Device device)
        {
            return service.AuthAsync(device);
            //return service.GetSummary(null);
        }
    }
}
