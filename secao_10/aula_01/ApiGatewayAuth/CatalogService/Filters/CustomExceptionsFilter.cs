using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CatalogService.Filters;

public class CustomExceptionsFilter : ExceptionFilterAttribute
{
  private readonly ILogger<CustomExceptionsFilter> _logger;
  public CustomExceptionsFilter(ILogger<CustomExceptionsFilter> logger)
  {
    _logger = logger;
  }

  public override void OnException(ExceptionContext context)
  {
    if (context.Exception is KeyNotFoundException notFoundException)
    {
      var response = new
      {
        StatusCode = 404,
        Error = "NotFound",
        Message = notFoundException.Message,
        Timestamp = DateTime.UtcNow
      };

      context.Result = new NotFoundObjectResult(response);
      context.ExceptionHandled = true;
    }
    else
    {
      var exception = context.Exception;
      var request = context.HttpContext.Request;

      _logger.LogError(exception,
          "Unhandled Exception occurred.\n" +
          "Message: {Message}\n" +
          "Type: {Type}\n" +
          "Stack Trace: {StackTrace}\n" +
          "Timestamp: {Timestamp}\n" +
          "Request Path: {RequestPath}\n" +
          "HTTP Method: {HttpMethod}\n" +
          "Query String: {QueryString}\n",
          exception.Message,
          exception.GetType().FullName,
          exception.StackTrace,
          DateTime.UtcNow,
          request.Path,
          request.Method,
          request.QueryString
      );

      context.Result = new ObjectResult(context.Exception.Message)
      {
        StatusCode = 500
      };
      context.ExceptionHandled = true;
    }
  }
}