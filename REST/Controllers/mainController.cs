using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace REST.Controllers
{
    [Route("api/")]
    [ApiController]
    public class mainController : ControllerBase
    {
        // GET: api/
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "Value requested: " + id;
        }

        // POST api/
        [HttpPost]
        public string Post([FromBody] string value)
        {
            return "Value send: " + value;
        }

        // PUT api/
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
