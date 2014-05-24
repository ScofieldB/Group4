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
            this.Imagingbtn = new System.Windows.Forms.Button();
            this.Finishbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Logoutbtn
            // 
            this.Logoutbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Logoutbtn.FlatAppearance.BorderSize = 0;
            this.Logoutbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logoutbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logoutbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Logoutbtn.Location = new System.Drawing.Point(609, 20);
            this.Logoutbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Logoutbtn.Name = "Logoutbtn";
            this.Logoutbtn.Size = new System.Drawing.Size(99, 23);
            this.Logoutbtn.TabIndex = 1;
            this.Logoutbtn.Text = "Logout";
            this.Logoutbtn.UseVisualStyleBackColor = true;
            this.Logoutbtn.Click += new System.EventHandler(this.Logoutbtn_Click);
            // 
            // Searchbtn
            // 
            this.Searchbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Searchbtn.FlatAppearance.BorderSize = 0;
            this.Searchbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Searchbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Searchbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Searchbtn.Location = new System.Drawing.Point(257, 22);
            this.Searchbtn.Name = "Searchbtn";
            this.Searchbtn.Size = new System.Drawing.Size(99, 23);
            this.Searchbtn.TabIndex = 35;
            this.Searchbtn.Text = "Search";
            this.Searchbtn.UseVisualStyleBackColor = true;
            this.Searchbtn.Click += new System.EventHandler(this.Searchbtn_Click);
            // 
            // Sealbl
            // 
            this.Sealbl.AutoSize = true;
            this.Sealbl.Location = new System.Drawing.Point(37, 26);
            this.Sealbl.Name = "Sealbl";
            this.Sealbl.Size = new System.Drawing.Size(89, 13);
            this.Sealbl.TabIndex = 34;
            this.Sealbl.Text = "Search Surname:";
            // 
            // Seatxt
            // 
            this.Seatxt.Location = new System.Drawing.Point(131, 22);
            this.Seatxt.Name = "Seatxt";
            this.Seatxt.Size = new System.Drawing.Size(121, 20);
            this.Seatxt.TabIndex = 33;
            // 
            // PatInfolbl
            // 
            this.PatInfolbl.AutoSize = true;
            this.PatInfolbl.Location = new System.Drawing.Point(490, 19);
            this.PatInfolbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PatInfolbl.Name = "PatInfolbl";
            this.PatInfolbl.Size = new System.Drawing.Size(0, 13);
            this.PatInfolbl.TabIndex = 36;
            // 
            // currentRoomtxt
            // 
            this.currentRoomtxt.AutoSize = true;
            this.currentRoomtxt.Location = new System.Drawing.Point(368, 19);
            this.currentRoomtxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentRoomtxt.Name = "currentRoomtxt";
            this.currentRoomtxt.Size = new System.Drawing.Size(0, 13);
            this.currentRoomtxt.TabIndex = 37;
            // 
            // historyDataGridView
            // 
            this.historyDataGridView.AllowUserToAddRows = false;
            this.historyDataGridView.AllowUserToDeleteRows = false;
            this.historyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.historyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyDataGridView.Location = new System.Drawing.Point(35, 76);
            this.historyDataGridView.Name = "historyDataGridView";
            this.historyDataGridView.ReadOnly = true;
            this.historyDataGridView.Size = new System.Drawing.Size(640, 150);
            this.historyDataGridView.TabIndex = 38;
            // 
            // addHistorybtn
            // 
            this.addHistorybtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.addHistorybtn.FlatAppearance.BorderSize = 0;
            this.addHistorybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addHistorybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addHistorybtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addHistorybtn.Location = new System.Drawing.Point(35, 279);
            this.addHistorybtn.Name = "addHistorybtn";
            this.addHistorybtn.Size = new System.Drawing.Size(99, 23);
            this.addHistorybtn.TabIndex = 39;
            this.addHistorybtn.Text = "Add History";
            this.addHistorybtn.UseVisualStyleBackColor = true;
            this.addHistorybtn.Click += new System.EventHandler(this.addHistorybtn_Click);
            // 
            // addHistorytbx
            // 
            this.addHistorytbx.Location = new System.Drawing.Point(35, 254);
            this.addHistorytbx.Name = "addHistorytbx";
            this.addHistorytbx.Size = new System.Drawing.Size(416, 20);
            this.addHistorytbx.TabIndex = 40;
            // 
            // ViewImgbtn
            // 
            this.ViewImgbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.ViewImgbtn.FlatAppearance.BorderSize = 0;
            this.ViewImgbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewImgbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewImgbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ViewImgbtn.Location = new System.Drawing.Point(562, 303);
            this.ViewImgbtn.Margin = new System.Windows.Forms.Padding(2);
            this.ViewImgbtn.Name = "ViewImgbtn";
            this.ViewImgbtn.Size = new System.Drawing.Size(99, 23);
            this.ViewImgbtn.TabIndex = 41;
            this.ViewImgbtn.Text = "View Image";
            this.ViewImgbtn.UseVisualStyleBackColor = true;
            this.ViewImgbtn.Visible = false;
            this.ViewImgbtn.Click += new System.EventHandler(this.ViewImgbtn_Click);
            // 
            // Surgerybtn
            // 
            this.Surgerybtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Surgerybtn.FlatAppearance.BorderSize = 0;
            this.Surgerybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Surgerybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Surgerybtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Surgerybtn.Location = new System.Drawing.Point(562, 332);
            this.Surgerybtn.Margin = new System.Windows.Forms.Padding(2);
            this.Surgerybtn.Name = "Surgerybtn";
            this.Surgerybtn.Size = new System.Drawing.Size(99, 23);
            this.Surgerybtn.TabIndex = 42;
            this.Surgerybtn.Text = "Book Surgery";
            this.Surgerybtn.UseVisualStyleBackColor = true;
            this.Surgerybtn.Visible = false;
            this.Surgerybtn.Click += new System.EventHandler(this.Surgerybtn_Click);
            // 
            // Imagingbtn
            // 
            this.Imagingbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Imagingbtn.FlatAppearance.BorderSize = 0;
            this.Imagingbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Imagingbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Imagingbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Imagingbtn.Location = new System.Drawing.Point(562, 362);
            this.Imagingbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Imagingbtn.Name = "Imagingbtn";
            this.Imagingbtn.Size = new System.Drawing.Size(99, 23);
            this.Imagingbtn.TabIndex = 43;
            this.Imagingbtn.Text = "Book Imaging";
            this.Imagingbtn.UseVisualStyleBackColor = true;
            this.Imagingbtn.Visible = false;
            this.Imagingbtn.Click += new System.EventHandler(this.Imagingbtn_Click);
            // 
            // Finishbtn
            // 
            this.Finishbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Finishbtn.FlatAppearance.BorderSize = 0;
            this.Finishbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Finishbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Finishbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Finishbtn.Location = new System.Drawing.Point(562, 275);
            this.Finishbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Finishbtn.Name = "Finishbtn";
            this.Finishbtn.Size = new System.Drawing.Size(99, 23);
            this.Finishbtn.TabIndex = 44;
            this.Finishbtn.Text = "Finish";
            this.Finishbtn.UseVisualStyleBackColor = true;
            this.Finishbtn.Click += new System.EventHandler(this.Finishbtn_Click);
            // 
            // HospitalSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(719, 427);
            this.Controls.Add(this.Finishbtn);
            this.Controls.Add(this.Imagingbtn);
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HospitalSystem";
            this.Text = "1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.Button Imagingbtn;
        private System.Windows.Forms.Button Finishbtn;
    }
}