using AuthService.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuthService.Filters;

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

      context.Result = new NotFoundObjectResult(response)
      {
        StatusCode = 404
      };

      context.ExceptionHandled = true;
    }
    else if (context.Exception is ConflictException conflict)
    {
      var response = new
      {
        StatusCode = 409,
        Error = "Conflict",
        Message = conflict.Message,
        Timestamp = DateTime.UtcNow
      };

      context.Result = new ConflictObjectResult(response)
      {
        StatusCode = 409
      };
      context.ExceptionHandled = true;
    }
    else if (context.Exception is UnauthorizedAccessException unauthorized)
    {
      var response = new
      {
        StatusCode = 401,
        Error = "Unauthorize",
        Message = unauthorized.Message,
        Timestamp = DateTime.UtcNow
      };

      context.Result = new UnauthorizedObjectResult(response)
      {
        StatusCode = 401
      };
      context.ExceptionHandled = true;
    }
    else if (context.Exception is ForbiddeException forbiddeException)
    {
      var response = new
      {
        StatusCode = 403,
        Error = "Forbidden",
        Message = forbiddeException.Message,
        Timestamp = DateTime.UtcNow
      };

      context.Result = new ObjectResult(response);

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