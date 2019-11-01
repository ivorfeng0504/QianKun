using System;
using System.Text;
using MqHelper;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMqConsumer
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("消费者...");
            DirectAcceptExchange();
            Console.ReadKey();
        }

        public static void DirectAcceptExchange()
        {
            using IConnection conn = MqFactory.ConnectionFactory.CreateConnection();
            using IModel channel = conn.CreateModel();
            channel.ExchangeDeclare(MqFactory.ExchangeName, "direct", true, false, null);
            channel.QueueDeclare(MqFactory.QueueName, true, false, false, null);
            channel.QueueBind(MqFactory.QueueName, MqFactory.ExchangeName, MqFactory.QueueName);

            while (true)
            {
                var msgResponse = channel.BasicGet(MqFactory.QueueName, false);

                if (msgResponse != null)
                {
                    var msgBody = Encoding.UTF8.GetString(msgResponse.Body);
                    Console.WriteLine("接收时间：{0:yyyy-MM-dd HH:mm:ss}，消息内容：{1}", DateTime.Now, msgBody);
                }
            }
        }
    }
}