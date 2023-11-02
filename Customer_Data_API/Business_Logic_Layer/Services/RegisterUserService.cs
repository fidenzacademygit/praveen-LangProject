using Business_Logic_Layer.Contracts;
using Business_Logic_Layer.Exceptions;
using Data_Access_Layer.Contracts;
using Data_Access_Layer.Models;

namespace Business_Logic_Layer.Services
{
    public class RegisterUserService : IRegisterUserService
    {
        public readonly IRegisterUserRepository _RegisterUser;
        public RegisterUserService(IRegisterUserRepository RegisterUser)
        {
            _RegisterUser = RegisterUser;
        }

        public IAsyncEnumerable<RegisterUser>? Register(RegisterUser registerVM)
        {
            try
            {
                if(registerVM != null)
                {
                    return (_RegisterUser.Register(registerVM));
                }
                else
                {
                    throw new ArgumentException("Invalid input: Registration details must not be null.");
                }
            }
            catch (Exception ex)
            {
                throw new CustomEditException("An error occurred while registering the user.", ex);
            }          
        }
    }
}
