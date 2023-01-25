using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectManagement.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace ProjectManagement.Middlewares
{
    public  class ErrorMiddleware
    {
        private readonly RequestDelegate _next;
        private  ILoggerFactory _logger;

        public ErrorMiddleware(ILoggerFactory logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

            }
            catch (ValidationException ex)
            {
                var logger = _logger.CreateLogger("ValidationException");
                logger.LogError($"A validation has been violated: {ex}");

                await HandleValidationException(httpContext, ex);


            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                var logger = _logger.CreateLogger("APIException");
               

                await HandleFluentAPIException(httpContext, ex);

            }

            catch (Exception ex)
            {

                var logger = _logger.CreateLogger("GlobalException");

                logger.LogError($"Something went wrong: {ex}");

                await  HandleExceptionAsync(httpContext, ex);

            }
            

        }

        private async Task HandleFluentAPIException(HttpContext context, DbUpdateException ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;



            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"A validation has been violated: {ex.InnerException.Message}"
            }.ToString());
        }

        private async Task HandleValidationException(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;



            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = $"A validation has been violated: {exception.Message}"
            }.ToString());

        }


        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

         

            await context.Response.WriteAsync(new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = "Oops...Something went wrong. Internal Server Error!"
            }.ToString());
        }

      
      


    }
}
