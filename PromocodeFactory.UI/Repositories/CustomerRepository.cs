using Microsoft.AspNetCore.WebUtilities;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using System.Text;
using System.Text.Json;

namespace PromocodeFactory.UI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly HttpClient _client;
        private JsonSerializerOptions _options;

        public CustomerRepository(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("api");
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }


        public async Task<PagingResponse<CustomerModel>> GetAllAsync(PagingParameters customerParameters)
        {
            var queryParam = new Dictionary<string, string>
            {
                ["pageNumber"] = customerParameters.PageNumber.ToString()
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("customers", queryParam));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<CustomerModel>
            {
                Items = JsonSerializer.Deserialize<List<CustomerModel>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)

            };
            return pagingResponse;
        }

        public async Task<CustomerModel> GetAsync(Guid customerId)
        {
            var response = await _client.GetAsync($"customers/{customerId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<CustomerModel>(content, _options);
        }
        public async Task CreateAsync(CreateOrUpdateCustomerModel customer)
        {
            var content = JsonSerializer.Serialize(customer);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var postResult = await _client.PostAsync("customers", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task UpdateAsync(CreateOrUpdateCustomerModel customer)
        {
            var content = JsonSerializer.Serialize(customer);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var putResult = await _client.PutAsync("customers", bodyContent);
            var putContent = await putResult.Content.ReadAsStringAsync();
            if (!putResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(putContent);
            }

        }

        public async Task DeleteAsync(Guid customerId)
        {
            var deleteResult = await _client.DeleteAsync($"customers/{customerId}");
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }

        }
    }
}
