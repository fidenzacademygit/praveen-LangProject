using Business_Logic_Layer.Contracts;
using Data_Access_Layer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IRegisterUserService _registerUserService;
        private readonly IAddRoleService _addRoleService;

        public AccountController(
            IRegisterUserService registerUser,
            IAddRoleService addRoleService
            )
        {
            _registerUserService = registerUser;
            _addRoleService = addRoleService;
        }
 
        //Add Role
        [HttpPost("AddRole")]
        public IActionResult AddRole()
        {
            if (_addRoleService.AddRole())
            {
                return Ok("User Successfully Registered.");
            }
            else
            {
                return NotFound("User Not Available!");
            }
        }

        //Register Endpoint
        [HttpPost("Register")]
        public IActionResult Register(RegisterUser registerVM)
        {
            if (registerVM != null)
            {
                return Ok(_registerUserService.Register(registerVM));
            }
            else
            {               
                return NotFound("User Not Available!");
            }
        }
    }
}
