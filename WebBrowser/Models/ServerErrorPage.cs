using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    /// <summary>
    /// Page model of a "server error" page 
    /// </summary>
    public class ServerErrorPage : Page
    {
        public ServerErrorPage(string address) : base(address, String.Format("Server Internal Error (error {0}): access to address '{1}' led to a server internal error.", 500, address))
        {
        }
    }
}
