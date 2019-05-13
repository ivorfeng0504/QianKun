using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CheckManagerModel;
using CheckManagerModel.DbModels;
using Dapper;
using QianKunHelper.DBHelper;

namespace CheckManagerDAL
{
    public class EzpEdDal
    {
        private string _dbName;
        public EzpEdDal(string dbName)
        {
            _dbName = dbName;
        }
        public IEnumerable<Ed_base_brand> GetEd_base_brand()
        {
            using (var db = DBhelper.GetDbConnection(_dbName))
            {
                var sql = DBhelper.GetSql("ezp_ed", "s.ed_base_brand");
                return db.Query<Ed_base_brand>(sql);
            }
        }
        public Task<IEnumerable<Ed_base_brand>> GetEd_base_brandAsync()
        {
            return Task.Run(GetEd_base_brand);
        }
    }
}
