using Asp.Versioning;
using Business_Logic_Layer.Contracts;
using Data_Access_Layer.Models;
using Data_Access_Layer.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserLoginController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IGenerateTokenServices _generateTokenServices;
        private readonly UserManager<ApplicationUser> _userManager;


        public UserLoginController(

            SignInManager<ApplicationUser> signInManager,
            IGenerateTokenServices generateTokenServices,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _generateTokenServices = generateTokenServices;
            _userManager = userManager;
        }

        //Login Endpoint
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser loginVM)
        {
            var result = await _signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password, loginVM.RememberMe, lockoutOnFailure: false);
            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (result.Succeeded && user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains(StaticDetails.Role_Admin))
                {
                    var AccessToken = _generateTokenServices.GenerateAdminTokenString(loginVM);
                    if (!string.IsNullOrEmpty(AccessToken))
                    {
                        return Ok(new { token = AccessToken });
                    }
                    else
                    {
                        return NotFound("Token generation failed");
                    }
                }
                else if (roles.Contains(StaticDetails.Role_Customer))
                {
                    var AccessToken = _generateTokenServices.GenerateCustomerTokenString(loginVM);
                    if (!string.IsNullOrEmpty(AccessToken))
                    {
                        return Ok(new { token = AccessToken });
                    }
                    else
                    {
                        return NotFound("Token generation failed");
                    }
                }
                else
                {
                    return BadRequest("User has no assigned role.");
                }
            }
            else
            {
                return NotFound("UnsuccessFull Login");
            }
        }
    }
}
