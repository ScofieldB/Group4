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
            this.SuspendLayout();
            // 
            // SearchSurnamelbl
            // 
            this.SearchSurnamelbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.SearchSurnamelbl.AutoSize = true;
            this.SearchSurnamelbl.Location = new System.Drawing.Point(37, 54);
            this.SearchSurnamelbl.Name = "SearchSurnamelbl";
            this.SearchSurnamelbl.Size = new System.Drawing.Size(175, 17);
            this.SearchSurnamelbl.TabIndex = 0;
            this.SearchSurnamelbl.Text = "Surname being searched: ";
            // 
            // Chooselbl
            // 
            this.Chooselbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Chooselbl.AutoSize = true;
            this.Chooselbl.Location = new System.Drawing.Point(40, 126);
            this.Chooselbl.Name = "Chooselbl";
            this.Chooselbl.Size = new System.Drawing.Size(263, 17);
            this.Chooselbl.TabIndex = 1;
            this.Chooselbl.Text = "Please choose from one of the following:";
            // 
            // chooseCmb
            // 
            this.chooseCmb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chooseCmb.FormattingEnabled = true;
            this.chooseCmb.Location = new System.Drawing.Point(43, 145);
            this.chooseCmb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chooseCmb.Name = "chooseCmb";
            this.chooseCmb.Size = new System.Drawing.Size(513, 24);
            this.chooseCmb.TabIndex = 2;
            this.chooseCmb.SelectedIndexChanged += new System.EventHandler(this.chooseCmb_SelectedIndexChanged);
            // 
            // Confirmbtn
            // 
            this.Confirmbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Confirmbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Confirmbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Confirmbtn.FlatAppearance.BorderSize = 0;
            this.Confirmbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Confirmbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.Confirmbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Confirmbtn.Location = new System.Drawing.Point(232, 206);
            this.Confirmbtn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Confirmbtn.Name = "Confirmbtn";
            this.Confirmbtn.Size = new System.Drawing.Size(132, 28);
            this.Confirmbtn.TabIndex = 3;
            this.Confirmbtn.Text = "Confirm";
            this.Confirmbtn.UseVisualStyleBackColor = true;
            this.Confirmbtn.Click += new System.EventHandler(this.Confirmbtn_Click);
            // 
            // ChoosePatient
            // 
            this.AcceptButton = this.Confirmbtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.BackgroundImage = global::Hospital.Properties.Resources.pagebackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(603, 290);
            this.Controls.Add(this.Confirmbtn);
            this.Controls.Add(this.chooseCmb);
            this.Controls.Add(this.Chooselbl);
            this.Controls.Add(this.SearchSurnamelbl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ChoosePatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChoosePatient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SearchSurnamelbl;
        private System.Windows.Forms.Label Chooselbl;
        private System.Windows.Forms.ComboBox chooseCmb;
        private System.Windows.Forms.Button Confirmbtn;
    }
}