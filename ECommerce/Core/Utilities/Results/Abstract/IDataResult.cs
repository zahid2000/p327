using Core.Utilities.Entities.Abstract;

namespace Core.Utilities.Results.Abstract;

public interface IDataResult<T>:IResult
{
   public T Data { get; }
}
