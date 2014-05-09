namespace Hospital {
    partial class Adminfrm {
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
            this.Newbtn = new System.Windows.Forms.Button();
            this.Deletebtn = new System.Windows.Forms.Button();
            this.Logoutbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Usernametxt = new System.Windows.Forms.TextBox();
            this.Usernamelbl = new System.Windows.Forms.Label();
            this.Rolelbl = new System.Windows.Forms.Label();
            this.Rolecmb = new System.Windows.Forms.ComboBox();
            this.reportbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Newbtn
            // 
            this.Newbtn.Location = new System.Drawing.Point(150, 150);
            this.Newbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Newbtn.Name = "Newbtn";
            this.Newbtn.Size = new System.Drawing.Size(76, 19);
            this.Newbtn.TabIndex = 0;
            this.Newbtn.Text = "New User";
            this.Newbtn.UseVisualStyleBackColor = true;
            this.Newbtn.Click += new System.EventHandler(this.Newbtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.Location = new System.Drawing.Point(312, 150);
            this.Deletebtn.Margin = new System.Windows.Forms.Padding(2);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(70, 19);
            this.Deletebtn.TabIndex = 1;
            this.Deletebtn.Text = "Delete User";
            this.Deletebtn.UseVisualStyleBackColor = true;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // Logoutbtn
            // 
            this.Logoutbtn.Location = new System.Drawing.Point(460, 10);
            this.Logoutbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Logoutbtn.Name = "Logoutbtn";
            this.Logoutbtn.Size = new System.Drawing.Size(56, 19);
            this.Logoutbtn.TabIndex = 2;
            this.Logoutbtn.Text = "Logout";
            this.Logoutbtn.UseVisualStyleBackColor = true;
            this.Logoutbtn.Click += new System.EventHandler(this.Logoutbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(194, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 26);
            this.label1.TabIndex = 3;
            this.label1.Text = "Admin Control";
            // 
            // Usernametxt
            // 
            this.Usernametxt.Location = new System.Drawing.Point(220, 74);
            this.Usernametxt.Margin = new System.Windows.Forms.Padding(2);
            this.Usernametxt.Name = "Usernametxt";
            this.Usernametxt.Size = new System.Drawing.Size(173, 20);
            this.Usernametxt.TabIndex = 8;
            // 
            // Usernamelbl
            // 
            this.Usernamelbl.AutoSize = true;
            this.Usernamelbl.Location = new System.Drawing.Point(158, 74);
            this.Usernamelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Usernamelbl.Name = "Usernamelbl";
            this.Usernamelbl.Size = new System.Drawing.Size(58, 13);
            this.Usernamelbl.TabIndex = 6;
            this.Usernamelbl.Text = "Username:";
            // 
            // Rolelbl
            // 
            this.Rolelbl.AutoSize = true;
            this.Rolelbl.Location = new System.Drawing.Point(185, 100);
            this.Rolelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Rolelbl.Name = "Rolelbl";
            this.Rolelbl.Size = new System.Drawing.Size(32, 13);
            this.Rolelbl.TabIndex = 13;
            this.Rolelbl.Text = "Role:";
            // 
            // Rolecmb
            // 
            this.Rolecmb.FormattingEnabled = true;
            this.Rolecmb.Items.AddRange(new object[] {
            "Doctor",
            "Nurse",
            "MedTech",
            "Reception",
            "Admin"});
            this.Rolecmb.Location = new System.Drawing.Point(221, 97);
            this.Rolecmb.Margin = new System.Windows.Forms.Padding(2);
            this.Rolecmb.Name = "Rolecmb";
            this.Rolecmb.Size = new System.Drawing.Size(173, 21);
            this.Rolecmb.TabIndex = 14;
            // 
            // reportbtn
            // 
            this.reportbtn.Location = new System.Drawing.Point(449, 209);
            this.reportbtn.Name = "reportbtn";
            this.reportbtn.Size = new System.Drawing.Size(75, 19);
            this.reportbtn.TabIndex = 15;
            this.reportbtn.Text = "Reports";
            this.reportbtn.UseVisualStyleBackColor = true;
            this.reportbtn.Click += new System.EventHandler(this.reportbtn_Click);
            // 
            // Adminfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 240);
            this.Controls.Add(this.reportbtn);
            this.Controls.Add(this.Rolecmb);
            this.Controls.Add(this.Rolelbl);
            this.Controls.Add(this.Usernametxt);
            this.Controls.Add(this.Usernamelbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Logoutbtn);
            this.Controls.Add(this.Deletebtn);
            this.Controls.Add(this.Newbtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Adminfrm";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Newbtn;
        private System.Windows.Forms.Button Deletebtn;
        private System.Windows.Forms.Button Logoutbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Usernametxt;
        private System.Windows.Forms.Label Usernamelbl;
        private System.Windows.Forms.Label Rolelbl;
        private System.Windows.Forms.ComboBox Rolecmb;
        private System.Windows.Forms.Button reportbtn;
    }
}