using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.AdditionalPages
{
    public partial class CustomerAdditional
    {
        [Parameter]
        public CustomerModel Customer { get; set; }
        [Parameter]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public EventCallback<Guid> OnDelete { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }
        public void UpdateCustomer(Guid id)
        {
            Navigation.NavigateTo($"updateCustomer/{id}");
        }
        private async Task Delete(Guid id)
        {

            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Вы уверены что хотите удалить  клиента с фамилией {Customer.LastName}?");
            if (confirmed)
            {
                await OnDelete.InvokeAsync(id);
            }
        }

    }
}
