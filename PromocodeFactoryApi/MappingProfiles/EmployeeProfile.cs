using AutoMapper;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Service.DTO.Administration;

namespace PromocodeFactoryApi.MappingProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee,EmployeeDTO>();
        }
    }
}
