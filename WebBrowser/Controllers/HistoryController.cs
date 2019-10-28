using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebBrowser.Models;

namespace WebBrowser.Controllers
{
    /// <summary>
    /// Controller class responsible for the intelligence code linked to the history management 
    /// </summary>
    public class HistoryController
    {
        /// <summary>
        /// Holds the instance of the <seealso cref="Models.History"/> which acts as a list of <seealso cref="Models.HistoryItem"/>
        /// </summary>
        private Models.History CurrentHistory { get; set; }
        /// <summary>
        /// Path to the .xml serialization of the "History" instance
        /// </summary>
        private const string HISTORY_PATH = "history.xml";

        /// <summary>
        /// The class constructor: loads the history from the .xml file
        /// </summary>
        public HistoryController()
        {
            this.LoadHistory();
        }

        /// <summary>
        /// Method that returns the list of <seealso cref="Models.HistoryItem"/> from an instance of History
        /// </summary>
        /// <param name="history">Instance of <seealso cref="Models.History"/> from which we want to extract <seealso cref="Models.HistoryItem"/></param>
        /// <returns><seealso cref="ArrayList"/>: List of <seealso cref="HistoryItem"/></returns>
        public static ArrayList GetListOfItemsFromHistory(Models.History history)
        {
            return history.HistoryOfAddresses;
        }

        /// <summary>
        /// Method that sorts the History according to an input pattern. Only matching HistoryItem are retrieved by this method
        /// </summary>
        /// <param name="sortingPattern">The pattern with which we want to sort the <seealso cref="Models.HistoryItem"/> using their address field.</param>
        /// <returns><seealso cref="Models.History"/>: History with filtered <seealso cref="Models.HistoryItem"/></returns>
        public Models.History SortHistory(string sortingPattern)
        {
            if (sortingPattern == null)
            {
                throw new Exceptions.InvalidValuedVariableException("Sorting Pattern value cannot be null");
            }
            //Using LINQ syntax for better readability and efficiency
            IEnumerable<Models.HistoryItem> sortedHistoryItems = from Models.HistoryItem address in this.CurrentHistory.HistoryOfAddresses where address.Address.Contains(String.Format("{0}", sortingPattern)) select address;

            ArrayList addressList = new ArrayList();

            foreach (Models.HistoryItem item in sortedHistoryItems)
            {
                addressList.Add(item);
            }

            return new Models.History
            {
                HistoryOfAddresses = addressList
            };
        }

        /// <summary>
        /// Method that returns the current history
        /// </summary>
        /// <returns><seealso cref="Models.History"/>: Method that returns the current History</returns>
        public History GetCurrentHistory()
        {
            return this.CurrentHistory;
        }

        /// <summary>
        /// Method that loads history from the corresponding .xml file into the class attribute
        /// </summary>
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
            if (this.CurrentHistory == null)
            {
                throw new Exceptions.InvalidValuedVariableException("CurrentHistory has not been correctly loaded.");
            }
        }

        /// <summary>
        /// Method that saves the history into a serialized .xml file
        /// </summary>
        public void SaveHistory()
        {
            Stream stream = File.Open(HISTORY_PATH, FileMode.OpenOrCreate);
            SoapFormatter formatter = new SoapFormatter();

            formatter.Serialize(stream, this.CurrentHistory);

            stream.Close();
            
        }

        /// <summary>
        /// Method that adds an address to the <seealso cref="Models.History"/> list attribute
        /// </summary>
        /// <param name="address">Address to add as an history attribute</param>
        public void AddAddress(string address)
        {
            if (address == null)
            {
                throw new Exceptions.InvalidValuedVariableException("Address to add cannot be null.");
            }
            this.CurrentHistory.HistoryOfAddresses.Add(new Models.HistoryItem(address, DateTime.Now));
            this.SaveHistory();
        }

        /// <summary>
        /// Method that returns the <seealso cref="Models.HistoryItem"/> of a given index
        /// </summary>
        /// <param name="index">Index of the <seealso cref="Models.HistoryItem"/> to return</param>
        /// <returns><seealso cref="Models.HistoryItem"/>: Item to return</returns>
        public Models.HistoryItem GetAddressAt(int index)
        {
            return this.CurrentHistory[index];
        }

        /// <summary>
        /// Method that returns the number of <seealso cref="Models.HistoryItem"/> in the history field
        /// </summary>
        /// <returns><seealso cref="int"/>The number of <seealso cref="Models.HistoryItem"/></returns>
        public int NumberOfAddresses()
        {
            return this.CurrentHistory.Count();
        }

        /// <summary>
        /// Method that returns an arrayList of <seealso cref="Models.HistoryItem"/>
        /// </summary>
        /// <returns><seealso cref="ArrayList"/>: List of <seealso cref="Models.HistoryItem"/></returns>
        public ArrayList ListOfHistoryItems()
        {
            return this.CurrentHistory.HistoryOfAddresses;
        }

    }
}
