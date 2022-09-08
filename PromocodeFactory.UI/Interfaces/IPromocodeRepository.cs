﻿using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Interfaces
{
    public interface IPromocodeRepository
    {
        Task<PagingResponse<PromocodeModel>> GetAllAsync(PagingParameters promocodeParameters);
        Task<PromocodeModel> GetAsync(Guid promocodeId);
        Task CreateAsync(CreatePromocodeModel promocode);
        Task DeleteAsync(Guid promocodeId);
    }
}
