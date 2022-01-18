using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace DaprFrontend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private ILogger<StoreController> _logger;
        private DaprClient _daprClient;

        public StoreController(DaprClient daprClient, ILogger<StoreController> logger)
        {
            _logger = logger;
            _daprClient = daprClient;
        }

        /// <summary>
        /// 基于状态存储组件存储订单状态标识
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> SaveStoreValue()
        {
            _logger.LogInformation(">>>>>>>>>>>>>>>>>>>>>>>> 保存订单状态标识");
            await _daprClient.SaveStateAsync("statestore", "orderState", Guid.NewGuid().ToString());

            return Ok("保存状态成功~");
        }

        /// <summary>
        /// 根据状态key获取对应状态标识
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("gain")]
        public async Task<IActionResult> GainStoreValue()
        {
            _logger.LogInformation(">>>>>>>>>>>>>>>>>>>>>>>> 保存订单状态标识");
            var result = await _daprClient.GetStateAsync<string>("statestore", "orderState");

            return Ok(result);
        }
    }
}
