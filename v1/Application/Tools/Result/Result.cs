using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Tools.Result
{
    public class Result<T> : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public T Data { get; set; }
    }
}
