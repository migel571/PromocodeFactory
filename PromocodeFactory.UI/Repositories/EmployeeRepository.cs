using Microsoft.AspNetCore.WebUtilities;
using PromocodeFactory.UI.Features;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Models;
using System.Text.Json;

namespace PromocodeFactory.UI.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly HttpClient _client;
        private JsonSerializerOptions _options;
        
        public EmployeeRepository(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("api");
           _options =  new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<PagingResponse<EmployeeModel>> GetAllAsync(PagingParameters employeeParameters)
        {
            var queryParam = new Dictionary<string, string>
            {
                ["pageNumber"] = employeeParameters.PageNumber.ToString()
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

        public Task<EmployeeModel> GetAsync(Guid employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
