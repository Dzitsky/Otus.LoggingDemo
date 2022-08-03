using Microsoft.Extensions.Logging;
using System;

namespace Otus.LoggingDemo
{
    public class MyLogger<T> : ILogger<T>
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            //throw new NotImplementedException();
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            //return true;
            return logLevel > LogLevel.Debug;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.WriteLine($"[{DateTime.Now}] {logLevel} EVENT = {eventId} {formatter(state, exception)} " );
        }
    }
}
