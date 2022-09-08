using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.MappingProfiles
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDTO, Customer>().ReverseMap();
            //    .ForMember(x => x.FirstName, c => c.MapFrom(x => x.FirstName))
            //    .ForMember(x => x.LastName, c => c.MapFrom(x => x.LastName)).ForMember(x => x.Email, c => c.MapFrom(x => x.Email));
            //CreateMap<Customer, CustomerDTO>().ForMember(x=>x.PreferenceIds, c=>c.MapFrom(x=>x.Preferences.Select(v=>v.PreferenceId)))
            //    .ForMember(x => x.PromocodeIds, c => c.MapFrom(x => x.PromoCodes.Select(v => v.PromoCodeId)));
           
            CreateMap<CustomerDTO, CreateCustomerCommand>().ReverseMap();
            CreateMap<CustomerDTO, UpdateCustomerCommand>().ReverseMap();
            CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(PagedListConverter<,>));
        }
    }
}
