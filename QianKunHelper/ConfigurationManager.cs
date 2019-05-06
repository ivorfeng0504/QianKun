using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace QianKunHelper
{
    public class ConfigurationManager
    {
        private static IConfiguration configuration;
        private static readonly object obj = new object();

        private static IConfiguration InitConfiguration()
        {
            if (configuration != null) return configuration;
            lock (obj)
            {
                if (configuration != null) return configuration;
                configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .Build();
                return configuration;
            }
        }
        public static IConfiguration AppSettings => InitConfiguration();

        /// <summary>
        /// 获取对象配置信息
        /// </summary>
        /// <param name="objectName">对象名称</param>
        /// <param name="attrName">属性名称</param>
        /// <returns></returns>
        public static string AppSettingOfObject(string objectName, string attrName)
        {
            if (string.IsNullOrWhiteSpace(objectName) || string.IsNullOrWhiteSpace(attrName))
                throw new Exception("objectName && attrName is not null or empty");
            return AppSettings[$"{objectName}:{attrName}"];
        }

        /// <summary>
        /// 获取集合配置信息
        /// </summary>
        /// <param name="objectName">对象名称</param>
        /// <param name="attrName">属性名称</param>
        /// <param name="index">索引(从0开始)</param>
        /// <returns></returns>
        public static string AppSettingOfList(string objectName, string attrName, int index)
        {
            if (string.IsNullOrWhiteSpace(objectName) || string.IsNullOrWhiteSpace(attrName))
                throw new Exception("objectName && attrName is not null or empty");
            return AppSettings[$"{objectName}:{index}:{attrName}"];
        }
    }
}
