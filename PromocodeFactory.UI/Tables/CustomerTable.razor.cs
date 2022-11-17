using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Tables
{
    public partial class CustomerTable
    {
        [Parameter]
        public List<CustomerModel> Customers { get; set; }
        [Parameter]
        public EventCallback<Guid> OnDelete { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }

        public void GetCustomer(Guid id)
        {
            Navigation.NavigateTo($"customer/{id}");
        }
        public void UpdateCustomer(Guid id)
        {
            Navigation.NavigateTo($"updateCustomer/{id}");
        }
        private async Task Delete(Guid id)
        {
            var customer = Customers.FirstOrDefault(p => p.CustomerId.Equals(id));

            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Вы уверены что хотите удалить клиента с фамилией {customer.LastName}?");
            if (confirmed)
            {
                await OnDelete.InvokeAsync(id);
            }
        }

    }
}
