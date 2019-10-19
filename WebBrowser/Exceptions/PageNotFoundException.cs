using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Exceptions
{
    /// <summary>
    /// Exception class thrown when the HttpError message sent back by the HttpClient is 404, meaning the ressource has not been found at the given address
    /// </summary>
    class PageNotFoundException : Exception
    {
        public PageNotFoundException(string message) : base(message)
        {

        }
    }
}
