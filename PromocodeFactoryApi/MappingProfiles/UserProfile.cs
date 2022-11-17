using AutoMapper;
using PromocodeFactory.Service.DTO.Identity;
using PromocodeFactory.Api.Commands;
using PromocodeFactory.Service.DTO.Administration;
using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactory.Api.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserRegistrationDTO, RegistrationUserCommand>().ReverseMap();
            CreateMap<UserLoginDTO, LoginUserCommand>().ReverseMap();
            
        }
    }
}
