using System;
using ServiceStack.Redis;

namespace QianKunHelper.CacheHelper
{
    public class RedisCacheFactory : ICacheFactory
    {
        private ICache cache;
        public ICache GetCache()
        {
            if (cache != null) return cache;
            cache = RedisCache.CreateRedisCache();
            return cache;
        }
    }
}
