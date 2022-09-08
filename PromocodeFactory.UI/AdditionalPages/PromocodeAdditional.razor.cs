using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.AdditionalPages
{
    public partial class PromocodeAdditional
    {
        [Parameter]
        public PromocodeModel Promocode { get; set; }
        [Parameter]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public EventCallback<Guid> OnDelete { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }
        public void UpdatePromocode(Guid id)
        {
            Navigation.NavigateTo($"updatePromocode/{id}");
        }
        private async Task Delete(Guid id)
        {

            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Вы уверены что хотите удалить  промокод {Promocode.Code}?");
            if (confirmed)
            {
                await OnDelete.InvokeAsync(id);
            }
        }

    }
}
