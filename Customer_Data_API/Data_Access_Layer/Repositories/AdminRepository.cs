using AutoMapper;
using Data_Access_Layer.Contracts;
using Data_Access_Layer.Data;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Models;
using Microsoft.EntityFrameworkCore;

namespace Data_Access_Layer.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AdminRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Edit Customer
        public AdminDTO? EditCustomer(string Id, AdminDTO customerObj)
        {
            try
            {
                var customer = _dbContext.Customers.Include(c => c.Address).FirstOrDefault(c => c.Id == Id);
                if (customer != null)
                {
                    _mapper.Map(customerObj, customer);
                    _dbContext.SaveChanges();
                    return GetCustomersById(Id);
                }
                else {
                    return null; 
                }
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
                searchText = searchText.ToLower();
                var customers = _dbContext.Customers.Include(c => c.Address);
                IEnumerable<UserDTO> matchingCustomers = Enumerable.Empty<UserDTO>();

                if (customers != null)
                {
                    matchingCustomers = customers
                        .Where(c =>
                            c.EyeColor.ToLower().Contains(searchText) ||
                            c.Name.ToLower().Contains(searchText) ||
                            c.Gender.ToLower().Contains(searchText) ||
                            c.Company.ToLower().Contains(searchText) ||
                            c.Email.ToLower().Contains(searchText) ||
                            c.Phone.ToLower().Contains(searchText) ||
                            c.Address.State.ToLower().Contains(searchText) ||
                            c.Address.Street.ToLower().Contains(searchText) ||
                            c.About.ToLower().Contains(searchText) ||
                            c.Address.City.ToLower().Contains(searchText)
                        )
                        .Select(c => _mapper.Map<UserDTO>(c))
                        .ToList();
                    return matchingCustomers;
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
                var customers = _dbContext.Customers.Include(c => c.Address);
                if (customers != null)
                {
                    var groupedCustomers = customers
                        .GroupBy(c => c.Address.Zipcode)
                        .Select(group => new
                        {
                            ZipCode = group.Key,
                            Customers = group.Select(c => _mapper.Map<UserDTO>(c)).ToList()
                        });
                    return groupedCustomers;
                }
                else { return null; }
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
                var customers = _dbContext.Customers.Include(c => c.Address);
                if (customers != null)
                {
                    var customersDetails = customers.Select(c => _mapper.Map<AdminDTO>(c));
                    return customersDetails;
                }
                else { return null; }
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
                var customer = _dbContext.Customers
                    .Include(c => c.Address)
                    .Select(c => _mapper.Map<AdminDTO>(c)).ToList()
                    .FirstOrDefault(c => c.Id == Id);
                if (customer != null)
                {
                    return customer;
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
