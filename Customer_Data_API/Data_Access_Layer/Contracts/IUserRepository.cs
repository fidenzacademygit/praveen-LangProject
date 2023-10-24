using Data_Access_Layer.DTOs;

namespace Data_Access_Layer.Contracts
{
    public interface IUserRepository
    {
        UserDTO? EditCustomer(string Id, UserEditDetailsDTO customerObj);
        double? GetDistance(string Id, double latitude, double longitude);
        UserDTO? GetCustomersById(string Id);
    }
}
