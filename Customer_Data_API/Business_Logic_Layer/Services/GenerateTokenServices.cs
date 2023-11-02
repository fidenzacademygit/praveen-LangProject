using Business_Logic_Layer.Contracts;
using Business_Logic_Layer.Exceptions;
using Data_Access_Layer.Models;
using Data_Access_Layer.Utility;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business_Logic_Layer.Services
{
    public class GenerateTokenServices : IGenerateTokenServices
    {
        private readonly IConfiguration _config;

        public GenerateTokenServices(IConfiguration config) 
        {
            _config = config;
        }

        public string GenerateAdminTokenString(LoginUser loginVM)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, loginVM.Email),
                    new Claim(ClaimTypes.Role, StaticDetails.Role_Admin),
                };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

                var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

                var securityToken = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(7),
                    issuer: _config.GetSection("Jwt:Issuer").Value,
                    audience: _config.GetSection("Jwt:Audience").Value,
                    signingCredentials: signingCred);
                string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
                return tokenString;
            }
            catch (Exception ex)
            {
                throw new CustomEditException("An error occurred while generating the token.", ex);
            }   
        }

        public string GenerateCustomerTokenString(LoginUser loginVM)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, loginVM.Email),
                    new Claim(ClaimTypes.Role, StaticDetails.Role_Customer),
                };

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));

                var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

                var securityToken = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(7),
                    issuer: _config.GetSection("Jwt:Issuer").Value,
                    audience: _config.GetSection("Jwt:Audience").Value,
                    signingCredentials: signingCred);
                string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
                return tokenString;

            }
            catch (Exception ex)
            {
                throw new CustomEditException("An error occurred while generating the token.", ex);
            }        
        }
    }
}
