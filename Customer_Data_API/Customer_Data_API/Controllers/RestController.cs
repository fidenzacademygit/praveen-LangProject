using Customer_Data_API.Data;
using Customer_Data_API.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Customer_Data_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public RestController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<RestController>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customers = _dbContext.Customers.Include(c => c.Address);
            return customers;
        }

        // GET api/<RestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
