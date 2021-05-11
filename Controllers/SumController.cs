using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace unleash_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SumController : ControllerBase
    {
        private readonly ILogger<SumController> _logger;

        public SumController(ILogger<SumController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(long num1, long num2)
        {
            var sum = num1 + num2;
            _logger.LogInformation("{0} + {1} = {2}", num1, num2, sum);
            return Ok(sum);

        }
    }
}
