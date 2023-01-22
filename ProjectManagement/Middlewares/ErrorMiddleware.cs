using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ProjectManagement.Models;
using System.Net;
using System.Runtime.CompilerServices;

namespace ProjectManagement.Middlewares
{
    public static class ErrorMiddleware
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
                        logger.LogError($"Something went wrong: { contextFeature.Error }");

                        await context.Response.WriteAsync(new ErrorDetails()
                        {

                            StatusCodeContext= context.Response.StatusCode,
                            Message = "Something Went Wrong. Please try again!"

                        }.ToString());

                    }

                });

            });


        }



    }
}
