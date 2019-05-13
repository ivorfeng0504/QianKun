using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CheckManagerModel;
using CheckManagerModel.DbModels;
using Dapper;
using QianKunHelper.DBHelper;

namespace CheckManagerDAL
{
    public class EzpBaseDal
    {
        private string _dbName;
        public EzpBaseDal(string dbName)
        {
            _dbName = dbName;
        }
        public IEnumerable<Pf_sys_db_shard_nodes> GetPf_sys_db_shard_nodes()
        {
            using (var db = DBhelper.GetDbConnection(_dbName))
            {
                var sql = DBhelper.GetSql("ezp_base", "s.pf_sys_db_shard_nodes");
                return db.Query<Pf_sys_db_shard_nodes>(sql);
            }
        }
        public Task<IEnumerable<Pf_sys_db_shard_nodes>> GetPf_sys_db_shard_nodesAsync()
        {
            return Task.Run(GetPf_sys_db_shard_nodes);
        }
    }
}
