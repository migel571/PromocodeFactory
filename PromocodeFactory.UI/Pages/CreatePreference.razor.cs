using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using PromocodeFactory.UI.Shared;

namespace PromocodeFactory.UI.Pages
{
    public partial class CreatePreference
    {
        private CreatePreferenceModel _preference = new CreatePreferenceModel();
        private SuccessNotification _notification;
        [Inject]
        IPreferenceRepository PreferenceRepo { get; set; }

        private async Task Create()
        {
            await PreferenceRepo.CreateAsync(_preference);
            _notification.Show();
        }
    }
}
