using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Tables
{
    public partial class PromocodeTable
    {
        [Parameter]
        public List<PromocodeModel> Promocodes { get; set; }
        [Parameter]
        public EventCallback<Guid> OnDelete { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }

        public void GetPromocode(Guid id)
        {
            Navigation.NavigateTo($"promocode/{id}");
        }
        public void UpdatePromocode(Guid id)
        {
            Navigation.NavigateTo($"updatePromocode/{id}");
        }
        private async Task Delete(Guid id)
        {
            var promocode = Promocodes.FirstOrDefault(p => p.PromocodeId.Equals(id));

            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Вы уверены что хотите удалить  промокод {promocode.Code}?");
            if (confirmed)
            {
                await OnDelete.InvokeAsync(id);
            }
        }

    }
}
