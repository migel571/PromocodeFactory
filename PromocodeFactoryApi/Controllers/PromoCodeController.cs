using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoCodeController : ControllerBase
    {
        private readonly IPromoCodeManager _manager;
        private readonly IMapper _mapper;
        public PromoCodeController(IPromoCodeManager manager, IMapper mapper)
        {
            _manager = manager; 
            _mapper = mapper;   
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPromoCodes()
        {
            var promocodes = _mapper.Map<PromoCodeDTO>(await _manager.GetAllAsync());
            return Ok(promocodes);  
        }
        [HttpGet]
        public async Task<IActionResult> GetPromoCode(Guid promoCodeId)
        {
            var promocode = _mapper.Map<PromoCodeDTO>(await _manager.GetAsync(promoCodeId));
            return Ok(promocode);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePromoCode([FromBody] CreatePromoCodeCommand promoCodeBody)
        {
            var promocode = _mapper.Map<PromoCodeDTO>(promoCodeBody);   
            await _manager.CreateAsync(promocode);
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePromoCode([FromBody] CreatePromoCodeCommand promoCodeBody)
        {
            var promocode = _mapper.Map<PromoCodeDTO>(promoCodeBody);
            await _manager.UpdateAsync(promocode);
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePromoCode(Guid promoCodeId)
        {
            _manager.DeleteAsync(promoCodeId);
            return NoContent();
        }

    }
}
