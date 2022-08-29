using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PromocodeFactory.UI;
using PromocodeFactory.UI.Interfaces;
using PromocodeFactory.UI.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("api", c =>
{
    c.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
});
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl")) });
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("CorsPolicy", opt => opt
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod()
        .WithExposedHeaders("X-Pagination"));
}
    );
builder.Services.AddScoped(
    sp => sp.GetService<IHttpClientFactory>().CreateClient("api"));
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

await builder.Build().RunAsync();
