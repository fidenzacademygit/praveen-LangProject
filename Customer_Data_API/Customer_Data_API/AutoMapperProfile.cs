using AutoMapper;
using Customer_Data_API.Domain.Dtos.AdminDtos;
using Customer_Data_API.Domain.Dtos.UserDtos;
using Customer_Data_API.Domain.Models;
using UserAddressDto = Customer_Data_API.Domain.Dtos.UserDtos.AddressDto;
using AdminAddressDto = Customer_Data_API.Domain.Dtos.AdminDtos.AddressDto;

namespace Customer_Data_API
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