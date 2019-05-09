namespace QianKunHelper.DBHelper
{
    public class DbConfig
    {
        public string DbName { get; set; }
        /// <summary>
        /// MySql:0;SqlServer:1;Oracel:2;
        /// </summary>
        public DbType DbType { get; set; }
        public string ConnectionString { get; set; }
    }
    public enum DbType
    {
        MySql = 0,
        SqlServer,
        Oracel
    }
}
