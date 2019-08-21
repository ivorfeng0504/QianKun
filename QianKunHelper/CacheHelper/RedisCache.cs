using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

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
        /// <summary>
        /// 自增1，返回自增后的值
        /// </summary>
        public long Incr(string key)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.IncrementValue(key);
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
        /// <summary>
        /// 向hashid集合中添加key/value
        /// </summary>       
        public bool Hset(string hashid, string key, string value)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.SetEntryInHash(hashid, key, value);
            }
        }
        /// <summary>
        /// 存储对象T t到hash集合中
        /// </summary>
        public void Hset(string hashId, Dictionary<string, string> dic)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                client.SetRangeInHash(hashId, dic);
            }
        }

        public void Hset<T>(string hashId, T t)
        {
            if (t == null) return;
            Type type = typeof(T);
            PropertyInfo[] propertyInfos = type.GetProperties();
            if (propertyInfos.Length == 0) return;
            var dic = propertyInfos.ToDictionary(propertyInfo => propertyInfo.Name, propertyInfo => propertyInfo.GetValue(t)?.ToString());
            Hset(hashId, dic);
        }
        /// <summary>
        /// 获取hashid数据集中所有key的集合
        /// </summary>
        public List<string> HgetKeys(string hashid)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.GetHashKeys(hashid);
            }
        }

        /// <summary>
        /// 获取所有hashid数据集的key/value数据集合
        /// </summary>
        public Dictionary<string, string> Hget(string hashid)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.GetAllEntriesFromHash(hashid);
            }
        }

        public T Hget<T>(string hashId)
        {
            Dictionary<string, string> dic = Hget(hashId);
            if (dic == null || dic.Keys.Count == 0) return default;
            var model = Activator.CreateInstance<T>();
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                if (!dic.ContainsKey(prop.Name)) break;
                if (!prop.CanWrite) break;
                if (!prop.PropertyType.IsValueType && prop.PropertyType != typeof(string)) break;

                prop.SetValue(model,
                    prop.PropertyType.IsEnum
                        ? Enum.Parse(prop.PropertyType, dic[prop.Name])
                        : Convert.ChangeType(dic[prop.Name], prop.PropertyType));
            }
            return model;
        }
        /// <summary>
        /// 获取hashid数据集中，key的value数据
        /// </summary>
        public string Hget(string hashid, string key)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.GetValueFromHash(hashid, key);
            }
        }

        /// <summary>
        /// key集合中添加value值
        /// </summary>
        public void Sset(string key, string value)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                client.AddItemToSet(key, value);
            }
        }
        /// <summary>
        /// key集合中添加list集合
        /// </summary>
        public void Sset(string key, List<string> list)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                client.AddRangeToSet(key, list);
            }
        }
        /// <summary>
        /// 随机获取key集合中的一个值
        /// </summary>
        public string SgetRandomItem(string key)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.GetRandomItemFromSet(key);
            }
        }
        /// <summary>
        /// 获取key集合值的数量
        /// </summary>
        public long SgetCount(string key)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.GetSetCount(key);
            }
        }
        /// <summary>
        /// 获取所有key集合的值
        /// </summary>
        public List<string> Sget(string key)
        {
            using (var client = PooledRedisClientManager.GetClient())
            {
                return client.GetAllItemsFromSet(key)?.ToList();
            }
        }
    }
}
