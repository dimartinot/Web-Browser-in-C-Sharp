using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    /// <summary>
    /// HistoryItem model class embedding a history address and access date
    /// </summary>
    [Serializable()]
    public class HistoryItem
    {
        public string Address { get; set; }
        public DateTime AccessDate { get; set; }

        public HistoryItem(string address, DateTime accessDate)
        {
            this.Address = address;
            this.AccessDate = accessDate;
        }
    }
}
