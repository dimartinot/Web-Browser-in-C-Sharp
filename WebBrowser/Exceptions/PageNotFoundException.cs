using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Exceptions
{
    class PageNotFoundException : Exception
    {
        public PageNotFoundException(string message) : base(message)
        {

        }
    }
}
