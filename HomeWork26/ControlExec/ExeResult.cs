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
        public List<string> Message { get; }
        public int ErrorCount
        {
            get
            {
                if (Message != null) return Message.Count;
                return 0;
            }
        }

        public ExeResult(bool error, List<string> Message)
        {
            Error = error;
            this.Message = Message;
        }

    }
}
