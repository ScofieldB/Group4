namespace Hospital {
    partial class NewPasswordfrm {
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
            this.Titlelbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NewPwtxt = new System.Windows.Forms.TextBox();
            this.VerifyPwtxt = new System.Windows.Forms.TextBox();
            this.NewUserbtn = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Titlelbl
            // 
            this.Titlelbl.AutoSize = true;
            this.Titlelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titlelbl.Location = new System.Drawing.Point(91, 23);
            this.Titlelbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titlelbl.Name = "Titlelbl";
            this.Titlelbl.Size = new System.Drawing.Size(366, 31);
            this.Titlelbl.TabIndex = 0;
            this.Titlelbl.Text = "Please input a new password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(106, 96);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Verify new Password";
            // 
            // NewPwtxt
            // 
            this.NewPwtxt.Location = new System.Drawing.Point(186, 93);
            this.NewPwtxt.Margin = new System.Windows.Forms.Padding(2);
            this.NewPwtxt.Name = "NewPwtxt";
            this.NewPwtxt.PasswordChar = '*';
            this.NewPwtxt.Size = new System.Drawing.Size(172, 20);
            this.NewPwtxt.TabIndex = 3;
            // 
            // VerifyPwtxt
            // 
            this.VerifyPwtxt.Location = new System.Drawing.Point(186, 131);
            this.VerifyPwtxt.Margin = new System.Windows.Forms.Padding(2);
            this.VerifyPwtxt.Name = "VerifyPwtxt";
            this.VerifyPwtxt.PasswordChar = '*';
            this.VerifyPwtxt.Size = new System.Drawing.Size(172, 20);
            this.VerifyPwtxt.TabIndex = 4;
            // 
            // NewUserbtn
            // 
            this.NewUserbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.NewUserbtn.FlatAppearance.BorderSize = 0;
            this.NewUserbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewUserbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewUserbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NewUserbtn.Location = new System.Drawing.Point(131, 179);
            this.NewUserbtn.Margin = new System.Windows.Forms.Padding(2);
            this.NewUserbtn.Name = "NewUserbtn";
            this.NewUserbtn.Size = new System.Drawing.Size(99, 23);
            this.NewUserbtn.TabIndex = 5;
            this.NewUserbtn.Text = "Update";
            this.NewUserbtn.UseVisualStyleBackColor = true;
            this.NewUserbtn.Click += new System.EventHandler(this.NewUserbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Cancelbtn.FlatAppearance.BorderSize = 0;
            this.Cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Cancelbtn.Location = new System.Drawing.Point(279, 179);
            this.Cancelbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(99, 23);
            this.Cancelbtn.TabIndex = 6;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // NewPasswordfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.BackgroundImage = global::Hospital.Properties.Resources.pagebackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(528, 236);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.NewUserbtn);
            this.Controls.Add(this.VerifyPwtxt);
            this.Controls.Add(this.NewPwtxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Titlelbl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NewPasswordfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewPassword";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Titlelbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NewPwtxt;
        private System.Windows.Forms.TextBox VerifyPwtxt;
        private System.Windows.Forms.Button NewUserbtn;
        private System.Windows.Forms.Button Cancelbtn;
    }
}