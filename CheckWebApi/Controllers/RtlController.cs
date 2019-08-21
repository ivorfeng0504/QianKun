using CheckManagerBLL;
using Microsoft.AspNetCore.Mvc;
using QianKunHelper.WebApiHelper;

namespace CheckWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RtlController : ControllerBase
    {
        /// <summary>
        /// 商品中心-获取商品总数
        /// </summary>
        /// <param name="brandId">品牌ID</param>
        /// <param name="connectionStr">数据库连接字符串</param>
        /// <param name="dbType">数据库类型；0:mysql;1:sqlserver;2:oracel</param>
        /// <returns>商品总数</returns>
        public ActionResult<CheckManagerModel.ApiResult<int>> GetRtlProdDetailCount(int brandId, string connectionStr, int dbType)
        {
            BllManager manager = new BllManager();
            var s= manager.GetRtlProdDetailCount(brandId, connectionStr, dbType);
            return new CheckManagerModel.ApiResult<int>(s);
        }
    }
}