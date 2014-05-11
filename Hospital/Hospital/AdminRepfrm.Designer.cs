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
            this.label1 = new System.Windows.Forms.Label();
            this.TestRepbtn = new System.Windows.Forms.Button();
            this.LogBtn = new System.Windows.Forms.Button();
            this.BackBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Form for holding all the report generating buttons used by admin";
            // 
            // TestRepbtn
            // 
            this.TestRepbtn.Location = new System.Drawing.Point(8, 122);
            this.TestRepbtn.Name = "TestRepbtn";
            this.TestRepbtn.Size = new System.Drawing.Size(75, 23);
            this.TestRepbtn.TabIndex = 1;
            this.TestRepbtn.Text = "Test Rep";
            this.TestRepbtn.UseVisualStyleBackColor = true;
            this.TestRepbtn.Click += new System.EventHandler(this.TestRepbtn_Click);
            // 
            // LogBtn
            // 
            this.LogBtn.Location = new System.Drawing.Point(233, 13);
            this.LogBtn.Name = "LogBtn";
            this.LogBtn.Size = new System.Drawing.Size(75, 23);
            this.LogBtn.TabIndex = 2;
            this.LogBtn.Text = "Logout";
            this.LogBtn.UseVisualStyleBackColor = true;
            this.LogBtn.Click += new System.EventHandler(this.LogBtn_Click);
            // 
            // BackBtn
            // 
            this.BackBtn.Location = new System.Drawing.Point(234, 226);
            this.BackBtn.Name = "BackBtn";
            this.BackBtn.Size = new System.Drawing.Size(75, 23);
            this.BackBtn.TabIndex = 3;
            this.BackBtn.Text = "Back";
            this.BackBtn.UseVisualStyleBackColor = true;
            this.BackBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // AdminRepfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 261);
            this.Controls.Add(this.BackBtn);
            this.Controls.Add(this.LogBtn);
            this.Controls.Add(this.TestRepbtn);
            this.Controls.Add(this.label1);
            this.Name = "AdminRepfrm";
            this.Text = "AdminRepfrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TestRepbtn;
        private System.Windows.Forms.Button LogBtn;
        private System.Windows.Forms.Button BackBtn;
    }
}