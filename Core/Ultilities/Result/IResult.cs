using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Ultilities.Result
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
