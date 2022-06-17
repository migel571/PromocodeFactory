using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class PartnerManager: IPartnerManager
    {
        private IRepositoryPartner _repository;
        private IMapper _mapper;
        public PartnerManager(IRepositoryPartner repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PartnerDTO>> GetAllAsync()
        {
            var partner = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PartnerDTO>>(partner);
        }

        public async Task<PartnerDTO> GetAsync(string name)
        {
            return _mapper.Map<PartnerDTO>(await _repository.GetAsync(name));
        }

        public async Task CreateAsync(PartnerDTO partner)
        {
            await _repository.CreateAsync(_mapper.Map<Partner>(partner));
        }
        public async Task UpdateAsync(PartnerDTO partner)
        {
            if (await _repository.ExistAsync(filter => filter.Name == partner.Name))
                return;

            await _repository.UpdateAsync(_mapper.Map<Partner>(partner));
        }
        public async Task DeleteAsync(Guid partnerId)
        {
            if (await _repository.ExistAsync(filter => filter.PartnerId == partnerId))
                return;
            await _repository.DeleteAsync(partnerId);
        }
    }
}
