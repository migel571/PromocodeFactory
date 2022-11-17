using PromocodeFactory.Domain.PromocodeManagement;
namespace PromocodeFactory.Infrastructure.Repository.RepositoryExtensions
{
   
    public static class RepositoryPromoCodeExtensions
    {
        public static IQueryable<PromoCode> Search(this IQueryable<PromoCode> promoCodes, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return promoCodes;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return promoCodes.Where(p => p.Code.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
