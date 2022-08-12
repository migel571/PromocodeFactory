using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Exceptions;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactory.Infrastructure.Pagging;

namespace PromocodeFactory.Service.Manager
{
    public class PromoCodeManager: IPromoCodeManager
    {
        private IPromoCodeRepository _repository;
        private IMapper _mapper;
        private ILoggerManager _logger;
        public PromoCodeManager(IPromoCodeRepository repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PagedList<PromoCodeDTO>> GetAllAsync(PaggingParameters promocodeParametres)
        {
            var promocode = await _repository.GetAllAsync(promocodeParametres);
            return _mapper.Map<PagedList<PromoCodeDTO>>(promocode);
        }

        public async Task<PromoCodeDTO> GetAsync(string code)
        {
            return _mapper.Map<PromoCodeDTO>(await _repository.GetAsync(code));
        }

        public async Task CreateAsync(PromoCodeDTO promocode)
        {
            
            if (await _repository.ExistAsync(p=>p.Code == promocode.Code))
            {
                _logger.LogInfo($"Promocode already exist.");
                throw new PromoCodeException($"Promocode already exist.");
            }
            await _repository.CreateAsync(_mapper.Map<PromoCode>(promocode));
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
    }
}
