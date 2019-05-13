using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml;
using MySql.Data.MySqlClient;
using Oracle.ManagedDataAccess.Client;

namespace QianKunHelper.DBHelper
{
    public class DBhelper
    {
        private static List<DbConfig> dbConfigs;

        public static IDbConnection GetDbConnection(string dbName = null)
        {
            DbConfig dbConfig = GetDbConfig(dbName);
            return GetDbConnection(dbConfig.ConnectionString, dbConfig.DbType);
        }

        public static IDbConnection GetDbConnection(string connStr, DbType dbType)
        {
            IDbConnection conn;
            switch (dbType)
            {
                case DbType.MySql: conn = new MySqlConnection(connStr); break;
                case DbType.SqlServer: conn = new SqlConnection(connStr); break;
                case DbType.Oracel: conn = new OracleConnection(connStr); break;
                default: conn = new MySqlConnection(connStr); break;
            }
            conn.Open();
            return conn;
        }
        private static DbConfig GetDbConfig(string dbName)
        {
            if (dbConfigs == null)
            {
                dbConfigs = ConfigurationManager.AppSettingOfList<DbConfig>("DbConfig");
            }

            return dbName == null ? dbConfigs[0] : dbConfigs.FirstOrDefault(x => x.DbName.Equals(dbName));
        }

        /// <summary>
        /// 从配置文件中获取Sql语句
        /// </summary>
        /// <param name="sql">配置文件名</param>
        /// <param name="key">sql语句名</param>
        /// <returns></returns>
        public static string GetSql(string sql, string key)
        {
            if (string.IsNullOrWhiteSpace(key)) return sql;
            //文件路径
            string filePath = string.Format(AppDomain.CurrentDomain.BaseDirectory + @"config\sql\{0}.config", sql);
            //解析xml
            XmlDocument Xdoc = new XmlDocument();
            Xdoc.Load(filePath);
            XmlNodeList list = Xdoc.SelectNodes("configuration/sqlmapping");
            XmlNode mappingNode = list.Cast<XmlNode>().FirstOrDefault(x => x.Attributes["key"].Value.Equals(key));
            XmlNode sqlNode = mappingNode.SelectSingleNode("sql");
            return sqlNode.InnerText.Replace("\r\n", "").Trim();
        }
    }
}
