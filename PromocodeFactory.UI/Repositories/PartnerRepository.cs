using Microsoft.AspNetCore.WebUtilities;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using System.Text;
using System.Text.Json;

namespace PromocodeFactory.UI.Repositories
{
    public class PartnerRepository : IPartnerRepository
    {
        private HttpClient _client;
        private JsonSerializerOptions _options;
        public PartnerRepository(IHttpClientFactory factory)
        {
            _client = factory.CreateClient();
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async  Task<PagingResponse<PartnerModel>> GetAllAsync(PagingParameters partnerParametres)
        {
            var queryParam = new Dictionary<string, string>
            {
                ["pageNumber"] = partnerParametres.PageNumber.ToString()
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("partners", queryParam));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<PartnerModel>
            {
                Items = JsonSerializer.Deserialize<List<PartnerModel>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)

            };
            return pagingResponse;
        }

        public async Task<PartnerModel> GetAsync(Guid partnerId)
        {
            var response = await _client.GetAsync($"partners/{partnerId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<PartnerModel>(content, _options);
        }
        public async Task CreateAsync(CreatePartnerModel partner)
        {
            var content = JsonSerializer.Serialize(partner);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var postResult = await _client.PostAsync("partners", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
               
        }

        public async Task UpdateAsync(PartnerModel partner)
        {
            var content = JsonSerializer.Serialize(partner);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var postResult = await _client.PutAsync("partners", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }
        public async Task DeleteAsync(Guid partnerId)
        {
            var deleteResult = await _client.DeleteAsync($"partners/{partnerId}");
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }

        
    }
}
