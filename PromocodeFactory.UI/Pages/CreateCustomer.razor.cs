using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using PromocodeFactory.UI.Shared;

namespace PromocodeFactory.UI.Pages
{
    public partial class CreateCustomer
    {
        [Parameter]
        public List<PreferenceModel> SelectedPreference { get; set; } 
        [Parameter]
        public List<PreferenceModel> NotSelectedPreference { get; set; }
        private List<MultipleSelectorModel> Selected = new List<MultipleSelectorModel>();
        private List<MultipleSelectorModel> NotSelected = new List<MultipleSelectorModel>();



        private CreateCustomerModel _customer = new CreateCustomerModel();
        private SuccessCreateCustomer _notification;
        private PagingParameters _preferenceParameters = new PagingParameters();
       
        [Inject]
        public ICustomerRepository CustomerRepo { get; set; }
        [Inject]
        public IPreferenceRepository PreferenceRepo { get; set; }
       
        protected async override Task OnInitializedAsync()
        {
            var pagingResponse = await PreferenceRepo.GetAllAsync(_preferenceParameters);
            NotSelectedPreference = pagingResponse.Items;
            SelectedPreference  = new();
            Selected = SelectedPreference.Select(x => new MultipleSelectorModel(x.PreferenceId.ToString(), x.Name)).ToList();
            NotSelected = NotSelectedPreference.Select(x => new MultipleSelectorModel(x.PreferenceId.ToString(), x.Name)).ToList();
            
        }
        private async Task Create()
        {
            _customer.PreferenceIds = Selected.Select(x=>Guid.Parse(x.Key)).ToList();
            var customer = await CustomerRepo.CreateAsync(_customer);
            _notification.Show(customer.CustomerId.ToString());
        }
    }
}
