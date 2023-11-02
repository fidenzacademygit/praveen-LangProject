using Data_Access_Layer.Models;

namespace Business_Logic_Layer.Contracts
{
    public interface IRegisterUserService
    {
        IAsyncEnumerable<RegisterUser>? Register(RegisterUser registerVM);
    }
}
