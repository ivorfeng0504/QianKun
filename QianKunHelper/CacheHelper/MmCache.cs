using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace QianKunHelper.CacheHelper
{
    public class MmCache : ICache
    {
        private static MmCache mmCache;
        private static MemoryCache cache;
        private static readonly object obj = new object();

        private MmCache()
        {
            cache = new MemoryCache(Options.Create(new MemoryCacheOptions()));
        }
        public static MmCache CreatMmCache()
        {
            if (mmCache != null) return mmCache;
            lock (obj)
            {
                if (mmCache != null) return mmCache;
                mmCache = new MmCache();
                return mmCache;
            }
        }
        public bool Set(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;

            return cache.Set(key, value) != null;
        }

        public bool Set(string key, string value, TimeSpan sp)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;

            return cache.Set(key, value, sp) != null;
        }

        public bool Set(string key, string value, DateTime dt)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;

            return cache.Set(key, value, dt) != null;
        }

        public bool Set<T>(string key, T value)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;

            return cache.Set(key, value) != null;
        }

        public bool Set<T>(string key, T value, TimeSpan sp)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;

            return cache.Set(key, value, sp) != null;
        }

        public bool Set<T>(string key, T value, DateTime dt)
        {
            if (string.IsNullOrWhiteSpace(key)) return false;

            return cache.Set(key, value, dt) != null;
        }

        public string Get(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return null;

            var result = cache.Get(key);
            return result?.ToString();
        }

        public T Get<T>(string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return default;

            var result = cache.Get<T>(key);
            return result;
        }
    }
}
