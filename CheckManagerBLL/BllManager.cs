using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckManagerModel;
using QianKunHelper.CacheHelper;

namespace CheckManagerBLL
{
    public class BllManager
    {
        #region API
        /// <summary>
        /// 获取品牌的基本信息
        /// </summary>
        /// <returns>品牌的基本信息</returns>
        public List<BrandInfo> GeBrandInfos(string cloudName)
        {
            var brandBll = new BrandInfoBll();
            return brandBll.GetBrandInfos(cloudName).ToList();
        }
        public async Task<List<BrandInfo>> GeBrandInfosAsycn(string cloudName)
        {
            var brandBll = new BrandInfoBll();
            var taskList= await brandBll.GetBrandInfosAsync(cloudName);
            return taskList.ToList();
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
            return rtlBll.GetRtlProdDetailCount(brandId, connectionStr, dbType);
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
        #endregion

        #region JOB
        /// <summary>
        /// 刷新品牌信息缓存
        /// </summary>
        /// <param name="cloudName">品牌所在云名称</param>
        public static void RefreshBrandInfoByCloudName(string cloudName)
        {
            //1.获取全部品牌信息
            JobBll jobBll = new JobBll();
            List<BrandInfo> brandInfos = jobBll.GetBrandInfosByApi(cloudName);
            if (brandInfos == null || brandInfos.Count == 0) return;
            //2.存入缓存
            jobBll.SetHBrands(cloudName, brandInfos);
        }
        /// <summary>
        /// 刷新品牌信息缓存
        /// </summary>
        /// <param name="cloudName">品牌所在云名称</param>
        public static void RefreshProductNumByCloudName(string cloudName)
        {
            //1.获取全部品牌HashId
            var hashIds = CacheManager.RedisCache.Sget(cloudName);
            if (hashIds == null || hashIds.Count == 0) return;
            //2.更新缓存
            JobBll jobBll = new JobBll();
            jobBll.UpdateProductNum(hashIds);
        }
        #endregion
    }
}
