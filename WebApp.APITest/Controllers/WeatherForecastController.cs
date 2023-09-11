using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;

namespace WebApp.APITest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public static int testIndex = 0;

        private static readonly string[] Summaries = new[]
            {"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"};

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetWeatherForecastData")]
        public ActionResult<WeatherForecast> GetWeatherForecastData()
        {
            // 3번시도 까지는 BadRequest
            if (testIndex < 3)
            {
                testIndex++;
                Debug.WriteLine($"★ {testIndex} BadRequest");
                return BadRequest();
            }
            else
            {
                // 4번째 결과 정상 처리
                Debug.WriteLine($"★ {testIndex} Sucess!!");

                return Ok(new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(1),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                });
            }
        }
    }
}