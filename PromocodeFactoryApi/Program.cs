using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog;
using PromocodeFactory.Infrastructure;
using PromocodeFactory.Api.Extensions;
using System.Reflection;
using System.Text;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);
//Add config log
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/NLog.config"));
// Add services to the container.
builder.Services.AddDbContext<PromocodeContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PromocodeFactoryDB")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<PromocodeContext>().
AddDefaultTokenProviders();
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options=>
{
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        RequireExpirationTime = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["AuthSettings:Key"])),
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorizationCore(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Admin"));
    options.AddPolicy("EmployeeOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Employee", "Admin"));
    options.AddPolicy("PartnerOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Partner", "Admin"));
    options.AddPolicy("All", policy => policy.RequireClaim(ClaimTypes.Role, "Employee", "Partner", "Admin"));
    options.AddPolicy("CustomerOnly", policy => policy.RequireClaim(ClaimTypes.Role, "Employee", "Customer", "Admin"));

});
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers().AddFluentValidation(f => { f.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()); f.ValidatorOptions.CascadeMode = FluentValidation.CascadeMode.Stop; }) ;
//builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAllManagersAndRepositories();
// Добавляем наши методы расширения из Extension
builder.Services.ConfigureCors();
//builder.Services.ConfigureIISIntegration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Обработчик ошибок 
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseCustomExceptionHandler();
app.UseAuthentication();

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
app.UseHsts();
app.UseHttpsRedirection();
  
app.UseAuthorization();

app.MapControllers();

app.Run();
