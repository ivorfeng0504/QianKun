using System;
using CheckManagerDAL;
using QianKunHelper.DBHelper;
using QianKunHelper.LogHelper;

namespace CheckManagerBLL
{
    public class CrmBll
    {
        private EzpCrmDal dal = new EzpCrmDal();
        ILog log = new NlogLogger(typeof(CrmBll));

        public int GetCrmPrdDetailCount(int brandId, string connectionStr, int dbType)
        {
            try
            {
                if (brandId == 0 || string.IsNullOrWhiteSpace(connectionStr)) return 0;
                return dal.GetCrmPrdDetailCount(brandId, connectionStr, (DbType)dbType);
            }
            catch (Exception e)
            {
                log.Error($"【Crm】GetCrmPrdDetailCount({brandId},{connectionStr},{dbType})", e);
                return -1;
            }
        }
    }
}
