using Data_Access_Layer.Contracts;
using Data_Access_Layer.Models;
using Data_Access_Layer.Utility;
using Microsoft.AspNetCore.Identity;

namespace Data_Access_Layer.Repositories
{
    public class RegisterUserRepository : IRegisterUserRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        

        public RegisterUserRepository(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager) 
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        public async IAsyncEnumerable<RegisterUser>? Register(RegisterUser registerVM)
        {
            ApplicationUser user = new()
            {
                Name = registerVM.Name,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
                NormalizedEmail = registerVM.Email.ToUpper(),
                EmailConfirmed = true,
                UserName = registerVM.Email,
                CreatedAt = DateTime.Now
            };

            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(registerVM.Role))
                {
                    await _userManager.AddToRoleAsync(user, registerVM.Role);
                    yield return registerVM;
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, StaticDetails.Role_Customer);
                }
            }
            yield return null;
        }
    }
}
