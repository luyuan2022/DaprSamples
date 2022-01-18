using Dapr;
using DaprSamples1115.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace DaprBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubController : ControllerBase
    {
        private ILogger<SubController> _logger;

        public SubController(ILogger<SubController> logger)
        {
            _logger = logger;
        }


        [HttpPost("sub")]
        [Topic("pubsub", "user_topic")]
        public IActionResult ConsumerMessage(UserInfo user)
        {
            _logger.LogInformation(">>>>>>>>>>>>>>>>>>>>>>>消费消息");
            Console.WriteLine($"userId:{user.UserId} userName:{user.UserName}");
            return Ok();
        }
    }
}
