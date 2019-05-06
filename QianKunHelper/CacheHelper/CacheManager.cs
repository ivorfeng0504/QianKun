using System.Reflection;

namespace QianKunHelper.CacheHelper
{
    public class CacheManager
    {
        private static readonly object obj = new object();

        public static ICache Cache => CacheFactory.GetCache();
        public static MmCache MmCache => (MmCache)MmCacheFactory.GetCache();
        public static RedisCache RedisCache => (RedisCache)RedisCacheFactory.GetCache();

        #region 配置决定缓存
        private static ICacheFactory cacheFactory;
        private static ICacheFactory CacheFactory
        {
            get
            {
                if (cacheFactory != null) return cacheFactory;
                lock (obj)
                {
                    if (cacheFactory != null) return cacheFactory;
                    var cacheConfig = ConfigurationManager.AppSettings["cacheConfig"];
                    if (string.IsNullOrWhiteSpace(cacheConfig))
                    {
                        cacheFactory = new MmCacheFactory();
                    }
                    else
                    {
                        var cacheType = cacheConfig.Split(',');
                        var assembly = Assembly.Load(cacheType[0]);
                        cacheFactory = (ICacheFactory)assembly.CreateInstance(cacheType[1]);
                    }

                    return cacheFactory;
                }
            }
        }
        #endregion

        #region MemoryCache
        private static MmCacheFactory mmCacheFactory;
        private static MmCacheFactory MmCacheFactory
        {
            get
            {
                if (mmCacheFactory != null) return mmCacheFactory;
                lock (obj)
                {
                    if (mmCacheFactory != null) return mmCacheFactory;
                    mmCacheFactory = new MmCacheFactory();
                    return mmCacheFactory;
                }
            }
        }
        #endregion

        #region RedisCache
        private static RedisCacheFactory redisCacheFactory;
        private static RedisCacheFactory RedisCacheFactory
        {
            get
            {
                if (redisCacheFactory != null) return redisCacheFactory;
                lock (obj)
                {
                    if (redisCacheFactory != null) return redisCacheFactory;
                    redisCacheFactory = new RedisCacheFactory();
                    return redisCacheFactory;
                }
            }
        }
        #endregion
    }
}

