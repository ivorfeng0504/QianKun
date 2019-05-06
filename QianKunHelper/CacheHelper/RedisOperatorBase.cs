using System;
using ServiceStack.Redis;

namespace QianKunHelper.CacheHelper
{
    public abstract class RedisOperatorBase : IDisposable
    {
        protected static readonly object obj = new object();
        private bool _disposed;
        private PooledRedisClientManager prcm;
        private readonly int PoolSizeMultiplier = 10;

        protected PooledRedisClientManager PooledRedisClientManager
        {
            get
            {
                if (prcm != null) return prcm;
                lock (obj)
                {
                    if (prcm != null) return prcm;

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
                    return prcm;
                }
            }
        }
        /// <summary>
        /// RedisClient
        /// </summary>
        /// <returns></returns>
        private IRedisClient Client => PooledRedisClientManager.GetClient();

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Client.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>  
        /// 保存数据DB文件到硬盘  
        /// </summary>  
        public void Save()
        {
            Client.Save();
        }

        /// <summary>  
        /// 异步保存数据DB文件到硬盘  
        /// </summary>  
        public void SaveAsync()
        {
            Client.SaveAsync();
        }
    }
}
