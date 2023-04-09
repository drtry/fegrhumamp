using BLL.Entities.Innosilicon;
using BLL.Entities;
using BLL.Managers;
using Microsoft.AspNetCore.Mvc;
using EmptyResult = BLL.Entities.EmptyResult;

namespace AsicMonitor.Controllers
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
        public Task<EmptyResult> AuthAsync([FromBody] Device device)
        {
            return service.AuthAsync(device);
        }

        [HttpPost("Summary")]
        public Task<Result<InnosiliconSummaryResult>> GetSummaryDevice(Device device)
        {
            return service.GetSummaryDevice(device);
        }

    }
}
