using Customer.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Customer.Filters;

public class CustomExceptionsFilter : ExceptionFilterAttribute
{
  private readonly ILogger<CustomExceptionsFilter> _logger;
  public CustomExceptionsFilter(ILogger<CustomExceptionsFilter> logger)
  {
    _logger = logger;
  }

  public override void OnException(ExceptionContext context)
  {
    if (context.Exception is ConflictException conflictException)
    {
      var response = new
      {
        StatusCode = 409,
        Error = "Conflict",
        Message = conflictException.Message,
        Timestamp = DateTime.UtcNow,
      };

      context.Result = new ConflictObjectResult(response)
      {
        StatusCode = 409
      };

      context.ExceptionHandled = true;
    }
    else if (context.Exception is KeyNotFoundException notFoundException)
    {
      var respose = new
      {
        StatusCode = 404,
        Error = "NotFound",
        Message = notFoundException.Message,
        Timestamp = DateTime.UtcNow
      };

      context.Result = new NotFoundObjectResult(respose);
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