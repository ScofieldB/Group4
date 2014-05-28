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
            this.Logoutbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Logoutbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Logoutbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logoutbtn.FlatAppearance.BorderSize = 0;
            this.Logoutbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logoutbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logoutbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Logoutbtn.Location = new System.Drawing.Point(1217, 32);
            this.Logoutbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Logoutbtn.Name = "Logoutbtn";
            this.Logoutbtn.Size = new System.Drawing.Size(132, 28);
            this.Logoutbtn.TabIndex = 1;
            this.Logoutbtn.Text = "Logout";
            this.Logoutbtn.UseVisualStyleBackColor = true;
            this.Logoutbtn.Click += new System.EventHandler(this.Logoutbtn_Click);
            // 
            // Searchbtn
            // 
            this.Searchbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Searchbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Searchbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Searchbtn.FlatAppearance.BorderSize = 0;
            this.Searchbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Searchbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Searchbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Searchbtn.Location = new System.Drawing.Point(309, 27);
            this.Searchbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Searchbtn.Name = "Searchbtn";
            this.Searchbtn.Size = new System.Drawing.Size(132, 28);
            this.Searchbtn.TabIndex = 35;
            this.Searchbtn.Text = "Search";
            this.Searchbtn.UseVisualStyleBackColor = true;
            this.Searchbtn.Click += new System.EventHandler(this.Searchbtn_Click);
            // 
            // Sealbl
            // 
            this.Sealbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Sealbl.AutoSize = true;
            this.Sealbl.Location = new System.Drawing.Point(16, 32);
            this.Sealbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Sealbl.Name = "Sealbl";
            this.Sealbl.Size = new System.Drawing.Size(118, 17);
            this.Sealbl.TabIndex = 34;
            this.Sealbl.Text = "Search Surname:";
            // 
            // Seatxt
            // 
            this.Seatxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Seatxt.Location = new System.Drawing.Point(141, 27);
            this.Seatxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Seatxt.Name = "Seatxt";
            this.Seatxt.Size = new System.Drawing.Size(160, 22);
            this.Seatxt.TabIndex = 33;
            // 
            // PatInfolbl
            // 
            this.PatInfolbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PatInfolbl.AutoSize = true;
            this.PatInfolbl.Location = new System.Drawing.Point(935, 38);
            this.PatInfolbl.Name = "PatInfolbl";
            this.PatInfolbl.Size = new System.Drawing.Size(0, 17);
            this.PatInfolbl.TabIndex = 36;
            // 
            // currentRoomtxt
            // 
            this.currentRoomtxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.currentRoomtxt.AutoSize = true;
            this.currentRoomtxt.Location = new System.Drawing.Point(589, 34);
            this.currentRoomtxt.Name = "currentRoomtxt";
            this.currentRoomtxt.Size = new System.Drawing.Size(0, 17);
            this.currentRoomtxt.TabIndex = 37;
            // 
            // historyDataGridView
            // 
            this.historyDataGridView.AllowUserToAddRows = false;
            this.historyDataGridView.AllowUserToDeleteRows = false;
            this.historyDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.historyDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.historyDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.historyDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.historyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyDataGridView.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.historyDataGridView.Location = new System.Drawing.Point(16, 94);
            this.historyDataGridView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.historyDataGridView.Name = "historyDataGridView";
            this.historyDataGridView.ReadOnly = true;
            this.historyDataGridView.Size = new System.Drawing.Size(1333, 639);
            this.historyDataGridView.TabIndex = 38;
            // 
            // addHistorybtn
            // 
            this.addHistorybtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addHistorybtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.addHistorybtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addHistorybtn.FlatAppearance.BorderSize = 0;
            this.addHistorybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addHistorybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addHistorybtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addHistorybtn.Location = new System.Drawing.Point(20, 825);
            this.addHistorybtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addHistorybtn.Name = "addHistorybtn";
            this.addHistorybtn.Size = new System.Drawing.Size(132, 28);
            this.addHistorybtn.TabIndex = 39;
            this.addHistorybtn.Text = "Add History";
            this.addHistorybtn.UseVisualStyleBackColor = true;
            this.addHistorybtn.Click += new System.EventHandler(this.addHistorybtn_Click);
            // 
            // addHistorytbx
            // 
            this.addHistorytbx.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addHistorytbx.Location = new System.Drawing.Point(20, 794);
            this.addHistorytbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addHistorytbx.Name = "addHistorytbx";
            this.addHistorytbx.Size = new System.Drawing.Size(553, 22);
            this.addHistorytbx.TabIndex = 40;
            // 
            // ViewImgbtn
            // 
            this.ViewImgbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ViewImgbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.ViewImgbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ViewImgbtn.FlatAppearance.BorderSize = 0;
            this.ViewImgbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ViewImgbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewImgbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ViewImgbtn.Location = new System.Drawing.Point(1219, 826);
            this.ViewImgbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ViewImgbtn.Name = "ViewImgbtn";
            this.ViewImgbtn.Size = new System.Drawing.Size(132, 28);
            this.ViewImgbtn.TabIndex = 41;
            this.ViewImgbtn.Text = "Images";
            this.ViewImgbtn.UseVisualStyleBackColor = true;
            this.ViewImgbtn.Visible = false;
            this.ViewImgbtn.Click += new System.EventHandler(this.ViewImgbtn_Click);
            // 
            // Surgerybtn
            // 
            this.Surgerybtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Surgerybtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Surgerybtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Surgerybtn.FlatAppearance.BorderSize = 0;
            this.Surgerybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Surgerybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Surgerybtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Surgerybtn.Location = new System.Drawing.Point(1219, 862);
            this.Surgerybtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Surgerybtn.Name = "Surgerybtn";
            this.Surgerybtn.Size = new System.Drawing.Size(132, 28);
            this.Surgerybtn.TabIndex = 42;
            this.Surgerybtn.Text = "Book Surgery";
            this.Surgerybtn.UseVisualStyleBackColor = true;
            this.Surgerybtn.Visible = false;
            this.Surgerybtn.Click += new System.EventHandler(this.Surgerybtn_Click);
            // 
            // Imagingbtn
            // 
            this.Imagingbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Imagingbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Imagingbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Imagingbtn.FlatAppearance.BorderSize = 0;
            this.Imagingbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Imagingbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Imagingbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Imagingbtn.Location = new System.Drawing.Point(1219, 898);
            this.Imagingbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Imagingbtn.Name = "Imagingbtn";
            this.Imagingbtn.Size = new System.Drawing.Size(132, 28);
            this.Imagingbtn.TabIndex = 43;
            this.Imagingbtn.Text = "Book Imaging";
            this.Imagingbtn.UseVisualStyleBackColor = true;
            this.Imagingbtn.Visible = false;
            this.Imagingbtn.Click += new System.EventHandler(this.Imagingbtn_Click);
            // 
            // Finishbtn
            // 
            this.Finishbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Finishbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Finishbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Finishbtn.FlatAppearance.BorderSize = 0;
            this.Finishbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Finishbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Finishbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Finishbtn.Location = new System.Drawing.Point(1219, 791);
            this.Finishbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Finishbtn.Name = "Finishbtn";
            this.Finishbtn.Size = new System.Drawing.Size(132, 28);
            this.Finishbtn.TabIndex = 44;
            this.Finishbtn.Text = "Finish";
            this.Finishbtn.UseVisualStyleBackColor = true;
            this.Finishbtn.Click += new System.EventHandler(this.Finishbtn_Click);
            // 
            // HospitalSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1365, 945);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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