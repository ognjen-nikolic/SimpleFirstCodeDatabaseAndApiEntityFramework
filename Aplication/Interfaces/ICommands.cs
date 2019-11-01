using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Interfaces
{
    public interface ICommands<TRequest>
    {
        void Execute(TRequest request);
    }
    public interface ICommands<TRequest,TResult>
    {
        TResult Execute(TRequest request);
    }
}
