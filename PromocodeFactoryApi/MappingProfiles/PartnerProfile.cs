using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Pagging;
using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class PartnerProfile:Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDTO>().ReverseMap();
            CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(PagedListConverter<,>));
        }
    }
}
