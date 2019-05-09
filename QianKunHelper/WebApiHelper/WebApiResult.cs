using System;
using Newtonsoft.Json;

namespace QianKunHelper.WebApiHelper
{
    public class ApiResult<T>
    {
        public ApiResult() { }

        public ApiResult(Exception ex, string message, ApiResultState state = ApiResultState.InException)
        {
            Success = false;
            Ex = ex;
            State = state;
            Message = $"{message}[异常]:{ex.Message}";
        }
        public ApiResult(string resultJson)
        {
            if (string.IsNullOrWhiteSpace(resultJson))
            {
                Success = false;
                State = ApiResultState.Error;
                Message = "接口返回空！";
                return;
            }

            try
            {
                Success = true;
                State = ApiResultState.Success;
                Data = JsonConvert.DeserializeObject<T>(resultJson);
            }
            catch (Exception e)
            {
                Success = false;
                State = ApiResultState.ConvertException;
                Ex = e;
                Message =$"返回结果[{resultJson}]序列化异常！";
            }
        }
        public bool Success { get; set; }
        public ApiResultState State { get; set; }
        public string Message { get; set; }
        public Exception Ex { get; set; }
        public T Data { get; set; }
    }

    public enum ApiResultState
    {
        /// <summary>
        /// 请求成功
        /// </summary>
        Success = 1100,
        /// <summary>
        /// 业务错误
        /// </summary>
        Error,
        /// <summary>
        /// 请求超时
        /// </summary>
        TimeOut,
        /// <summary>
        /// 内部异常
        /// </summary>
        InException,
        /// <summary>
        /// 第三方接口异常
        /// </summary>
        OutException,
        /// <summary>
        /// 返回数据转换异常
        /// </summary>
        ConvertException
    }
}
