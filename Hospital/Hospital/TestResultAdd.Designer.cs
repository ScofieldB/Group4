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
            this.SuspendLayout();
            // 
            // Loadbtn
            // 
            this.Loadbtn.Location = new System.Drawing.Point(48, 62);
            this.Loadbtn.Name = "Loadbtn";
            this.Loadbtn.Size = new System.Drawing.Size(75, 23);
            this.Loadbtn.TabIndex = 0;
            this.Loadbtn.Text = "Load";
            this.Loadbtn.UseVisualStyleBackColor = true;
            this.Loadbtn.Click += new System.EventHandler(this.Loadbtn_Click);
            // 
            // FilePathtb
            // 
            this.FilePathtb.Location = new System.Drawing.Point(48, 91);
            this.FilePathtb.Name = "FilePathtb";
            this.FilePathtb.Size = new System.Drawing.Size(190, 20);
            this.FilePathtb.TabIndex = 1;
            // 
            // Uploadbtn
            // 
            this.Uploadbtn.Location = new System.Drawing.Point(48, 187);
            this.Uploadbtn.Name = "Uploadbtn";
            this.Uploadbtn.Size = new System.Drawing.Size(75, 23);
            this.Uploadbtn.TabIndex = 2;
            this.Uploadbtn.Text = "Upload";
            this.Uploadbtn.UseVisualStyleBackColor = true;
            this.Uploadbtn.Click += new System.EventHandler(this.Uploadbtn_Click);
            // 
            // Cancelbtn
            // 
            this.Cancelbtn.Location = new System.Drawing.Point(163, 186);
            this.Cancelbtn.Name = "Cancelbtn";
            this.Cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.Cancelbtn.TabIndex = 3;
            this.Cancelbtn.Text = "Cancel";
            this.Cancelbtn.UseVisualStyleBackColor = true;
            this.Cancelbtn.Click += new System.EventHandler(this.Cancelbtn_Click);
            // 
            // TestResultAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Cancelbtn);
            this.Controls.Add(this.Uploadbtn);
            this.Controls.Add(this.FilePathtb);
            this.Controls.Add(this.Loadbtn);
            this.Name = "TestResultAdd";
            this.Text = "TestResultAdd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Loadbtn;
        private System.Windows.Forms.TextBox FilePathtb;
        private System.Windows.Forms.Button Uploadbtn;
        private System.Windows.Forms.Button Cancelbtn;
    }
}