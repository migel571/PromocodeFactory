using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Pagging;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class PartnerProfile:Profile
    {
        public PartnerProfile()
        {
            CreateMap<PartnerDTO,Partner >().ReverseMap();
            CreateMap<CreatePartnerCommand, PartnerDTO>().ReverseMap();
            CreateMap<UpdatePartnerCommand, PartnerDTO>().ReverseMap();
            CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(PagedListConverter<,>));
        }
    }
}
