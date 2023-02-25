using BlogApp.Service.Exceptions;
using BlogApp.SharedLibrary.ResponseDTOs;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace BlogApp.WebAPI.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;
                    var response = Response<NoDataDto>.Fail(statusCode, exceptionFeature.Error.Message);
                    // API uygulaması olduğu için globale response'u JSON türünde dönmemiz gerekiyor 
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
