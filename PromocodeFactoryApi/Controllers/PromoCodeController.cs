using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactoryApi.Commands;
using PromocodeFactory.Infrastructure.Pagging;

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
        public async Task<IActionResult> GetAllPromoCodes([FromQuery]PaggingParameters promocodeParametres)
        {
            var promocodes = await _manager.GetAllAsync(promocodeParametres);
            return Ok(promocodes);  
        }
        [HttpGet]
        public async Task<IActionResult> GetPromoCode(string code)
        {
            var promocode = await _manager.GetAsync(code);
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
