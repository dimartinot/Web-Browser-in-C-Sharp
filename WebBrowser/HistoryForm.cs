using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebBrowser
{    
    /// <summary>
    /// Class of the History form, displaying the list of all visiting webpages
    /// </summary>
    public class HistoryForm : Form
    {
        private Label label1;
        private TextBox sortingTextBox;
        private ListBox listBox;

        /// <summary>
        /// <seealso cref="Controllers.HistoryController"/> instance to provide the History intelligence
        /// </summary>
        private Controllers.HistoryController HistoryController { get; set; }
        /// <summary>
        /// <seealso cref="MainWindow"/> instance to be able to interact back with it (for the display of a given favorite)
        /// </summary>
        private MainWindow MainWindowRef { get; set; }

        /// <summary>
        /// Class constructor calling the <seealso cref="InitializeComponent()"/> method (automatically generated).
        /// </summary>
        /// <param name="favoritesController"><seealso cref="Controllers.FavoritesController"/> instance</param>
        /// <param name="mainWindow"><seealso cref="MainWindow"/> instance</param>
        public HistoryForm(Controllers.HistoryController historyController, MainWindow MainWindowRef)
        {
            this.HistoryController = historyController;
            this.MainWindowRef = MainWindowRef;
            this.InitializeComponent();
        }

        /// <summary>
        /// Retrieve the current history from the controller, calls the <seealso cref="PopulateListBox(Models.History)"/> method and displays the current form
        /// </summary>
        public void ShowForm()
        {
            
            this.Text = String.Format("History: {0} elements", this.HistoryController.NumberOfAddresses());
            this.SetBounds(10, 10, 400, 400);
            /*
            listBox.Dock = DockStyle.Fill;
            listBox.Size = new System.Drawing.Size(200, 200);
            listBox.Location = new System.Drawing.Point(0, 0);
            */


            //this.Controls.Add(listBox);

            //this.ResumeLayout(false);
            this.PopulateListBox(this.HistoryController.GetCurrentHistory());

            this.ShowDialog();
            
        }

        /// <summary>
        /// Changes the content of the listBox based on the <seealso cref="Models.History"/> class instance provided
        /// </summary>
        /// <param name="history"></param>
        public void PopulateListBox(Models.History history)
        {
            listBox.Items.Clear();
            foreach (Models.HistoryItem historyItem in Controllers.HistoryController.GetListOfItemsFromHistory(history))
            {
                listBox.Items.Add(String.Format("{0}\t{1}", historyItem.AccessDate, historyItem.Address));
            }
        }

        /// <summary>
        /// Automatically generated method that holds all the design information of the current form
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sortingTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 16;
            this.listBox.Location = new System.Drawing.Point(0, 62);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(284, 196);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enter search criterias to sort your history entries:";
            // 
            // sortingTextBox
            // 
            this.sortingTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortingTextBox.Location = new System.Drawing.Point(0, 16);
            this.sortingTextBox.Name = "sortingTextBox";
            this.sortingTextBox.Size = new System.Drawing.Size(284, 22);
            this.sortingTextBox.TabIndex = 2;
            this.sortingTextBox.TextChanged += new System.EventHandler(this.SortingTextBox_TextChanged);
            // 
            // HistoryForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.sortingTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox);
            this.Name = "HistoryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        /// <summary>
        /// Method called when the sorting pattern of the input box has been changed. Calls the <seealso cref="Controllers.HistoryController.SortHistory(string)"/> method to sort the History according to this pattern and populates the ListBox with the newly sorted History
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SortingTextBox_TextChanged(object sender, EventArgs e)
        {
            Models.History history = this.HistoryController.SortHistory(this.sortingTextBox.Text);
            this.PopulateListBox(history);
        }

        /// <summary>
        /// Method called when a click happens on a given item of the listBox. Loads the page clicked and closes the current form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String itemContent = this.listBox.SelectedItem.ToString();
            String address = itemContent.Split('\t')[1];
            this.MainWindowRef.LoadAddressFromOutside(address);
            this.Close();
        }
    }
}
