using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Pages
{
    public partial class Customer
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        ICustomerRepository CustomerRepo { get; set; }
        [Inject]
        IPreferenceRepository PreferenceRepo { get; set; }
        [Inject]
        IPromocodeRepository PromocodeRepo { get; set; }
        [Parameter]
        public NavigationManager Navigation { get; set; }

        public CustomerModel CustomerMod { get; set; }
        public List<PromocodeModel> PromocodeMod { get; set; }
        public List<PreferenceModel> PreferenceMod { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await GetCustomerAsync();
            await GetPreferenceAsync();
            await GetPromocodeAsync();
            await base.OnInitializedAsync();
        }
        private async Task GetCustomerAsync()
        {
            CustomerMod = await CustomerRepo.GetAsync(Guid.Parse(Id));
        }
        private async Task GetPromocodeAsync()
        {
            PromocodeMod = await PromocodeRepo.GetPromocodeByCustomerIdAsync(Guid.Parse(Id));
        }
        private async Task GetPreferenceAsync()
        {
            PreferenceMod = await PreferenceRepo.GetPreferenceByCustomerIdAsync(Guid.Parse(Id));
        }
        private async Task DeleteCustomer(Guid id)
        {
            await CustomerRepo.DeleteAsync(id);
            Navigation.NavigateTo("/getCustomer");
        }
    }
}
