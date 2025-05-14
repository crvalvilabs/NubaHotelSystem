namespace NubaHotel.BookingSystem.Api.Logging
{
    /// <summary>
    /// The LoggingService class is responsible for handling logging functionality
    /// within the application. It allows writing logs to a specified file path.
    /// </summary>
    public class LoggingService
    {
        /// <summary>
        /// Represents the file path where log data is written and stored.
        /// Configured based on the application's settings, typically under "LogPath:PathFile".
        /// </summary>
        private readonly string? _pathFile;

        /// <summary>
        /// Represents the default name of the log file used by the logging service.
        /// This value is combined with the current date to generate the full log file name
        /// when writing logs, ensuring unique log files per day.
        /// </summary>
        private const string FileName = "Nubalog.txt";

        /// <summary>
        /// The LoggingService class is responsible for handling logging functionality
        /// within the application. It facilitates writing logs to a file specified
        /// in the application's configuration.
        /// </summary>
        public LoggingService(IConfiguration configuration)
        {
            _pathFile = configuration.GetSection("LogPath:PathFile").Value;
        }

        /// <summary>
        /// Writes the details of a specified exception to the log file.
        /// </summary>
        /// <param name="exception">The exception to be logged, containing information about the error.</param>
        public async Task WriteLog(Exception exception)
        {
            var messageDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var dateFileName = DateTime.Now.ToString("yyyy_MM_dd");
            var file = $"{_pathFile}//{FileName}_{dateFileName}.txt";
            var logMessage = $"{messageDate}: \nError: {exception.Message} \nSource: {exception.Source} \nInnerException: {exception.InnerException} \nMethod: {exception.TargetSite}";

            await using var sw = new StreamWriter(file, true);
            await sw.WriteLineAsync(logMessage);
            sw.AutoFlush = true;
        }
    }
}