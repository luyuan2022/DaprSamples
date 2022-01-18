using Microsoft.AspNetCore.Mvc;

namespace DaprGrpc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<List<UserInfo>> ListUser()
        {
            _logger.LogInformation("调用了 UserController->ListUser方法11123456");
            var userList = new List<UserInfo>()
            {
                new UserInfo(1001,"zhangsan",20),
                new UserInfo(1002,"lisi",40),
                new UserInfo(1003,"wangwu",30),
                new UserInfo(1004,"zhaoliu",25)
            };

            return Ok(userList);
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
