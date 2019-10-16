using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    public class Bookmark
    {

        public String Title { get; set; }

        public Bookmark(String title)
        {
            this.Title = title;
        }

    }
}
