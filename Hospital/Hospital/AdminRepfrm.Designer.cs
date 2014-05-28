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
            this.TestRepbtn.Location = new System.Drawing.Point(15, 63);
            this.TestRepbtn.Name = "TestRepbtn";
            this.TestRepbtn.Size = new System.Drawing.Size(99, 23);
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
            this.LogBtn.Location = new System.Drawing.Point(209, 12);
            this.LogBtn.Name = "LogBtn";
            this.LogBtn.Size = new System.Drawing.Size(99, 23);
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
            this.BackBtn.Location = new System.Drawing.Point(209, 226);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(99, 23);
            this.BackBtn.TabIndex = 3;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // Desc
            // 
            this.Desc.AutoSize = true;
            this.Desc.Location = new System.Drawing.Point(12, 38);
            this.Desc.Name = "Desc";
            this.Desc.Size = new System.Drawing.Size(218, 13);
            this.Desc.TabIndex = 4;
            this.Desc.Text = "Selection of reports for use by Administrators.";
            // 
            // AdminRepfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.BackgroundImage = global::Hospital.Properties.Resources.pagebackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(320, 261);
            this.Controls.Add(this.Desc);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.LogBtn);
            this.Controls.Add(this.TestRepbtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
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
    }
}