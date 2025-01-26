using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CorePackages.Infrastructure.Security.Extensions;

namespace BuzluManav.Presentation.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>() ?? throw new NullReferenceException();
    private IMediator? _mediator;
    
    protected string? getIpAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
    }

    protected Guid getUserIdFromRequest() //todo authentication behavior?
    {
        Guid userId = HttpContext.User.GetUserId();
        return userId;
    }

    protected IActionResult HandleErrors<T>(Func<T> func)
    {
        try
        {
            return Ok(func.Invoke());
        }
        catch (Exception e)
        {
            return Problem(Error.Failure(e.Detail(includeStackTrace: true), e.Message));
        }
    }

    protected async Task<IActionResult> HandleErrorsAsync<T>(Func<Task<T>> func)
    {
        try
        {
            return Ok(await func.Invoke());
        }
        catch (Exception e)
        {
            return Problem(Error.Failure(e.Detail(includeStackTrace: true), e.Message));
        }
    }

    protected async Task<IActionResult> HandleErrorsAsync(Func<Task> func)
    {
        try
        {
            await func.Invoke();
            return Ok();
        }
        catch (Exception e)
        {
            return Problem(Error.Failure(e.Detail(includeStackTrace: true), e.Message));
        }
    }

    private IActionResult Problem(Error error)
    {
        return Problem(new List<Error> { error });
    }

    private IActionResult Problem(List<Error> errors)
    {
        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors)
            {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }

        if (errors.Any(e => e.Type == ErrorType.Unexpected))
        {
            return Problem();
        }

        var firstError = errors[0];

        var statusCode = firstError.Type switch
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: firstError.Description, detail: firstError.Code);
    }
}

public static class ExceptionExtensions
{
    private const int MaxDepth = 5;

    public static string Detail(this Exception exception, bool includeInnerExceptions = true, bool includeStackTrace = false, int depth = 1)
    {
        if (exception is null || depth < 1 || depth > MaxDepth)
        {
            return string.Empty;
        }
        var innerExceptions = string.Empty;
        if (includeInnerExceptions && exception is not AggregateException && exception.InnerException is not null)
        {
            innerExceptions = Detail(exception.InnerException, includeInnerExceptions, false, depth + 1);
        }
        var result = innerExceptions == string.Empty ? exception.Message : $"{exception.Message}{Environment.NewLine}{string.Concat(Enumerable.Repeat("==", depth))}> {innerExceptions}";
        return includeStackTrace ? $"{result}{Environment.NewLine}{Environment.NewLine}{exception.StackTrace}" : result;
    }
}
