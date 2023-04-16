using BLL.Entities;
using BLL.Managers;
using Microsoft.AspNetCore.Mvc;
using EmptyResult = BLL.Entities.EmptyResult;
using BLL.Entities.Innosilicon.Response;
using BLL.Logs;

namespace AsicMonitor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        private static string _logFileName = "DeviceController";

        private readonly IInnosiliconService _innosiliconService;

        public DeviceController(IInnosiliconService _innosiliconService)
        {
            this._innosiliconService = _innosiliconService;
        }

        [HttpGet("EmulationDeviceCount")]
        public Result<int?> GetEmulationDeviceCount()
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("GetEmulationDeviceCount start");
            try
            {
                LogRecorder.GetLogRecorder(_logFileName).Write(string.Format("GetEmulationDeviceCount {0}", _innosiliconService.EmulationDevieCount));
                return new Result<int?>() { Data = _innosiliconService.EmulationDevieCount, Success = true };
            }
            catch
            {
                LogRecorder.GetLogRecorder(_logFileName).Write("GetEmulationDeviceCount error");
                return new Result<int?> { Data = null, Success = false, Message = "Не удалось получить количество устройств эмуляции." };
            }
        }

        [HttpPost("EmulationDeviceCount")]
        public EmptyResult SetEmulationDeviceCount([FromBody] int emulationDeviceCount)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("SetEmulationDeviceCount start");
            try
            {
                LogRecorder.GetLogRecorder(_logFileName).Write(string.Format("SetEmulationDeviceCount before {0} after {1}", _innosiliconService.EmulationDevieCount, emulationDeviceCount));
                _innosiliconService.EmulationDevieCount = emulationDeviceCount;
                return new EmptyResult() { Success = true };
            }
            catch
            {
                LogRecorder.GetLogRecorder(_logFileName).Write("SetEmulationDeviceCount error");
                return new EmptyResult() { Success = false, Message = "Не удалось установить количество устройств эмуляции." };
            }
        }

        [HttpPost("Auth")]
        public async Task<EmptyResult> AuthAsync([FromBody] Device device)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("AuthAsync start");
            Task<EmptyResult> authTask = _innosiliconService.AuthAsync(device);
            LogRecorder.GetLogRecorder(_logFileName).Write("AuthAsync end");
            await authTask;
            return authTask.Result;
        }

        [HttpPost("Reboot")]
        public async Task<EmptyResult> RebootAsync([FromBody] Device device)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("RebootAsync start");
            Task<EmptyResult> rebootTask = _innosiliconService.RebootAsync(device);
            LogRecorder.GetLogRecorder(_logFileName).Write("RebootAsync end");
            await rebootTask;
            return rebootTask.Result;
        }

        [HttpPost("Summary")]
        public async Task<Result<InnosiliconSummaryResult>> GetSummaryDevice(Device device)
        {
            LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice start");
            Task<Result<InnosiliconSummaryResult>> getSummaryTask = _innosiliconService.GetSummaryDeviceAsync(device);
            LogRecorder.GetLogRecorder(_logFileName).Write("GetSummaryDevice start");
            await getSummaryTask;
            return getSummaryTask.Result;
        }

    }
}
