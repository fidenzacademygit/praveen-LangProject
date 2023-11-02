using Data_Access_Layer.Models;

namespace Data_Access_Layer.Contracts
{
    public interface IRegisterUserRepository
    {
        IAsyncEnumerable<RegisterUser>? Register(RegisterUser registerVM);
    }
}
