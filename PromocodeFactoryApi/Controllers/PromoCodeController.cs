﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactory.Api.Commands;
using PromocodeFactory.Infrastructure.Paging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace PromocodeFactory.Api.Controllers
{
    [Route("api/promocodes")]
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
        [Authorize(Policy = "EmployeeOnly")]
        [HttpGet]
        public async Task<IActionResult> GetAllPromoCodes([FromQuery] PagingParameters promocodeParametres)
        {
            var promocodes = await _manager.GetAllAsync(promocodeParametres);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(promocodes.MetaData));
            return Ok(promocodes);
        }
        [Authorize(Policy = "EmployeeOnly")]
        [HttpGet("{promoCodeId:Guid}")]
        public async Task<IActionResult> GetPromoCode(Guid promoCodeId)
        {
            var promocode = await _manager.GetAsync(promoCodeId);
            return Ok(promocode);
        }
        [Authorize(Policy = "CustomerOnly")]
        [HttpGet("customer/{customerId:Guid}")]
        public async Task<IActionResult> GetPromoCodeByCustomerId(Guid customerId)
        {
            var promocode = await _manager.GetPromocodeByCustomerIdAsync(customerId);
            return Ok(promocode);
        }
        [Authorize(Policy = "PartnerOnly")]
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
        [Authorize(Policy = "EmployeeOnly")]
        [HttpDelete("{promoCodeId:Guid}")]
        public async Task<IActionResult> DeletePromoCode(Guid promoCodeId)
        {
            await _manager.DeleteAsync(promoCodeId);
            return Ok();
        }

    }
}
