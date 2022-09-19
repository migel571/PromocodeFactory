using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.AdditionalPages
{
    public partial class PartnerAdditional
    {
        [Parameter]
        public PartnerModel Partner { get; set; }
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public EventCallback<Guid> OnDelete { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }
        public void UpdatePartner(Guid id)
        {
            Navigation.NavigateTo($"updatePartner/{id}");
        }
        private async Task Delete(Guid id)
        {

            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Вы уверены что хотите удалить  партнера с именем {Partner.Name}?");
            if (confirmed)
            {
                await OnDelete.InvokeAsync(id);
            }
        }

    }
}
