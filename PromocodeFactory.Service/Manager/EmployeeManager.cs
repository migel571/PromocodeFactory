﻿using AutoMapper;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;
using PromocodeFactory.Service.DTO.Administration;
using PromocodeFactory.Service.Exceptions;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        private IRepositoryEmployee _repository;
        private readonly ILoggerManager _logger;
        private IMapper _mapper;

        public EmployeeManager(IRepositoryEmployee repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EmployeeDTO>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task<IEnumerable<EmployeeDTO>> GetAsync(string lastName)
        {
            return _mapper.Map<IEnumerable<EmployeeDTO>>(await _repository.GetAsync(lastName));
        }

        public async Task CreateAsync(EmployeeDTO employee)
        {
            if (await _repository.ExistAsync(filter => filter.Email == employee.Email && filter.LastName == employee.LastName))
            {
                _logger.LogInfo($"Employee with name={employee.Email} and LastName={employee.LastName} already exist.");
                throw new EmployeeAlreadyExistException($"Employee with name={employee.Email} and LastName={employee.LastName} already exist.");
            }
            await _repository.CreateAsync(_mapper.Map<Employee>(employee));

        }
        public async Task UpdateAsync(EmployeeDTO employee)
        {
            if (await _repository.ExistAsync(filter => filter.Email == employee.Email && filter.LastName == employee.LastName))
            {
                _logger.LogInfo($"Employee with name={employee.Email} and LastName={employee.LastName} already exist.");
                throw new EmployeeAlreadyExistException($"Employee with name={employee.Email} and LastName={employee.LastName} already exist.");
            }
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
