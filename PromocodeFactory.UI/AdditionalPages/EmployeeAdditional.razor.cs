using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.AdditionalPages
{
    public partial class EmployeeAdditional
    {
        [Parameter]
        public EmployeeModel Employee { get; set; }
        [Parameter]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public EventCallback<Guid> OnDelete { get; set; }
        [Inject] 
        public IJSRuntime Js { get; set; }
        public void UpdateEmployee(Guid id)
        {
            Navigation.NavigateTo($"updateEmployee/{id}");
        }
        private async Task Delete(Guid id)
        {
            
            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Вы уверены что хотите удалить  сотрудника с именем {Employee.LastName}?");
            if (confirmed)
            {
                await OnDelete.InvokeAsync(id);
            }
        }

    }
}
