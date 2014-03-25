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
            this.Titlelbl.Location = new System.Drawing.Point(121, 28);
            this.Titlelbl.Name = "Titlelbl";
            this.Titlelbl.Size = new System.Drawing.Size(460, 39);
            this.Titlelbl.TabIndex = 0;
            this.Titlelbl.Text = "Please input a new password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(142, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "New Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Verify new Password";
            // 
            // NewPwtxt
            // 
            this.NewPwtxt.Location = new System.Drawing.Point(248, 115);
            this.NewPwtxt.Name = "NewPwtxt";
            this.NewPwtxt.PasswordChar = '*';
            this.NewPwtxt.Size = new System.Drawing.Size(228, 22);
            this.NewPwtxt.TabIndex = 3;
            // 
            // VerifyPwtxt
            // 
            this.VerifyPwtxt.Location = new System.Drawing.Point(248, 161);
            this.VerifyPwtxt.Name = "VerifyPwtxt";
            this.VerifyPwtxt.PasswordChar = '*';
            this.VerifyPwtxt.Size = new System.Drawing.Size(228, 22);
            this.VerifyPwtxt.TabIndex = 4;
            // 
            // NewUserbtn
            // 
            this.NewUserbtn.Location = new System.Drawing.Point(248, 220);
            this.NewUserbtn.Name = "NewUserbtn";
            this.NewUserbtn.Size = new System.Drawing.Size(75, 23);
            this.NewUserbtn.TabIndex = 5;
            this.NewUserbtn.Text = "Update";
            this.NewUserbtn.UseVisualStyleBackColor = true;
            this.NewUserbtn.Click += new System.EventHandler(this.NewUserbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Location = new System.Drawing.Point(399, 220);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.Cancelbtn.TabIndex = 6;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // NewPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 290);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.NewUserbtn);
            this.Controls.Add(this.VerifyPwtxt);
            this.Controls.Add(this.NewPwtxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Titlelbl);
            this.Name = "NewPassword";
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