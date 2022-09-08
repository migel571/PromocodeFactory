using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using PromocodeFactory.UI.Shared;

namespace PromocodeFactory.UI.Pages
{
    public partial class CreatePartner
    {
        private CreatePartnerModel _partner = new CreatePartnerModel();
        private SuccessNotification _notification;
        [Inject]
        public IPartnerRepository PartnerRepo { get; set; }

        private async Task Create()
        {
            await PartnerRepo.CreateAsync(_partner);
            _notification.Show();
        }
    }
}
