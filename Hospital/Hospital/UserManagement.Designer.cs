namespace Hospital {
    partial class UserManagement {
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
            this.Rolecmb = new System.Windows.Forms.ComboBox();
            this.Rolelbl = new System.Windows.Forms.Label();
            this.Usernametxt = new System.Windows.Forms.TextBox();
            this.Usernamelbl = new System.Windows.Forms.Label();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.Newbtn = new System.Windows.Forms.Button();
            this.LogBtn = new System.Windows.Forms.Button();
            this.Updatebtn = new System.Windows.Forms.Button();
            this.Querybtn = new System.Windows.Forms.Button();
            this.Backbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Rolecmb
            // 
            this.Rolecmb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Rolecmb.FormattingEnabled = true;
            this.Rolecmb.Items.AddRange(new object[] {
            "Doctor",
            "Nurse",
            "MedTech",
            "Receptionist",
            "Admin"});
            this.Rolecmb.Location = new System.Drawing.Point(304, 138);
            this.Rolecmb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Rolecmb.Name = "Rolecmb";
            this.Rolecmb.Size = new System.Drawing.Size(229, 24);
            this.Rolecmb.TabIndex = 20;
            // 
            // Rolelbl
            // 
            this.Rolelbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Rolelbl.AutoSize = true;
            this.Rolelbl.Location = new System.Drawing.Point(258, 144);
            this.Rolelbl.Name = "Rolelbl";
            this.Rolelbl.Size = new System.Drawing.Size(41, 17);
            this.Rolelbl.TabIndex = 19;
            this.Rolelbl.Text = "Role:";
            // 
            // Usernametxt
            // 
            this.Usernametxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Usernametxt.Location = new System.Drawing.Point(304, 112);
            this.Usernametxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Usernametxt.Name = "Usernametxt";
            this.Usernametxt.Size = new System.Drawing.Size(229, 22);
            this.Usernametxt.TabIndex = 18;
            // 
            // Usernamelbl
            // 
            this.Usernamelbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Usernamelbl.AutoSize = true;
            this.Usernamelbl.Location = new System.Drawing.Point(240, 115);
            this.Usernamelbl.Name = "Usernamelbl";
            this.Usernamelbl.Size = new System.Drawing.Size(58, 17);
            this.Usernamelbl.TabIndex = 17;
            this.Usernamelbl.Text = "Staff ID:";
            // 
            // Deletebtn
            // 
            this.Deletebtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Deletebtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Deletebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Deletebtn.FlatAppearance.BorderSize = 0;
            this.Deletebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Deletebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deletebtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Deletebtn.Location = new System.Drawing.Point(38, 191);
            this.Deletebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(132, 28);
            this.Deletebtn.TabIndex = 16;
            this.Deletebtn.Text = "Delete User";
            this.Deletebtn.UseVisualStyleBackColor = true;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // Newbtn
            // 
            this.Newbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Newbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Newbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Newbtn.FlatAppearance.BorderSize = 0;
            this.Newbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Newbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Newbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Newbtn.Location = new System.Drawing.Point(38, 127);
            this.Newbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Newbtn.Name = "Newbtn";
            this.Newbtn.Size = new System.Drawing.Size(132, 28);
            this.Newbtn.TabIndex = 15;
            this.Newbtn.Text = "New User";
            this.Newbtn.UseVisualStyleBackColor = true;
            this.Newbtn.Click += new System.EventHandler(this.Newbtn_Click);
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
            this.LogBtn.Location = new System.Drawing.Point(536, 22);
            this.LogBtn.Margin = new System.Windows.Forms.Padding(4);
            this.LogBtn.Name = "LogBtn";
            this.LogBtn.Size = new System.Drawing.Size(132, 28);
            this.LogBtn.TabIndex = 21;
            this.LogBtn.Text = "Logout";
            this.LogBtn.UseVisualStyleBackColor = false;
            this.LogBtn.Click += new System.EventHandler(this.LogBtn_Click);
            // 
            // Updatebtn
            // 
            this.Updatebtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Updatebtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Updatebtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Updatebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Updatebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.Updatebtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Updatebtn.Location = new System.Drawing.Point(38, 159);
            this.Updatebtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.Size = new System.Drawing.Size(132, 28);
            this.Updatebtn.TabIndex = 22;
            this.Updatebtn.Text = "Update User";
            this.Updatebtn.UseVisualStyleBackColor = true;
            this.Updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // Querybtn
            // 
            this.Querybtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Querybtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Querybtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Querybtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Querybtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.Querybtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Querybtn.Location = new System.Drawing.Point(38, 94);
            this.Querybtn.Name = "Querybtn";
            this.Querybtn.Size = new System.Drawing.Size(132, 28);
            this.Querybtn.TabIndex = 23;
            this.Querybtn.Text = "Query User";
            this.Querybtn.UseVisualStyleBackColor = true;
            this.Querybtn.Click += new System.EventHandler(this.Querybtn_Click);
            // 
            // Backbtn
            // 
            this.Backbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Backbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Backbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Backbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Backbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.Backbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Backbtn.Location = new System.Drawing.Point(536, 286);
            this.Backbtn.Name = "Backbtn";
            this.Backbtn.Size = new System.Drawing.Size(132, 28);
            this.Backbtn.TabIndex = 24;
            this.Backbtn.Text = "Back";
            this.Backbtn.UseVisualStyleBackColor = true;
            this.Backbtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.BackgroundImage = global::Hospital.Properties.Resources.pagebackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(701, 342);
            this.Controls.Add(this.Backbtn);
            this.Controls.Add(this.Querybtn);
            this.Controls.Add(this.Updatebtn);
            this.Controls.Add(this.LogBtn);
            this.Controls.Add(this.Rolecmb);
            this.Controls.Add(this.Rolelbl);
            this.Controls.Add(this.Usernametxt);
            this.Controls.Add(this.Usernamelbl);
            this.Controls.Add(this.Deletebtn);
            this.Controls.Add(this.Newbtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "UserManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UserManagement";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Rolecmb;
        private System.Windows.Forms.Label Rolelbl;
        private System.Windows.Forms.TextBox Usernametxt;
        private System.Windows.Forms.Label Usernamelbl;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.Button Newbtn;
        private System.Windows.Forms.Button LogBtn;
        private System.Windows.Forms.Button Updatebtn;
        private System.Windows.Forms.Button Querybtn;
        private System.Windows.Forms.Button Backbtn;
    }
}