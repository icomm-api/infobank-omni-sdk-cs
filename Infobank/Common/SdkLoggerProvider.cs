using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace Infobank.Common
{


    public  class SdkLoggerProvider :ILoggerProvider
    {
        private  readonly ConcurrentDictionary<string, ILogger> _loggers = new(StringComparer.OrdinalIgnoreCase);

        private static ILoggerFactory LoggerFactory { get; set;} = new LoggerFactory();

        public void SetSdkLogger(ILoggerFactory loggerFactory)
        {
            LoggerFactory?.Dispose();
            LoggerFactory = loggerFactory;
            _loggers.Clear();
        }

        public ILogger CreateLogger(string categoryName) =>
            _loggers.GetOrAdd(categoryName, name => LoggerFactory.CreateLogger(categoryName));

        public void Dispose()
        {
          _loggers.Clear();
          GC.SuppressFinalize(this);
        }
  

   
    

    }
}