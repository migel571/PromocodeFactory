using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.AdditionalPages
{
    public partial class PreferenceAdditional
    {
        [Parameter]
        public PreferenceModel Preference { get; set; }
        [Parameter]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public EventCallback<Guid> OnDelete { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }
        public void UpdatePreference(Guid id)
        {
            Navigation.NavigateTo($"updatePreference/{id}");
        }
        private async Task Delete(Guid id)
        {

            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Вы уверены что хотите удалить  предпочтение с названием {Preference.Name}?");
            if (confirmed)
            {
                await OnDelete.InvokeAsync(id);
            }
        }

    }
}
