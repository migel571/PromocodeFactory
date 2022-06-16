using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Service.DTO.PromocodeManagment;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class PartnerProfile:Profile
    {
        public PartnerProfile()
        {
            CreateMap<Partner, PartnerDTO>();
        }
    }
}
