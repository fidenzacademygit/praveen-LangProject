using Customer_Data_API.Domain.Abstractions;
using Customer_Data_API.Domain.Dtos.AdminDtos;
using Customer_Data_API.Domain.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Data_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public AdminController(IAdminService service)
        {
            _service = service;
        }
        private readonly IAdminService _service;


        //A. Edit Customer
        // PUT api/Admin/5
        [HttpPut("{Id}")]
        public IActionResult EditCustomer(string Id, [FromBody] AdminCustomerDetailsDto customerObj)
        {

            if (_service.EditCustomer(Id, customerObj))
            {
                return Ok("Success");
            }
            else
            {
                return NotFound("User Not Available!");
            }
            
        }


        //C. Search Customer
        // GET: api/Admin/SearchCustomers
        [HttpGet("SearchCustomers")]
        public IEnumerable<UserCustomerDetailsDto> SearchCustomers(string searchText)
        {
            return _service.SearchCustomers(searchText);
        }

        //D. Get customer list grouped by Zip code
        // GET api/Admin/CustomersGroupByZipcode
        [HttpGet("CustomersGroupByZipcode")]
        public IActionResult GetCustomersGroupedByZipCode()
        {
            return Ok(_service.GetCustomersGroupedByZipCode());
        }


        // GET: api/Admin/GetAllCustomers
        [HttpGet("GetAllCustomers")]

        public IEnumerable<AdminCustomerDetailsDto> GetAllCustomers()
        {
            return _service.GetAllCustomers();
        }

        // GET api/Admin/GetCustomerById/5aa252be01865d3202ddcbac
        [HttpGet("GetCustomerById/{Id}")]
        public AdminCustomerDetailsDto? GetCustomersById(string Id)
        {
            return _service.GetCustomersById(Id);
        }
    }
}
