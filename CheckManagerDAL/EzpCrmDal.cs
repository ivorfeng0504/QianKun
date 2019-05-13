using Dapper;
using QianKunHelper.DBHelper;

namespace CheckManagerDAL
{
    public class EzpCrmDal
    {
        public int GetCrmPrdDetailCount(int brandId, string connectionStr, DbType dbType)
        {
            using (var db = DBhelper.GetDbConnection(connectionStr, dbType))
            {
                var sql = DBhelper.GetSql("ezp_crm", "count.crm_prd_detail");
                return db.ExecuteScalar<int>(sql, new { BrandId = brandId });
            }
        }
    }
}
