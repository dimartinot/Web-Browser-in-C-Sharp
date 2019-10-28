using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Exceptions
{
    public class InvalidValuedVariableException : Exception
    {
        public InvalidValuedVariableException(string msg): base(msg)
        {

        }
    }
}
