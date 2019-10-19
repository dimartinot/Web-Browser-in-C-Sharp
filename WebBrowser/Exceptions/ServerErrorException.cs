using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Exceptions
{
    /// <summary>
    /// Exception class thrown when the HttpError message sent back by the HttpClient is 500, meaning a server error occured
    /// </summary>
    class ServerErrorException : Exception
    {

        public ServerErrorException(string message): base(message)
        {

        }

    }
}
