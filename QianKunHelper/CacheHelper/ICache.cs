using System;
using System.Collections.Generic;
using System.Text;

namespace QianKunHelper.CacheHelper
{
    public interface ICache
    {
        bool Set(string key, string value);
        bool Set(string key, string value, TimeSpan sp);
        bool Set(string key, string value, DateTime dt);
        bool Set<T>(string key, T value);
        bool Set<T>(string key, T value, TimeSpan sp);
        bool Set<T>(string key, T value, DateTime dt);

        string Get(string key);
        T Get<T>(string key);
    }
}
