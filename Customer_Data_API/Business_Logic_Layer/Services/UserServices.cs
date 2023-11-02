using Business_Logic_Layer.Contracts;
using Business_Logic_Layer.Exceptions;
using Data_Access_Layer.Contracts;
using Data_Access_Layer.DTOs;

namespace Business_Logic_Layer.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _UserRepository;
        public UserServices(IUserRepository UserRepository) { 
            _UserRepository = UserRepository;
        }

        //Edit Customer
        public UserDTO? EditCustomer(string Id, UserEditDetailsDTO customerObj)
        {
            try
            {
                if (Id != null && customerObj != null)
                {
                    return _UserRepository.EditCustomer(Id, customerObj);
                }
                else {
                    throw new ArgumentException("Invalid input: Id and User details must not be null.");
                }
            }
            catch (Exception ex) {
                throw new CustomEditException("An error occurred while editing the customer.", ex);
            }
        }

        //Get Distance
        public double? GetDistance(string Id, double latitude, double longitude)
        {
            try
            {
                if (Id != null)
                {
                    return _UserRepository.GetDistance(Id, latitude, longitude);
                }
                else {
                    throw new ArgumentException("Invalid input: Id must not be null.");
                }
            }
            catch (Exception ex)
            {
                throw new CustomEditException("An error occurred while calculating the distance.", ex);
            }
        }

        //Get Customer By Id
        public UserDTO? GetCustomersById(string Id)
        {
            try
            {
                if (Id != null)
                {
                    return _UserRepository.GetCustomersById(Id);
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
