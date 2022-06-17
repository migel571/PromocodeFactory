﻿using Microsoft.EntityFrameworkCore;
using PromocodeFactory.Domain.PromocodeManagement;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using System.Linq.Expressions;

namespace PromocodeFactory.Infrastructure.Repository.PromocodeManagment
{
    public class PromoCodeRepository : IRepositoryPromoCode
    {
        private readonly PromocodeContext _context;
        private readonly DbSet<PromoCode> _dbSet;
        public PromoCodeRepository(PromocodeContext context)
        {
            _context = context;
            _dbSet = context.Set<PromoCode>();
        }
        public async Task<IEnumerable<PromoCode>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<PromoCode> GetAsync(string code)
        {
            return await _dbSet.FirstOrDefaultAsync(t=>t.Code == code);
        }

        public async Task CreateAsync(PromoCode promoCode)
        {
            await _dbSet.AddAsync(promoCode);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(PromoCode promoCode)
        {
            _dbSet.Update(promoCode);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid promoCodeId)
        {
            var promoCode = await _dbSet.FindAsync(promoCodeId);
            if (promoCode == null) return;
            _dbSet.Remove(promoCode);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistAsync(Expression<Func<PromoCode, bool>> expression)
        {
            return await _dbSet.AnyAsync(expression);
        }

    }
}
