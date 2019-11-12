using Autofac;
using QianKunHelper.CacheHelper;
using QianKunHelper.LogHelper;
using QianKunHelper.WebApiHelper;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using QianKunAutofac;

namespace QianKunConsole
{
    public class Program
    {
        private static QianKun QianKun = new QianKun();

        private static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<A>().AsSelf().As<IStartable>().InstancePerLifetimeScope();
            builder.RegisterType<B>().InstancePerDependency();
            AutofacTest.Container = builder.Build();

            AutofacTest autofacTest = new AutofacTest();
            int flag = 0;

            while (flag != 99)
            {
                autofacTest.LazyInstantiation();
                int.TryParse(Console.ReadLine(), out flag);
            }

            Console.WriteLine("======END=====");
            Console.ReadKey();
        }
    }

    public class Parent
    {
        public Parent()
        {
            Console.WriteLine("parent");
        }
    }

    public class QianKun : Parent
    {
        public string x;
        private ILog _log;

        public QianKun()
        {
            Console.WriteLine("qiankeun");
            _log = LogManager.GetLog<QianKun>();
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

        public int A300()
        {
            Thread.Sleep(3000);
            Console.WriteLine($"A[{Thread.CurrentThread.ManagedThreadId}]");
            return 300;
        }

        public Task<int> B500Asycn()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"B[{Thread.CurrentThread.ManagedThreadId}]");
                return 500;
            });
        }

        public Task<int> B400Asycn()
        {
            return Task.Run(() =>
            {
                Thread.Sleep(4000);
                Console.WriteLine($"B[{Thread.CurrentThread.ManagedThreadId}]");
                return 400;
            });
        }

        #endregion async&await

        #region Parallel

        public void ParallelTesting()
        {
            Parallel.For(0, 1001, new ParallelOptions { MaxDegreeOfParallelism = 1000 }, x =>
                {
                    var rep = WebapiHelper.Get<string>("https://localhost:5001/api/values/" + x);
                    _log.Info($"{x}:{rep.Data}:{Thread.CurrentThread.ManagedThreadId}");
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

        #endregion Parallel

        #region HttpClient

        public void Post()
        {
            var reslut = WebapiHelper.Post<int>("https://localhost:44335/api/values", new Random().Next(100).ToString());
            _log.Debug(reslut.Data);
            Console.WriteLine(reslut.Data);
        }

        public void Get()
        {
            _log.Debug("");
        }

        #endregion HttpClient
    }
}