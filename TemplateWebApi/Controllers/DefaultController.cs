using Microsoft.AspNetCore.Mvc;
using QianKunModel.Common;
using QianKunModel.Test;

namespace TemplateWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult CreateUser(User user)
        {
            return new ApiResult { Success = true, Data = user };
        }

        /// <summary>
        /// 获取 用户信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="name">名称</param>
        /// <returns></returns>
        [HttpGet]
        public ApiResult GetUser(int id, string name)
        {
            return new ApiResult { Success = true, Data = new { Id = id, Name = name } };
        }
    }
}