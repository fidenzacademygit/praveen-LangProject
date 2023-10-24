using AutoMapper;
using Data_Access_Layer.Contracts;
using Data_Access_Layer.Data;
using Data_Access_Layer.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Edit Customer
        public UserDTO? EditCustomer(string Id, UserEditDetailsDTO customerObj)
        {
            try
            {
                var customer = _dbContext.Customers.Include(c => c.Address).FirstOrDefault(c => c.Id == Id);
                if(customer != null)
                {
                    if (customerObj.Name != null || customerObj.Email != null || customerObj.Phone != null)
                    {
                        if (customerObj.Name != null)
                        {
                            customer.Name = customerObj.Name;
                        }
                        if (customerObj.Email != null)
                        {
                            customer.Email = customerObj.Email;
                        }
                        if (customerObj.Phone != null)
                        {
                            customer.Phone = customerObj.Phone;
                        }
                        _dbContext.SaveChanges();
                        return GetCustomersById(Id);
                    }
                    else{return null;}

                }
                else{ return null;}

            }
            catch (Exception){throw;}
        }

        //Get Distance
        public double? GetDistance(string Id, double latitude, double longitude)
        {
            try
            {
                var customer = _dbContext.Customers.Find(Id);
                double earthRadiusKm = 6371;
                if(customer != null)
                {
                    double lat1 = ToRadians(customer.Latitude);
                    double lon1 = ToRadians(customer.Longitude);
                    double lat2 = ToRadians(latitude);
                    double lon2 = ToRadians(longitude);

                    double dLat = lat2 - lat1;
                    double dLon = lon2 - lon1;

                    double a = Math.Sin((double)(dLat / 2)) * Math.Sin((double)(dLat / 2)) +
                               Math.Cos((double)lat1) * Math.Cos((double)lat2) *
                               Math.Sin((double)(dLon / 2)) * Math.Sin((double)(dLon / 2));

                    double c = 2 * Math.Atan2(Math.Sqrt((double)a), Math.Sqrt((double)(1 - a)));

                    double distance = earthRadiusKm * c;

                    return distance;
                }
                else { return null; }
            }
            catch (Exception) { throw; }  
        }
        private static double ToRadians(double degrees)
        {
            return (degrees * (Math.PI / 180));
        }

        //Get Customer By Id
        public UserDTO? GetCustomersById(string Id)
        {
            try
            {
                var customer = _dbContext.Customers
                .Include(c => c.Address)
                .Select(c => _mapper.Map<UserDTO>(c)).ToList()
                .FirstOrDefault(c => c.Id == Id);
                if(customer != null)
                {
                    return customer;
                }
                else { return null; }
            }
            catch (Exception) { throw; }               
        }
    }
}
