using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckManagerBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CrmController : ControllerBase
    {
        /// <summary>
        /// 商品中心-获取商品总数
        /// </summary>
        /// <param name="brandId">品牌ID</param>
        /// <param name="connectionStr">数据库连接字符串</param>
        /// <param name="dbType">数据库类型；0:mysql;1:sqlserver;2:oracel</param>
        /// <returns>商品总数</returns>
        public ActionResult<int> GetCrmPrdDetailCount(int brandId, string connectionStr, int dbType)
        {
            BllManager manager = new BllManager();
            return manager.GetCrmPrdDetailCount(brandId, connectionStr, dbType);
        }
    }
}