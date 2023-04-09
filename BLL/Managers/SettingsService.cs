using BLL.Entities;
using System.Text.Json;

namespace BLL.Managers
{
    public class SettingsService : ISettingsService
    {

        private readonly string ConfigPath = "../BLL/config.json";

        public async Task<Result<Settings>> GetSettingsFromConfigAsync()
        {
            try
            {
                string json = await File.ReadAllTextAsync(ConfigPath);
                var config = JsonSerializer.Deserialize<Settings>(json);
                return new Result<Settings> { Success = true, Data = config };
            }
            catch (FileNotFoundException ex)
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
