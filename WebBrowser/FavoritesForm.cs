using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebBrowser
{
    /// <summary>
    /// Class of the FavoriteList form, displaying two inputs for the user to enter the favorite name and address
    /// </summary>
    class FavoritesForm : Form
    {
        private TextBox favoriteAddingAddress;
        private TextBox favoriteAddingName;
        private TextBox labelFavoriteAddingURL;
        private TextBox labelAddingFavoriteName;
        private Button addFavoritesButton;
        private TableLayoutPanel tableLayoutPanel1;

        /// <summary>
        /// <seealso cref="Controllers.FavoritesController"/> instance to provide the Favorites intelligence
        /// </summary>
        private Controllers.FavoritesController FavoritesController { set; get; }

        /// <summary>
        /// Class constructor calling the <seealso cref="InitializeComponent()"/> method (automatically generated).
        /// </summary>
        /// <param name="favoritesController"><seealso cref="Controllers.FavoritesController"/> instance</param>
        public FavoritesForm(Controllers.FavoritesController favoritesController)
        {
            InitializeComponent();
            this.FavoritesController = favoritesController;
        }

        /// <summary>
        /// Displays the current form and set the default favorite address input text as the current web page address
        /// </summary>
        public void ShowForm(string addressToAdd)
        {

            this.favoriteAddingName.Text = addressToAdd;
            
            this.ShowDialog();

        }

        /// <summary>
        /// Automatically generated method that holds all the design information of the current form
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelAddingFavoriteName = new System.Windows.Forms.TextBox();
            this.favoriteAddingAddress = new System.Windows.Forms.TextBox();
            this.favoriteAddingName = new System.Windows.Forms.TextBox();
            this.labelFavoriteAddingURL = new System.Windows.Forms.TextBox();
            this.addFavoritesButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.labelAddingFavoriteName, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.favoriteAddingAddress, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.favoriteAddingName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelFavoriteAddingURL, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.addFavoritesButton, 0, 4);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.70642F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.29358F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(261, 287);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelAddingFavoriteName
            // 
            this.labelAddingFavoriteName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAddingFavoriteName.Location = new System.Drawing.Point(3, 126);
            this.labelAddingFavoriteName.Multiline = true;
            this.labelAddingFavoriteName.Name = "labelAddingFavoriteName";
            this.labelAddingFavoriteName.ReadOnly = true;
            this.labelAddingFavoriteName.Size = new System.Drawing.Size(255, 51);
            this.labelAddingFavoriteName.TabIndex = 3;
            this.labelAddingFavoriteName.TabStop = false;
            this.labelAddingFavoriteName.Text = "Please enter the URL of the favourite to add:";
            // 
            // favoriteAddingAddress
            // 
            this.favoriteAddingAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.favoriteAddingAddress.Location = new System.Drawing.Point(3, 189);
            this.favoriteAddingAddress.Name = "favoriteAddingAddress";
            this.favoriteAddingAddress.Size = new System.Drawing.Size(255, 26);
            this.favoriteAddingAddress.TabIndex = 1;
            // 
            // favoriteAddingName
            // 
            this.favoriteAddingName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.favoriteAddingName.Location = new System.Drawing.Point(3, 62);
            this.favoriteAddingName.Name = "favoriteAddingName";
            this.favoriteAddingName.Size = new System.Drawing.Size(255, 26);
            this.favoriteAddingName.TabIndex = 0;
            // 
            // labelFavoriteAddingURL
            // 
            this.labelFavoriteAddingURL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFavoriteAddingURL.Location = new System.Drawing.Point(3, 3);
            this.labelFavoriteAddingURL.Multiline = true;
            this.labelFavoriteAddingURL.Name = "labelFavoriteAddingURL";
            this.labelFavoriteAddingURL.ReadOnly = true;
            this.labelFavoriteAddingURL.Size = new System.Drawing.Size(255, 46);
            this.labelFavoriteAddingURL.TabIndex = 4;
            this.labelFavoriteAddingURL.TabStop = false;
            this.labelFavoriteAddingURL.Text = "Please enter a name for the favourite:";
            // 
            // addFavoritesButton
            // 
            this.addFavoritesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addFavoritesButton.Location = new System.Drawing.Point(3, 229);
            this.addFavoritesButton.Name = "addFavoritesButton";
            this.addFavoritesButton.Size = new System.Drawing.Size(92, 32);
            this.addFavoritesButton.TabIndex = 2;
            this.addFavoritesButton.Text = "Add";
            this.addFavoritesButton.UseVisualStyleBackColor = true;
            this.addFavoritesButton.Click += new System.EventHandler(this.AddFavoritesButton_Click);
            // 
            // FavoritesForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 286);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FavoritesForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Method that is called when the AddFavorites is being clicked: add the written page address and name as a new favorite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddFavoritesButton_Click(object sender, EventArgs e)
        {
            if (this.favoriteAddingAddress.Text != "" && this.favoriteAddingName.Text != "")
            {
                this.FavoritesController.AddToFavorites(this.favoriteAddingAddress.Text, this.favoriteAddingName.Text);
                this.Close();
            }
        }
    }
}
