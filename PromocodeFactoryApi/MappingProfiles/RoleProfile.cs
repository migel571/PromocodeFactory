using AutoMapper;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Service.DTO.Administration;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class RoleProfile:Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<RoleDTO, CreateRoleCommand>().ReverseMap();
            CreateMap<RoleDTO, UpdateRoleCommand>().ReverseMap();
        }
       
    }
}
