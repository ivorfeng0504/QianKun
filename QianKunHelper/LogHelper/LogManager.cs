using System;
using System.Collections.Generic;
using System.Text;

namespace QianKunHelper.LogHelper
{
    public class LogManager<T>
    {
        public ILog Log;
        public LogManager()
        {
            Log = LoggerFactroy.GetLogger(typeof(T));
        }
    }
}
