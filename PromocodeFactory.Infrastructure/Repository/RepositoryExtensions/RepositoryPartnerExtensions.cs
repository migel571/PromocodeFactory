using PromocodeFactory.Domain.PromocodeManagement;

namespace PromocodeFactory.Infrastructure.Repository.RepositoryExtensions
{
    
    public static class RepositoryPartnerExtensions
    {
        public static IQueryable<Partner> Search(this IQueryable<Partner> partners, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return partners;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return partners.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
