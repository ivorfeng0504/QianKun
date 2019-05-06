using System;
using ServiceStack.Redis;

namespace QianKunHelper.CacheHelper
{
    public class RedisManager
    {
        protected static readonly object obj = new object();
        private static PooledRedisClientManager prcm;
        private static readonly int PoolSizeMultiplier = 10;

        private static void CreatePooledRedisClientManager()
        {
            //readWriteHost：可写的Redis链接地址。  
            var readWriteHosts = ConfigurationManager.AppSettingOfObject("redisConfig", "ReadWriteHosts");
            var ReadWriteHosts = readWriteHosts.Split(',', StringSplitOptions.RemoveEmptyEntries);
            //readOnlyHosts：可读的Redis链接地址。  
            var readOnlyHosts = ConfigurationManager.AppSettingOfObject("redisConfig", "ReadOnlyHosts");
            var ReadOnlyHosts = readOnlyHosts.Split(',', StringSplitOptions.RemoveEmptyEntries);
            //initalDb：内部数据库编号
            var initalDb = ConfigurationManager.AppSettingOfObject("redisConfig", "InitalDb");
            int.TryParse(initalDb, out int InitalDb);

            var maxWritePoolSize = ConfigurationManager.AppSettingOfObject("redisConfig", "MaxWritePoolSize");
            int.TryParse(maxWritePoolSize, out int MaxWritePoolSize);
            var maxReadPoolSize = ConfigurationManager.AppSettingOfObject("redisConfig", "MaxReadPoolSize");
            int.TryParse(maxReadPoolSize, out int MaxReadPoolSize);

            // 支持读写分离，均衡负载   
            prcm = new PooledRedisClientManager(ReadWriteHosts, ReadOnlyHosts, new RedisClientManagerConfig
            {
                //MaxWritePoolSize：最大写链接数。  
                MaxWritePoolSize = MaxWritePoolSize * PoolSizeMultiplier,
                //MaxReadPoolSize：最大读链接数。 
                MaxReadPoolSize = MaxReadPoolSize * PoolSizeMultiplier,
                //AutoStart：自动重启。  
                AutoStart = true,
            }, InitalDb, PoolSizeMultiplier, 10);
        }
        /// <summary>
        /// RedisClient
        /// </summary>
        /// <returns></returns>
        public static IRedisClient GetClient()
        {
            if (prcm != null) return prcm.GetClient();
            lock (obj)
            {
                if (prcm != null) return prcm.GetClient();
                CreatePooledRedisClientManager();
                return prcm.GetClient();
            }
        }
    }
}
