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
    /// <summary>
    /// Class of the HomePage form, displaying the HomePage information and the input for eventual changes
    /// </summary>
    public partial class HomePageForm : Form
    {
        /// <summary>
        /// <seealso cref="Controllers.HomePageController"/> instance to provide the HomePage intelligence
        /// </summary>
        private Controllers.HomePageController HomePageController { get; set; }

        /// <summary>
        /// Class constructor calling the <seealso cref="InitializeComponent()"/> method (automatically generated) and setting the label text at the current HomePage value
        /// </summary>
        /// <param name="homePageController"></param>
        public HomePageForm(Controllers.HomePageController homePageController)
        {
            InitializeComponent();
            this.HomePageController = homePageController;
            this.currentHomeAddress.Text = this.HomePageController.GetHomePage();
        }

        /// <summary>
        /// Method called when cancelButton is clicked: closes the current form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelbuttonChangeHomePage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Method called when the confirmButton is clicked: registers the change to the controller and closes the form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmbuttonChangeHomePage_Click(object sender, EventArgs e)
        {
            this.HomePageController.ChangeHomePage(this.inputChangeHomePage.Text);
            this.Close();
        }

    }
}
