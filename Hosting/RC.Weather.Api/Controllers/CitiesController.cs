using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace RC.Weather.Api.Controllers
{
    public class CitiesController : ApplicationBaseController
    {
        // GET: api/cities
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Cities/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cities
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
