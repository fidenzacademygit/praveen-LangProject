using Customer_Data_API.Domain.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Data_API.Domain.Abstractions
{
    public interface IUserService
    {
        Boolean EditCustomer(string Id, EditCustomerDetailsDTO customerObj);
        double? GetDistance(string Id, double latitude, double longitude);
        UserCustomerDetailsDto GetCustomersById(string Id);
    }
}
