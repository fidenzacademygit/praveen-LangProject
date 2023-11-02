using Data_Access_Layer.Models;

namespace Business_Logic_Layer.Contracts
{
    public interface IGenerateTokenServices
    {
        string GenerateAdminTokenString(LoginUser loginVM);
        string GenerateCustomerTokenString(LoginUser loginVM);
    }
}
