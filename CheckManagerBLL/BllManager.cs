using System.Collections.Generic;
using System.Linq;
using CheckManagerModel;

namespace CheckManagerBLL
{
    public class BllManager
    {
        /// <summary>
        /// 获取品牌的基本信息
        /// </summary>
        /// <returns>品牌的基本信息</returns>
        public List<BrandInfo> GeBrandInfos()
        {
            var brandBll = new BrandInfoBll();
            return brandBll.GetBrandInfos().ToList();
        }

        /// <summary>
        /// 商品中心-获取商品总数
        /// </summary>
        /// <param name="brandId">品牌ID</param>
        /// <param name="connectionStr">数据库连接字符串</param>
        /// <param name="dbType">数据库类型；0:mysql;1:sqlserver;2:oracel</param>
        /// <returns>商品总数</returns>
        public int GetRtlProdDetailCount(int brandId, string connectionStr, int dbType)
        {
            var rtlBll = new RtlBll();
            return rtlBll.GetRtlProdDetailCount( brandId, connectionStr, dbType);
        }
        /// <summary>
        /// CRM-获取商品总数
        /// </summary>
        /// <param name="brandId">品牌ID</param>
        /// <param name="connectionStr">数据库连接字符串</param>
        /// <param name="dbType">数据库类型；0:mysql;1:sqlserver;2:oracel</param>
        /// <returns>商品总数</returns>
        public int GetCrmPrdDetailCount(int brandId, string connectionStr, int dbType)
        {
            var crmBll = new CrmBll();
            return crmBll.GetCrmPrdDetailCount(brandId, connectionStr, dbType);
        }
    }
}
