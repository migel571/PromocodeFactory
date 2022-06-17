using AutoMapper;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;
using PromocodeFactory.Service.DTO.Administration;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class EmployeeManager:IEmployeeManager
    {
        private IRepositoryEmployee _repository;
        private IMapper _mapper;
        public EmployeeManager(IRepositoryEmployee repository, IMapper mapper)
        {
            _repository = repository;   
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAsync(string lastName)
        {
          return  _mapper.Map<IEnumerable<EmployeeDTO>>(await  _repository.GetAsync(lastName));
        }

        public async Task CreateAsync(EmployeeDTO employee)
        { 
           await _repository.CreateAsync(_mapper.Map<Employee>(employee));
        }
        public async Task UpdateAsync(EmployeeDTO employee)
        {
            if (await _repository.ExistAsync(filter => filter.LastName == employee.LastName))
                return;

            await _repository.UpdateAsync(_mapper.Map<Employee>(employee));
        }
        public async Task DeleteAsync(Guid employeeId)
        {
            if (await _repository.ExistAsync(filter => filter.EmployeeId == employeeId))
                return;
            await _repository.DeleteAsync(employeeId);
        }

        

       
    }
}
