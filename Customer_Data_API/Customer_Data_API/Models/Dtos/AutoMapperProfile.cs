using AutoMapper;
using Customer_Data_API.Models.Dtos.AdminDtos;
using Customer_Data_API.Models.Dtos.UserDtos;
using UserAddressDto = Customer_Data_API.Models.Dtos.UserDtos.AddressDto;
using AdminAddressDto = Customer_Data_API.Models.Dtos.AdminDtos.AddressDto;
using Customer_Data_API.Domain.Models;

namespace Customer_Data_API.Models.Dtos
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, AdminCustomerDetailsDto>();
            CreateMap<Customer, UserCustomerDetailsDto>();
            CreateMap<Address, AdminAddressDto>();
            CreateMap<Address, UserAddressDto>();

            CreateMap<AdminCustomerDetailsDto, Customer>();
            CreateMap<AdminAddressDto, Address>();

        }
    }
}
