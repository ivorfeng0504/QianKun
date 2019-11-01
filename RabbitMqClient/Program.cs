using System;
using System.Text;
using MqHelper;
using RabbitMQ.Client;

namespace RabbitMqClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("按 1 開始...");
            string flag;
            do
            {
                flag = Console.ReadLine();
            } while (flag != "1");

            Console.WriteLine("定义生产者...");

            DirectExchangeSendMsg();

            Console.WriteLine("按任意键退出程序！");
            Console.ReadKey();
        }

        public static void DirectExchangeSendMsg()
        {
            using IConnection conn = MqFactory.ConnectionFactory.CreateConnection();
            using IModel channel = conn.CreateModel();
            channel.ExchangeDeclare(MqFactory.ExchangeName, "direct", true, false, null);
            channel.QueueDeclare(MqFactory.QueueName, true, false, false, null);
            channel.QueueBind(MqFactory.QueueName, MqFactory.ExchangeName, MqFactory.QueueName);

            var props = channel.CreateBasicProperties();
            props.Persistent = true;

            Console.WriteLine("请输入需要发送的消息:");
            string vadata = Console.ReadLine();
            while (vadata != "exit")
            {
                var msgBody = Encoding.UTF8.GetBytes(vadata);
                channel.BasicPublish(MqFactory.ExchangeName, MqFactory.QueueName, props, msgBody);
                Console.WriteLine("发送时间：{0:yyyy-MM-dd HH:mm:ss}，发送完毕，输入exit退出消息发送", DateTime.Now);
                vadata = Console.ReadLine();
            }
        }
    }
}