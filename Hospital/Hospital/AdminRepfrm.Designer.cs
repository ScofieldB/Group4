namespace Hospital {
    partial class AdminRepfrm {
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
            this.TestRepbtn = new System.Windows.Forms.Button();
            this.LogBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.Desc = new System.Windows.Forms.Label();
            this.Outstandingbtn = new System.Windows.Forms.Button();
            this.Roomsbtn = new System.Windows.Forms.Button();
            this.CountStaffBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestRepbtn
            // 
            this.TestRepbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TestRepbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.TestRepbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TestRepbtn.FlatAppearance.BorderSize = 0;
            this.TestRepbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TestRepbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.TestRepbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TestRepbtn.Location = new System.Drawing.Point(20, 77);
            this.TestRepbtn.Margin = new System.Windows.Forms.Padding(4);
            this.TestRepbtn.Name = "TestRepbtn";
            this.TestRepbtn.Size = new System.Drawing.Size(132, 51);
            this.TestRepbtn.TabIndex = 1;
            this.TestRepbtn.Text = "Test Rep";
            this.TestRepbtn.UseVisualStyleBackColor = true;
            this.TestRepbtn.Click += new System.EventHandler(this.TestRepbtn_Click);
            // 
            // LogBtn
            // 
            this.LogBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogBtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.LogBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LogBtn.FlatAppearance.BorderSize = 0;
            this.LogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.LogBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogBtn.Location = new System.Drawing.Point(279, 15);
            this.LogBtn.Margin = new System.Windows.Forms.Padding(4);
            this.LogBtn.Name = "LogBtn";
            this.LogBtn.Size = new System.Drawing.Size(132, 28);
            this.LogBtn.TabIndex = 2;
            this.LogBtn.Text = "Logout";
            this.LogBtn.UseVisualStyleBackColor = false;
            this.LogBtn.Click += new System.EventHandler(this.LogBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BackBtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.BackBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackBtn.FlatAppearance.BorderSize = 0;
            this.BackBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.BackBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackBtn.Location = new System.Drawing.Point(279, 278);
            this.BackBtn.Margin = new System.Windows.Forms.Padding(4);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(132, 28);
            this.BackBtn.TabIndex = 3;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // Desc
            // 
            this.Desc.AutoSize = true;
            this.Desc.Location = new System.Drawing.Point(29, 45);
            this.Desc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Desc.Name = "Desc";
            this.Desc.Size = new System.Drawing.Size(123, 17);
            this.Desc.TabIndex = 4;
            this.Desc.Text = "Available Reports:";
            // 
            // Outstandingbtn
            // 
            this.Outstandingbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Outstandingbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Outstandingbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Outstandingbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.Outstandingbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Outstandingbtn.Location = new System.Drawing.Point(20, 135);
            this.Outstandingbtn.Name = "Outstandingbtn";
            this.Outstandingbtn.Size = new System.Drawing.Size(132, 51);
            this.Outstandingbtn.TabIndex = 5;
            this.Outstandingbtn.Text = "Outstanding Charges";
            this.Outstandingbtn.UseVisualStyleBackColor = true;
            this.Outstandingbtn.Click += new System.EventHandler(this.Outstandingbtn_Click);
            // 
            // Roomsbtn
            // 
            this.Roomsbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Roomsbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Roomsbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Roomsbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.Roomsbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Roomsbtn.Location = new System.Drawing.Point(20, 192);
            this.Roomsbtn.Name = "Roomsbtn";
            this.Roomsbtn.Size = new System.Drawing.Size(132, 51);
            this.Roomsbtn.TabIndex = 6;
            this.Roomsbtn.Text = "Current Rooms";
            this.Roomsbtn.UseVisualStyleBackColor = true;
            this.Roomsbtn.Click += new System.EventHandler(this.Roomsbtn_Click);
            // 
            // CountStaffBtn
            // 
            this.CountStaffBtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.CountStaffBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CountStaffBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CountStaffBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.CountStaffBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CountStaffBtn.Location = new System.Drawing.Point(203, 77);
            this.CountStaffBtn.Name = "CountStaffBtn";
            this.CountStaffBtn.Size = new System.Drawing.Size(132, 51);
            this.CountStaffBtn.TabIndex = 7;
            this.CountStaffBtn.Text = "Count of Roles";
            this.CountStaffBtn.UseVisualStyleBackColor = true;
            this.CountStaffBtn.Click += new System.EventHandler(this.CountStaffBtn_Click);
            // 
            // AdminRepfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.BackgroundImage = global::Hospital.Properties.Resources.pagebackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(427, 321);
            this.Controls.Add(this.CountStaffBtn);
            this.Controls.Add(this.Roomsbtn);
            this.Controls.Add(this.Outstandingbtn);
            this.Controls.Add(this.Desc);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.LogBtn);
            this.Controls.Add(this.TestRepbtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AdminRepfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminRepfrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TestRepbtn;
        private System.Windows.Forms.Button LogBtn;
        private System.Windows.Forms.Button BackBtn;
        private System.Windows.Forms.Label Desc;
        private System.Windows.Forms.Button Outstandingbtn;
        private System.Windows.Forms.Button Roomsbtn;
        private System.Windows.Forms.Button CountStaffBtn;
    }
}