using System;
using System.Threading.Tasks;
using CrpcService;
using Grpc.Net.Client;
using GrpcService;

namespace GrpcClient
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "悟空" });
            Console.WriteLine("调用Greeter服务 : " + reply.Message);

            var ss = new MyMath.MyMathClient(channel);

            var ssReply = await ss.AddAsync(new AddRquest { X = 10, Y = 11 });
            Console.WriteLine("调用MyMath服务 : " + ssReply.Sum);

            Console.ReadLine();
        }
    }
}