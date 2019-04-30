using QianKunHelper.LogHelper;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QianKunConsole
{
    class Program
    {
        private static QianKun QianKun = new QianKun();
        static void Main(string[] args)
        {
            var log = LogManager.GetLog<Program>();
            log.Info("hello");
            QianKun.Action();
            Console.ReadKey();
        }
    }

    public class QianKun
    {
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
    }
}
