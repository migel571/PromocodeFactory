using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class PartnerPromoCodeLimitProfile:Profile
    {
        public PartnerPromoCodeLimitProfile()
        {
            CreateMap<PartnerPromoCodeLimit, PartnerPromoCodeLimitDTO>();
        }

    }
}
