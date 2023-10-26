using Business_Logic_Layer.Exceptions;
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
                    return _AdminService.EditCustomer(Id, customerObj);
                }
                else {
                    throw new ArgumentException("Invalid input: Id and customerObj must not be null.");
                }
            }
            catch (Exception ex)
            {
                throw new CustomEditException("An error occurred while editing the customer.", ex);
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
                else {
                    throw new ArgumentException("Invalid input: search text must not be null.");
                }
            }
            catch (Exception ex)
            {
                throw new CustomEditException("An error occurred while searching the customer.", ex);
            }
        }

        //Group By Zipcode
        public IEnumerable<object>? GetCustomersGroupedByZipCode()
        {
            try
            {
                return _AdminService.GetCustomersGroupedByZipCode();
            }
            catch (Exception ex)
            {
                throw new CustomEditException("An error occurred while grouping customers.", ex);
            }
        }

        //Get All Customers
        public IEnumerable<AdminDTO>? GetAllCustomers()
        {
            try
            {
                return _AdminService.GetAllCustomers();
            }
            catch (Exception ex)
            {
                throw new CustomEditException("An error occurred while get all the customers.", ex);
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
                else {
                    throw new ArgumentException("Invalid input: Id must not be null.");
                }
            }
            catch (Exception ex)
            {
                throw new CustomEditException("An error occurred while getting the customer.", ex);
            }
        }
    }
}
