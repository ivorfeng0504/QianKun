using System;
using System.Reflection;

namespace QianKunHelper.LogHelper
{
    public class LogManager
    {
        private static readonly object obj = new object();
        private static ILoggerFactory _loggerFactory;

        public static ILoggerFactory LoggerFactory
        {
            get
            {
                if (_loggerFactory != null) return _loggerFactory;
                lock (obj)
                {
                    if (_loggerFactory != null) return _loggerFactory;
                    var logConfig = ConfigurationManager.AppSettings["logConfig"];
                    if (!string.IsNullOrWhiteSpace(logConfig))
                    {
                        string[] typeInfo = logConfig.Split(',');
                        Assembly assembly = Assembly.Load(typeInfo[0]);
                        var type = assembly.GetType(typeInfo[1]);
                        _loggerFactory = (ILoggerFactory)Activator.CreateInstance(type);
                    }
                    else
                    {
                        _loggerFactory = new Log4netLoggerFactroy();
                    }
                }

                return _loggerFactory;
            }
        }

        public static ILog GetLog<T>()
        {
            return LoggerFactory.GetLogger(typeof(T));
        }
    }
}
