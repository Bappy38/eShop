namespace Catalog.Domain.Abstraction;

public sealed record Error(string Code, string? Message = null)
{
    public static readonly Error None = new(string.Empty);
}


public class Result
{
    protected Result(bool isSuccess, Error error)
    {
        if (!IsValidObject(isSuccess, error))
        {
            throw new ArgumentException("Invalid Error", nameof(error));
        }
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsError => !IsSuccess;
    public Error Error { get; }

    public static Result Success() => new(true, Error.None);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result Failure(Error error) => new(false, error);

    private static bool IsValidObject(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
            return false;
        if (!isSuccess && error == Error.None)
            return false;
        return true;
    }
}

public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The value of a failure result cannot be accessed.");

    public static implicit operator Result<TValue>(TValue? value) => new(value, true, Error.None);
}