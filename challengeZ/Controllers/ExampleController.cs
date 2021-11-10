using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challengeZ.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExampleController : ControllerBase
    {

        private readonly ILogger<ExampleController> _logger;

        public ExampleController(ILogger<ExampleController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Try with POST method ;)";
        }

        [HttpPost]
        public ActionResult<decimal[]> Post(int[] numbers)
        {
            if (numbers == null || numbers.Length == 0)
                return BadRequest();

            return MasMenos(numbers);
        }

        private decimal[] MasMenos(int[] numbers) 
        {
            decimal totalNumbers = numbers.Length;
            decimal positivos = numbers.Where(n => n > 0).Count() / totalNumbers;
            decimal negativos = numbers.Where(n => n < 0).Count() / totalNumbers;
            decimal ceros = numbers.Where(n => n == 0).Count() / totalNumbers;

            return new decimal[] { decimal.Round(positivos,2) , decimal.Round(negativos, 2), decimal.Round(ceros, 2) };
        }

    }
}
