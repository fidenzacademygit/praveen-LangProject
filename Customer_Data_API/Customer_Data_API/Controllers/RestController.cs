using Customer_Data_API.Data;
using Customer_Data_API.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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

        // GET: api/Rest/GetCustomers
        [HttpGet("GetCustomers")]
        
        public IEnumerable<Customer> Get()
        {
            var customers = _dbContext.Customers.Include(c => c.Address);
            return customers;
        }

        // GET api/Rest/5
        [HttpGet("{Id}")]
        public Customer? Get(string Id)
        {
            var customer = _dbContext.Customers.Include(c => c.Address).FirstOrDefault(c => c.Id == Id);
            return customer;
        }

        // GET api/Rest/CustomersGroupByZipcode
        [HttpGet]
        [Route("CustomersGroupByZipcode")]
        public IActionResult GetCustomersGroupedByZipCode()
        {
            var customers = _dbContext.Customers.Include(c => c.Address);

            var groupedCustomers = customers
                .GroupBy(c => c.Address.Zipcode)
                .Select(group => new
                {
                    ZipCode = group.Key,
                    Customers = group.ToList()
                });

            return Ok(groupedCustomers);
        }

        // PUT api/Rest/5
        [HttpPut("{Id}")]
        public IActionResult Put(string Id, [FromBody] Customer customerObj)
        {
            var customer = _dbContext.Customers.Include(c => c.Address).FirstOrDefault(c => c.Id == Id);
            if(customer != null)
            {
                if(customerObj.Name != null || customerObj.Email != null || customerObj.Phone != null)
                {
                    if (customerObj.Name != null)
                    {
                        customer.Name = customerObj.Name;
                    }
                    if (customerObj.Email != null)
                    {
                        customer.Email = customerObj.Email;
                    }
                    if (customerObj.Phone != null)
                    {
                        customer.Phone = customerObj.Phone;
                    }
                }
                else
                {
                    return NotFound("Enter Edit Details!");
                }
            }
            else
            {
                return NotFound("User Not Available!");
            }
            
            _dbContext.SaveChanges();
            return Ok("Success");

        }

    }
}
