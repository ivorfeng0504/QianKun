using System.Collections.Generic;
using CheckManagerBLL;
using CheckManagerModel;
using Microsoft.AspNetCore.Mvc;

namespace CheckWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        public BllManager manager = new BllManager();

        [HttpGet]
        public ActionResult<IEnumerable<BrandInfo>> GetBrandInfo(string cloudName)
        {
            var list = manager.GeBrandInfos(cloudName);
            return list;
        }
    }
}