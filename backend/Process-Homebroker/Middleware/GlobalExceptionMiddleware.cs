using Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Process_Homebroker.Middleware
{
    public class GlobalExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(ILogger<GlobalExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BusinessException ex)
            {
                _logger.LogError($"Ocorreu um erro interno tratado - Erro ocorrido {ex}");
                await HandleBusinessException(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ocorreu um erro na requisição - Erro ocorrido: {ex}");
                await HandleExceptionAsync(context, ex);
            }
        }
        
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var json = new
            {
                context.Response.StatusCode,
                Message = "Ocorreu um erro na sua requisição, tente novamente mais tarde!",
                Detailed = new
                {
                    StackTrance = exception.StackTrace
                }
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }

        private static Task HandleBusinessException(HttpContext context, BusinessException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            var json = new
            {
                context.Response.StatusCode,
                Message = exception.Message,
                Detailed = new
                {
                    StackTrance = exception.StackTrace
                }
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(json));
        }
    }
}