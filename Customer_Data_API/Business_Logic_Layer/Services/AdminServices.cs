using Data_Access_Layer.Contracts;
using Data_Access_Layer.DTOs;

namespace Business_Logic_Layer.Services
{
    public class AdminServices
    {
        public readonly IAdminRepository _AdminService;
        public AdminServices(IAdminRepository AdminService) {
            _AdminService = AdminService;
        }

        //Edit Customer
        public AdminDTO? EditCustomer(string Id, AdminDTO customerObj)
        {
            try
            {
                if (Id != null && customerObj != null)
                {
                    Console.Write("Customer ID and object correctly got from the client!");
                    Console.WriteLine(Id);
                    Console.WriteLine(customerObj.Company);
                    return _AdminService.EditCustomer(Id, customerObj);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Search Customer
        public IEnumerable<UserDTO>? SearchCustomers(string searchText)
        {
            try
            {
                if (searchText != null)
                {
                    return _AdminService.SearchCustomers(searchText);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Group By Zipcode
        public IEnumerable<object>? GetCustomersGroupedByZipCode()
        {
            try
            {
                return _AdminService.GetCustomersGroupedByZipCode();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get All Customers
        public IEnumerable<AdminDTO>? GetAllCustomers()
        {
            try
            {
                return _AdminService.GetAllCustomers();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Get customer by Id
        public AdminDTO? GetCustomersById(string Id)
        {
            try
            {
                if (Id != null)
                {
                    return _AdminService.GetCustomersById(Id);
                }
                else { return null; }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
