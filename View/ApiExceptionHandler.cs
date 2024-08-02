using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using books_api.Exceptions;

namespace books_api.View
{
    public class ApiExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.Result = ErrorResponseFactory.CreateErrorResponse(exception);
        }
    }
}

public static class ErrorResponseFactory
{
    public static IActionResult CreateErrorResponse(Exception exception)
    {

        HttpStatusCode statusCode = exception switch
        {
            EntityNotFoundException => HttpStatusCode.NotFound,
            TitleAndAuthorException or EntityInUseException => HttpStatusCode.Conflict,
            _ => HttpStatusCode.InternalServerError
        };

        var errorResponse = new ErrorResponse
        {
            Code = (int)statusCode,
            Message = exception.Message,
        };

        return new JsonResult(errorResponse)
        {
            StatusCode = (int)statusCode
        };
    }
}

public class ErrorResponse
{
    public int Code { get; set; }
    public string Message { get; set; }
}