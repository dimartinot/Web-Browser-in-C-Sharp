using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Models
{
    [Serializable()]
    public class History
    {
        //A stack would be way more relevant but for serializable properties concern, an Arraylist is used..
        public ArrayList HistoryOfAddresses { get; set; }

        public History()
        {
            this.HistoryOfAddresses = new ArrayList();
        }

        public History(ArrayList historyOfAddresses)
        {
            this.HistoryOfAddresses = historyOfAddresses;
        }

        public HistoryItem this[int index]
        {
            get
            {
                return (HistoryItem)this.HistoryOfAddresses[index];
            }
        }

        public int Count ()
        {
            return this.HistoryOfAddresses.Count;
        }
    }
}
