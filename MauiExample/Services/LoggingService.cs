using System.Diagnostics;

namespace MauiExample.Services
{
    public class LoggingService
    {

        private readonly LogLevel currentLogLevel;

        public LoggingService(LogLevel logLevel)
        {
            this.currentLogLevel = logLevel;
        }

        public void LogMessage(string message, LogLevel logLevel = LogLevel.DEFAULT)
        {
            if (currentLogLevel <= logLevel)
            {
                var date = DateTime.Now.ToString("yyyy/MM/dd HH:mm");
                Trace.WriteLine($"{date} - {logLevel} - {message}");
            }
        }

        public enum LogLevel
        {
            DEBUG = 0,
            INFO = 1,
            DEFAULT = 2
        }

    }
}
