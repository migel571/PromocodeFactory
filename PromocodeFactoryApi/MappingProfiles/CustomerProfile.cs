using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<CustomerDTO, CreateCustomerCommand>().ReverseMap();
        }
    }
}
