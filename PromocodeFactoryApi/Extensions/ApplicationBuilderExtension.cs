using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using PromocodeFactory.Infrastructure.Interfaces;
using PromocodeFactory.Infrastructure.Interfaces.AdministrationRep;
using PromocodeFactory.Infrastructure.Interfaces.PromocodeManagment;
using PromocodeFactory.Infrastructure.Repository.Administration;
using PromocodeFactory.Infrastructure.Repository.PromocodeManagment;
using PromocodeFactory.Service;
using PromocodeFactory.Service.Exceptions;
using PromocodeFactory.Service.Interfaces;
using PromocodeFactory.Service.Manager;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace PromocodeFactory.Api.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void UseCustomExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(a => a.Run(async context =>
              {
                  var feature = context.Features.Get<IExceptionHandlerPathFeature>();
                  var exception = feature.Error;
                  context.Response.StatusCode = exception switch
                  {
                     
                      EmployeeException _ => Status400BadRequest,
                      CustomerException _ => Status400BadRequest,
                      PreferenceException _ => Status400BadRequest,
                      PromoCodeException _ => Status400BadRequest,
                      PartnerException _ => Status400BadRequest,
                      _ => context.Response.StatusCode
                  };
                  var result = JsonConvert.SerializeObject(new { error = exception.Message });
                  context.Response.ContentType = "application/json";
                  await context.Response.WriteAsync(result);  

              }

                ));
        }
        public static void AddAllManagersAndRepositories(this IServiceCollection collection)
        {
            collection.AddSingleton<ILoggerManager, LoggerManager>();

            
            collection.AddScoped<IEmployeeRepository, EmployeeRepository>();
            collection.AddScoped<ICustomerRepository, CustomerRepository>();
            collection.AddScoped<IPreferenceRepository, PreferenceRepository>();
            collection.AddScoped<IPromoCodeRepository, PromoCodeRepository>();
            collection.AddScoped<IPartnerRepository, PartnerRepository>();
                        
            
            collection.AddScoped<IEmployeeManager, EmployeeManager>();
            collection.AddScoped<ICustomerManager, CustomerManager>();
            collection.AddScoped<IPreferenceManager, PreferenceManager>();
            collection.AddScoped<IPromoCodeManager, PromoCodeManager>();
            collection.AddScoped<IPartnerManager, PartnerManager>();
            collection.AddScoped<IUserManager, UserManager>();


        }
    }
}
