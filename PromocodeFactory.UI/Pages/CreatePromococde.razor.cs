using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using PromocodeFactory.UI.Shared;

namespace PromocodeFactory.UI.Pages
{
    public partial class CreatePromocode
    {
        private CreatePromocodeModel _promocode = new CreatePromocodeModel();
        private SuccessNotification _notification;
        [Inject]
        public IPromocodeRepository PromocodeRepo { get; set; }

        private async Task Create()
        {
            await PromocodeRepo.CreateAsync(_promocode);
            _notification.Show();
        }
    }
}
