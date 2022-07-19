using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class PreferenceProfile:Profile
    {
        public PreferenceProfile()
        {
            CreateMap<Preference, PreferenceDTO>().ReverseMap();
            CreateMap<PreferenceDTO, CreatePreferenceCommand>().ReverseMap();
            CreateMap<PreferenceDTO, UpdatePreferenceCommand>().ReverseMap();
        }
    }
}
