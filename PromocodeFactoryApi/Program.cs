using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using NLog;
using PromocodeFactory.Infrastructure;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Infrastructure.Repository.Administration;
using PromocodeFactory.Infrastructure.Repository.PromocodeManagment;
using PromocodeFactory.LoggerService;
using PromocodeFactoryApi.Extensions;


var builder = WebApplication.CreateBuilder(args);
//Add config log
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/NLog.config"));
// Add services to the container.
builder.Services.AddDbContext<PromocodeContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PromocodeFactoryDB")));
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<IRepositoryEmployee, EmployeeRepository>();
builder.Services.AddScoped<IRepositoryRole, RoleRepository>();
builder.Services.AddScoped<IRepositoryCustomer, CustomerRepository>();
builder.Services.AddScoped<IRepositoryPreference, PreferenceRepository>();
builder.Services.AddControllers();
// Добавляем наши методы расширения из Extension
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Добавляем свои компоненты в конвейер 
app.UseCors("CorsPolicy");
app.UseStaticFiles();
// Для прокси серверов 
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

// Компоненты при создании шаблона
app.UseHttpsRedirection();
  
app.UseAuthorization();

app.MapControllers();

app.Run();
