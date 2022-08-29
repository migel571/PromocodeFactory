using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.MappingProfiles
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
