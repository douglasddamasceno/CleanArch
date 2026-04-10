using Domain.Common;
using Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Extensions
{
    public static class ResultExtension
    {
        public static IResult ToResult(this Result result)
        {
            if (result.IsSuccess)
                return TypedResults.Ok();
            else
            {
                return result.Error!.Type switch
                {
                    ErrorType.Conflict => TypedResults.Conflict(new ProblemDetails
                    {
                        Status = StatusCodes.Status409Conflict,
                        Title = result.Error.Code,
                        Detail = result.Error.Message
                    }),
                    ErrorType.Validation => TypedResults.BadRequest(new ProblemDetails
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Title = result.Error.Code,
                        Detail = result.Error.Message
                    }),
                    ErrorType.NotFound => TypedResults.NotFound(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title = result.Error.Code,
                        Detail = result.Error.Message
                    }),
                    _ => TypedResults.InternalServerError(new ProblemDetails
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Title = result.Error.Code,
                        Detail = result.Error.Message
                    }),
                };
            }
        }

        public static IResult ToResult<T>(this Result<T> result)
        {
            if (result.IsSuccess)
                return TypedResults.Ok(result.Data);
            else
            {
                return result.Error!.Type switch
                {
                    ErrorType.Conflict => TypedResults.Conflict(new ProblemDetails
                    {
                        Status = StatusCodes.Status409Conflict,
                        Title = result.Error.Code,
                        Detail = result.Error.Message
                    }),
                    ErrorType.Validation => TypedResults.BadRequest(new ProblemDetails
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Title = result.Error.Code,
                        Detail = result.Error.Message
                    }),
                    ErrorType.NotFound => TypedResults.NotFound(new ProblemDetails
                    {
                        Status = StatusCodes.Status404NotFound,
                        Title = result.Error.Code,
                        Detail = result.Error.Message
                    }),
                    _ => TypedResults.InternalServerError(new ProblemDetails
                    {
                        Status = StatusCodes.Status500InternalServerError,
                        Title = result.Error.Code,
                        Detail = result.Error.Message
                    }),
                };
            }
        }
    }
}