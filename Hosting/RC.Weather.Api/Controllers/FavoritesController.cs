using Microsoft.AspNetCore.Mvc;
using RC.Weather.Presentation;
using RC.Weather.Presentation.Models;

namespace RC.Weather.Api.Controllers
{
    public class FavoritesController : ApplicationBaseController
    {
        private readonly IPresentationFavoriteService favoriteService;

        public FavoritesController(IPresentationFavoriteService favoriteService)
        {
            this.favoriteService = favoriteService;
        }

        // GET: api/favorites
        [HttpGet]
        public IActionResult Get()
        {
            var response = this.favoriteService.Get();
            return StatusCode((int)response.HttpStatusCode, response.Data);
        }

        // POST: api/favorites
        [HttpPost]
        public IActionResult Post([FromBody] PresentationCityModel favorite)
        {
            var response = this.favoriteService.Create(favorite);
            return StatusCode((int)response.HttpStatusCode);
        }

        // DELETE: api/favorites
        [HttpDelete("{cityCode}")]
        public IActionResult Delete(string cityCode)
        {
            var response = this.favoriteService.Delete(cityCode);
            return StatusCode((int)response.HttpStatusCode);
        }
    }
}
