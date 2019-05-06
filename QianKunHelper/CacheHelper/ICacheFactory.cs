using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using log4net;

namespace QianKunHelper.CacheHelper
{
    public interface ICacheFactory
    {
        ICache GetCache();
    }
}
