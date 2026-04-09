using Domain.Common.Errors;

namespace Domain.Common;

public class Result
{
    public bool IsSuccess { get; }
    public Error? Error { get; }

    protected Result(bool success, Error? error)
    {
        if (success && error is not null)
            throw new InvalidOperationException("A success result cannot contain an error.");

        if (!success && error is null)
            throw new InvalidOperationException("A failure result must contain an error message.");

        IsSuccess = success;
        Error = error;
    }

    public static Result Success() => new(true, null);
    public static Result Failure(Error error) => new(false, error);
}

public class Result<T> : Result
{
    public T Data { get; }

    private Result(bool success, T? data, Error? error)
        : base(success, error)
    {
        if (success && data is null)
            throw new InvalidOperationException("A success result must contain a non-null value.");

        Data = data!;
    }

    public static Result<T> Success(T data) => new(true, data, null);
    public static new Result<T> Failure(Error error) => new(false, default, error);
}