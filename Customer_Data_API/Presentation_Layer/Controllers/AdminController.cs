using Business_Logic_Layer.Services;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = StaticDetails.Role_Admin)]
    public class AdminController(AdminServices service) : ControllerBase
    {
        private readonly AdminServices _service = service;

        [HttpPut("{Id}")]
        public IActionResult EditCustomer(string Id, [FromBody] AdminDTO customerObj)
        {
            var result = _service.EditCustomer(Id, customerObj);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("User Not Available!");
            }

        }

        [HttpGet("SearchCustomers")]
        public IEnumerable<UserDTO>? SearchCustomers(string searchText)
        {
            return _service.SearchCustomers(searchText);
        }

        [HttpGet("CustomersGroupByZipcode")]
        public IActionResult GetCustomersGroupedByZipCode()
        {
            return Ok(_service.GetCustomersGroupedByZipCode());
        }

        [HttpGet("GetAllCustomers")]

        public IEnumerable<AdminDTO>? GetAllCustomers()
        {
            return _service.GetAllCustomers();
        }

        [HttpGet("GetCustomerById/{Id}")]
        public AdminDTO? GetCustomersById(string Id)
        {
            return _service.GetCustomersById(Id);
        }
    }
}
