namespace Domain.Common.Errors;

public static class CommonErrors
{
    public static readonly Error NotFound =
        new(ErrorType.NotFound, "NOT_FOUND", "Recurso não encontrado");

    public static readonly Error Validation =
        new(ErrorType.Validation, "VALIDATION_ERROR", "Erro de validação");

    public static readonly Error Conflict =
        new(ErrorType.Conflict, "CONFLICT", "Conflito de estado");

    public static readonly Error Unexpected =
        new(ErrorType.Unexpected, "UNEXPECTED", "Erro inesperado");
}