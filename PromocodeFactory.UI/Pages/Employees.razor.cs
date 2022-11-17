using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Pages
{
    public partial class Employees
    {
        public List<EmployeeModel> EmployeesList { get; set; } = new List<EmployeeModel>();
        public MetaData MetaData { get; set; } = new MetaData();
        private PagingParameters _employeeParameters = new PagingParameters();  

        [Inject]
        public IEmployeeRepository EmployeeRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetEmployees();
            await base.OnInitializedAsync();

        }

        private async Task GetEmployees()
        {
            
            var pagingResponse = await EmployeeRepo.GetAllAsync(_employeeParameters);
            EmployeesList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;
            
        }
        private async Task SelectedPage(int page)
        {
            _employeeParameters.PageNumber = page;
            await GetEmployees();
        }
        private async Task DeleteEmployee(Guid id)
        {
            await EmployeeRepo.DeleteAsync(id);
            _employeeParameters.PageNumber = 1;
            await GetEmployees();
        }
        private async Task SearchChanged(string searchTerm)
        {

            _employeeParameters.PageNumber = 1;
            _employeeParameters.SearchTerm = searchTerm;
            await GetEmployees();
        }

    }
}
