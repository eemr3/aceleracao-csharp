using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiFilterExample.Filteres;
public class NotFoundExceptionFilter : ExceptionFilterAttribute
{
  public override void OnException(ExceptionContext context)
  {
    if (context.Exception is KeyNotFoundException notFoundException)
    {
      var response = new
      {
        StatusCode = 404,
        Error = "NotFound",
        Message = notFoundException.Message,
        TimeStampe = DateTime.Now,
        Datails = "The requested resource was not found"
      };

      context.Result = new NotFoundObjectResult(response)
      {
        StatusCode = 404,
      };
      context.ExceptionHandled = true;
    }
    else
    {
      context.Result = new ObjectResult(new { message = "An unexpected error occurred." })
      {
        StatusCode = 500
      };
    }

    base.OnException(context);
  }
}