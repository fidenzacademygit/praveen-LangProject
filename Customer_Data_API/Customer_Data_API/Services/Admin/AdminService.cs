using AutoMapper;
using Customer_Data_API.Data;
using Customer_Data_API.Domain.Abstractions;
using Customer_Data_API.Domain.Dtos.AdminDtos;
using Customer_Data_API.Domain.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customer_Data_API.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public AdminService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //Edit Customer
        public Boolean EditCustomer(string Id, [FromBody] AdminCustomerDetailsDto customerObj)
        {
            var customer = _dbContext.Customers.Include(c => c.Address).FirstOrDefault(c => c.Id == Id);
            if (customer != null)
            {
                _mapper.Map(customerObj, customer);
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //Search Customer
        public IEnumerable<UserCustomerDetailsDto> SearchCustomers(string searchText)
        {
            searchText = searchText.ToLower();

            var customers = _dbContext.Customers.Include(c => c.Address);

            IEnumerable<UserCustomerDetailsDto> matchingCustomers = Enumerable.Empty<UserCustomerDetailsDto>();

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
                .Select(c => _mapper.Map<UserCustomerDetailsDto>(c))
                .ToList();
            return matchingCustomers;
        }

        //Group By Zipcode
        public IEnumerable<object> GetCustomersGroupedByZipCode()
        {
            var customers = _dbContext.Customers.Include(c => c.Address);
            var groupedCustomers = customers
                .GroupBy(c => c.Address.Zipcode)
                .Select(group => new
                {
                    ZipCode = group.Key,
                    Customers = group.Select(c => _mapper.Map<UserCustomerDetailsDto>(c)).ToList()
                });

            return groupedCustomers;
        }

        //Get All Customers
        public IEnumerable<AdminCustomerDetailsDto> GetAllCustomers()
        {
            var customers = _dbContext.Customers.Include(c => c.Address);
            var customersDetails = customers.Select(c => _mapper.Map<AdminCustomerDetailsDto>(c));

            return customersDetails;
        }

        //Get customer by Id
        public AdminCustomerDetailsDto GetCustomersById(string Id)
        {
            var customer = _dbContext.Customers
                .Include(c => c.Address)
                .Select(c => _mapper.Map<AdminCustomerDetailsDto>(c)).ToList()
                .FirstOrDefault(c => c.Id == Id);
            return customer;
        }


    }
}
