using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebBrowser
{
    /// <summary>
    /// Class of the FavoriteList form, displaying the list of favorites and allowing to either acces, edit or delete them.
    /// </summary>
    class FavoriteListForm : Form
    {
        private ComboBox listFavoriteItems;
        private TextBox labelFavoriteListForm;
        private TableLayoutPanel tableLayoutPanel2;
        private Button accessButton;
        private Button editButton;
        private Button deleteButton;
        private TableLayoutPanel tableLayoutPanel3;
        private TextBox editFavoriteAddressInput;
        private TextBox editFavoriteNameInput;
        private Label editFavoriteNameLabel;
        private Label editFavoriteAddressLabel;
        private TableLayoutPanel tableLayoutPanel1;

        /// <summary>
        /// <seealso cref="Controllers.FavoritesController"/> instance to provide the Favorites intelligence
        /// </summary>
        private Controllers.FavoritesController FavoritesController { set; get; }
        /// <summary>
        /// <seealso cref="MainWindow"/> instance to be able to interact back with it (for the display of a given favorite)
        /// </summary>
        private MainWindow MainWindow { set; get; }

        /// <summary>
        /// Class constructor calling the <seealso cref="InitializeComponent()"/> method (automatically generated).
        /// </summary>
        /// <param name="favoritesController"><seealso cref="Controllers.FavoritesController"/> instance</param>
        /// <param name="mainWindow"><seealso cref="MainWindow"/> instance</param>
        public FavoriteListForm(Controllers.FavoritesController favoritesController, MainWindow mainWindow)
        {
            InitializeComponent();
            this.FavoritesController = favoritesController;
            this.MainWindow = mainWindow;
            
        }

        /// <summary>
        /// Loads the <seealso cref="Models.FavouriteItem"/> in the ComboBox
        /// </summary>
        public void LoadFavoritesInComboBox()
        {
            if (this.listFavoriteItems.Items != null)
            {
                foreach (Object obj in this.listFavoriteItems.Items)
                {
                    this.listFavoriteItems.Items.Remove(obj);
                }
                foreach (Models.FavouriteItem favItem in this.FavoritesController.ListOfFavoriteItems())
                {
                    this.listFavoriteItems.Items.Add(new Models.FavouriteItem(favItem.Address, favItem.Name));
                }

            }
        }

        /// <summary>
        /// Calls the <seealso cref="LoadFavoritesInComboBox"/> method and displays the current form
        /// </summary>
        public void ShowForm()
        {
            this.LoadFavoritesInComboBox();
            this.ShowDialog();
        }

        /// <summary>
        /// Automatically generated method that holds all the design information of the current form
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelFavoriteListForm = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.accessButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.listFavoriteItems = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.editFavoriteAddressInput = new System.Windows.Forms.TextBox();
            this.editFavoriteNameInput = new System.Windows.Forms.TextBox();
            this.editFavoriteNameLabel = new System.Windows.Forms.Label();
            this.editFavoriteAddressLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelFavoriteListForm, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.listFavoriteItems, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(260, 314);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // labelFavoriteListForm
            // 
            this.labelFavoriteListForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFavoriteListForm.Location = new System.Drawing.Point(3, 3);
            this.labelFavoriteListForm.Multiline = true;
            this.labelFavoriteListForm.Name = "labelFavoriteListForm";
            this.labelFavoriteListForm.ReadOnly = true;
            this.labelFavoriteListForm.Size = new System.Drawing.Size(254, 52);
            this.labelFavoriteListForm.TabIndex = 1;
            this.labelFavoriteListForm.TabStop = false;
            this.labelFavoriteListForm.Text = "Please select a favorite to perform an action:";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel2.Controls.Add(this.accessButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.editButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.deleteButton, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 218);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(254, 32);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // accessButton
            // 
            this.accessButton.Location = new System.Drawing.Point(3, 3);
            this.accessButton.Name = "accessButton";
            this.accessButton.Size = new System.Drawing.Size(75, 23);
            this.accessButton.TabIndex = 0;
            this.accessButton.Text = "Access";
            this.accessButton.UseVisualStyleBackColor = true;
            this.accessButton.Click += new System.EventHandler(this.accessButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(88, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editFavoriteAddressLabel_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(173, 3);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // listFavoriteItems
            // 
            this.listFavoriteItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listFavoriteItems.FormattingEnabled = true;
            this.listFavoriteItems.Location = new System.Drawing.Point(3, 61);
            this.listFavoriteItems.Name = "listFavoriteItems";
            this.listFavoriteItems.Size = new System.Drawing.Size(254, 28);
            this.listFavoriteItems.TabIndex = 0;
            this.listFavoriteItems.SelectedIndexChanged += new System.EventHandler(this.listFavoriteItems_SelectedIndexChanged);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.editFavoriteAddressInput, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.editFavoriteNameInput, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.editFavoriteNameLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.editFavoriteAddressLabel, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 95);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 58F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(257, 117);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // editFavoriteAddressInput
            // 
            this.editFavoriteAddressInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editFavoriteAddressInput.Location = new System.Drawing.Point(3, 88);
            this.editFavoriteAddressInput.Name = "editFavoriteAddressInput";
            this.editFavoriteAddressInput.Size = new System.Drawing.Size(248, 26);
            this.editFavoriteAddressInput.TabIndex = 1;
            // 
            // editFavoriteNameInput
            // 
            this.editFavoriteNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editFavoriteNameInput.Location = new System.Drawing.Point(3, 25);
            this.editFavoriteNameInput.Name = "editFavoriteNameInput";
            this.editFavoriteNameInput.Size = new System.Drawing.Size(251, 26);
            this.editFavoriteNameInput.TabIndex = 0;
            // 
            // editFavoriteNameLabel
            // 
            this.editFavoriteNameLabel.AutoSize = true;
            this.editFavoriteNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editFavoriteNameLabel.Location = new System.Drawing.Point(3, 0);
            this.editFavoriteNameLabel.Name = "editFavoriteNameLabel";
            this.editFavoriteNameLabel.Size = new System.Drawing.Size(51, 20);
            this.editFavoriteNameLabel.TabIndex = 2;
            this.editFavoriteNameLabel.Text = "Name";
            // 
            // editFavoriteAddressLabel
            // 
            this.editFavoriteAddressLabel.AutoSize = true;
            this.editFavoriteAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editFavoriteAddressLabel.Location = new System.Drawing.Point(3, 55);
            this.editFavoriteAddressLabel.Name = "editFavoriteAddressLabel";
            this.editFavoriteAddressLabel.Size = new System.Drawing.Size(68, 20);
            this.editFavoriteAddressLabel.TabIndex = 3;
            this.editFavoriteAddressLabel.Text = "Address";
            this.editFavoriteAddressLabel.Click += new System.EventHandler(this.editFavoriteAddressLabel_Click);
            // 
            // FavoriteListForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 266);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FavoriteListForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Method that is called when the accessButton is being clicked: redirects the currentPage of the MainWindow to the favorite and closes the current form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void accessButton_Click(object sender, EventArgs e)
        {
            if (this.listFavoriteItems.SelectedItem != null)
            {
                Models.FavouriteItem obj = (Models.FavouriteItem)this.listFavoriteItems.SelectedItem;
                this.MainWindow.LoadAddressFromOutside(obj.Address);
                this.Close();
            }
        }

        /// <summary>
        /// Method that is called when the editButton is being clicked: redirects the currentPage of the MainWindow to the favorite and closes the current form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editFavoriteAddressLabel_Click(object sender, EventArgs e)
        {
            if (this.listFavoriteItems.SelectedItem != null)
            {
                Models.FavouriteItem obj = (Models.FavouriteItem)this.listFavoriteItems.SelectedItem;
                int objIndex = this.FavoritesController.ListOfFavoriteItems().IndexOf(obj);
                obj.Address = this.editFavoriteAddressInput.Text;
                obj.Name = this.editFavoriteNameInput.Text;

                this.FavoritesController.UpdateFavorite(obj, objIndex);
                this.listFavoriteItems.Text = obj.ToString();

                if (objIndex >= 0 && objIndex < this.listFavoriteItems.Items.Count)
                {
                    this.listFavoriteItems.Items.RemoveAt(objIndex);
                    this.listFavoriteItems.Items.Insert(objIndex, obj);
                }

                // this.LoadFavoritesInComboBox();
            }
        }

        /// <summary>
        /// Method that is called when a new selection is made in the ComboBox. This updates the content of the Input Texts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listFavoriteItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listFavoriteItems.SelectedItem != null)
            {
                Models.FavouriteItem obj = (Models.FavouriteItem)this.listFavoriteItems.SelectedItem;
                this.editFavoriteAddressInput.Text = obj.Address;
                this.editFavoriteNameInput.Text = obj.Name;
            }
        }

        /// <summary>
        /// Method that is called when the deleteButton is being clicked: deletes the currently selected favorite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.listFavoriteItems.SelectedItem != null)
            {
                Models.FavouriteItem obj = (Models.FavouriteItem)this.listFavoriteItems.SelectedItem;
                int objIndex = this.FavoritesController.ListOfFavoriteItems().IndexOf(obj);
                this.FavoritesController.DeleteFavorite(objIndex);
                if (objIndex >=0 && objIndex < this.listFavoriteItems.Items.Count)
                {
                    this.listFavoriteItems.Items.RemoveAt(objIndex);
                    this.listFavoriteItems.Text = "";
                    this.editFavoriteAddressInput.Text = "";
                    this.editFavoriteNameInput.Text = "";
                }
            }
        }
    }
}
