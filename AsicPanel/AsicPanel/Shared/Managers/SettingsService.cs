using AsicPanel.Shared.Entities;
using AsicPanel.Shared.Entities.Innosilicon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AsicPanel.Shared.Managers
{
    public class SettingsService : ISettingsService
    {

        private readonly string ConfigPath = "../Shared/config.json";

        public async Task<Result<Settings>> GetSettingsFromConfigAsync()
        {
            try
            {
                string json = await File.ReadAllTextAsync(ConfigPath);
                var config = JsonSerializer.Deserialize<Settings>(json);
                return new Result<Settings> { Success = true, Data = config };
            }
            catch (FileNotFoundException)
            {
                return new Result<Settings> { Success = false, Message = "Ошибка: файл не найден." };
            }
            catch (JsonException ex)
            {
                return new Result<Settings> { Success = false, Message = "Ошибка: не удалось прочитать файл." };
            }
            catch (Exception ex)
            {
                return new Result<Settings> { Success = false, Message = $"Ошибка: {ex.Message}" };
            }
        }
    }

    public interface ISettingsService
    {
        Task<Result<Settings>> GetSettingsFromConfigAsync();
    }
}
