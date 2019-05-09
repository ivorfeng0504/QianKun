using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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

            IDbConnection conn = null;
            switch (dbConfig.DbType)
            {
                case 0:
                    {
                        conn = new MySqlConnection(dbConfig.ConnectionString);
                        break;
                    }
                case DbType.SqlServer:
                    {
                        conn = new SqlConnection(dbConfig.ConnectionString);
                        break;
                    }

                case DbType.Oracel:
                    {
                        conn = new OracleConnection(dbConfig.ConnectionString);
                        break;
                    }
                default:
                    conn = new MySqlConnection(dbConfig.ConnectionString);
                    break;
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
    }
}
