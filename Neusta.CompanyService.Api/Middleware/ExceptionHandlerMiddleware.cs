using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Neusta.CompanyService.Abstraction.Exceptions;

namespace Neusta.CompanyService.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly IDictionary<Type, Func<HttpContext, Exception, Task>> exceptionDictionary;
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;

            this.exceptionDictionary = new Dictionary<Type, Func<HttpContext, Exception, Task>>
            {
                {typeof(CompanyNotFoundException), HandleFirmaNotFoundException}
            };
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await this.HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, System.Exception exception)
        {
            System.Type type = exception.GetType();
            if (exceptionDictionary.ContainsKey(type))
            {
                return exceptionDictionary[type].Invoke(context, exception);
            }

            return HandleUnknownException(context, exception);
        }

        private async Task HandleUnknownException(HttpContext context, Exception exception)
        {
            throw new NotImplementedException();
        }


        private Task HandleFirmaNotFoundException(HttpContext context, Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}