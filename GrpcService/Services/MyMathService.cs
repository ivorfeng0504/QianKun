using CrpcService;
using System.Threading.Tasks;
using Grpc.Core;

namespace GrpcService.Services
{
    public class MyMathService : MyMath.MyMathBase
    {
        public override Task<AddReply> Add(AddRquest request, ServerCallContext serverCallContext)
        {
            return Task.Run(() =>
            {
                var result = request.X + request.Y;
                return new AddReply
                {
                    Sum = result.ToString()
                };
            });
        }
    }
}