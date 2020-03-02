using Microsoft.AspNetCore.Mvc;
using RC.Weather.Presentation;
using RC.Weather.Presentation.Models.Requests;
using System.Threading.Tasks;

namespace RC.Weather.Api.Controllers
{
    public class CitiesController : ApplicationBaseController
    {
        private readonly IPresentationCityService cityService;

        public CitiesController(IPresentationCityService cityService)
        {
            this.cityService = cityService;
        }

        // GET: api/cities
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PresentationCitiesListRequest model)
        {
            var response = await this.cityService.SearchCityAsync(model);
            return StatusCode((int)response.HttpStatusCode, response.Data);
        }
    }
}
