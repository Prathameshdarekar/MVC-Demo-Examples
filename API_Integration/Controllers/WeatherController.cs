using System.Threading.Tasks;
using System.Web.Mvc;
using API_Integration.Services;
using API_Integration.Models;

namespace API_Integration.Controllers
{
    public class WeatherController : Controller
    {
        private readonly WeatherService _weatherService;

        public WeatherController()
        {
            _weatherService = new WeatherService();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> GetWeather(string city)
        {
            var weatherData = await _weatherService.GetWeatherAsync(city);
            return View("WeatherResult", weatherData);
        }
    }
}
