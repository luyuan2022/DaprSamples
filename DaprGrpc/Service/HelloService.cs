using Dapr.AppCallback.Autogen.Grpc.v1;
using Dapr.Client.Autogen.Grpc.v1;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using GrpcGreeter;

namespace DaprGrpc.Service
{
    public class HelloService : AppCallback.AppCallbackBase
    {
        private ILogger<HelloService> _logger;

        public HelloService(ILogger<HelloService> logger)
        {
            _logger = logger;
        }
        public override Task<InvokeResponse> OnInvoke(InvokeRequest request, ServerCallContext context)
        {
            _logger.LogInformation("========================>调用了后端的GRPC服务");
            var response = new InvokeResponse();
            switch (request.Method)
            {
                case "grpc":
                    var input = request.Data.Unpack<HelloRequest>();
                    response.Data = Any.Pack(new HelloReply { Message = "Dapr GrpcServer Called" });
                    Console.WriteLine("=================>input data:" + input);
                    break;
            }
            return Task.FromResult(response);
        }
    }
}
