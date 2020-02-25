using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RC.Weather.Api.Controllers
{
    public class FavoritesController : ApplicationBaseController
    {
        // GET: api/favorites
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/favorites/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/favorites
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // DELETE: api/favorites
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
