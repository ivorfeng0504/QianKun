using RabbitMQ.Client;

namespace MqHelper
{
    public class MqFactory
    {
        public static ConnectionFactory ConnectionFactory
        {
            get
            {
                var _connectionFactory = new ConnectionFactory
                {
                    HostName = "localhost",
                    UserName = "sayook",
                    Password = "sayook",
                    Port = 5672,
                    VirtualHost = "/"
                };
                return _connectionFactory;
            }
        }

        /// <summary>
        /// 队列名称
        /// </summary>
        public const string QueueName = "qiankun_Queue_no.1";

        /// <summary>
        /// 路由名称
        /// </summary>
        public const string ExchangeName = "qiankun_Exchange_no.1";
    }
}