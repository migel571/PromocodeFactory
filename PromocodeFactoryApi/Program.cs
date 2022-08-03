using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLog;
using PromocodeFactory.Infrastructure;
using PromocodeFactoryApi.Extensions;
using System.Text;

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
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qazxsw")),
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
builder.Services.AddAllManagersAndRepositories();
// ��������� ���� ������ ���������� �� Extension
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//���������� ������ 
if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseCustomExceptionHandler();
app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// ��������� ���� ���������� � �������� 
app.UseCors("CorsPolicy");
app.UseStaticFiles();
// ��� ������ �������� 
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

// ���������� ��� �������� �������
app.UseHttpsRedirection();
  
app.UseAuthorization();

app.MapControllers();

app.Run();
