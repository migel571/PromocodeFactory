using Microsoft.AspNetCore.WebUtilities;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using System.Text;
using System.Text.Json;

namespace PromocodeFactory.UI.Repositories
{
    public class PromocodeRepository : IPromocodeRepository
    {
        private readonly HttpClient _client;
        private JsonSerializerOptions _options;

        public PromocodeRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }


        public async Task<PagingResponse<PromocodeModel>> GetAllAsync(PagingParameters promocodeParameters)
        {
            var queryParam = new Dictionary<string, string>
            {
                ["pageNumber"] = promocodeParameters.PageNumber.ToString(),
                ["searchTerm"] = promocodeParameters.SearchTerm == null ? "" : promocodeParameters.SearchTerm
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("promocodes", queryParam));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<PromocodeModel>
            {
                Items = JsonSerializer.Deserialize<List<PromocodeModel>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)

            };
            return pagingResponse;
        }

        public async Task<PromocodeModel> GetAsync(Guid promocodeId)
        {
            var response = await _client.GetAsync($"promocodes/{promocodeId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<PromocodeModel>(content, _options);
        }
        public async Task CreateAsync(CreatePromocodeModel promocode)
        {
            var content = JsonSerializer.Serialize(promocode);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var postResult = await _client.PostAsync("promocodes", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }
        public async Task DeleteAsync(Guid promocodeId)
        {
            var deleteResult = await _client.DeleteAsync($"promocodes/{promocodeId}");
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }

        }

        public async Task<List<PromocodeModel>> GetPromocodeByCustomerIdAsync(Guid customerId)
        {
            var response = await _client.GetAsync($"promocodes/customer/{customerId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<PromocodeModel>>(content, _options);
        }
    }
}
