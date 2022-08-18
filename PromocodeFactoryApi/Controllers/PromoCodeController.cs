using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactoryApi.Commands;
using PromocodeFactory.Infrastructure.Pagging;
using Newtonsoft.Json;

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
        [HttpGet("GetAllPromocodes")]
        public async Task<IActionResult> GetAllPromoCodes([FromQuery]PaggingParameters promocodeParametres)
        {
            var promocodes = await _manager.GetAllAsync(promocodeParametres);
            var metadata = new
            {
                promocodes.TotalCount,
                promocodes.PageSize,
                promocodes.CurrentPage,
                promocodes.TotalPages,
                promocodes.HasNext,
                promocodes.HasPrevious

            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(promocodes);  
        }
        [HttpGet("GetPromocode")]
        public async Task<IActionResult> GetPromoCode(string code)
        {
            var promocode = await _manager.GetAsync(code);
            return Ok(promocode);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePromoCode([FromBody] CreatePromoCodeCommand promoCodeBody)
        {
            var promocode = _mapper.Map<PromoCodeDTO>(promoCodeBody);   
            await _manager.CreateAsync(promocode, promocode.PreferenceId);
            return Ok(promocode);
        }
        //[HttpPut]
        //public async Task<IActionResult> UpdatePromoCode([FromBody] CreatePromoCodeCommand promoCodeBody)
        //{
        //    var promocode = _mapper.Map<PromoCodeDTO>(promoCodeBody);
        //    await _manager.UpdateAsync(promocode);
        //    return Ok(promocode);
        //}
        [HttpDelete]
        public async Task<IActionResult> DeletePromoCode(Guid promoCodeId)
        {
            _manager.DeleteAsync(promoCodeId);
            return Ok();
        }

    }
}
