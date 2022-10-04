using Microsoft.AspNetCore.WebUtilities;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using System.Text;
using System.Text.Json;

namespace PromocodeFactory.UI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient _client;
        private JsonSerializerOptions _options;

        public EmployeeRepository(HttpClient client)
        {
            _client = client;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }


        public async Task<PagingResponse<EmployeeModel>> GetAllAsync(PagingParameters employeeParameters)
        {
            var queryParam = new Dictionary<string, string>
            {
                ["pageNumber"] = employeeParameters.PageNumber.ToString(),
                ["searchTerm"] = employeeParameters.SearchTerm == null ? "" : employeeParameters.SearchTerm
            };
            var response = await _client.GetAsync(QueryHelpers.AddQueryString("employees", queryParam));
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            var pagingResponse = new PagingResponse<EmployeeModel>
            {
                Items = JsonSerializer.Deserialize<List<EmployeeModel>>(content, _options),
                MetaData = JsonSerializer.Deserialize<MetaData>(response.Headers.GetValues("X-Pagination").First(), _options)

            };
            return pagingResponse;
        }

        public async Task<EmployeeModel> GetAsync(Guid employeeId)
        {
            var response = await _client.GetAsync($"employees/{employeeId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<EmployeeModel>(content, _options);
        }
        public async Task CreateAsync(CreateEmployeeModel employee)
        {
            var content = JsonSerializer.Serialize(employee);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var postResult = await _client.PostAsync("employees", bodyContent);
            var postContent = await postResult.Content.ReadAsStringAsync();
            if (!postResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(postContent);
            }
        }

        public async Task UpdateAsync(EmployeeModel employee)
        {
            var content = JsonSerializer.Serialize(employee);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            
            var putResult = await _client.PutAsync("employees",bodyContent);
            var putContent = await putResult.Content.ReadAsStringAsync();
            if (!putResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(putContent);
            }
                       
        }

        public async Task DeleteAsync(Guid employeeId)
        {
            var deleteResult = await _client.DeleteAsync($"employees/{employeeId}");
            var deleteContent = await deleteResult.Content.ReadAsStringAsync();
            if (!deleteResult.IsSuccessStatusCode)
            {
                throw new ApplicationException(deleteContent);
            }
            
        }
    }
}
