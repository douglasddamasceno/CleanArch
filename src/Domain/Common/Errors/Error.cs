namespace Domain.Common.Errors;

public record Error(
    ErrorType Type,
    string Code,
    string Message
);