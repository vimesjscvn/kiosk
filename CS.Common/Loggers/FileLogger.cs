using System;
using System.IO;
using Microsoft.Extensions.Logging;

namespace CS.Common.Loggers
{
    public class FileLogger : ILogger
    {
        private static readonly object _lock = new object();
        private readonly string filePath;

        public FileLogger(string path)
        {
            filePath = path;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //return logLevel == LogLevel.Trace;
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
                lock (_lock)
                {
                    var fullFilePath = Path.Combine(filePath, DateTime.Now.ToString("yyyy-MM-dd") + "_log.txt");
                    var n = Environment.NewLine;
                    var exc = "";
                    if (exception != null)
                        exc = exception.GetType() + ": " + exception.Message + n + exception.StackTrace + n;

                    using (var sw = File.AppendText(fullFilePath))
                    {
                        sw.WriteLine(logLevel + ": " + DateTime.Now + " " + formatter(state, exception));
                    }
                }
        }
    }
}