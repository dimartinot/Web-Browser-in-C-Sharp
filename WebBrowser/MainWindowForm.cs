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
    public partial class MainWindow : Form
    {

        public Models.Page ActivePage { set; get; }
        private Controllers.NavigationController NavigationController { set; get; }
        private Controllers.HistoryController HistoryController { set; get; }
        private Controllers.FavoritesController FavoritesController { set; get; }

        public Models.History History { set; get; }

        public MainWindow()
        {
            InitializeComponent();
            this.NavigationController = new Controllers.NavigationController();
            this.HistoryController = new Controllers.HistoryController();
            this.FavoritesController = new Controllers.FavoritesController();
        }

        private void ReloadContent()
        /**
         * Loads in the view the content of the activate page instance 
        */
        {
            if (this.ActivePage != null)
            {
                this.pageBody.Text = this.ActivePage.Content;
                this.addressTextBox.Text = this.ActivePage.Address;
                this.HistoryController.AddAddress(this.ActivePage.Address);
            } else
            {
                this.pageBody.Text = "No page loaded yet...";
            }

        }
        private async void LoadContent(string address)
        /**
         * Loads in the activate page instance the one corresponding to the given address
        */
        {
            
            this.ActivePage = await this.NavigationController.loadPage(address, this.ActivePage);
            this.ReloadContent();

        }


        private void TableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddressTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.addressTextBox.Focused && this.addressTextBox.Text != "")
            {
                this.LoadContent(addressTextBox.Text);
            }
        }

        private void ButtonLeft_Click(object sender, EventArgs e)
        {
            this.ActivePage = this.NavigationController.backwardPage(this.ActivePage);
            this.ReloadContent();
        }

        private void ButtonRight_Click(object sender, EventArgs e)
        {
            this.ActivePage = this.NavigationController.forwardPage(this.ActivePage);
            this.ReloadContent();
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ComboBox combobox = (ComboBox)sender;

            switch (combobox.SelectedIndex)
            {
                case 0:

                    HistoryForm historyForm = new HistoryForm(this.HistoryController);
                    historyForm.ShowForm();

                    break;
                case 1:

                    FavoriteListForm favoriteListForm = new FavoriteListForm(this.FavoritesController, this);
                    favoriteListForm.ShowForm();

                    break;
                default:

                    break;
            }
        }


        private void RefreshButton_Click(object sender, EventArgs e)
        {
            this.ReloadContent();
        }

        private void StarButton_Click(object sender, EventArgs e)
        {
            FavoritesForm favoritesForm = new FavoritesForm(this.FavoritesController);
            favoritesForm.Show();
            //string address = addressTextBox.Text;
            //this.favoritesController.AddToFavorites(address);
        }

        public void LoadAddressFromOutside(string address)
        {
            this.LoadContent(address);
        }
    }
}
