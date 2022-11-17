using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Pages
{
    public  partial class Partners
    {
        public List<PartnerModel> PartnersList { get; set; } = new List<PartnerModel>();
        public MetaData MetaData { get; set; } = new MetaData();
        private PagingParameters _partnerParameters = new PagingParameters();

        [Inject]
        public IPartnerRepository PartnerRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetPartners();
            await base.OnInitializedAsync();

        }

        private async Task GetPartners()
        {
            var pagingResponse = await PartnerRepo.GetAllAsync(_partnerParameters);
            PartnersList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;

        }
        private async Task SelectedPage(int page)
        {
            _partnerParameters.PageNumber = page;
            await GetPartners();
        }
        private async Task DeletePartner(Guid id)
        {
            await PartnerRepo.DeleteAsync(id);
            _partnerParameters.PageNumber = 1;
            await GetPartners();
        }
        private async Task SearchChanged(string searchTerm)
        {

            _partnerParameters.PageNumber = 1;
            _partnerParameters.SearchTerm = searchTerm;
            await GetPartners();
        }

    }
}
