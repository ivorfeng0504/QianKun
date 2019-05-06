using System;

namespace QianKunHelper.CacheHelper
{
    public class RedisCache : RedisOperatorBase, ICache
    {
        private static RedisCache redisCache;
        private RedisCache() { }

        public static RedisCache CreateRedisCache()
        {
            if (redisCache != null) return redisCache;
            lock (obj)
            {
                if (redisCache != null) return redisCache;
                redisCache = new RedisCache();
                return redisCache;
            }
        }
        public bool Set(string key, string value)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.Set(key, value);
            }
        }

        public bool Set(string key, string value, TimeSpan sp)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.Set(key, value, sp);
            }
        }

        public bool Set(string key, string value, DateTime dt)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.Set(key, value, dt);
            }
        }

        public bool Set<T>(string key, T value)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.Set(key, value);
            }
        }

        public bool Set<T>(string key, T value, TimeSpan sp)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.Set(key, value, sp);
            }
        }

        public bool Set<T>(string key, T value, DateTime dt)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.Set(key, value, dt);
            }
        }

        public string Get(string key)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.Get<string>(key);
            }
        }

        public T Get<T>(string key)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.Get<T>(key);
            }
        }
    }
}
