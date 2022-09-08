using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Pages
{
    public partial class Preferences
    {
        public List<PreferenceModel> PreferencesList { get; set; } = new List<PreferenceModel>();
        public MetaData MetaData { get; set; } = new MetaData();
        private PagingParameters _preferenceParameters = new PagingParameters();

        [Inject]
        public IPreferenceRepository PreferenceRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetPreferences();
            await base.OnInitializedAsync();

        }

        private async Task GetPreferences()
        {
            var pagingResponse = await PreferenceRepo.GetAllAsync(_preferenceParameters);
            PreferencesList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;

        }
        private async Task SelectedPage(int page)
        {
            _preferenceParameters.PageNumber = page;
            await GetPreferences();
        }
        private async Task DeletePreference(Guid id)
        {
            await PreferenceRepo.DeleteAsync(id);
            _preferenceParameters.PageNumber = 1;
            await GetPreferences();
        }

    }
}
