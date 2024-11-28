using Microsoft.AspNetCore.Mvc;

namespace BimbaApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<string> queTiempo = new List<string>()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = queTiempo[Random.Shared.Next(queTiempo.Count)]
            })
            .ToArray();
        }

        [HttpPost]

        public List<string> CrearTiempo(string nombreTiempo) 
            {
                queTiempo.Add(nombreTiempo);
                return queTiempo;
            }
    }
}
