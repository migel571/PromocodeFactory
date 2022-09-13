using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using PromocodeFactory.UI.Shared;

namespace PromocodeFactory.UI.Pages
{
    public partial class UpdateCustomer
    {
        [Parameter]
        public List<PreferenceModel> SelectedPreference { get; set; }
        [Parameter]
        public List<PreferenceModel> NotSelectedPreference { get; set; }
        private List<MultipleSelectorModel> Selected = new List<MultipleSelectorModel>();
        private List<MultipleSelectorModel> NotSelected = new List<MultipleSelectorModel>();

        private CreateOrUpdateCustomerModel _customer;
        private SuccessNotification _notification;
        private PagingParameters _preferenceParameters = new PagingParameters();
        [Parameter]
        public string CustomerId { get; set; }
        [Inject]
        ICustomerRepository CustomerRepo { get; set; }
        [Inject]
        IPreferenceRepository PreferenceRepo { get; set; }
        
       
       
        protected async override Task OnInitializedAsync()
        {
           var customer = await CustomerRepo.GetAsync(Guid.Parse(CustomerId));
            _customer.FirstName = customer.FirstName;
            _customer.LastName = customer.LastName;
            _customer.Email = customer.Email;
            var preference = await PreferenceRepo.GetPreferenceByCustomerIdAsync(customer.CustomerId);
            var pagingResponse = await PreferenceRepo.GetAllAsync(_preferenceParameters);
            SelectedPreference = pagingResponse.Items.Except(preference).ToList(); 
            Selected = SelectedPreference.Select(x => new MultipleSelectorModel(x.PreferenceId.ToString(), x.Name)).ToList();
            NotSelected = NotSelectedPreference.Select(x => new MultipleSelectorModel(x.PreferenceId.ToString(), x.Name)).ToList();

        }
        private async Task Update()
        {
            _customer.PreferenceIds = Selected.Select(x => Guid.Parse(x.Key)).ToList(); 
            await CustomerRepo.UpdateAsync(_customer);
            _notification.Show();
        }
    }
}
