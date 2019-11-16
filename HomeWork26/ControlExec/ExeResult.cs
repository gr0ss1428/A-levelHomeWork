using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlExec
{
    public class ExeResult
    {
        public bool IsError
        {
            get
            {
                if (Message != null)
                {
                    if (Message.Count != 0) return true;
                }
                return false;
            }
        }
        public List<string> Message { get; }
        public int ErrorCount
        {
            get
            {
                if (Message != null) return Message.Count;
                return 0;
            }
        }

        public ExeResult( List<string> Message)
        {
            this.Message = Message;
        }

    }
}
