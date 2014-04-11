namespace Hospital {
    partial class HospitalSystem {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.Logoutbtn = new System.Windows.Forms.Button();
            this.Searchbtn = new System.Windows.Forms.Button();
            this.Sealbl = new System.Windows.Forms.Label();
            this.Seatxt = new System.Windows.Forms.TextBox();
            this.PatInfolbl = new System.Windows.Forms.Label();
            this.currentRoomtxt = new System.Windows.Forms.Label();
            this.historyDataGridView = new System.Windows.Forms.DataGridView();
            this.addHistorybtn = new System.Windows.Forms.Button();
            this.addHistorytbx = new System.Windows.Forms.TextBox();
            this.ViewImgbtn = new System.Windows.Forms.Button();
            this.Surgerybtn = new System.Windows.Forms.Button();
            this.Xraybtn = new System.Windows.Forms.Button();
            this.Finishbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Logoutbtn
            // 
            this.Logoutbtn.Location = new System.Drawing.Point(825, 27);
            this.Logoutbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Logoutbtn.Name = "Logoutbtn";
            this.Logoutbtn.Size = new System.Drawing.Size(75, 23);
            this.Logoutbtn.TabIndex = 1;
            this.Logoutbtn.Text = "Logout";
            this.Logoutbtn.UseVisualStyleBackColor = true;
            this.Logoutbtn.Click += new System.EventHandler(this.Logoutbtn_Click);
            // 
            // Searchbtn
            // 
            this.Searchbtn.Location = new System.Drawing.Point(205, 23);
            this.Searchbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Searchbtn.Name = "Searchbtn";
            this.Searchbtn.Size = new System.Drawing.Size(100, 28);
            this.Searchbtn.TabIndex = 35;
            this.Searchbtn.Text = "Search";
            this.Searchbtn.UseVisualStyleBackColor = true;
            this.Searchbtn.Click += new System.EventHandler(this.Searchbtn_Click);
            // 
            // Sealbl
            // 
            this.Sealbl.AutoSize = true;
            this.Sealbl.Location = new System.Drawing.Point(9, 30);
            this.Sealbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Sealbl.Name = "Sealbl";
            this.Sealbl.Size = new System.Drawing.Size(79, 17);
            this.Sealbl.TabIndex = 34;
            this.Sealbl.Text = "Search PID";
            // 
            // Seatxt
            // 
            this.Seatxt.Location = new System.Drawing.Point(100, 26);
            this.Seatxt.Margin = new System.Windows.Forms.Padding(4);
            this.Seatxt.Name = "Seatxt";
            this.Seatxt.Size = new System.Drawing.Size(97, 22);
            this.Seatxt.TabIndex = 33;
            // 
            // PatInfolbl
            // 
            this.PatInfolbl.AutoSize = true;
            this.PatInfolbl.Location = new System.Drawing.Point(653, 23);
            this.PatInfolbl.Name = "PatInfolbl";
            this.PatInfolbl.Size = new System.Drawing.Size(0, 17);
            this.PatInfolbl.TabIndex = 36;
            // 
            // currentRoomtxt
            // 
            this.currentRoomtxt.AutoSize = true;
            this.currentRoomtxt.Location = new System.Drawing.Point(491, 23);
            this.currentRoomtxt.Name = "currentRoomtxt";
            this.currentRoomtxt.Size = new System.Drawing.Size(0, 17);
            this.currentRoomtxt.TabIndex = 37;
            // 
            // historyDataGridView
            // 
            this.historyDataGridView.AllowUserToAddRows = false;
            this.historyDataGridView.AllowUserToDeleteRows = false;
            this.historyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.historyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyDataGridView.Location = new System.Drawing.Point(47, 94);
            this.historyDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.historyDataGridView.Name = "historyDataGridView";
            this.historyDataGridView.ReadOnly = true;
            this.historyDataGridView.Size = new System.Drawing.Size(853, 185);
            this.historyDataGridView.TabIndex = 38;
            // 
            // addHistorybtn
            // 
            this.addHistorybtn.Location = new System.Drawing.Point(47, 343);
            this.addHistorybtn.Margin = new System.Windows.Forms.Padding(4);
            this.addHistorybtn.Name = "addHistorybtn";
            this.addHistorybtn.Size = new System.Drawing.Size(100, 28);
            this.addHistorybtn.TabIndex = 39;
            this.addHistorybtn.Text = "Add History";
            this.addHistorybtn.UseVisualStyleBackColor = true;
            this.addHistorybtn.Click += new System.EventHandler(this.addHistorybtn_Click);
            // 
            // addHistorytbx
            // 
            this.addHistorytbx.Location = new System.Drawing.Point(47, 313);
            this.addHistorytbx.Margin = new System.Windows.Forms.Padding(4);
            this.addHistorytbx.Name = "addHistorytbx";
            this.addHistorytbx.Size = new System.Drawing.Size(554, 22);
            this.addHistorytbx.TabIndex = 40;
            // 
            // ViewImgbtn
            // 
            this.ViewImgbtn.Location = new System.Drawing.Point(750, 373);
            this.ViewImgbtn.Name = "ViewImgbtn";
            this.ViewImgbtn.Size = new System.Drawing.Size(150, 30);
            this.ViewImgbtn.TabIndex = 41;
            this.ViewImgbtn.Text = "View Image";
            this.ViewImgbtn.UseVisualStyleBackColor = true;
            this.ViewImgbtn.Visible = false;
            this.ViewImgbtn.Click += new System.EventHandler(this.ViewImgbtn_Click);
            // 
            // Surgerybtn
            // 
            this.Surgerybtn.Location = new System.Drawing.Point(750, 409);
            this.Surgerybtn.Name = "Surgerybtn";
            this.Surgerybtn.Size = new System.Drawing.Size(150, 30);
            this.Surgerybtn.TabIndex = 42;
            this.Surgerybtn.Text = "Book Surgery";
            this.Surgerybtn.UseVisualStyleBackColor = true;
            this.Surgerybtn.Visible = false;
            this.Surgerybtn.Click += new System.EventHandler(this.Surgerybtn_Click);
            // 
            // Xraybtn
            // 
            this.Xraybtn.Location = new System.Drawing.Point(750, 446);
            this.Xraybtn.Name = "Xraybtn";
            this.Xraybtn.Size = new System.Drawing.Size(150, 30);
            this.Xraybtn.TabIndex = 43;
            this.Xraybtn.Text = "Book Xray";
            this.Xraybtn.UseVisualStyleBackColor = true;
            this.Xraybtn.Visible = false;
            this.Xraybtn.Click += new System.EventHandler(this.Xraybtn_Click);
            // 
            // Finishbtn
            // 
            this.Finishbtn.Location = new System.Drawing.Point(750, 373);
            this.Finishbtn.Name = "Finishbtn";
            this.Finishbtn.Size = new System.Drawing.Size(150, 30);
            this.Finishbtn.TabIndex = 44;
            this.Finishbtn.Text = "Finish";
            this.Finishbtn.UseVisualStyleBackColor = true;
            this.Finishbtn.Click += new System.EventHandler(this.Finishbtn_Click);
            // 
            // HospitalSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 526);
            this.Controls.Add(this.Finishbtn);
            this.Controls.Add(this.Xraybtn);
            this.Controls.Add(this.Surgerybtn);
            this.Controls.Add(this.ViewImgbtn);
            this.Controls.Add(this.addHistorytbx);
            this.Controls.Add(this.addHistorybtn);
            this.Controls.Add(this.historyDataGridView);
            this.Controls.Add(this.currentRoomtxt);
            this.Controls.Add(this.PatInfolbl);
            this.Controls.Add(this.Searchbtn);
            this.Controls.Add(this.Sealbl);
            this.Controls.Add(this.Seatxt);
            this.Controls.Add(this.Logoutbtn);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HospitalSystem";
            this.Text = "1";
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Logoutbtn;
        private System.Windows.Forms.Button Searchbtn;
        private System.Windows.Forms.Label Sealbl;
        private System.Windows.Forms.TextBox Seatxt;
        private System.Windows.Forms.Label PatInfolbl;
        private System.Windows.Forms.Label currentRoomtxt;
        private System.Windows.Forms.DataGridView historyDataGridView;
        private System.Windows.Forms.Button addHistorybtn;
        private System.Windows.Forms.TextBox addHistorytbx;
        private System.Windows.Forms.Button ViewImgbtn;
        private System.Windows.Forms.Button Surgerybtn;
        private System.Windows.Forms.Button Xraybtn;
        private System.Windows.Forms.Button Finishbtn;
    }
}