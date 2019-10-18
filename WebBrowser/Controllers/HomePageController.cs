using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowser.Controllers
{
    public class HomePageController
    {
        private Models.HomeItem CurrentHomePage { get; set; }
        private const string HOME_PATH = "homepage.xml";

        public HomePageController()
        {
            this.LoadHomePage();
        }

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
                    CurrentHomePage = new Models.HomeItem("");
                }
                stream.Close();
            }
            else
            {
                Stream stream = File.Open(HOME_PATH, FileMode.Create);
                stream.Close();

                CurrentHomePage = new Models.HomeItem("");
            }
        }

        public string GetHomePage()
        {
            return this.CurrentHomePage.Address;
        }

        public void SaveHomePage()
        {
            Stream stream = File.Open(HOME_PATH, FileMode.OpenOrCreate);
            SoapFormatter formatter = new SoapFormatter();

            formatter.Serialize(stream, this.CurrentHomePage);

            stream.Close();
        }

        public void ChangeHomePage(string address)
        {
            Models.HomeItem NewHomePage = new Models.HomeItem(address);

            this.CurrentHomePage = NewHomePage;

            this.SaveHomePage();
        }
    }
}
