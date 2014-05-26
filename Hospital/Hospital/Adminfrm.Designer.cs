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
            this.Logoutbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.reportbtn = new System.Windows.Forms.Button();
            this.usermgmtbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Logoutbtn
            // 
            this.Logoutbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Logoutbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Logoutbtn.FlatAppearance.BorderSize = 0;
            this.Logoutbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Logoutbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logoutbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Logoutbtn.Location = new System.Drawing.Point(556, 14);
            this.Logoutbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Logoutbtn.Name = "Logoutbtn";
            this.Logoutbtn.Size = new System.Drawing.Size(132, 28);
            this.Logoutbtn.TabIndex = 2;
            this.Logoutbtn.Text = "Logout";
            this.Logoutbtn.UseVisualStyleBackColor = true;
            this.Logoutbtn.Click += new System.EventHandler(this.Logoutbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(259, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Admin Control";
            // 
            // reportbtn
            // 
            this.reportbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.reportbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.reportbtn.FlatAppearance.BorderSize = 0;
            this.reportbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportbtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.reportbtn.Location = new System.Drawing.Point(64, 149);
            this.reportbtn.Margin = new System.Windows.Forms.Padding(4);
            this.reportbtn.Name = "reportbtn";
            this.reportbtn.Size = new System.Drawing.Size(132, 28);
            this.reportbtn.TabIndex = 15;
            this.reportbtn.Text = "Reports";
            this.reportbtn.UseVisualStyleBackColor = true;
            this.reportbtn.Click += new System.EventHandler(this.reportbtn_Click);
            // 
            // usermgmtbtn
            // 
            this.usermgmtbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.usermgmtbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.usermgmtbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usermgmtbtn.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.usermgmtbtn.Location = new System.Drawing.Point(64, 114);
            this.usermgmtbtn.Name = "usermgmtbtn";
            this.usermgmtbtn.Size = new System.Drawing.Size(132, 28);
            this.usermgmtbtn.TabIndex = 16;
            this.usermgmtbtn.Text = "User Mgmt";
            this.usermgmtbtn.UseVisualStyleBackColor = true;
            this.usermgmtbtn.Click += new System.EventHandler(this.usermgmtbtn_Click);
            // 
            // Adminfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.BackgroundImage = global::Hospital.Properties.Resources.pagebackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(715, 295);
            this.Controls.Add(this.usermgmtbtn);
            this.Controls.Add(this.reportbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Logoutbtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Adminfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Logoutbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reportbtn;
        private System.Windows.Forms.Button usermgmtbtn;
    }
}