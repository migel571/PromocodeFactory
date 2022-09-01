using Microsoft.AspNetCore.Components;

namespace PromocodeFactory.UI.Pages
{
    public partial class GetEmployee
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        void ShowEmployee()
        {
            Navigation.NavigateTo($"employee/{Id}");
        }
    }
}
