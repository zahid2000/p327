﻿using Core.Utilities.Entities.Abstract;

namespace Core.Utilities.Results.Concrete;

public class ErrorDataResult<T> : DataResult<T>
{
    public ErrorDataResult() : base(default, false)
    {

    }
    public ErrorDataResult(T data) : base(data, false)
    {

    }
    public ErrorDataResult(string message) : base(default, false, message)
    {

    }
    public ErrorDataResult(T data, string message) : base(data, false, message)
    {

    }
}
