using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Exceptions
{
    /// <summary>
    /// Exception class thrown when the HttpError message sent back by the HttpClient has an error code not managed by the other Exception classes
    /// </summary>
    public class UnsupportedErrorException : Exception
    {
        public UnsupportedErrorException(string message): base(message)
        {

        }
    }
}
