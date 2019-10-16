using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Exceptions
{
    public class ForbiddenPageException : Exception
    {
        public ForbiddenPageException(string message) : base(message)
        {

        }
    }
}
