using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class HomePageForm : Form
    {

        private Controllers.HomePageController HomePageController { get; set; }

        public HomePageForm(Controllers.HomePageController homePageController)
        {
            InitializeComponent();
            this.HomePageController = homePageController;
            this.currentHomeAddress.Text = this.HomePageController.GetHomePage();
        }


        private void cancelbuttonChangeHomePage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void confirmbuttonChangeHomePage_Click(object sender, EventArgs e)
        {
            this.HomePageController.ChangeHomePage(this.inputChangeHomePage.Text);
            this.Close();
        }

    }
}
