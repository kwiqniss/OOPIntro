using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OopIntroLib.Logger
{
    public interface ILogger
    {
        void WriteLine(string? message = null);

        void WriteError(string? message = null);
    }
}
