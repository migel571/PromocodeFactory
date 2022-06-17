using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class PromoCodeProfile:Profile
    {
        public PromoCodeProfile()
        {
            CreateMap<PromoCode, PromoCodeDTO>();  
        }
    }
}
