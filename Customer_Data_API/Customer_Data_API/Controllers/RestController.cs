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

            var customers = _dbContext.Customers;

            var matchingCustomers = customers
                .Where(c =>
                c.EyeColor.ToLower().Contains(searchText) ||
                c.Name.ToLower().Contains(searchText) ||
                c.Gender.ToLower().Contains(searchText) ||
                c.Company.ToLower().Contains(searchText) ||
                c.Email.ToLower().Contains(searchText) ||
                c.Phone.ToLower().Contains(searchText) ||
                c.Address.State.ToLower().Contains(searchText) ||
                c.Address.Street.ToLower().Contains(searchText) ||
                c.About.ToLower().Contains(searchText) ||
                c.Address.City.ToLower().Contains(searchText)
                )
                .Include(c => c.Address)
                .ToList();

            return matchingCustomers;
        }

        [HttpGet("GetDistance/{Id}")]
        public IActionResult GetDistance( string Id, double latitude, double longitude)
        {
            var customer = _dbContext.Customers.Find(Id);

            if (customer == null)
            {
                return NotFound("Customer not found");
            }

            double? earthRadiusKm = 6371;

            double? lat1 = ToRadians(customer.Latitude);
            double? lon1 = ToRadians(customer.Longitude);
            double? lat2 = ToRadians(latitude);
            double? lon2 = ToRadians(longitude);

            double? dLat = lat2 - lat1;
            double? dLon = lon2 - lon1;

            double? a = Math.Sin((double)(dLat / 2)) * Math.Sin((double)(dLat / 2)) +
                       Math.Cos((double)lat1) * Math.Cos((double)lat2) *
                       Math.Sin((double)(dLon / 2)) * Math.Sin((double)(dLon / 2));

            double? c = 2 * Math.Atan2(Math.Sqrt((double)a), Math.Sqrt((double)(1 - a)));

            double? distance = earthRadiusKm * c;

            return Ok(distance);
        }
        private static double? ToRadians(double? degrees)
        {
            return (degrees * (Math.PI / 180));
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
