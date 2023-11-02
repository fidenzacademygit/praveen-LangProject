using Business_Logic_Layer.Contracts;
using Business_Logic_Layer.Exceptions;
using Data_Access_Layer.Utility;
using Microsoft.AspNetCore.Identity;

namespace Business_Logic_Layer.Services
{
    public class AddRoleService : IAddRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AddRoleService(RoleManager<IdentityRole> roleManager )
        {
            _roleManager = roleManager;
        }

        public Boolean AddRole()
        {
            try
            {
                if (!_roleManager.RoleExistsAsync(StaticDetails.Role_Admin).GetAwaiter().GetResult())
                {
                    _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Admin)).Wait();
                    _roleManager.CreateAsync(new IdentityRole(StaticDetails.Role_Customer)).Wait();

                    return true;
                }
                else
                {
                    return false;
                    throw new ArgumentException("Invalid input.");
                }
            }
            catch (Exception ex)
            {
                throw new CustomEditException("An error occurred while adding the role.", ex);
            }     
        }
    }
}
