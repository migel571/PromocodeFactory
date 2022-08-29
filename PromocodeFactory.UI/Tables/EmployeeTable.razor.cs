using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Tables
{
    public partial class EmployeeTable
    {
        [Parameter]
        public List<EmployeeModel> Employees { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }

        public void GetEmployee(Guid id)
        {
            Navigation.NavigateTo($"employee/{id}");
        }
    }
}
