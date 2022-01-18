using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DaprFrontend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PubsubController : ControllerBase
    {
        private DaprClient _daprClient;
        private ILogger<PubsubController> _logger;

        public PubsubController(DaprClient daprClient, ILogger<PubsubController> logger)
        {
            _daprClient = daprClient;
            _logger = logger;
        }

        /// <summary>
        /// 发布消息的方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("pub")]
        public async Task<IActionResult> PublishMessage()
        {
            _logger.LogInformation(">>>>>>>>>>>>>>>>>>>>>> 发布消息");
            var data = new UserInfo(40001,"张三",43);
            await _daprClient.PublishEventAsync("pubsub", "user_topic",data);

            return Ok("发布消息成功~");
        }
    }
}
