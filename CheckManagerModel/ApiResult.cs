using System;
using System.Collections.Generic;

namespace CheckManagerModel
{
    /// <summary>
    /// API返回结果类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResult<T>
    {
        public ApiResult(T Data, string msg = null)
        {
            Success = true;
            Code = "200";
            Result = Data;
            Message = msg ?? "响应成功";
        }
        public ApiResult(List<T> Datas, string msg = null)
        {
            Success = true;
            Code = "200";
            Results = Datas;
            Message = msg ?? "响应成功";
        }

        public ApiResult(Exception ex, string errorTitle = null)
        {
            Success = false;
            Message = "响应异常";
            ErrorMsg = $"【{errorTitle}】{ex.Message}";
            Code = "500";
        }
        public bool Success { get; set; }
        public string Code { get; set; }
        public T Result { get; set; }
        public List<T> Results { get; set; }
        public string Message { get; set; }
        public string ErrorMsg { get; set; }
    }
}