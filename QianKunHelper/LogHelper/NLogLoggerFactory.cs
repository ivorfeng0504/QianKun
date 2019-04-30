using System;
using System.Collections.Generic;
using System.Text;

namespace QianKunHelper.LogHelper
{
    public class NLogLoggerFactory : ILoggerFactory
    {
        public ILog GetLogger(Type t)
        {
            return new NlogLogger(t);
        }
    }
}
