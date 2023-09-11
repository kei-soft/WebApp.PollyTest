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
            // 3���õ� ������ BadRequest
            if (testIndex < 3)
            {
                testIndex++;
                Debug.WriteLine($"�� {testIndex} BadRequest");
                return BadRequest();
            }
            else
            {
                // 4��° ��� ���� ó��
                Debug.WriteLine($"�� {testIndex} Sucess!!");

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