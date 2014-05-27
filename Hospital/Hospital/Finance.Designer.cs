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
            this.Chooselbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Chooselbl.AutoSize = true;
            this.Chooselbl.Location = new System.Drawing.Point(49, 56);
            this.Chooselbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Chooselbl.Name = "Chooselbl";
            this.Chooselbl.Size = new System.Drawing.Size(186, 13);
            this.Chooselbl.TabIndex = 0;
            this.Chooselbl.Text = "Please choose one from the following:";
            // 
            // Choicescmb
            // 
            this.Choicescmb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Choicescmb.FormattingEnabled = true;
            this.Choicescmb.Location = new System.Drawing.Point(51, 83);
            this.Choicescmb.Margin = new System.Windows.Forms.Padding(2);
            this.Choicescmb.Name = "Choicescmb";
            this.Choicescmb.Size = new System.Drawing.Size(331, 21);
            this.Choicescmb.TabIndex = 1;
            // 
            // Confirmbtn
            // 
            this.Confirmbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Confirmbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Confirmbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Confirmbtn.FlatAppearance.BorderSize = 0;
            this.Confirmbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Confirmbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Confirmbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Confirmbtn.Location = new System.Drawing.Point(92, 158);
            this.Confirmbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Confirmbtn.Name = "Confirmbtn";
            this.Confirmbtn.Size = new System.Drawing.Size(99, 23);
            this.Confirmbtn.TabIndex = 2;
            this.Confirmbtn.Text = "Confirm";
            this.Confirmbtn.UseVisualStyleBackColor = true;
            this.Confirmbtn.Click += new System.EventHandler(this.Confirmbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Cancelbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Cancelbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Cancelbtn.FlatAppearance.BorderSize = 0;
            this.Cancelbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancelbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cancelbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Cancelbtn.Location = new System.Drawing.Point(247, 158);
            this.Cancelbtn.Margin = new System.Windows.Forms.Padding(2);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(99, 23);
            this.Cancelbtn.TabIndex = 3;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // Finance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.BackgroundImage = global::Hospital.Properties.Resources.pagebackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(464, 215);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.Confirmbtn);
            this.Controls.Add(this.Choicescmb);
            this.Controls.Add(this.Chooselbl);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Finance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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