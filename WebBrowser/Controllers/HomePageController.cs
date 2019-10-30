using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Controllers
{
    /// <summary>
    /// Controller class responsible for the intelligence code linked to the HomePage management
    /// </summary>
    public class HomePageController
    {
        /// <summary>
        /// Instance attribute of the <seealso cref="Models.HomeItem"/> class that holds the HomePage data
        /// </summary>
        private Models.HomeItem CurrentHomePage { get; set; }
        /// <summary>
        /// Path to the .xml serialization of the "HomeItem" instance
        /// </summary>
        private const string HOME_PATH = "homepage.xml";
        private const string DEFAULT_HOME = "https://www.google.com";

        /// <summary>
        /// Class constructor that calls the <seealso cref="Controllers.HomePageController.LoadHomePage"/> to load the CurrentHomePage attribute from the serialized .xml
        /// </summary>
        public HomePageController()
        {
            this.LoadHomePage();
        }

        /// <summary>
        /// Method that reads the .xml file to get the serialized <seealso cref="Models.HomeItem"/> and load it into the class attribute
        /// </summary>
        public void LoadHomePage()
        {
            if (File.Exists(HOME_PATH))
            {
                Stream stream = File.Open(HOME_PATH, FileMode.Open);
                SoapFormatter formatter = new SoapFormatter();
                try
                {
                    CurrentHomePage = (Models.HomeItem)formatter.Deserialize(stream);
                }
                catch (Exception e)
                {
                    CurrentHomePage = new Models.HomeItem(DEFAULT_HOME);
                }
                stream.Close();
            }
            else
            {
                Stream stream = File.Open(HOME_PATH, FileMode.Create);
                stream.Close();

                CurrentHomePage = new Models.HomeItem(DEFAULT_HOME);
            }
            if (this.CurrentHomePage == null)
            {
                throw new Exceptions.InvalidValuedVariableException("CurrentHomePage has not been correctly loaded.");
            }
        }

        /// <summary>
        /// Access method to return the address of the current HomePage. Does not show the Models class.
        /// </summary>
        /// <returns><seealso cref="string"/>: Address of the current HomePage</returns>
        public string GetHomePage()
        {
            return this.CurrentHomePage.Address;
        }

        /// <summary>
        /// Method that saves the <seealso cref="Controllers.HomePageController.CurrentHomePage"/> attribute to the .xml file
        /// </summary>
        public void SaveHomePage()
        {
            Stream stream = File.Open(HOME_PATH, FileMode.OpenOrCreate);
            SoapFormatter formatter = new SoapFormatter();

            formatter.Serialize(stream, this.CurrentHomePage);

            stream.Close();
        }

        /// <summary>
        /// Method that given a URL address string, will change the <seealso cref="Controllers.HomePageController.CurrentHomePage"/> attribute
        /// </summary>
        /// <param name="address"></param>
        public void ChangeHomePage(string address)
        {
            if (address == null)
            {
                throw new Exceptions.InvalidValuedVariableException("Address to add cannot be null.");
            }

            Models.HomeItem NewHomePage = new Models.HomeItem(address);

            this.CurrentHomePage = NewHomePage;

            this.SaveHomePage();
        }
    }
}
