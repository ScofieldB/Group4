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
            this.button1 = new System.Windows.Forms.Button();
            this.Passwordtxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Rolelbl = new System.Windows.Forms.Label();
            this.Rolecmb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Newbtn
            // 
            this.Newbtn.Location = new System.Drawing.Point(200, 184);
            this.Newbtn.Name = "Newbtn";
            this.Newbtn.Size = new System.Drawing.Size(102, 23);
            this.Newbtn.TabIndex = 0;
            this.Newbtn.Text = "New User";
            this.Newbtn.UseVisualStyleBackColor = true;
            this.Newbtn.Click += new System.EventHandler(this.Newbtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.Location = new System.Drawing.Point(416, 184);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(93, 23);
            this.Deletebtn.TabIndex = 1;
            this.Deletebtn.Text = "Delete User";
            this.Deletebtn.UseVisualStyleBackColor = true;
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // Logoutbtn
            // 
            this.Logoutbtn.Location = new System.Drawing.Point(613, 12);
            this.Logoutbtn.Name = "Logoutbtn";
            this.Logoutbtn.Size = new System.Drawing.Size(75, 23);
            this.Logoutbtn.TabIndex = 2;
            this.Logoutbtn.Text = "Logout";
            this.Logoutbtn.UseVisualStyleBackColor = true;
            this.Logoutbtn.Click += new System.EventHandler(this.Logoutbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Admin Control";
            // 
            // Usernametxt
            // 
            this.Usernametxt.Location = new System.Drawing.Point(294, 91);
            this.Usernametxt.Name = "Usernametxt";
            this.Usernametxt.Size = new System.Drawing.Size(229, 22);
            this.Usernametxt.TabIndex = 8;
            // 
            // Usernamelbl
            // 
            this.Usernamelbl.AutoSize = true;
            this.Usernamelbl.Location = new System.Drawing.Point(211, 91);
            this.Usernamelbl.Name = "Usernamelbl";
            this.Usernamelbl.Size = new System.Drawing.Size(77, 17);
            this.Usernamelbl.TabIndex = 6;
            this.Usernamelbl.Text = "Username:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(294, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Update pw to hashed";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Passwordtxt
            // 
            this.Passwordtxt.Location = new System.Drawing.Point(309, 240);
            this.Passwordtxt.Name = "Passwordtxt";
            this.Passwordtxt.Size = new System.Drawing.Size(229, 22);
            this.Passwordtxt.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Password:";
            // 
            // Rolelbl
            // 
            this.Rolelbl.AutoSize = true;
            this.Rolelbl.Location = new System.Drawing.Point(247, 123);
            this.Rolelbl.Name = "Rolelbl";
            this.Rolelbl.Size = new System.Drawing.Size(41, 17);
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
            this.Rolecmb.Location = new System.Drawing.Point(295, 119);
            this.Rolecmb.Name = "Rolecmb";
            this.Rolecmb.Size = new System.Drawing.Size(229, 24);
            this.Rolecmb.TabIndex = 14;
            // 
            // Adminfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 295);
            this.Controls.Add(this.Rolecmb);
            this.Controls.Add(this.Rolelbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Passwordtxt);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Usernametxt);
            this.Controls.Add(this.Usernamelbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Logoutbtn);
            this.Controls.Add(this.Deletebtn);
            this.Controls.Add(this.Newbtn);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Passwordtxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Rolelbl;
        private System.Windows.Forms.ComboBox Rolecmb;
    }
}