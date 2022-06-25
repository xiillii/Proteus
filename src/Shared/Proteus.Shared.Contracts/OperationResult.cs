using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proteus.Shared.Entities.Dtos;

namespace Proteus.Shared.Contracts
{
    public class OperationResult
    {
        public bool Failure { get; set; }
        public bool Success { get; set; }
        public ErrorDto? Error { get; set; }

        public OperationResult(bool isSuccess)
        {
            Success = isSuccess;
            Failure = !Success;
        }

        public OperationResult() : this(false)
        {
           
        }

        public OperationResult(ErrorDto error): this(false)
        {
            Error = error;
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T? Result { get; private set; }

        public OperationResult(T result) : base(result != null)
        {
            Result = result;
        }

        public OperationResult(T result, ErrorDto error) : base(error)
        {
            Result = result;
        }

        public OperationResult(ErrorDto error) : base(error)
        {
            
        }
    }
}
