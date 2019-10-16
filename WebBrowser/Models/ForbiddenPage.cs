using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    class ForbiddenPage : Page
    {
        public ForbiddenPage(string address) : base(address, String.Format("Error {0}: Acces to this page is forbidden (address: '{1}')", 403, address))
        {
        }
    }
}
