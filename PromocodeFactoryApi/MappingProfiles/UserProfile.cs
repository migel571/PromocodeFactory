using AutoMapper;
using PromocodeFactory.Service.DTO.Identity;
using PromocodeFactory.Api.Commands;

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
