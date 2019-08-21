using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CheckManagerModel;
using QianKunHelper;
using QianKunHelper.CacheHelper;
using QianKunHelper.LogHelper;
using QianKunHelper.WebApiHelper;

namespace CheckManagerBLL
{
    public class JobBll
    {
        private static ILog log = LogManager.GetLog<JobBll>();
        private readonly string uri = ConfigurationManager.AppSettings["QianKunApi"];
        public List<BrandInfo> GetBrandInfosByApi(string cloudName)
        {
            var url = $"{uri}Brand/GetBrandInfo?cloudName={cloudName}";
            var result = WebapiHelper.Get<List<BrandInfo>>(url);
            return result.Success ? result.Data : null;
        }

        public List<BrandInfo> GetBrandInfosByCache(string cloudName)
        {
            var url = $"{uri}Brand/GetBrandInfo?cloudName={cloudName}";
            var result = WebapiHelper.Get<List<BrandInfo>>(url);
            return result.Success ? result.Data : null;
        }
        public void SetHBrands(string cloudName, List<BrandInfo> brandInfos)
        {
            try
            {
                var keys = new List<string>();
                brandInfos.ForEach(x =>
                    {
                        var brandHashId = string.Format(Const.HashIdOfBrand, cloudName, x.BrandId);
                        keys.Add(brandHashId);
                        CacheManager.RedisCache.Hset(brandHashId, x);
                    });
                CacheManager.RedisCache.Sset(cloudName, keys);
            }
            catch (Exception e)
            {
                log.Error($"【JOB】SetHBrands({cloudName})", e);
            }
        }

        private async void GetProdctCountAsycn(string hashId, bool isCrmUrl)
        {
            var branId = CacheManager.RedisCache.Hget(hashId, "BrandId");
            var connectionStr = CacheManager.RedisCache.Hget(hashId, (isCrmUrl ? "CrmDbConnectiong" : "RtlDbConnectiong"));
            var url = uri + (isCrmUrl ? "Crm/GetCrmPrdDetailCount" : "Rtl/GetRtlProdDetailCount") + "?brandId={0}&connectionStr={1}&dbType={2}";
            url = string.Format(url, branId, connectionStr, Const.DataBaseType);
            var num = await GetProdctCount(url);
            var key = isCrmUrl ? "CrmNum" : "PosNum";
            CacheManager.RedisCache.Hset(hashId, key, num.ToString());
        }
        private Task<int> GetProdctCount(string url)
        {
            return Task.Run(() =>
            {
                var result = WebapiHelper.Get<int>(url);
                return result.Success ? result.Data : 0;
            });
        }

        public void UpdateProductNum(List<string> hashIds)
        {
            hashIds.ForEach(x =>
            {
                GetProdctCountAsycn(x, true);
                GetProdctCountAsycn(x, false);
            });
        }
    }
}
