namespace OperationResult;

public class OperationResult
{
    public bool IsSuccess { get; }
    public string? Message { get; }

    protected OperationResult(bool isSuccess, string? message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static OperationResult Success(string? message = default)
    {
        return new OperationResult(true, message);
    }

    public static OperationResult Fail(string? message = default)
    {
        return new OperationResult(false, message);
    }
}

public class OperationResult<TType> : OperationResult
{
    public TType? Data { get; }

    protected OperationResult(bool isSuccess, string? message, TType? data)
        : base(isSuccess, message)
    {
        Data = data;
    }

    public static OperationResult<TData?> Success<TData>(TData? data = default, string? message = default)
    {
        return new OperationResult<TData?>(true, message, data);
    }

    public static OperationResult<TData?> Fail<TData>(TData? data = default, string? message = default)
    {
        return new OperationResult<TData?>(false, message, data);
    }
}