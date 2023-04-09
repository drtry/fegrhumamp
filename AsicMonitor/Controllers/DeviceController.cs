using BLL.Entities;
using BLL.Managers;
using Microsoft.AspNetCore.Mvc;
using EmptyResult = BLL.Entities.EmptyResult;
using BLL.Entities.Innosilicon.Response;

namespace AsicMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private readonly IInnosiliconService _innosiliconService;

        public DeviceController(IInnosiliconService _innosiliconService)
        {
            this._innosiliconService = _innosiliconService;
        }

        [HttpGet("Emulation")]
        public Result<bool?> GetEmulation()
        {
            try
            {
                return new Result<bool?>() { Data = _innosiliconService.IsEmulation, Success = true };
            }
            catch
            {
                return new Result<bool?> { Data = null, Success = false, Message = "Не удалось получить статус режима эмуляции." };
            }
        }

        [HttpPost("Emulation")]
        public EmptyResult SetEmulation([FromBody] bool isEmulation)
        {
            try
            {
                _innosiliconService.IsEmulation = isEmulation;
                return new EmptyResult() { Success = true };
            }
            catch
            {
                return new EmptyResult() { Success = false, Message = "Не удалось установить статус режима эмуляции." };
            }
        }

        [HttpGet("EmulationDeviceCount")]
        public Result<int?> GetEmulationDeviceCount()
        {
            try
            {
                return new Result<int?>() { Data = _innosiliconService.EmulationDevieCount, Success = true };
            }
            catch
            {
                return new Result<int?> { Data = null, Success = false, Message = "Не удалось получить количество устройств эмуляции." };
            }
        }

        [HttpPost("EmulationDeviceCount")]
        public EmptyResult SetEmulationDeviceCount([FromBody] int emulationDeviceCount)
        {
            try
            {
                _innosiliconService.EmulationDevieCount = emulationDeviceCount;
                return new EmptyResult() { Success = true };
            }
            catch
            {
                return new EmptyResult() { Success = false, Message = "Не удалось установить количество устройств эмуляции." };
            }
        }

        [HttpPost("Auth")]
        public Task<EmptyResult> AuthAsync([FromBody] Device device)
        {
            return _innosiliconService.AuthAsync(device);
        }

        [HttpPost("Summary")]
        public Task<Result<InnosiliconSummaryResult>> GetSummaryDevice(Device device)
        {
            return _innosiliconService.GetSummaryDevice(device);
        }

    }
}
