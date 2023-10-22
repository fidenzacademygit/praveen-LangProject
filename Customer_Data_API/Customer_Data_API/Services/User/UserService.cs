using AutoMapper;
using Customer_Data_API.Data;
using Customer_Data_API.Domain.Abstractions;
using Customer_Data_API.Domain.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer_Data_API.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Edit Customer
        public Boolean EditCustomer(string Id, [FromBody] EditCustomerDetailsDTO customerObj)
        {
            var customer = _dbContext.Customers.Include(c => c.Address).FirstOrDefault(c => c.Id == Id);
            if (customer != null)
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
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            _dbContext.SaveChanges();
            return true;
        }

        //Get Distance
        public double? GetDistance(string Id, double latitude, double longitude)
        {
            var customer = _dbContext.Customers.Find(Id);

            double? earthRadiusKm = 6371;

            double? lat1 = ToRadians(customer.Latitude);
            double? lon1 = ToRadians(customer.Longitude);
            double? lat2 = ToRadians(latitude);
            double? lon2 = ToRadians(longitude);

            double? dLat = lat2 - lat1;
            double? dLon = lon2 - lon1;

            double? a = Math.Sin((double)(dLat / 2)) * Math.Sin((double)(dLat / 2)) +
                       Math.Cos((double)lat1) * Math.Cos((double)lat2) *
                       Math.Sin((double)(dLon / 2)) * Math.Sin((double)(dLon / 2));

            double? c = 2 * Math.Atan2(Math.Sqrt((double)a), Math.Sqrt((double)(1 - a)));

            double? distance = earthRadiusKm * c;

            return distance;
        }
        private static double? ToRadians(double? degrees)
        {
            return (degrees * (Math.PI / 180));
        }

        //Get Customer By Id
        public UserCustomerDetailsDto GetCustomersById(string Id)
        {
            var customer = _dbContext.Customers
                .Include(c => c.Address)
                .Select(c => _mapper.Map<UserCustomerDetailsDto>(c)).ToList()
                .FirstOrDefault(c => c.Id == Id);
            return customer;
        }
    }
}
