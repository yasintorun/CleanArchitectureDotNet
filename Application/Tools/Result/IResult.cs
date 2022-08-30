using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Tools.Result
{
    public interface IResult<T>
    {
        bool Success { get; }
        string Message { get; }
        T Data { get; }
    }
}
