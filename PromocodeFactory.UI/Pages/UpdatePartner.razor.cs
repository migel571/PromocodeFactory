using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using PromocodeFactory.UI.Shared;

namespace PromocodeFactory.UI.Pages
{
    public partial class UpdatePartner
    {
        private PartnerModel _partner;
        private SuccessNotification _notification;
        [Parameter]
        public string PartnerId { get; set; }
        [Inject]
        IPartnerRepository PartnerRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _partner = await PartnerRepo.GetAsync(Guid.Parse(PartnerId));
        }
        private async Task Update()
        {
            await PartnerRepo.UpdateAsync(_partner);
            _notification.Show();
        }
    }
}
