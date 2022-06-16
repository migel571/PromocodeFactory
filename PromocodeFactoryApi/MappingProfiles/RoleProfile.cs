using AutoMapper;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Service.DTO.Administration;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>();
        }
       
    }
}
