using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Pages
{
    public partial class Preference
    {
        [Parameter]
        public string Id { get; set; }
        [Inject]
        IPreferenceRepository PreferenceRepo { get; set; }
        [Parameter]
        public NavigationManager Navigation { get; set; }

        public PreferenceModel PreferenceMod { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await GetPreferenceAsync();
            await base.OnInitializedAsync();
        }
        private async Task GetPreferenceAsync()
        {
            PreferenceMod = await PreferenceRepo.GetAsync(Guid.Parse(Id));
        }
        private async Task DeletePreference(Guid id)
        {
            await PreferenceRepo.DeleteAsync(id);
            Navigation.NavigateTo("/getEmployee");
        }
    }
}
