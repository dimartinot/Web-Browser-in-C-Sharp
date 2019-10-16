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
        private ListBox listBox;

        private Controllers.HistoryController historyController { get; set; }

        public HistoryForm(Controllers.HistoryController historyController)
        {
            this.historyController = historyController;
            this.InitializeComponent();
        }

        public void ShowForm()
        {
            
            this.Text = String.Format("History: {0} elements", this.historyController.NumberOfAddresses());
            this.SetBounds(10, 10, 400, 400);
            /*
            listBox.Dock = DockStyle.Fill;
            listBox.Size = new System.Drawing.Size(200, 200);
            listBox.Location = new System.Drawing.Point(0, 0);
            */
            foreach (Models.HistoryItem historyItem in this.historyController.ListOfHistoryItems())
            {
                listBox.Items.Add(String.Format("{0}\t{1}", historyItem.AccessDate, historyItem.Address));
            }

            this.Controls.Add(listBox);

            this.ResumeLayout(false);


            this.ShowDialog();
            
        }

        private void InitializeComponent()
        {
            this.listBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(0, 62);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(284, 199);
            this.listBox.TabIndex = 0;
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
            // HistoryForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
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
    }
}
