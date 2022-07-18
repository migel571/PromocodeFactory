using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using PromocodeFactory.Service.Exceptions;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace PromocodeFactoryApi.Extensions
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
                      RoleException _ => Status400BadRequest,
                      EmployeeException _ => Status400BadRequest,
                      CustomerException _ => Status400BadRequest,
                      _ => context.Response.StatusCode
                  };
                  var result = JsonConvert.SerializeObject(new { error = exception.Message });
                  context.Response.ContentType = "application/json";
                  await context.Response.WriteAsync(result);  

              }

                ));
        }
    }
}
