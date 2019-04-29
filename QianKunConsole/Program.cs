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
            var log = new LogManager<Program>().Log;
            QianKun.Action();
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }

    public class QianKun
    {
        public async void Action()
        {
            Console.WriteLine("喝茶1...");
            var title = await LookNewsTitleAsync();
            Console.WriteLine("喝茶2...");
            Console.WriteLine(title);
        }
        public Task<string> LookNewsTitleAsync()
        {
            return Task.Run(LookNewsTitle);
        }
        public string LookNewsTitle()
        {
            Console.WriteLine("查看新闻标题...");
            Thread.Sleep(1000);
            Console.WriteLine("查看完成...");
            return "中国海军成立70周年";
        }
    }
}
