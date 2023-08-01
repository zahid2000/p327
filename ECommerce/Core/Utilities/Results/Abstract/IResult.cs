namespace Core.Utilities.Results.Abstract;

public interface IResult
{
    public string Message { get; }
    public bool Success { get; }
}
