namespace WebBrowser
{
    partial class HomePageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.InputBoxHomePageInputLabel = new System.Windows.Forms.Label();
            this.inputChangeHomePage = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.confirmbuttonChangeHomePage = new System.Windows.Forms.Button();
            this.cancelbuttonChangeHomePage = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.currentHomePageAddressLabel = new System.Windows.Forms.Label();
            this.currentHomeAddress = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.07921F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.92079F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(284, 223);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.InputBoxHomePageInputLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.inputChangeHomePage, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 80);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(278, 99);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // InputBoxHomePageInputLabel
            // 
            this.InputBoxHomePageInputLabel.AutoSize = true;
            this.InputBoxHomePageInputLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputBoxHomePageInputLabel.Location = new System.Drawing.Point(3, 0);
            this.InputBoxHomePageInputLabel.Name = "InputBoxHomePageInputLabel";
            this.InputBoxHomePageInputLabel.Size = new System.Drawing.Size(251, 40);
            this.InputBoxHomePageInputLabel.TabIndex = 0;
            this.InputBoxHomePageInputLabel.Text = "Please change the address in this field:";
            // 
            // inputChangeHomePage
            // 
            this.inputChangeHomePage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputChangeHomePage.Location = new System.Drawing.Point(3, 52);
            this.inputChangeHomePage.Name = "inputChangeHomePage";
            this.inputChangeHomePage.Size = new System.Drawing.Size(272, 26);
            this.inputChangeHomePage.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.confirmbuttonChangeHomePage, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cancelbuttonChangeHomePage, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 185);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(278, 35);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // confirmbuttonChangeHomePage
            // 
            this.confirmbuttonChangeHomePage.Location = new System.Drawing.Point(3, 3);
            this.confirmbuttonChangeHomePage.Name = "confirmbuttonChangeHomePage";
            this.confirmbuttonChangeHomePage.Size = new System.Drawing.Size(75, 23);
            this.confirmbuttonChangeHomePage.TabIndex = 0;
            this.confirmbuttonChangeHomePage.Text = "Confirm";
            this.confirmbuttonChangeHomePage.UseVisualStyleBackColor = true;
            this.confirmbuttonChangeHomePage.Click += new System.EventHandler(this.ConfirmbuttonChangeHomePage_Click);
            // 
            // cancelbuttonChangeHomePage
            // 
            this.cancelbuttonChangeHomePage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelbuttonChangeHomePage.Location = new System.Drawing.Point(200, 3);
            this.cancelbuttonChangeHomePage.Name = "cancelbuttonChangeHomePage";
            this.cancelbuttonChangeHomePage.Size = new System.Drawing.Size(75, 23);
            this.cancelbuttonChangeHomePage.TabIndex = 1;
            this.cancelbuttonChangeHomePage.Text = "Cancel";
            this.cancelbuttonChangeHomePage.UseVisualStyleBackColor = true;
            this.cancelbuttonChangeHomePage.Click += new System.EventHandler(this.CancelbuttonChangeHomePage_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.currentHomePageAddressLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.currentHomeAddress, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(278, 71);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // currentHomePageAddressLabel
            // 
            this.currentHomePageAddressLabel.AutoSize = true;
            this.currentHomePageAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentHomePageAddressLabel.Location = new System.Drawing.Point(3, 0);
            this.currentHomePageAddressLabel.Name = "currentHomePageAddressLabel";
            this.currentHomePageAddressLabel.Size = new System.Drawing.Size(217, 20);
            this.currentHomePageAddressLabel.TabIndex = 0;
            this.currentHomePageAddressLabel.Text = "Current Home Page Address:";
            // 
            // currentHomeAddress
            // 
            this.currentHomeAddress.AutoSize = true;
            this.currentHomeAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentHomeAddress.Location = new System.Drawing.Point(3, 35);
            this.currentHomeAddress.Name = "currentHomeAddress";
            this.currentHomeAddress.Size = new System.Drawing.Size(108, 13);
            this.currentHomeAddress.TabIndex = 1;
            this.currentHomeAddress.Text = "No Home Address";
            // 
            // HomePageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 223);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "HomePageForm";
            this.Text = "HomePageForm";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label InputBoxHomePageInputLabel;
        private System.Windows.Forms.TextBox inputChangeHomePage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button confirmbuttonChangeHomePage;
        private System.Windows.Forms.Button cancelbuttonChangeHomePage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label currentHomePageAddressLabel;
        private System.Windows.Forms.Label currentHomeAddress;
    }
}