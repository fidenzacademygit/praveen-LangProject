using Customer_Data_API.Data;
using Customer_Data_API.Models.Domain;
using Customer_Data_API.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

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
        public IEnumerable<Customer> GetAllCustomers()
        {
            var customers = _dbContext.Customers.Include(c => c.Address);

            return customers;
        }

        // GET api/Rest/5
        [HttpGet("{Id}")]
        public Customer? GetCustomersById(string Id)
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

        // GET: api/Rest/SearchCustomers
        [HttpGet("SearchCustomers")]
        public IEnumerable<Customer> SearchCustomers(string searchText)
        {
            searchText = searchText.ToLower();

            var customers = _dbContext.Customers.Include(c => c.Address);

            var matchingCustomers = customers
                .Where(c => c.Name.ToLower().Contains(searchText))
                .ToList();

            return matchingCustomers;
        }


        // PUT api/Rest/5
        [HttpPut("{Id}")]
        public IActionResult EditCustomer(string Id, [FromBody] Customer customerObj)
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
