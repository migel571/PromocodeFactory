using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Tables
{
    public partial class PartnerTable
    {
        [Parameter]
        public List<PartnerModel> Partners { get; set; }
        [Parameter]
        public EventCallback<Guid> OnDelete { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }

        public void GetPartner(Guid id)
        {
            Navigation.NavigateTo($"partner/{id}");
        }
        public void UpdatePartner(Guid id)
        {
            Navigation.NavigateTo($"updatePartner/{id}");
        }
        private async Task Delete(Guid id)
        {
            var partner = Partners.FirstOrDefault(p => p.PartnerId.Equals(id));

            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Вы уверены что хотите удалить  партнера с именем {partner.Name}?");
            if (confirmed)
            {
                await OnDelete.InvokeAsync(id);
            }
        }

    }
}
