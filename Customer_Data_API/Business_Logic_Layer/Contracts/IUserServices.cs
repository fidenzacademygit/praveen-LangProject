using Data_Access_Layer.DTOs;

namespace Business_Logic_Layer.Contracts
{
    public interface IUserServices
    {
        UserDTO? EditCustomer(string Id, UserEditDetailsDTO customerObj);
        double? GetDistance(string Id, double latitude, double longitude);
        UserDTO? GetCustomersById(string Id);
    }
}
