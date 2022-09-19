using PromocodeFactory.Domain.PromocodeManagement;
namespace PromocodeFactory.Infrastructure.Repository.RepositoryExtensions
{
   
    public static class RepositoryPreferenceExtensions
    {
        public static IQueryable<Preference> Search(this IQueryable<Preference> preferences, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return preferences;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return preferences.Where(p => p.Name.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
