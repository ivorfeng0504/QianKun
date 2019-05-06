using QianKunHelper.LogHelper;
using System;
using System.Threading;
using System.Threading.Tasks;
using QianKunHelper.CacheHelper;

namespace QianKunConsole
{
    class Program
    {
        private static ILog log = LogManager.GetLog<Program>();
        private static QianKun QianKun = new QianKun(log);
        static void Main(string[] args)
        {
            Console.WriteLine("action...");
            QianKun.ParallelTesting();
            Console.WriteLine("***end!");
            Console.ReadKey();
        }
    }

    public class QianKun
    {
        public ILog _log;

        public QianKun(ILog log)
        {
            _log = log;
        }

        #region async&await
        public async void Action()
        {
            var id = Thread.GetCurrentProcessorId();
            Console.WriteLine("Action:" + id);
            Console.WriteLine("喝茶1...");
            var title = await LookNewsTitleAsync();
            Console.WriteLine("喝茶2...");
            Console.WriteLine(title);
        }
        public Task<string> LookNewsTitleAsync()
        {
            var id = Thread.GetCurrentProcessorId();
            Console.WriteLine("LookNewsTitleAsync:" + id);
            return Task.Run(LookNewsTitle);
        }
        public string LookNewsTitle()
        {

            var id = Thread.GetCurrentProcessorId();
            Console.WriteLine("LookNewsTitle:" + id);
            Console.WriteLine("查看新闻标题...");
            Thread.Sleep(1000);
            Console.WriteLine("查看完成...");
            return "中国海军成立70周年";
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
    }
}
