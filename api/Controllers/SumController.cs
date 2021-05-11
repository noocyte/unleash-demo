using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using Unleash;

namespace unleash_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SumController : ControllerBase
    {
        private readonly ILogger<SumController> _logger;
        private readonly IUnleash _unleash;

        public SumController(ILogger<SumController> logger, IUnleash unleash)
        {
            _logger = logger;
            this._unleash = unleash;
        }

        [HttpGet]
        public IActionResult Get(long num1, long num2)
        {
            if (_unleash.IsEnabled("sumv2"))
            {
                _logger.LogInformation("Using Sum v2");
                var nums = new[] { num1, num2 };
                var sum = nums.Aggregate((a, b) => a + b);
                return Ok(sum);
            }
            else
            {
                _logger.LogInformation("Using Sum v1");
                var sum = num1 + num2;
                return Ok(sum);
            }
        }
    }
}
