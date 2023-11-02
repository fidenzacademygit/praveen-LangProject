using Data_Access_Layer.DTOs;

namespace Business_Logic_Layer.Contracts
{
    public interface IAdminServices
    {
        AdminDTO? EditCustomer(string Id, AdminDTO customerObj);
        IEnumerable<UserDTO>? SearchCustomers(string searchText);
        IEnumerable<object>? GetCustomersGroupedByZipCode();
        IEnumerable<AdminDTO>? GetAllCustomers();
        AdminDTO? GetCustomersById(string Id);
    }
}
