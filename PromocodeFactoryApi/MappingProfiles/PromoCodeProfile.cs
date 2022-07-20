using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class PromoCodeProfile:Profile
    {
        public PromoCodeProfile()
        {
            CreateMap<PromoCode, PromoCodeDTO>().ReverseMap();
            CreateMap<PromoCodeDTO, CreatePromoCodeCommand>().ReverseMap();
            CreateMap<PromoCodeDTO, UpdatePromoCodeCommand>().ReverseMap();

        }
    }
}
