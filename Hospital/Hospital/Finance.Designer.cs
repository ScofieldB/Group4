namespace Hospital {
    partial class Finance {
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
            this.Chooselbl = new System.Windows.Forms.Label();
            this.Choicescmb = new System.Windows.Forms.ComboBox();
            this.Confirmbtn = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Chooselbl
            // 
            this.Chooselbl.AutoSize = true;
            this.Chooselbl.Location = new System.Drawing.Point(65, 69);
            this.Chooselbl.Name = "Chooselbl";
            this.Chooselbl.Size = new System.Drawing.Size(247, 17);
            this.Chooselbl.TabIndex = 0;
            this.Chooselbl.Text = "Please choose one from the following:";
            // 
            // Choicescmb
            // 
            this.Choicescmb.FormattingEnabled = true;
            this.Choicescmb.Location = new System.Drawing.Point(68, 102);
            this.Choicescmb.Name = "Choicescmb";
            this.Choicescmb.Size = new System.Drawing.Size(440, 24);
            this.Choicescmb.TabIndex = 1;
            // 
            // Confirmbtn
            // 
            this.Confirmbtn.Location = new System.Drawing.Point(162, 195);
            this.Confirmbtn.Name = "Confirmbtn";
            this.Confirmbtn.Size = new System.Drawing.Size(75, 23);
            this.Confirmbtn.TabIndex = 2;
            this.Confirmbtn.Text = "Confirm";
            this.Confirmbtn.UseVisualStyleBackColor = true;
            this.Confirmbtn.Click += new System.EventHandler(this.Confirmbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Location = new System.Drawing.Point(342, 195);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.Cancelbtn.TabIndex = 3;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // Finance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 265);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.Confirmbtn);
            this.Controls.Add(this.Choicescmb);
            this.Controls.Add(this.Chooselbl);
            this.Name = "Finance";
            this.Text = "Finance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Chooselbl;
        private System.Windows.Forms.ComboBox Choicescmb;
        private System.Windows.Forms.Button Confirmbtn;
        private System.Windows.Forms.Button Cancelbtn;
    }
}