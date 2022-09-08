using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using PromocodeFactory.UI.Shared;

namespace PromocodeFactory.UI.Pages
{
    public partial class CreateCustomer
    {
        private CreateCustomerModel _customer = new CreateCustomerModel();
        private SuccessNotification _notification;
        private PagingParameters _preferenceParameters = new PagingParameters();
        public List<PreferenceModel> PreferencesList { get; set; } = new List<PreferenceModel>();
        [Inject]
        public ICustomerRepository CustomerRepo { get; set; }
        public IPreferenceRepository PreferenceRepo { get; set; }
        private List<Guid> PreferenceIds = new(); 
       
        protected async override Task OnInitializedAsync()
        {
            var pagingResponse = await PreferenceRepo.GetAllAsync(_preferenceParameters);
            PreferencesList = pagingResponse.Items;
        }
        private async Task Create()
        {
            _customer.PreferenceIds = PreferenceIds; 
            await CustomerRepo.CreateAsync(_customer);
            _notification.Show();
        }
    }
}
