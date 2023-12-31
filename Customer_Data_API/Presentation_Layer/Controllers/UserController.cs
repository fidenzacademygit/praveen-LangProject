﻿using Asp.Versioning;
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
    [Authorize(Roles = StaticDetails.Role_Customer)]
    public class UserController(UserServices service) : ControllerBase
    {
        private readonly IUserServices _service = service;

        [HttpPut("{Id}")]
        public IActionResult EditCustomer(string Id, [FromBody] UserEditDetailsDTO customerObj)
        {
            var result = _service.EditCustomer(Id, customerObj);
            if (result != null ) 
            { 
                return Ok(result); 
            }
            else 
            { 
                return NotFound("Unsuccess"); 
            }
        }

        [HttpGet("GetDistance/{Id}")]
        public IActionResult GetDistance(string Id, double latitude, double longitude)
        {
            var result = _service.GetDistance(Id, latitude, longitude);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Unsuccess");
            }
        }

        [HttpGet("GetCustomerById/{Id}")]
        public IActionResult GetCustomersById(string Id)
        {
            var result = _service.GetCustomersById(Id);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("Unsuccess");
            }
        }

    }
}
