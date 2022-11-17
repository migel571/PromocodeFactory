using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using PromocodeFactory.UI.Shared;

namespace PromocodeFactory.UI.Pages
{
    public partial class CreatePromocode
    {
        private CreatePromocodeModel _promocode = new CreatePromocodeModel() { BeginDate = DateTime.UtcNow, EndDate = DateTime.UtcNow };
        private PagingParameters _preferenceParameters = new PagingParameters();
        public List<PreferenceModel> PreferencesList { get; set; } 
        private SuccessNotification _notification;
        [Inject]
        public IPromocodeRepository PromocodeRepo { get; set; }
        [Inject]
        public IPreferenceRepository PreferenceRepo { get; set; }


        protected async override Task OnInitializedAsync()
        {
            var preferences = await PreferenceRepo.GetAllAsync(_preferenceParameters);
            PreferencesList = preferences.Items;

        }
        private async Task Create()
        {
            _promocode.BeginDate = _promocode.BeginDate.ToUniversalTime();
            _promocode.EndDate = _promocode.EndDate.ToUniversalTime();
            await PromocodeRepo.CreateAsync(_promocode);
            _notification.Show();
        }
    }
}
