using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class PartnerPromoCodeLimitManager : IPartnerPromoCodeLimitManager
    {
        private IRepositoryPartnerPromoCodeLimit _repository;
        private IMapper _mapper;
        public PartnerPromoCodeLimitManager(IRepositoryPartnerPromoCodeLimit repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PartnerPromoCodeLimitDTO>> GetAllAsync()
        {
            var limit = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PartnerPromoCodeLimitDTO>>(limit);
        }

        public async Task<PartnerPromoCodeLimitDTO> GetAsync(Guid limitId)
        {
            var limit = await _repository.GetAsync(limitId);
            return _mapper.Map<PartnerPromoCodeLimitDTO>(limit);
        }
        public async Task CreateAsync(PartnerPromoCodeLimitDTO limitDTO)
        {
            if (!await _repository.ExistAsync(t => t.PartnerPromoCodeLimitId == limitDTO.PartnerPromoCodeLimitId))
                return;
            var limit = _mapper.Map<PartnerPromoCodeLimit>(limitDTO);
          await _repository.CreateAsync(limit);
        }
        public async Task UpdateAsync(PartnerPromoCodeLimitDTO limitDTO)
        {
            if (!await _repository.ExistAsync(t => t.PartnerPromoCodeLimitId == limitDTO.PartnerPromoCodeLimitId))
                return;
            var limit = _mapper.Map<PartnerPromoCodeLimit>(limitDTO);
            _repository.UpdetaAsync(limit);
        }
        public async Task DeleteAsync(Guid limitId)
        {
            if (!await _repository.ExistAsync(t => t.PartnerPromoCodeLimitId == limitId))
                return;
            await _repository.DeleteAsync(limitId);
            
        }



       
    }
}
