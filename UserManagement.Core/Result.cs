using System.Net;

namespace UserManagement.Core;

public class Result
{
    public bool IsSuccess { get; }
    public int StatusCode { get; }
    public string? ErrorMessage { get; }

    protected Result(bool isSuccess, HttpStatusCode statusCode, string? errorMessage = null)
    {
        IsSuccess = isSuccess;
        StatusCode = (int)statusCode;
        ErrorMessage = errorMessage;
    }

    public static Result Success()
    {
        return new Result(true, HttpStatusCode.OK);
    }

    public static Result Created()
    {
        return new Result(true, HttpStatusCode.Created);
    }

    public static Result NoContent()
    {
        return new Result(true, HttpStatusCode.NoContent);
    }

    public static Result BadRequest(string errorMessage)
    {
        return new Result(false, HttpStatusCode.BadRequest, errorMessage);
    }

    public static Result Unauthorized(string errorMessage)
    {
        return new Result(false, HttpStatusCode.Unauthorized, errorMessage);
    }

    public static Result NotFound(string errorMessage)
    {
        return new Result(false, HttpStatusCode.NotFound, errorMessage);
    }

    public static Result Conflict(string errorMessage)
    {
        return new Result(false, HttpStatusCode.Conflict, errorMessage);
    }

    public static Result Fail(string errorMessage)
    {
        return new Result(false, HttpStatusCode.InternalServerError, errorMessage);
    }
}

public class Result<T> : Result
{
    public T Value { get; }

    protected Result(T value, bool isSuccess, HttpStatusCode statusCode, string? errorMessage = null) :
        base(isSuccess, statusCode, errorMessage)
    {
        Value = value;
    }

    protected Result(bool isSuccess, HttpStatusCode statusCode, string? errorMessage = null) :
        base(isSuccess, statusCode, errorMessage)
    {
        Value = default!;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value, true, HttpStatusCode.OK);
    }

    public static Result<T> Created(T value)
    {
        return new Result<T>(value, true, HttpStatusCode.Created);
    }

    public new static Result<T> BadRequest(string errorMessage)
    {
        return new Result<T>(false, HttpStatusCode.BadRequest, errorMessage);
    }

    public new static Result<T> Unauthorized(string errorMessage)
    {
        return new Result<T>(false, HttpStatusCode.Unauthorized, errorMessage);
    }

    public new static Result<T> NotFound(string errorMessage)
    {
        return new Result<T>(false, HttpStatusCode.NotFound, errorMessage);
    }

    public new static Result<T> Conflict(string errorMessage)
    {
        return new Result<T>(false, HttpStatusCode.Conflict, errorMessage);
    }

    public new static Result<T> Fail(string errorMessage)
    {
        return new Result<T>(false, HttpStatusCode.InternalServerError, errorMessage);
    }
}