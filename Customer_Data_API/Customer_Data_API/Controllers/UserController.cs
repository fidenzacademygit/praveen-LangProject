using AutoMapper;
using Customer_Data_API.Data;
using Customer_Data_API.Domain.Abstractions;
using Customer_Data_API.Domain.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Customer_Data_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController(IUserService service)
        {
            _service = service;
        }
        private readonly IUserService _service;

        //A. Edit Customer
        // PUT api/User/5aa252be01865d3202ddcbac
        [HttpPut("{Id}")]
        public IActionResult EditCustomer(string Id, [FromBody] EditCustomerDetailsDTO customerObj)
        {
            if (_service.EditCustomer(Id, customerObj)){return Ok("Success");}
            else{return Ok("Unsuccess");}
        }

        //B. Get Distance
        // Get api/User/GetDistance/5aa252be01865d3202ddcbac
        [HttpGet("GetDistance/{Id}")]
        public IActionResult GetDistance(string Id, double latitude, double longitude)
        {
            return Ok(_service.GetDistance(Id, latitude, longitude));
        }

        // GET api/User/5
        [HttpGet("GetCustomerById/{Id}")]
        public UserCustomerDetailsDto? GetCustomersById(string Id)
        {             
            return _service.GetCustomersById(Id);
        }
        
    }
}
