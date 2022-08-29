using AutoMapper;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.Administration;
using PromocodeFactory.Api.Commands;

namespace PromocodeFactory.Api.MappingProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee,EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeDTO, CreateEmployeeCommand>().ReverseMap();
            CreateMap<EmployeeDTO, UpdateEmployeeCommand>().ReverseMap();
            CreateMap(typeof(PagedList<>), typeof(PagedList<>)).ConvertUsing(typeof(PagedListConverter<,>));
        }
    }
}
