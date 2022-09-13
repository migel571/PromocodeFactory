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



        private CreateOrUpdateCustomerModel _customer = new CreateOrUpdateCustomerModel();
        private SuccessNotification _notification;
        private PagingParameters _preferenceParameters = new PagingParameters();
        //public List<PreferenceModel> PreferencesList { get; set; } = new List<PreferenceModel>();
        [Inject]
        public ICustomerRepository CustomerRepo { get; set; }
        [Inject]
        public IPreferenceRepository PreferenceRepo { get; set; }
        //private List<Guid> PreferenceIds = new(); 
       
        protected async override Task OnInitializedAsync()
        {
            var pagingResponse = await PreferenceRepo.GetAllAsync(_preferenceParameters);
            NotSelectedPreference = pagingResponse.Items;
            Selected = SelectedPreference.Select(x => new MultipleSelectorModel(x.PreferenceId.ToString(), x.Name)).ToList();
            NotSelected = NotSelectedPreference.Select(x => new MultipleSelectorModel(x.PreferenceId.ToString(), x.Name)).ToList();
            
        }
        private async Task Create()
        {
            _customer.PreferenceIds = Selected.Select(x=>Guid.Parse(x.Key)).ToList(); 
            await CustomerRepo.CreateAsync(_customer);
            _notification.Show();
        }
    }
}
