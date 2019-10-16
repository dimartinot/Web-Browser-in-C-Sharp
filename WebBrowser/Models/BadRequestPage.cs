using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    class BadRequestPage : Page
    {
        public BadRequestPage(string address) : base(address, String.Format("Error {0}: Bad Request sent", 400))
        {
        }
    }
}
