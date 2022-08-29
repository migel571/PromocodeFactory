using AutoMapper;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Infrastructure.Paging;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Exceptions;
using PromocodeFactory.Service.Interfaces;

namespace PromocodeFactory.Service.Manager
{
    public class PartnerManager: IPartnerManager
    {
        private IPartnerRepository _repository;
        private IMapper _mapper;
        private ILoggerManager _logger;
        public PartnerManager(IPartnerRepository repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<PagedList<PartnerDTO>> GetAllAsync(PagingParameters partnerParametres)
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
            
            if (await _repository.ExistAsync(filter => filter.Name == partner.Name))
            {
                _logger.LogInfo($"Partner with already exist.");
                throw new PartnerException($"Partner already exist.");
            }
            await _repository.CreateAsync(_mapper.Map<Partner>(partner));
        }
        public async Task UpdateAsync(PartnerDTO partner)
        {
            
            if (!await _repository.ExistAsync(f=>f.PartnerId == partner.PartnerId))
            {
                _logger.LogInfo($"Partner does not exist.");
                throw new PartnerException($"Partner does not exist.");
            }
           await _repository.UpdateAsync(_mapper.Map<Partner>(partner));
        }
        public async Task DeleteAsync(Guid partnerId)
        {
            if (!await _repository.ExistAsync(f => f.PartnerId == partnerId))
            {
                _logger.LogInfo($"Partner does not exist.");
                throw new PartnerException($"Partner does not exist.");
            }
            await _repository.DeleteAsync(partnerId);
        }
    }
}
