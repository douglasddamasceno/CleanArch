namespace Domain.Common.Errors;

public enum ErrorType
{
    Conflict,
    Validation,
    NotFound,
    Forbidden,
    Unauthorized,
    Unexpected
}