namespace BLL.Logs
{
    internal class LogRecorder
    {
        /// <summary>
        /// Получить объект для записи логов
        /// </summary>
        /// <param name="Name">Имя файла (без расширения)</param>
        /// <returns>Объект для записи логов</returns>
        public static LogRecorder GetLogRecorder(string Name)
        {
            if (logRecorders.ContainsKey(Name))
                return logRecorders[Name];
            else
            {
                logRecorders.Add(Name, new LogRecorder(Name));
                return logRecorders[Name];
            }
        }

        /// <summary>
        /// Закрыть все файлы логов
        /// </summary>
        public static void DisposeAll()
        {
            foreach (LogRecorder logRecorder in logRecorders.Values)
                logRecorder.Dispose();
        }

        /// <summary>
        /// Словарь, содержащий потоки для логов
        /// имя лог файла - поток
        /// </summary>
        private static Dictionary<string, LogRecorder> logRecorders = new Dictionary<string, LogRecorder>();

        private StreamWriter logWriter;
        private string _name;

        private LogRecorder(string Name)
        {
            _name = Name;

            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + Constants.LOGS_DIRECTORY_NAME))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + Constants.LOGS_DIRECTORY_NAME);

            logWriter = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + Constants.LOGS_DIRECTORY_NAME + Constants.BACK_SLASH + Name + Constants.TXT_FILE_EXTENSION);
        }

        /// <summary>
        /// Запись сообщение в файл
        /// </summary>
        /// <param name="message">Текст сообщения</param>
        public void Write(string message)
        {
            logWriter.WriteLine(string.Format("{0:dd.MM.yyyy H:mm:ss.fff}: {1}", DateTime.Now, message));
            logWriter.Flush();
        }

        /// <summary>
        /// Освободить файл
        /// </summary>
        public void Dispose()
        {
            Write(string.Format("\"{0}{1}\" dispose", _name, Constants.TXT_FILE_EXTENSION));
            logWriter.Dispose();
        }
    }
}
