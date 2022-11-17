using Microsoft.AspNetCore.Components;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;

namespace PromocodeFactory.UI.Pages
{
    public partial class Promocodes
    {
        public List<PromocodeModel> PromocodesList { get; set; } = new List<PromocodeModel>();
        public MetaData MetaData { get; set; } = new MetaData();
        private PagingParameters _promocodeParameters = new PagingParameters();

        [Inject]
        public IPromocodeRepository PromocodeRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetPromocodes();
            await base.OnInitializedAsync();

        }

        private async Task GetPromocodes()
        {

            var pagingResponse = await PromocodeRepo.GetAllAsync(_promocodeParameters);
            PromocodesList = pagingResponse.Items;
            MetaData = pagingResponse.MetaData;

        }
        private async Task SelectedPage(int page)
        {
            _promocodeParameters.PageNumber = page;
            await GetPromocodes();
        }
        private async Task DeletePromocode(Guid id)
        {
            await PromocodeRepo.DeleteAsync(id);
            _promocodeParameters.PageNumber = 1;
            await GetPromocodes();
        }
        private async Task SearchChanged(string searchTerm)
        {

            _promocodeParameters.PageNumber = 1;
            _promocodeParameters.SearchTerm = searchTerm;
            await GetPromocodes();
        }

    }
}
