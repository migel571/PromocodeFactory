using PromocodeFactory.Domain.PromocodeManagement;

namespace PromocodeFactory.Infrastructure.Repository.RepositoryExtensions
{

    public static class RepositoryCustomerExtensions
    {
        public static IQueryable<Customer> Search(this IQueryable<Customer> customers, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return customers;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return customers.Where(p => p.LastName.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
