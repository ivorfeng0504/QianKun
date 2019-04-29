
using System;
using System.Collections.Generic;
using System.Text;

namespace QianKunHelper.LogHelper
{
    public class LoggerFactroy
    {
        public static ILog GetLogger(Type t)
        {
            return new Log4netLogger(t);
        }
    }
}
