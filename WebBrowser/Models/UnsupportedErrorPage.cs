using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    public class UnsupportedErrorPage : Page
    {
        public UnsupportedErrorPage(string address) : base(address, String.Format("Unsupported Error: acces to the following address '{0}' led to an unsupported error", address))
        {
        }
    }
}
