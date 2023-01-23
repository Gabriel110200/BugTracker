using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProjectManagement.Models;
using System.Net;

namespace ProjectManagement.Middlewares
{
    public static class ErrorMiddlewareManager
    {

        public static void UseAPiExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(appError =>
            {

                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";


                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature != null)
                    {

                        var logger = loggerFactory.CreateLogger("GlobalException");
                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {

                            StatusCode = context.Response.StatusCode,
                            Message = $"{contextFeature.Error.InnerException}"

                        }.ToString());

                    }

                });

            });


        }


        public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorMiddleware>();
        }



    }
}
