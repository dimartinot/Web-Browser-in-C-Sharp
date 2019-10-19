using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    /// <summary>
    /// Basic page model
    /// </summary>
    public class Page
    {
        public String Address { set; get;  }
        public String Content { set; get; }


        public Page(String address, String content)
        {
            this.Address = address;
            this.Content = content;
        }

    }
}
