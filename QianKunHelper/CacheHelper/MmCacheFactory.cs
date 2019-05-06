namespace QianKunHelper.CacheHelper
{
    public class MmCacheFactory : ICacheFactory
    {
        private ICache cache;
        public ICache GetCache()
        {
            if (cache != null) return cache;
            cache = MmCache.CreatMmCache();
            return cache;
        }
    }
}
