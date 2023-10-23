using Data_Access_Layer.DTOs;

namespace Data_Access_Layer.Contracts
{
    public interface IAdminRepository
    {
        AdminDTO? EditCustomer(string Id, AdminDTO customerObj);
        IEnumerable<UserDTO>? SearchCustomers(string searchText);
        IEnumerable<AdminDTO>? GetAllCustomers();
        AdminDTO? GetCustomersById(string Id);
        IEnumerable<object>? GetCustomersGroupedByZipCode();
    }
}
