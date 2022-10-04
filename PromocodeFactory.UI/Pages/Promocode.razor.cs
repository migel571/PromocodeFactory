using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Pages
{
    public partial class Promocode
    {
        [Parameter]
        public string Id { get; set; }
        
      
        [Inject]
        IPromocodeRepository PromocodeRepo { get; set; }
        [Inject]
        IPreferenceRepository PreferenceRepo { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }

        public PromocodeModel PromocodeMod { get; set; }
        public string PreferenceName { get; set; }
        
        protected async override Task OnInitializedAsync()
        {

            await GetPromocodeAsync();
            var preference = await PreferenceRepo.GetAsync(PromocodeMod.PreferenceId);
            PreferenceName = preference.Name;
            await base.OnInitializedAsync();
        }
        private async Task GetPromocodeAsync()
        {
            PromocodeMod = await PromocodeRepo.GetAsync(Guid.Parse(Id));
        }
        private async Task DeletePromocode(Guid id)
        {
            await PromocodeRepo.DeleteAsync(id);
            Navigation.NavigateTo("/getPromocode");
        }
    }
}
