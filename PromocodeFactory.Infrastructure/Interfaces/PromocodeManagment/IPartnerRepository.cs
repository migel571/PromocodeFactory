﻿using PromocodeFactory.Domain.PromocodeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment
{
    public interface IPartnerRepository
    {
        Task<IEnumerable<Partner>> GetAllAsync();
        Task<Partner> GetAsync(string name);
        Task CreateAsync(Partner partner);
        Task UpdateAsync(Partner partner);
        Task DeleteAsync(Guid partnerId);
        Task<bool> ExistAsync(Expression<Func<Partner, bool>> expression);
    }
}