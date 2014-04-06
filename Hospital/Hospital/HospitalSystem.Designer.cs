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
            this.label1 = new System.Windows.Forms.Label();
            this.Logoutbtn = new System.Windows.Forms.Button();
            this.Searchbtn = new System.Windows.Forms.Button();
            this.Sealbl = new System.Windows.Forms.Label();
            this.Seatxt = new System.Windows.Forms.TextBox();
            this.PatInfolbl = new System.Windows.Forms.Label();
            this.currentRoomtxt = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(909, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "This form is used for doctors and should have the history stuff";
            // 
            // Logoutbtn
            // 
            this.Logoutbtn.Location = new System.Drawing.Point(851, 26);
            this.Logoutbtn.Name = "Logoutbtn";
            this.Logoutbtn.Size = new System.Drawing.Size(75, 23);
            this.Logoutbtn.TabIndex = 1;
            this.Logoutbtn.Text = "Logout";
            this.Logoutbtn.UseVisualStyleBackColor = true;
            this.Logoutbtn.Click += new System.EventHandler(this.Logoutbtn_Click);
            // 
            // Searchbtn
            // 
            this.Searchbtn.Location = new System.Drawing.Point(206, 23);
            this.Searchbtn.Margin = new System.Windows.Forms.Padding(4);
            this.Searchbtn.Name = "Searchbtn";
            this.Searchbtn.Size = new System.Drawing.Size(100, 28);
            this.Searchbtn.TabIndex = 35;
            this.Searchbtn.Text = "Search";
            this.Searchbtn.UseVisualStyleBackColor = true;
            this.Searchbtn.Click += new System.EventHandler(this.Searchbtn_Click);
            // 
            // Sealbl
            // 
            this.Sealbl.AutoSize = true;
            this.Sealbl.Location = new System.Drawing.Point(9, 30);
            this.Sealbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Sealbl.Name = "Sealbl";
            this.Sealbl.Size = new System.Drawing.Size(79, 17);
            this.Sealbl.TabIndex = 34;
            this.Sealbl.Text = "Search PID";
            // 
            // Seatxt
            // 
            this.Seatxt.Location = new System.Drawing.Point(100, 26);
            this.Seatxt.Margin = new System.Windows.Forms.Padding(4);
            this.Seatxt.Name = "Seatxt";
            this.Seatxt.Size = new System.Drawing.Size(97, 22);
            this.Seatxt.TabIndex = 33;
            // 
            // PatInfolbl
            // 
            this.PatInfolbl.AutoSize = true;
            this.PatInfolbl.Location = new System.Drawing.Point(654, 23);
            this.PatInfolbl.Name = "PatInfolbl";
            this.PatInfolbl.Size = new System.Drawing.Size(0, 17);
            this.PatInfolbl.TabIndex = 36;
            // 
            // currentRoomtxt
            // 
            this.currentRoomtxt.AutoSize = true;
            this.currentRoomtxt.Location = new System.Drawing.Point(491, 23);
            this.currentRoomtxt.Name = "currentRoomtxt";
            this.currentRoomtxt.Size = new System.Drawing.Size(0, 17);
            this.currentRoomtxt.TabIndex = 37;
            // 
            // HospitalSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 525);
            this.Controls.Add(this.currentRoomtxt);
            this.Controls.Add(this.PatInfolbl);
            this.Controls.Add(this.Searchbtn);
            this.Controls.Add(this.Sealbl);
            this.Controls.Add(this.Seatxt);
            this.Controls.Add(this.Logoutbtn);
            this.Controls.Add(this.label1);
            this.Name = "HospitalSystem";
            this.Text = "HospitalSystem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Logoutbtn;
        private System.Windows.Forms.Button Searchbtn;
        private System.Windows.Forms.Label Sealbl;
        private System.Windows.Forms.TextBox Seatxt;
        private System.Windows.Forms.Label PatInfolbl;
        private System.Windows.Forms.Label currentRoomtxt;
    }
}