using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlExec
{
    public class ExeResult
    {
        public bool Error { get; }
        public string Message { get; }

        public ExeResult(bool error, string message)
        {
            Error = error;
            Message = message;
        }

    }
}
