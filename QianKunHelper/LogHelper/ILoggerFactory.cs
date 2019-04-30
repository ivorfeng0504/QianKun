using System;
using System.Collections.Generic;
using System.Text;

namespace QianKunHelper.LogHelper
{
    public interface ILoggerFactory
    {
        /// <summary>
        /// 获取日志记录器
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        ILog GetLogger(Type t);
    }
}
