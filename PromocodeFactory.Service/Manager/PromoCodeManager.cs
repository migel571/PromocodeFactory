using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class PromoCodeManager: IPromoCodeManager
    {
        private IRepositoryPromoCode _repository;
        private IMapper _mapper;
        public PromoCodeManager(IRepositoryPromoCode repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PromoCodeDTO>> GetAllAsync()
        {
            var promocode = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PromoCodeDTO>>(promocode);
        }

        public async Task<PromoCodeDTO> GetAsync(string code)
        {
            return _mapper.Map<PromoCodeDTO>(await _repository.GetAsync(code));
        }

        public async Task CreateAsync(PromoCodeDTO promocode)
        {
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
            if (await _repository.ExistAsync(filter => filter.PromoCodeId == promocodeId))
                return;
            await _repository.DeleteAsync(promocodeId);
        }
    }
}
