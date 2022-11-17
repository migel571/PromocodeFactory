using Microsoft.AspNetCore.Components;

namespace PromocodeFactory.UI.Pages
{
    public partial class GetPreference
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        void ShowPreference()
        {
            Navigation.NavigateTo($"preference/{Id}");
        }
    }
}
