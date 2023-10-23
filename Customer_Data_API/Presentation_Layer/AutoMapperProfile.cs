using AutoMapper;
using Data_Access_Layer.DTOs;
using Data_Access_Layer.Models;

namespace Presentation_Layer
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, AdminDTO>();
            CreateMap<Customer, UserDTO>();
            CreateMap<Address, AddressDTO>();

            CreateMap<AdminDTO, Customer>();
            CreateMap<AddressDTO, Address>();

        }
    }
}
