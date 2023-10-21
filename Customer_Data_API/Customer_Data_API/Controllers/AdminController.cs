using AutoMapper;
using Customer_Data_API.Data;
using Customer_Data_API.Models.Dtos.AdminDtos;
using Customer_Data_API.Models.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer_Data_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private ApplicationDbContext _dbContext;

        public AdminController(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        private readonly IMapper _mapper;


        //A. Edit Customer
        // PUT api/Admin/5
        [HttpPut("{Id}")]
        public IActionResult EditCustomer(string Id, [FromBody] AdminCustomerDetailsDto customerObj)
        {
            var customer = _dbContext.Customers.Include(c => c.Address).FirstOrDefault(c => c.Id == Id);
            if (customer != null)
            {
                _mapper.Map(customerObj, customer);
            }
            else
            {
                return NotFound("User Not Available!");
            }

            _dbContext.SaveChanges();
            return Ok("Success");
        }


        //C. Search Customer
        // GET: api/Admin/SearchCustomers
        [HttpGet("SearchCustomers")]
        public IEnumerable<UserCustomerDetailsDto> SearchCustomers(string searchText)
        {
            searchText = searchText.ToLower();

            var customers = _dbContext.Customers.Include(c => c.Address);

            IEnumerable<UserCustomerDetailsDto> matchingCustomers = Enumerable.Empty<UserCustomerDetailsDto>();

            matchingCustomers = customers
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
                .Select(c => _mapper.Map<UserCustomerDetailsDto>(c))
                .ToList();
            return matchingCustomers;
        }

        //D. Get customer list grouped by Zip code
        // GET api/Admin/CustomersGroupByZipcode
        [HttpGet("CustomersGroupByZipcode")]
        public IActionResult GetCustomersGroupedByZipCode()
        {
            var customers = _dbContext.Customers.Include(c => c.Address);
            var groupedCustomers = customers
                .GroupBy(c => c.Address.Zipcode)
                .Select(group => new
                {
                    ZipCode = group.Key,
                    Customers = group.Select(c => _mapper.Map<UserCustomerDetailsDto>(c)).ToList()
                });

            return Ok(groupedCustomers);
        }


        // GET: api/Admin/GetAllCustomers
        [HttpGet("GetAllCustomers")]

        public IEnumerable<AdminCustomerDetailsDto> GetAllCustomers()
        {
            var customers = _dbContext.Customers.Include(c => c.Address);
            var customersDetails = customers.Select(c => _mapper.Map<AdminCustomerDetailsDto>(c));

            return customersDetails;
        }

        // GET api/Admin/GetCustomerById/5aa252be01865d3202ddcbac
        [HttpGet("GetCustomerById/{Id}")]
        public AdminCustomerDetailsDto? GetCustomersById(string Id)
        {
            var customer = _dbContext.Customers
                .Include(c => c.Address)
                .Select(c => _mapper.Map<AdminCustomerDetailsDto>(c)).ToList()
                .FirstOrDefault(c => c.Id == Id);
            return customer;
        }
    }
}
