﻿namespace Hospital {
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
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Logoutbtn
            // 
            this.Logoutbtn.Location = new System.Drawing.Point(638, 21);
            this.Logoutbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Logoutbtn.Name = "Logoutbtn";
            this.Logoutbtn.Size = new System.Drawing.Size(56, 19);
            this.Logoutbtn.TabIndex = 1;
            this.Logoutbtn.Text = "Logout";
            this.Logoutbtn.UseVisualStyleBackColor = true;
            this.Logoutbtn.Click += new System.EventHandler(this.Logoutbtn_Click);
            // 
            // Searchbtn
            // 
            this.Searchbtn.Location = new System.Drawing.Point(154, 19);
            this.Searchbtn.Name = "Searchbtn";
            this.Searchbtn.Size = new System.Drawing.Size(75, 23);
            this.Searchbtn.TabIndex = 35;
            this.Searchbtn.Text = "Search";
            this.Searchbtn.UseVisualStyleBackColor = true;
            this.Searchbtn.Click += new System.EventHandler(this.Searchbtn_Click);
            // 
            // Sealbl
            // 
            this.Sealbl.AutoSize = true;
            this.Sealbl.Location = new System.Drawing.Point(7, 24);
            this.Sealbl.Name = "Sealbl";
            this.Sealbl.Size = new System.Drawing.Size(62, 13);
            this.Sealbl.TabIndex = 34;
            this.Sealbl.Text = "Search PID";
            // 
            // Seatxt
            // 
            this.Seatxt.Location = new System.Drawing.Point(75, 21);
            this.Seatxt.Name = "Seatxt";
            this.Seatxt.Size = new System.Drawing.Size(74, 20);
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
            this.historyDataGridView.Size = new System.Drawing.Size(633, 150);
            this.historyDataGridView.TabIndex = 38;
            // 
            // addHistorybtn
            // 
            this.addHistorybtn.Location = new System.Drawing.Point(593, 342);
            this.addHistorybtn.Name = "addHistorybtn";
            this.addHistorybtn.Size = new System.Drawing.Size(75, 23);
            this.addHistorybtn.TabIndex = 39;
            this.addHistorybtn.Text = "Add History";
            this.addHistorybtn.UseVisualStyleBackColor = true;
            this.addHistorybtn.Click += new System.EventHandler(this.addHistorybtn_Click);
            // 
            // addHistorytbx
            // 
            this.addHistorytbx.Location = new System.Drawing.Point(35, 254);
            this.addHistorytbx.Name = "addHistorytbx";
            this.addHistorytbx.Size = new System.Drawing.Size(419, 20);
            this.addHistorytbx.TabIndex = 40;
            // 
            // HospitalSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 427);
            this.Controls.Add(this.addHistorytbx);
            this.Controls.Add(this.addHistorybtn);
            this.Controls.Add(this.historyDataGridView);
            this.Controls.Add(this.currentRoomtxt);
            this.Controls.Add(this.PatInfolbl);
            this.Controls.Add(this.Searchbtn);
            this.Controls.Add(this.Sealbl);
            this.Controls.Add(this.Seatxt);
            this.Controls.Add(this.Logoutbtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HospitalSystem";
            this.Text = "HospitalSystem";
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
    }
}