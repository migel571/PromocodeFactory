using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Pages
{
    public partial class Partner
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        IPartnerRepository PartnerRepo { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public PartnerModel PartnerMod { get; set; } 
        protected async override Task OnInitializedAsync()
        {
            await GetPartnerAsync();
            await base.OnInitializedAsync();
        }
        private async Task GetPartnerAsync()
        {
            PartnerMod = await PartnerRepo.GetAsync(Guid.Parse(Id));
        }
        private async Task DeletePartner(Guid id)
        {
            await PartnerRepo.DeleteAsync(id);
            Navigation.NavigateTo("/getPartner");
        }
    }
}
