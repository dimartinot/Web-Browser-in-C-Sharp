using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Exceptions
{
    class ServerErrorException: Exception
    {

        public ServerErrorException(string message): base(message)
        {

        }

    }
}
