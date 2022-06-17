using AutoMapper;
using PromocodeFactory.Domain.Administaration;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;
using PromocodeFactory.Service.DTO.Administration;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class RoleManager : IRoleManager
    {
        private IRepositoryRole _repository;
        private IMapper _mapper;
        public RoleManager(IRepositoryRole repository, IMapper mapper)
        {
            _repository = repository;
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
        public async Task<bool> CreateAsync(RoleDTO roleDTO)
        {
            if (!await _repository.ExistAsync(filter => filter.RoleName == roleDTO.RoleName))
                return false;

            await _repository.CreateAsync(_mapper.Map<Role>(roleDTO));
            return true;
        }
        public async Task UpdateAsync(RoleDTO role)
        {
            if (!await _repository.ExistAsync(filter => filter.RoleName == role.RoleName))
                return;

            await _repository.UpdateAsync(_mapper.Map<Role>(role));
        }
        public async Task DeleteAsync(Guid roleId)
        {
            if (await _repository.ExistAsync(filter => filter.RoleId == roleId))
                return;
            await _repository.DeleteAsync(roleId);

        }


    }
}
