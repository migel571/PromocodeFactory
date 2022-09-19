using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Exceptions;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactory.Infrastructure.Paging;

namespace PromocodeFactory.Service.Manager
{
    public class PromoCodeManager : IPromoCodeManager
    {
        private IPromoCodeRepository _repository;
        private IPreferenceRepository _repositoryPreference;
        private IMapper _mapper;
        private ILoggerManager _logger;
        public PromoCodeManager(IPromoCodeRepository repository, IPreferenceRepository repositoryPreference, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _repositoryPreference = repositoryPreference;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PagedList<PromoCodeDTO>> GetAllAsync(PagingParameters promocodeParametres)
        {
            var promocode = await _repository.GetAllAsync(promocodeParametres);
            return _mapper.Map<PagedList<PromoCodeDTO>>(promocode);
        }

        public async Task<PromoCodeDTO> GetAsync(Guid promoCodeId)
        {
            return _mapper.Map<PromoCodeDTO>(await _repository.GetAsync(promoCodeId));
        }

        public async Task CreateAsync(PromoCodeDTO promocode, Guid preferenceId)
        {
            var promocodeNew = _mapper.Map<PromoCode>(promocode);
            if (await _repository.ExistAsync(p => p.Code == promocode.Code))
            {
                _logger.LogInfo($"Promocode already exist.");
                throw new PromoCodeException($"Promocode already exist.");
            }
            var preference = await _repositoryPreference.FindPreferenceAsync(preferenceId);
            if (preference == null)
            {
                _logger.LogInfo($"Preferences does not exist.");
                throw new PromoCodeException($"Preferences does not exist.");
            }
            promocodeNew.Preference = preference;
            await _repository.CreateAsync(promocodeNew);
        }
        public async Task UpdateAsync(PromoCodeDTO promocode)
        {

            if (await _repository.ExistAsync(filter => filter.Code == promocode.Code))
                return;

            await _repository.UpdateAsync(_mapper.Map<PromoCode>(promocode));
        }
        public async Task DeleteAsync(Guid promocodeId)
        {
            var promoCode = await _repository.FindPromoCodeAsync(promocodeId);
            if (promoCode == null)
            {
                _logger.LogInfo($"Promocode does not exist.");
                throw new PromoCodeException($"Promocode does not exist.");
            }
            await _repository.DeleteAsync(promoCode);
        }

        public async Task<List<PromoCodeDTO>> GetPromocodeByCustomerIdAsync(Guid customerId)
        {
           var promocode = await _repository.GetPromocodeByCustomerIdAsync(customerId);
           return _mapper.Map<List<PromoCodeDTO>>(promocode);
        }
    }
}
