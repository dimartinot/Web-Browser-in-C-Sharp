using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Exceptions
{
    class UnsupportedErrorException: Exception
    {
        public UnsupportedErrorException(string message): base(message)
        {

        }
    }
}
