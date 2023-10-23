using Data_Access_Layer.Contracts;
using Data_Access_Layer.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Business_Logic_Layer.Services
{
    public class AdminServices
    {
        public readonly IAdminRepository _AdminRepository;
        public AdminServices(IAdminRepository AdminRepository) {
            _AdminRepository = AdminRepository;
        }

        //Edit Customer
        public AdminDTO? EditCustomer(string Id, AdminDTO customerObj)
        {
            try
            {
                if (Id != null && customerObj != null)
                {
                    return _AdminRepository.EditCustomer(Id, customerObj);
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
                    return _AdminRepository.SearchCustomers(searchText);
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
                return _AdminRepository.GetCustomersGroupedByZipCode();
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
                return _AdminRepository.GetAllCustomers();
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
                    return _AdminRepository.GetCustomersById(Id);
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
