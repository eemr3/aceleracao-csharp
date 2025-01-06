using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ServicoExternoApi.Filteres;
public class CustomExceptionFilter : ExceptionFilterAttribute
{
  public override void OnException(ExceptionContext context)
  {
    // Tratamento para KeyNotFoundException
    if (context.Exception is KeyNotFoundException keyNotFoundException)
    {
      var response = new
      {
        StatusCode = 404,
        Error = "NotFound",
        Message = keyNotFoundException.Message,
        Timestamp = DateTime.UtcNow,
        Details = "The requested resource was not found."
      };

      context.Result = new NotFoundObjectResult(response)
      {
        StatusCode = 404
      };
      context.ExceptionHandled = true;
    }
    // Tratamento para ArgumentException
    else if (context.Exception is ArgumentException argumentException)
    {
      var response = new
      {
        StatusCode = 400,
        Error = "BadRequest",
        Message = argumentException.Message,
        Timestamp = DateTime.UtcNow,
        Details = "The request parameters were invalid."
      };

      context.Result = new BadRequestObjectResult(response)
      {
        StatusCode = 400
      };
      context.ExceptionHandled = true;
    }
    // Tratamento para HttpRequestException (erros de API externa)
    else if (context.Exception is HttpRequestException httpRequestException)
    {
      var response = new
      {
        StatusCode = 503,
        Error = "ServiceUnavailable",
        Message = "An error occurred while communicating with an external service.",
        Timestamp = DateTime.UtcNow,
        Details = httpRequestException.Message
      };

      context.Result = new ObjectResult(response)
      {
        StatusCode = 503
      };
      context.ExceptionHandled = true;
    }

    base.OnException(context);
  }
}