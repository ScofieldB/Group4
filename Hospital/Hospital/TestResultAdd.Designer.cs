namespace Hospital
{
    partial class TestResultAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Loadbtn = new System.Windows.Forms.Button();
            this.FilePathtb = new System.Windows.Forms.TextBox();
            this.Uploadbtn = new System.Windows.Forms.Button();
            this.Cancelbtn = new System.Windows.Forms.Button();
            this.addimagelbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Loadbtn
            // 
            this.Loadbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Loadbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Loadbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Loadbtn.FlatAppearance.BorderSize = 0;
            this.Loadbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Loadbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loadbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Loadbtn.Location = new System.Drawing.Point(48, 62);
            this.Loadbtn.Name = "Loadbtn";
            this.Loadbtn.Size = new System.Drawing.Size(99, 23);
            this.Loadbtn.TabIndex = 0;
            this.Loadbtn.Text = "Load";
            this.Loadbtn.UseVisualStyleBackColor = true;
            this.Loadbtn.Click += new System.EventHandler(this.Loadbtn_Click);
            // 
            // FilePathtb
            // 
            this.FilePathtb.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.FilePathtb.Location = new System.Drawing.Point(48, 91);
            this.FilePathtb.Name = "FilePathtb";
            this.FilePathtb.Size = new System.Drawing.Size(190, 20);
            this.FilePathtb.TabIndex = 1;
            // 
            // Uploadbtn
            // 
            this.Uploadbtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Uploadbtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.Uploadbtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Uploadbtn.FlatAppearance.BorderSize = 0;
            this.Uploadbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Uploadbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Uploadbtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Uploadbtn.Location = new System.Drawing.Point(48, 186);
            this.Uploadbtn.Name = "Uploadbtn";
            this.Uploadbtn.Size = new System.Drawing.Size(99, 23);
            this.Uploadbtn.TabIndex = 2;
            this.Uploadbtn.Text = "Upload";
            this.Uploadbtn.UseVisualStyleBackColor = true;
            this.Uploadbtn.Click += new System.EventHandler(this.Uploadbtn_Click);
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
            this.Cancelbtn.Location = new System.Drawing.Point(153, 186);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(99, 23);
            this.Cancelbtn.TabIndex = 3;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // addimagelbl
            // 
            this.addimagelbl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addimagelbl.AutoSize = true;
            this.addimagelbl.Location = new System.Drawing.Point(45, 32);
            this.addimagelbl.Name = "addimagelbl";
            this.addimagelbl.Size = new System.Drawing.Size(58, 13);
            this.addimagelbl.TabIndex = 4;
            this.addimagelbl.Text = "Add Image";
            // 
            // TestResultAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.BackgroundImage = global::Hospital.Properties.Resources.pagebackground;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.addimagelbl);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.Uploadbtn);
            this.Controls.Add(this.FilePathtb);
            this.Controls.Add(this.Loadbtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestResultAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TestResultAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Loadbtn;
        private System.Windows.Forms.TextBox FilePathtb;
        private System.Windows.Forms.Button Uploadbtn;
        private System.Windows.Forms.Button Cancelbtn;
        private System.Windows.Forms.Label addimagelbl;
    }
}