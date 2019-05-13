using Dapper;
using QianKunHelper.DBHelper;

namespace CheckManagerDAL
{
    public class EzpRtlDal
    {
        public int GetRtlProdDetailCount(int brandId, string connectionStr, DbType dbType)
        {
            using (var db = DBhelper.GetDbConnection(connectionStr, dbType))
            {
                var sql = DBhelper.GetSql("ezp_rtl", "count.rtl_prod_detail");
                return db.ExecuteScalar<int>(sql, new { BrandId = brandId });
            }
        }
    }
}
