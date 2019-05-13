using QianKunHelper.LogHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CheckManagerBLL;
using QianKunHelper;
using QianKunHelper.CacheHelper;
using QianKunHelper.DBHelper;
using QianKunHelper.WebApiHelper;

namespace QianKunConsole
{
    class Program
    {
        private static ILog log = LogManager.GetLog<Program>();
        private static QianKun QianKun = new QianKun(log);
        static void Main(string[] args)
        {
            Console.WriteLine("action...");

            BrandInfoBll bll = new BrandInfoBll();
            var list = bll.GetBrandInfos().ToList();
            //var lenght = QianKun.Action();
            //Console.WriteLine("lenght" + lenght.Result);
            Console.WriteLine("***end!");
            Console.ReadKey();
        }
    }

    public class QianKun
    {
        public string x;
        public ILog _log;
        public QianKun(ILog log)
        {
            _log = log;
        }

        #region async&await
        public async Task<int> Action()
        {
            Console.WriteLine("喝茶1...");
            var title1 = await LookNewsTitleAsync(2000);
            var title2 = await LookNewsTitleAsync(1000);
            Console.WriteLine("喝茶2...");
            Console.WriteLine(title1);
            Console.WriteLine(title2);
            return (title1 + title2).Length;
        }
        public Task<string> LookNewsTitleAsync(int sleep)
        {
            Console.WriteLine("LookNewsTitleAsync:" + Thread.CurrentThread.ManagedThreadId);
            return Task.Run(() => LookNewsTitle(sleep));
        }
        public string LookNewsTitle(int sleep)
        {
            Console.WriteLine("LookNewsTitle:" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("查看新闻标题...");
            Thread.Sleep(sleep);
            var content = "中国海军成立70周年:" + sleep;
            Console.WriteLine(content);
            Console.WriteLine("查看完成...");
            return content;
        }
        #endregion

        #region Parallel
        public void ParallelTesting()
        {
            Parallel.For(0, 1001, new ParallelOptions { MaxDegreeOfParallelism = 1000 }, x =>
               {
                   try
                   {
                       string key = $"key_{x}";
                       try
                       {
                           CacheManager.Cache.Set(key, Thread.CurrentThread.ManagedThreadId);
                           var value = CacheManager.Cache.Get(key);
                           _log.Debug($"{key}:{value}");
                       }
                       catch (Exception e)
                       {
                           _log.Debug($"{key}:【异常】{e.Message}");
                       }
                   }
                   catch (Exception e)
                   {
                       var factroy = new Log4netLoggerFactroy();
                       factroy.GetLogger(typeof(Program)).Debug(e.Message);
                   }

               });
        }
        public void NotParallelTesting()
        {
            for (int i = 0; i < 220; i++)
            {
                try
                {
                    string key = $"key_{i}";
                    try
                    {
                        CacheManager.Cache.Set(key, Thread.CurrentThread.ManagedThreadId);
                        var value = CacheManager.Cache.Get(key);
                        _log.Debug($"{key}:{value}");
                    }
                    catch (Exception e)
                    {
                        _log.Debug($"{key}:【异常】{e.Message}");
                    }
                }
                catch (Exception e)
                {
                    var factroy = new Log4netLoggerFactroy();
                    factroy.GetLogger(typeof(Program)).Debug(e.Message);
                }
            }
        }
        #endregion

        #region HttpClient

        public void Get()
        {
            Parallel.For(0, 1000
                , new ParallelOptions { MaxDegreeOfParallelism = 1000 }
                , x =>
                {
                    var reslut = WebapiHelper.Get<int>("https://localhost:44335/api/values/" + x);
                    Console.WriteLine(reslut.Data);
                });

        }

        public void Post()
        {
            var reslut = WebapiHelper.Post<int>("https://localhost:44335/api/values", new Random().Next(100).ToString());
            Console.WriteLine(reslut.Data);
        }

        #endregion
    }
}
