namespace Hospital {
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
            this.Welcomelbl = new System.Windows.Forms.Label();
            this.Logoutbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Welcomelbl
            // 
            this.Welcomelbl.AutoSize = true;
            this.Welcomelbl.Location = new System.Drawing.Point(52, 45);
            this.Welcomelbl.Name = "Welcomelbl";
            this.Welcomelbl.Size = new System.Drawing.Size(46, 17);
            this.Welcomelbl.TabIndex = 0;
            this.Welcomelbl.Text = "label1";
            // 
            // Logoutbtn
            // 
            this.Logoutbtn.Location = new System.Drawing.Point(867, 13);
            this.Logoutbtn.Name = "Logoutbtn";
            this.Logoutbtn.Size = new System.Drawing.Size(75, 23);
            this.Logoutbtn.TabIndex = 1;
            this.Logoutbtn.Text = "Logout";
            this.Logoutbtn.UseVisualStyleBackColor = true;
            this.Logoutbtn.Click += new System.EventHandler(this.Logoutbtn_Click);
            // 
            // HospitalSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 515);
            this.Controls.Add(this.Logoutbtn);
            this.Controls.Add(this.Welcomelbl);
            this.Name = "HospitalSystem";
            this.Text = "HospitalSystem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Welcomelbl;
        private System.Windows.Forms.Button Logoutbtn;
    }
}