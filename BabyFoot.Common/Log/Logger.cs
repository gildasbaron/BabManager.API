using System;
using BabyFoot.Common.Context;
using Serilog;
using Serilog.Events;

namespace BabyFoot.Common.Log
{
    public class Logger : ILogger
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IRequestContextInfo _requestContext;

         string mapPath = AppDomain.CurrentDomain.BaseDirectory + (@"\log.txt");

        public Logger(
            IApplicationContext applicationContext, 
            IRequestContextInfo requestContext)
        {
              _applicationContext = applicationContext;
            _requestContext = requestContext;
        }

        public void Log(string message)
        {
            using (var _log = new LoggerConfiguration()
                .WriteTo.File(mapPath)
                .CreateLogger())
            {
                _log.Write(LogEventLevel.Information,
                    $" {_applicationContext.RequestCounter} - {_requestContext.User} - {_requestContext.RequestId} - {message} - ()");
            }
        }
    }
}
