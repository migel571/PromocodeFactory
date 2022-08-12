using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Infrastructure.Pagging;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class PartnerManager: IPartnerManager
    {
        private IPartnerRepository _repository;
        private IMapper _mapper;
        public PartnerManager(IPartnerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PagedList<PartnerDTO>> GetAllAsync(PaggingParameters partnerParametres)
        {
            var partner = await _repository.GetAllAsync(partnerParametres);
            return _mapper.Map<PagedList<PartnerDTO>>(partner);
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
