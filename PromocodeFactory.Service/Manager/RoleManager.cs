using AutoMapper;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;
using PromocodeFactory.Service.DTO.Administration;
using PromocodeFactory.Service.Exceptions;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class RoleManager : IRoleManager
    {
        private IRepositoryRole _repository;
        private readonly ILoggerManager _logger;
        private IMapper _mapper;

        public RoleManager(IRepositoryRole repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<IEnumerable<RoleDTO>> GetAllAsync()
        {

            var role = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<RoleDTO>>(role);
        }

        public async Task<RoleDTO> GetAsync(string roleName)
        {
            var role = await _repository.GetAsync(roleName);
            return _mapper.Map<RoleDTO>(role);
        }
        public async Task CreateAsync(RoleDTO role)
        {
            if (await _repository.ExistAsync(filter => filter.RoleName == role.RoleName))
            {
                _logger.LogInfo($"Role with name={role.RoleName} already exist.");
                throw new RoleAlreadyExistException($"Role with name={role.RoleName} already exist.");
            }
            await _repository.CreateAsync(_mapper.Map<Role>(role));

        }
        public async Task UpdateAsync(RoleDTO role)
        {
            if (await _repository.ExistAsync(filter => filter.RoleName == role.RoleName))
            {
                _logger.LogInfo($"Role with name={role.RoleName} already exist.");
                throw new RoleAlreadyExistException($"Role with name={role.RoleName} already exist.");
            }
            await _repository.UpdateAsync(_mapper.Map<Role>(role));
        }
        public async Task DeleteAsync(Guid roleId)
        {
            await _repository.DeleteAsync(roleId);

        }


    }
}
