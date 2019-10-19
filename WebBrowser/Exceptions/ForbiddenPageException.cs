using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Exceptions
{
    /// <summary>
    /// Exception class thrown when the HttpError message sent back by the HttpClient is 403, meaning we are forbidden to access the ressource
    /// </summary>
    public class ForbiddenPageException : Exception
    {
        public ForbiddenPageException(string message) : base(message)
        {

        }
    }
}
