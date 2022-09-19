using PromocodeFactory.Domain.Administaration;

namespace PromocodeFactory.Infrastructure.Repository.RepositoryExtensions
{
    
    public static class RepositoryEmployeeExtensions
    {
        public static IQueryable<Employee> Search(this IQueryable<Employee> employees, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return employees;
            var lowerCaseSearchTerm = searchTerm.Trim().ToLower();
            return employees.Where(p => p.LastName.ToLower().Contains(lowerCaseSearchTerm));
        }
    }
}
