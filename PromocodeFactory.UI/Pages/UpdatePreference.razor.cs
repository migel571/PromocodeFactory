using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using PromocodeFactory.UI.Shared;

namespace PromocodeFactory.UI.Pages
{
    public partial class UpdatePreference
    {
        private PreferenceModel _preference;
        private SuccessNotification _notification;
        [Parameter]
        public string PreferenceId { get; set; }
        [Inject]
        IPreferenceRepository PreferenceRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _preference = await PreferenceRepo.GetAsync(Guid.Parse(PreferenceId));
        }
        private async Task Update()
        {
            await PreferenceRepo.UpdateAsync(_preference);
            _notification.Show();
        }
    }
}
