using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PromocodeFactory.Infrastructure.Pagging;
using PromocodeFactory.Service.DTO.PromocodeManagment;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactoryApi.Commands;

namespace PromocodeFactoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartnerController : ControllerBase
    {
        private readonly IPartnerManager _manager;
        private readonly IMapper _mapper;
        public PartnerController(IPartnerManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;

        }
        [HttpGet("GetPartner")]
        public async Task<IActionResult> GetPartner(string name)
        {
            var partner = await _manager.GetAsync(name);
            return Ok(partner);
        }
        [HttpGet("GetAllPartners")]
        public async Task<IActionResult> GetAllPartners([FromQuery] PaggingParameters partnerParametres)
        {
            var partners = await _manager.GetAllAsync(partnerParametres);
            var metadata = new
            {
                partners.TotalCount,
                partners.PageSize,
                partners.CurrentPage,
                partners.TotalPages,
                partners.HasNext,
                partners.HasPrevious

            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(partners);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePartner([FromBody] CreatePartnerCommand partnerBody)
        {
            var partner = _mapper.Map<PartnerDTO>(partnerBody);
            await _manager.CreateAsync(partner);
            return Ok(partner);
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePartner([FromBody] UpdatePartnerCommand partnerBody)
        {
            var partner = _mapper.Map<PartnerDTO>(partnerBody);
            await _manager.UpdateAsync(partner);
            return Ok(partner);
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePartner(Guid partnerId)
        {
            await _manager.DeleteAsync(partnerId);
            return Ok();
        }

    }
}
