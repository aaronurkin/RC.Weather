using Microsoft.AspNetCore.Mvc;
using RC.Weather.Presentation;
using RC.Weather.Presentation.Models.Requests;
using System.Threading.Tasks;

namespace RC.Weather.Api.Controllers
{
    public class WeatherController : ApplicationBaseController
    {
        private readonly IWeatherPresentationService weatherPresentationService;

        public WeatherController(IWeatherPresentationService weatherPresentationService)
        {
            this.weatherPresentationService = weatherPresentationService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PresentationWeatherRequest model)
        {
            var response = await this.weatherPresentationService.GetWeatherAsync(model);
            return StatusCode((int)response.HttpStatusCode, response.Data);
        }
    }
}