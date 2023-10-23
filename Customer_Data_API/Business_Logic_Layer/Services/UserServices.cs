using Data_Access_Layer.Contracts;
using Data_Access_Layer.DTOs;

namespace Business_Logic_Layer.Services
{
    public class UserServices
    {
        private readonly IUserRepository _UserRepository;
        public UserServices(IUserRepository UserRepository) { 
            _UserRepository = UserRepository;
        }

        //Edit Customer
        public UserEditDetailsDTO? EditCustomer(string Id, UserEditDetailsDTO customerObj)
        {
            try
            {
                if (Id != null && customerObj != null)
                {
                    return _UserRepository.EditCustomer(Id, customerObj);
                }
                else { return null; }
            }
            catch (Exception) { 
                throw; 
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
                else { return null; }
            }
            catch (Exception) { 
                throw; 
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
                else { return null; }
            }
            catch (Exception) { 
                throw; 
            }
        }
    }
}
