namespace Hospital
{
    partial class TestResultViewer
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ZoomInButton = new System.Windows.Forms.Button();
            this.ZoomOutButton = new System.Windows.Forms.Button();
            this.RotateLeftButton = new System.Windows.Forms.Button();
            this.RotateRightButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(600, 400);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ZoomIn
            // 
            this.ZoomInButton.Location = new System.Drawing.Point(646, 102);
            this.ZoomInButton.Name = "ZoomIn";
            this.ZoomInButton.Size = new System.Drawing.Size(75, 23);
            this.ZoomInButton.TabIndex = 1;
            this.ZoomInButton.Text = "Zoom In";
            this.ZoomInButton.UseVisualStyleBackColor = true;
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomIn_Click);
            // 
            // ZoomOut
            // 
            this.ZoomOutButton.Location = new System.Drawing.Point(646, 131);
            this.ZoomOutButton.Name = "ZoomOut";
            this.ZoomOutButton.Size = new System.Drawing.Size(75, 23);
            this.ZoomOutButton.TabIndex = 2;
            this.ZoomOutButton.Text = "Zoom Out";
            this.ZoomOutButton.UseVisualStyleBackColor = true;
            // 
            // RotateLeft
            // 
            this.RotateLeftButton.Location = new System.Drawing.Point(646, 198);
            this.RotateLeftButton.Name = "RotateLeft";
            this.RotateLeftButton.Size = new System.Drawing.Size(75, 23);
            this.RotateLeftButton.TabIndex = 3;
            this.RotateLeftButton.Text = "Rotate Left";
            this.RotateLeftButton.UseVisualStyleBackColor = true;
            // 
            // RotateRight
            // 
            this.RotateRightButton.Location = new System.Drawing.Point(646, 227);
            this.RotateRightButton.Name = "RotateRight";
            this.RotateRightButton.Size = new System.Drawing.Size(75, 23);
            this.RotateRightButton.TabIndex = 4;
            this.RotateRightButton.Text = "RotateRight";
            this.RotateRightButton.UseVisualStyleBackColor = true;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(646, 296);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            // 
            // TestResultViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 418);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.RotateRightButton);
            this.Controls.Add(this.RotateLeftButton);
            this.Controls.Add(this.ZoomOutButton);
            this.Controls.Add(this.ZoomInButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "TestResultViewer";
            this.Text = "Test Result";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ZoomInButton;
        private System.Windows.Forms.Button ZoomOutButton;
        private System.Windows.Forms.Button RotateLeftButton;
        private System.Windows.Forms.Button RotateRightButton;
        private System.Windows.Forms.Button BackButton;

    }
}