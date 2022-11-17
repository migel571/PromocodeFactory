using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Api.Commands;
using PromocodeFactory.Infrastructure.Paging;

namespace PromocodeFactory.Api.MappingProfiles
{
    public class PreferenceProfile:Profile
    {
        public PreferenceProfile()
        {
            CreateMap<Preference, PreferenceDTO>().ReverseMap();
            CreateMap<PreferenceDTO, CreatePreferenceCommand>().ReverseMap();
            CreateMap<PreferenceDTO, UpdatePreferenceCommand>().ReverseMap();
            CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(PagedListConverter<,>));
        }
    }
}
