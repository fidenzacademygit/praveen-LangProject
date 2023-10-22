using Customer_Data_API.Domain.Dtos.AdminDtos;
using Customer_Data_API.Domain.Dtos.UserDtos;

namespace Customer_Data_API.Domain.Abstractions
{
    public interface IAdminService
    {
        Boolean EditCustomer(string Id, AdminCustomerDetailsDto customerObj);
        IEnumerable<UserCustomerDetailsDto> SearchCustomers(string searchText);
        IEnumerable<AdminCustomerDetailsDto> GetAllCustomers();
        AdminCustomerDetailsDto GetCustomersById(string Id);
        IEnumerable<object> GetCustomersGroupedByZipCode();
    }
}
