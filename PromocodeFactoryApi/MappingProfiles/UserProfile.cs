using AutoMapper;
using PromocodeFactory.Service.DTO.Identity;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.MappingProfiles
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
