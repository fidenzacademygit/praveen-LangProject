using Asp.Versioning;
using Business_Logic_Layer.Contracts;
using Business_Logic_Layer.Services;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize(Roles = StaticDetails.Role_Admin)]
    public class AdminController(IAdminServices service) : ControllerBase
    {
        private readonly IAdminServices _service = service;

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
