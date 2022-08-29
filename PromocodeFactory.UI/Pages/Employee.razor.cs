using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Pages
{
    public partial class Employee
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        IEmployeeRepository employeeRepo { get; set; }

        EmployeeModel employee = new EmployeeModel();
        protected async override Task OnInitializedAsync()
        {
            await GetEmployeeAsync();
            await base.OnInitializedAsync();
        }
        private async Task GetEmployeeAsync()
        {
            employee = await employeeRepo.GetAsync(Guid.Parse(Id));
        }
    }
}
