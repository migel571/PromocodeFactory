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
        private IPartnerRepository _repositoryPartner;
        private IMapper _mapper;
        private ILoggerManager _logger;
        public PromoCodeManager(IPromoCodeRepository repository, IPreferenceRepository repositoryPreference, IPartnerRepository repositoryPartner, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _repositoryPreference = repositoryPreference;
            _repositoryPartner = repositoryPartner;
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
           
            if (promocode.BeginDate > promocode.EndDate)
            {
                _logger.LogInfo($"Date is not correct.");
                throw new PromoCodeException($"Date is not correct.");
            }
            var promocodeNew = _mapper.Map<PromoCode>(promocode);
            if (await _repository.ExistAsync(p => p.Code == promocode.Code))
            {
                _logger.LogInfo($"Promocode already exist.");
                throw new PromoCodeException($"Promocode already exist.");
            }
            if (!await _repositoryPartner.ExistAsync(x => x.Name.ToLower() == promocode.PartnerName.ToLower()) && await _repositoryPartner.ExistAsync(x => x.IsActive == false))
            {
                _logger.LogInfo($"PartnerName is not correct or not active.");
                throw new PromoCodeException($"PartnerName is not correct or not active.");
            }
            if (!await _repositoryPartner.ExistAsync(x => x.NumberIssuedPromoCode > 0))
            {
                _logger.LogInfo($"Partner {promocode.PartnerName} have not nubmerPromocode.");
                throw new PromoCodeException($"Partner {promocode.PartnerName} have not nubmerPromocode.");
            }
            var preference = await _repositoryPreference.FindPreferenceAsync(preferenceId);
            if (preference == null)
            {
                _logger.LogInfo($"Preferences does not exist.");
                throw new PromoCodeException($"Preferences does not exist.");
            }
            promocodeNew.Preference = preference;
            await _repositoryPartner.UpdateNubmberPromoCodeAsync(promocode.PartnerName);
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
