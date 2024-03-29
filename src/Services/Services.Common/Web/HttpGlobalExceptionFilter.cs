// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Services.Common.Exceptions;
using Services.Common.Web;
using System.Net;

namespace Services.Common;

public partial class HttpGlobalExceptionFilter : IExceptionFilter
{
    private readonly IHostingEnvironment _hostingEnvironment;
    private readonly ILogger<HttpGlobalExceptionFilter> _logger;

    public HttpGlobalExceptionFilter(IHostingEnvironment hostingEnvironment, ILogger<HttpGlobalExceptionFilter> logger)
    {
        _hostingEnvironment = hostingEnvironment ?? throw new ArgumentNullException(nameof(hostingEnvironment)); ;
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void OnException(ExceptionContext context)
    {
        _logger.LogError(new EventId(context.Exception.HResult),
            context.Exception,
            context.Exception.Message);

        if (context.Exception.GetType() == typeof(DomainException))
        {
            var json = new JsonErrorResponse
            {
                Messages = new[] { context.Exception.Message }
            };

            context.Result = new BadRequestObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        }
        else
        {
            var json = new JsonErrorResponse
            {
                Messages = new[] { $"An error ocurr.Try it again." }
            };

            if (_hostingEnvironment.IsDevelopment()) json.DeveloperMeesage = context.Exception;

            context.Result = new InternalServerErrorObjectResult(json);
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
        context.ExceptionHandled = true;
    }
}
