using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QianKunHelper.CacheHelper;
using QianKunHelper.LogHelper;
using SmileService;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private ILog log = LogManager.GetLog<ValuesController>();
        private const string sleepInKey = "smile.sleep.Input";
        private const string sleepOutKey = "smile.sleep.Output";
        private const string noSleepInKey = "smile.nosleep.Input";
        private const string noSleepOutKey = "smile.nosleep.Output";

        [HttpGet("{id}")]
        [DisplayName("1002")]
        [Description("12001")]
        public ActionResult<string> Get(int id)
        {
            try
            {
                CacheManager.RedisCache.Incr(sleepInKey);
                log.Error("start...");
                var clint = new SmileServiceSoapClient(SmileServiceSoapClient.EndpointConfiguration.SmileServiceSoap12);
                var result = clint.SleepAsync(id).Result.Body.SleepResult;
                CacheManager.RedisCache.Incr(sleepOutKey);
                log.Error(result + "-end!");
                return result;
            }
            catch (Exception e)
            {
                log.Error("[异常]：" + e.Message, e);
                return e.Message;
            }
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var w = await CallWebService();
            log.Error("sleep");
            try
            {
                CacheManager.RedisCache.Incr(noSleepInKey);
                log.Error("start...");
                var binding = new BasicHttpBinding();
                //binding.ReceiveTimeout
                var endpoind = new EndpointAddress("http://qiankun.ezrpro.com:6066/SmileService.asmx?wsdl");
                var factory = new ChannelFactory<SmileServiceSoap>(binding, endpoind);
                var callClient = factory.CreateChannel();
                var dd = callClient.NoSleepAsync(new NoSleepRequest()).Result;
                var clint = new SmileServiceSoapClient(SmileServiceSoapClient.EndpointConfiguration.SmileServiceSoap12);
                var result = clint.NoSleepAsync().Result.Body.NoSleepResult;
                log.Error(result + "-end!");
                CacheManager.RedisCache.Incr(noSleepOutKey);
                return result;
            }
            catch (Exception e)
            {
                log.Error("[异常]：" + e.Message, e);
                return e.Message;
            }
        }

        public async Task<string> CallWebService()
        {
            var binding = new BasicHttpBinding();
            var endpoind = new EndpointAddress("http://qiankun.ezrpro.com:6066/SmileService.asmx?wsdl");
            var factory = new ChannelFactory<SmileServiceSoap>(binding, endpoind);
            var callClient = factory.CreateChannel();
            var relult = await callClient.NoSleepAsync(new NoSleepRequest());
            return relult.Body.NoSleepResult;
        }
    }
}