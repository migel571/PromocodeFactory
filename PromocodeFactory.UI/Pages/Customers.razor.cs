using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Pages
{
    public partial class Customers
    {
        public List<CustomerModel> CustomersList { get; set; } = new List<CustomerModel>();
        public MetaData MetaData { get; set; } = new MetaData();
        private PagingParameters _customerParameters = new PagingParameters();

        [Inject]
        public ICustomerRepository CustomerRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetCustomers();
            await base.OnInitializedAsync();

        }

        private async Task GetCustomers()
        {
            var pagingResponse = await CustomerRepo.GetAllAsync(_customerParameters);
            CustomersList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;

        }
        private async Task SelectedPage(int page)
        {
            _customerParameters.PageNumber = page;
            await GetCustomers();
        }
        private async Task DeleteCustomer(Guid id)
        {
            await CustomerRepo.DeleteAsync(id);
            _customerParameters.PageNumber = 1;
            await GetCustomers();
        }
        private async Task SearchChanged(string searchTerm)
        {

            _customerParameters.PageNumber = 1;
            _customerParameters.SearchTerm = searchTerm;
            await GetCustomers();
        }

    }
}
