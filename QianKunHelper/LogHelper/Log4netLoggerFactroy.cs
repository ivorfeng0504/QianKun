
using System;
using System.IO;
using log4net.Config;

namespace QianKunHelper.LogHelper
{
    public class Log4netLoggerFactroy : ILoggerFactory
    {
        private const string repositoryName = "log4netLoggerFactroy";
        public Log4netLoggerFactroy()
        {
            var repository = log4net.LogManager.CreateRepository(repositoryName);
            string log4netFile = Path.Combine(Directory.GetCurrentDirectory(), "Config\\log4net.config");
            var fileInfo = new FileInfo(log4netFile);
            XmlConfigurator.Configure(repository, fileInfo);
        }

        public ILog GetLogger(Type t)
        {
            return new Log4netLogger(repositoryName, t);
        }
    }
}
