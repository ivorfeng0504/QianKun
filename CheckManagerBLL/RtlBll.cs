using System;
using System.Collections.Generic;
using System.Text;
using CheckManagerDAL;
using QianKunHelper.DBHelper;

namespace CheckManagerBLL
{
    public class RtlBll
    {
        private EzpRtlDal dal = new EzpRtlDal();

        public int GetRtlProdDetailCount(int brandId, string connectionStr, int dbType)
        {
            return dal.GetRtlProdDetailCount(brandId, connectionStr, (DbType)dbType);
        }
    }
}
