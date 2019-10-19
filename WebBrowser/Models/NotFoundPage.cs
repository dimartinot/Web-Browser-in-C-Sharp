using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    /// <summary>
    /// Page model of a "not found" page error
    /// </summary>
    public class NotFoundPage : Page
    {

        public NotFoundPage(string address) : base(address, String.Format("Error {0}: Page at address '{1}' not found.", 404, address))
        {

        }

    }
}
