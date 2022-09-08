using Microsoft.AspNetCore.Components;

namespace PromocodeFactory.UI.Pages
{
    public partial class GetCustomer
    {
        [Parameter]
        public string Id { get; set; }

        [Inject]
        public NavigationManager Navigation { get; set; }

        void ShowCustomer()
        {
            Navigation.NavigateTo($"customer/{Id}");
        }
    }
}
