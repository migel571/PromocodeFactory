using Microsoft.AspNetCore.WebUtilities;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using System.Text;
using System.Text.Json;

namespace PromocodeFactory.UI.Repositories
{
    public class PreferenceRepository : IPreferenceRepository
    {
        private HttpClient _client;
        private JsonSerializerOptions _options;
        public PreferenceRepository(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("api");
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true};
        }

        public async Task<PagingResponse<PreferenceModel>> GetAllAsync(PagingParameters preferenceParametres)
        {
            var queryParam = new Dictionary<string, string>
            {
                ["pageNumber"] = preferenceParametres.PageNumber.ToString(),
                ["searchTerm"] = preferenceParametres.SearchTerm == null ? "" : preferenceParametres.SearchTerm
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("preferences", queryParam));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<PreferenceModel>
            {
                Items = JsonSerializer.Deserialize<List<PreferenceModel>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)

            };
            return pagingResponse;
        }
        public async Task<PreferenceModel> GetAsync(Guid preferenceId)
        {
            var response = await _client.GetAsync($"preferences/{preferenceId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<PreferenceModel>(content, _options);
        }
        public async Task<List<PreferenceModel>> GetPreferenceByCustomerIdAsync (Guid customerId)
        {
            var response = await _client.GetAsync($"preferences/customer/{customerId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<PreferenceModel>>(content, _options);
        }
        
        public async Task CreateAsync(CreatePreferenceModel preference)
        {
            var content = JsonSerializer.Serialize(preference);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var postResult = await _client.PostAsync("preferences", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }
        public async Task UpdateAsync(PreferenceModel preference)
        {
            var content = JsonSerializer.Serialize(preference);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var postResult = await _client.PutAsync("preferences", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task DeleteAsync(Guid preferenceId)
        {
            var deleteResult = await _client.DeleteAsync($"preferences/{preferenceId}");
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
        }

       

       

       
    }
}
