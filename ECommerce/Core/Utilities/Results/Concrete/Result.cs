
using Core.Utilities.Results.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Core.Utilities.Results.Concrete;

public class Result : IResult
{
    public Result(bool success)
    {
        Success = success;
    }
    public Result(bool success,string message):this(success)
    {
        Message = message;
    }
    public string Message { get; }
    public bool Success { get; }
}
