using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Tables
{
    public partial class EmployeeTable
    {
        [Parameter]
        public List<EmployeeModel> Employees { get; set; }
        [Parameter]
        public EventCallback<Guid> OnDelete { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }

        public void GetEmployee(Guid id)
        {
            Navigation.NavigateTo($"employee/{id}");
        }
        public void UpdateEmployee(Guid id)
        {
            Navigation.NavigateTo($"updateEmployee/{id}");
        }
        private async Task Delete(Guid id)
        {
            var employee = Employees.FirstOrDefault(p => p.EmployeeId.Equals(id));

            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Вы уверены что хотите удалить  сотрудника с именем {employee.LastName}?");
            if (confirmed)
            {
                await OnDelete.InvokeAsync(id);
            }
        }

    }
}
