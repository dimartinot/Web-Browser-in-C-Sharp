using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    [Serializable()]
    public class HomeItem
    {
        public string Address { get; set; }

        public HomeItem(string address)
        {
            this.Address = address;
        }
    }
}
