using Microsoft.AspNetCore.Components;

namespace PromocodeFactory.UI.Shared
{

    public partial class SuccessCreateCustomer
    {
        private string _modalDisplay;
        private string _modalClass;
        private bool _showBackdrop;
        [Inject]
        public NavigationManager Navigation { get; set; }
        [Parameter]
        public string Id { get; set; }
        public void Show(string id)
        {
            Id = id;
            _modalDisplay = "block;";
            _modalClass = "show";
            _showBackdrop = true;
            StateHasChanged();
        }
        private void Hide()
        {
            _modalDisplay = "none;";
            _modalClass = "";
            _showBackdrop = false;
            StateHasChanged();
            Navigation.NavigateTo("/");
        }
    }

}
