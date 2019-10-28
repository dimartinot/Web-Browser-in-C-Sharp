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
    /// Partial class of the MainWindow form, displaying the main components of the app.
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// Holds the active page information
        /// </summary>
        public Models.Page ActivePage { set; get; }

        /// <summary>
        /// Holds the <seealso cref="Controllers.NavigationController"/> instance
        /// </summary>
        private Controllers.NavigationController NavigationController { set; get; }

        /// <summary>
        /// Holds the <seealso cref="Controllers.HistoryController"/> instance
        /// </summary>
        private Controllers.HistoryController HistoryController { set; get; }

        /// <summary>
        /// Holds the <seealso cref="Controllers.FavoritesController"/> instance
        /// </summary>
        private Controllers.FavoritesController FavoritesController { set; get; }

        /// <summary>
        /// Holds the <seealso cref="Controllers.HomePageController"/> instance
        /// </summary>
        private Controllers.HomePageController HomePageController { set; get; }

        /// <summary>
        /// Holds the <seealso cref="Models.History"/> instance
        /// </summary>
        public Models.History History { set; get; }

        /// <summary>
        /// Class constructor calling the <seealso cref="InitializeComponent()"/> method (automatically generated) and the <seealso cref="LoadContent(string)"/> method to display the home page
        /// </summary>
        public MainWindow()
        {
            Console.WriteLine("Running tests at launch...");
            Tests.UnitTest.TestFavoritesController();
            Tests.UnitTest.TestHistoryController();
            Tests.UnitTest.TestHomePageController();
            Tests.UnitTest.TestNavigationControllerAsync();


            InitializeComponent();
            this.NavigationController = new Controllers.NavigationController();
            this.HistoryController = new Controllers.HistoryController();
            this.FavoritesController = new Controllers.FavoritesController();
            this.HomePageController = new Controllers.HomePageController();

            this.LoadContent(this.HomePageController.GetHomePage());
        }

        /// <summary>
        /// Loads in the view the content of the <seealso cref="ActivePage"/> instance 
        /// </summary>
        private void ReloadContent()
        {
            if (this.ActivePage != null)
            {
                this.webPageTitle.Text = this.NavigationController.GetPageTitle(this.ActivePage);
                this.pageBody.Text = this.ActivePage.Content;
                this.addressTextBox.Text = this.ActivePage.Address;
                this.HistoryController.AddAddress(this.ActivePage.Address);
            } else
            {
                this.pageBody.Text = "No page loaded yet...";
            }

        }

        /// <summary>
        /// Async method that loads in the activate page instance the one corresponding to the given address
        /// </summary>
        /// <param name="address">Address of the web page to load</param>
        private async void LoadContent(string address)
        /**
         * Loads in the activate page instance the one corresponding to the given address
        */
        {
            
            this.ActivePage = await this.NavigationController.LoadPage(address, this.ActivePage);
            this.ReloadContent();

        }

        /// <summary>
        /// Called when a key is typed on the AddressTextBox and executes a loading when it is the enter key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.addressTextBox.Focused && this.addressTextBox.Text != "")
            {
                this.LoadContent(addressTextBox.Text);
            }
        }

        /// <summary>
        /// Called when the buttonLeft is clicked. Loads the "before current" page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            this.ActivePage = this.NavigationController.BackwardPage(this.ActivePage);
            this.ReloadContent();
        }

        /// <summary>
        /// Called when the buttonRight is clicked. Loads the "after current" page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRight_Click(object sender, EventArgs e)
        {
            this.ActivePage = this.NavigationController.ForwardPage(this.ActivePage);
            this.ReloadContent();
        }

        /// <summary>
        /// Called when a selection is made in the ComboBox, acting as a menu with Favorites selection or History selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;

            switch (combobox.SelectedIndex)
            {
                case 0:

                    HistoryForm historyForm = new HistoryForm(this.HistoryController, this);
                    historyForm.ShowForm();

                    break;
                case 1:

                    FavoriteListForm favoriteListForm = new FavoriteListForm(this.FavoritesController, this);
                    favoriteListForm.ShowForm();

                    break;
                default:
                    this.Close();
                    break;
            }
        }

        /// <summary>
        /// Method called when the refreshButton is clicked: reload the <seealso cref="ActivePage"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.ReloadContent();
        }

        /// <summary>
        /// Method called when the starButton is clicked: opens a <seealso cref="FavoritesForm"/> form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StarButton_Click(object sender, EventArgs e)
        {
            FavoritesForm favoritesForm = new FavoritesForm(this.FavoritesController);
            favoritesForm.Show();
            //string address = addressTextBox.Text;
            //this.favoritesController.AddToFavorites(address);
        }

        /// <summary>
        /// Public method used to change the Active Page from an outside class.
        /// </summary>
        /// <param name="address">Address of the page to be loaded</param>
        public void LoadAddressFromOutside(string address)
        {
            this.LoadContent(address);
        }

        /// <summary>
        /// Method called when the homeButton is clicked: opens a <seealso cref="HomePageForm"/> form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeButton_Click(object sender, EventArgs e)
        {
            HomePageForm homePageForm = new HomePageForm(this.HomePageController);
            homePageForm.Show();
        }
    }
}
