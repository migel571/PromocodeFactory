using Microsoft.AspNetCore.Components;

namespace PromocodeFactory.UI.Pages
{
    public partial class GetPartner
    {

        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        void ShowPartner()
        {
            Navigation.NavigateTo($"partner/{Id}");
        }
    }
}
