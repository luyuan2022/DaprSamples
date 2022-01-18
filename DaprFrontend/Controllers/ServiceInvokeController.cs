using Dapr.Client;
using GrpcGreeter;
using Microsoft.AspNetCore.Mvc;

namespace DaprFrontend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceInvokeController : ControllerBase
    {
        private DaprClient _daprClient;
        private ILogger<ServiceInvokeController> _logger;

        public ServiceInvokeController(DaprClient daprClient, ILogger<ServiceInvokeController> logger)
        {
            _daprClient = daprClient;
            _logger = logger;
        }

        [HttpGet]
        [Route("invokeService")]
        public async Task<ActionResult<List<UserInfo>>> InvokeService()
        {
            _logger.LogInformation("DaprFrontend Called");
            // 基于Http协议方式调用
            var result = await _daprClient.InvokeMethodAsync<List<UserInfo>>(HttpMethod.Get, "http-backend", "/user/all");
            return Ok(result);
        }

        [HttpGet]
        [Route("invokeGrpc")]
        public async Task<ActionResult<List<UserInfo>>> InvokeGrpc()
        {
            _logger.LogInformation("DaprFrontend Grpc Called");
            // 基于Http协议方式调用
            var result = await _daprClient.InvokeMethodGrpcAsync<HelloRequest, HelloReply>("backend", "grpc", new HelloRequest { Name = "Gerry Grpc" });
            return Ok(result);
        }
    }

    /// <summary>
    /// 定义类（包含带三个参数构造函数）
    /// </summary>
    /// <param name="UserId"></param>
    /// <param name="UserName"></param>
    /// <param name="Age"></param>
    public record UserInfo(long UserId, string UserName, int Age);
}
