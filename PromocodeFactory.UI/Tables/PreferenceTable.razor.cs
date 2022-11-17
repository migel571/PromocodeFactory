using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Tables
{
    public partial class PreferenceTable
    {
        [Parameter]
        public List<PreferenceModel> Preferences { get; set; }
        [Parameter]
        public EventCallback<Guid> OnDelete { get; set; }

        [Inject]
        NavigationManager Navigation { get; set; }
        [Inject]
        public IJSRuntime Js { get; set; }

        public void GetPreference(Guid id)
        {
            Navigation.NavigateTo($"preference/{id}");
        }
        public void UpdatePreference(Guid id)
        {
            Navigation.NavigateTo($"updatePreference/{id}");
        }
        private async Task Delete(Guid id)
        {
            var preference = Preferences.FirstOrDefault(p => p.PreferenceId.Equals(id));

            var confirmed = await Js.InvokeAsync<bool>("confirm", $"Вы уверены что хотите удалить  предпочтение с именем {preference.Name}?");
            if (confirmed)
            {
                await OnDelete.InvokeAsync(id);
            }
        }

    }
}
