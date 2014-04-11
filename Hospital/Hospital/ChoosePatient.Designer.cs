namespace Hospital {
    partial class ChoosePatient {
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
            this.SearchSurnamelbl = new System.Windows.Forms.Label();
            this.Chooselbl = new System.Windows.Forms.Label();
            this.chooseCmb = new System.Windows.Forms.ComboBox();
            this.Confirmbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SearchSurnamelbl
            // 
            this.SearchSurnamelbl.AutoSize = true;
            this.SearchSurnamelbl.Location = new System.Drawing.Point(37, 54);
            this.SearchSurnamelbl.Name = "SearchSurnamelbl";
            this.SearchSurnamelbl.Size = new System.Drawing.Size(175, 17);
            this.SearchSurnamelbl.TabIndex = 0;
            this.SearchSurnamelbl.Text = "Surname being searched: ";
            // 
            // Chooselbl
            // 
            this.Chooselbl.AutoSize = true;
            this.Chooselbl.Location = new System.Drawing.Point(40, 125);
            this.Chooselbl.Name = "Chooselbl";
            this.Chooselbl.Size = new System.Drawing.Size(263, 17);
            this.Chooselbl.TabIndex = 1;
            this.Chooselbl.Text = "Please choose from one of the following:";
            // 
            // chooseCmb
            // 
            this.chooseCmb.FormattingEnabled = true;
            this.chooseCmb.Location = new System.Drawing.Point(43, 145);
            this.chooseCmb.Name = "chooseCmb";
            this.chooseCmb.Size = new System.Drawing.Size(513, 24);
            this.chooseCmb.TabIndex = 2;
            this.chooseCmb.SelectedIndexChanged += new System.EventHandler(this.chooseCmb_SelectedIndexChanged);
            // 
            // Confirmbtn
            // 
            this.Confirmbtn.Location = new System.Drawing.Point(232, 206);
            this.Confirmbtn.Name = "Confirmbtn";
            this.Confirmbtn.Size = new System.Drawing.Size(115, 34);
            this.Confirmbtn.TabIndex = 3;
            this.Confirmbtn.Text = "Confirm";
            this.Confirmbtn.UseVisualStyleBackColor = true;
            this.Confirmbtn.Click += new System.EventHandler(this.Confirmbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 244);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // ChoosePatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 290);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Confirmbtn);
            this.Controls.Add(this.chooseCmb);
            this.Controls.Add(this.Chooselbl);
            this.Controls.Add(this.SearchSurnamelbl);
            this.Name = "ChoosePatient";
            this.Text = "ChoosePatient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SearchSurnamelbl;
        private System.Windows.Forms.Label Chooselbl;
        private System.Windows.Forms.ComboBox chooseCmb;
        private System.Windows.Forms.Button Confirmbtn;
        private System.Windows.Forms.Label label1;
    }
}