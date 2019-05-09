using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using QianKunHelper.LogHelper;

namespace QianKunHelper.WebApiHelper
{
    public class WebapiHelper
    {
        private static ILog log = LogManager.GetLog<WebapiHelper>();
        public static ApiResult<T> Post<T>(string url, string postData)
        {
            ApiResult<T> result = null;
            try
            {
                HttpContent httpContent = new StringContent(postData);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var httpClient = HttpClientFactory.Create(new HttpClientHandler());
                var timeOut = ConfigurationManager.AppSettings["TimeOut"];
                int.TryParse(timeOut, out int Timeout);
                httpClient.Timeout = new TimeSpan(0, 0, Timeout <= 0 ? 5 : Timeout);
                var response = httpClient.PostAsync(url, httpContent).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = response.Content.ReadAsStringAsync().Result;
                    result = new ApiResult<T>(responseJson);
                }
                else
                {
                    string sError = response.Content.ReadAsStringAsync().Result;
                    result = new ApiResult<T>(new Exception(sError), "HTTP响应失败！", ApiResultState.OutException);
                }
            }
            catch (Exception e)
            {
                result = new ApiResult<T>(e, "调用第三方接口异常！");
            }
            log.Debug($"URL:{url};Request:{postData};Response:{JsonConvert.SerializeObject(result)}");
            return result;
        }

        public static ApiResult<T> Get<T>(string url, Dictionary<string, string> haders = null)
        {
            ApiResult<T> result = null;
            try
            {

                var httpClient = HttpClientFactory.Create(new HttpClientHandler());
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var timeOut = ConfigurationManager.AppSettings["TimeOut"];
                int.TryParse(timeOut, out int Timeout);
                httpClient.Timeout = new TimeSpan(0, 0, Timeout <= 0 ? 5 : Timeout);

                if (haders != null && haders.Keys.Count > 0)
                {
                    foreach (var item in haders)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                var response = httpClient.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseJson = response.Content.ReadAsStringAsync().Result;
                    result = new ApiResult<T>(responseJson);
                }
                else
                {
                    string sError = response.Content.ReadAsStringAsync().Result;
                    result = new ApiResult<T>(new Exception(sError), "HTTP响应失败！", ApiResultState.OutException);
                }
            }
            catch (Exception e)
            {
                result = new ApiResult<T>(e, "调用第三方接口异常！");
            }
            log.Debug($"URL:{url};Response:{JsonConvert.SerializeObject(result)}");
            return result;
        }
    }
}
