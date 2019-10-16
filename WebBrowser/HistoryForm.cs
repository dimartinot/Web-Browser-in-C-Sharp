using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WebBrowser
{
    public class HistoryForm : Form
    {
        private Label label1;
        private TextBox sortingTextBox;
        private ListBox listBox;

        private Controllers.HistoryController HistoryController { get; set; }

        private MainWindow MainWindowRef { get; set; }

        public HistoryForm(Controllers.HistoryController historyController, MainWindow MainWindowRef)
        {
            this.HistoryController = historyController;
            this.MainWindowRef = MainWindowRef;
            this.InitializeComponent();
        }

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

        public void PopulateListBox(Models.History history)
        {
            listBox.Items.Clear();
            foreach (Models.HistoryItem historyItem in Controllers.HistoryController.GetListOfItemsFromHistory(history))
            {
                listBox.Items.Add(String.Format("{0}\t{1}", historyItem.AccessDate, historyItem.Address));
            }
        }

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
            this.Load += new System.EventHandler(this.HistoryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {

        }

        private void SortingTextBox_TextChanged(object sender, EventArgs e)
        {
            Models.History history = this.HistoryController.SortHistory(this.sortingTextBox.Text);
            this.PopulateListBox(history);
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            String itemContent = this.listBox.SelectedItem.ToString();
            String address = itemContent.Split('\t')[1];
            this.MainWindowRef.LoadAddressFromOutside(address);
            this.Close();
        }
    }
}
