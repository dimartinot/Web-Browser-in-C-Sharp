using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Controllers
{
    public class HistoryController
    {

        private Models.History CurrentHistory { get; set; }
        private const string HISTORY_PATH = "history.xml";

        public HistoryController()
        {
            this.LoadHistory();
        }

        public void LoadHistory()
        {
            if (File.Exists(HISTORY_PATH))
            {
                Stream stream = File.Open(HISTORY_PATH, FileMode.Open);
                SoapFormatter formatter = new SoapFormatter();
                try
                {
                    CurrentHistory = (Models.History)formatter.Deserialize(stream);
                } catch (Exception e)
                {
                    CurrentHistory = new Models.History();
                }
                stream.Close();
            } else
            {
                Stream stream = File.Open(HISTORY_PATH, FileMode.Create);
                stream.Close();

                this.CurrentHistory = new Models.History();
            }
        }

        public void SaveHistory()
        {
            Stream stream = File.Open(HISTORY_PATH, FileMode.OpenOrCreate);
            SoapFormatter formatter = new SoapFormatter();

            formatter.Serialize(stream, this.CurrentHistory);

            stream.Close();
            
        }

        public void AddAddress(string address)
        {
            this.CurrentHistory.HistoryOfAddresses.Add(new Models.HistoryItem(address, DateTime.Now));
            this.SaveHistory();
        }

        public Models.HistoryItem GetAddressAt(int index)
        {
            return this.CurrentHistory[index];
        }

        public int NumberOfAddresses()
        {
            return this.CurrentHistory.Count();
        }

        public ArrayList ListOfHistoryItems()
        {
            return this.CurrentHistory.HistoryOfAddresses;
        }

    }
}
