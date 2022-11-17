using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.MappingProfiles
{
    public class PromoCodeProfile : Profile
    {
        public PromoCodeProfile()
        {
            CreateMap<PromoCodeDTO, PromoCode>().ForMember(c => c.Preference, opt => opt.MapFrom(o => new Preference { PreferenceId = o.PreferenceId})).ReverseMap();
            CreateMap<CreatePromoCodeCommand, PromoCodeDTO>().ReverseMap();
            CreateMap<UpdatePromoCodeCommand, PromoCodeDTO>().ReverseMap();
            CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(PagedListConverter<,>));

        }
    }
}
