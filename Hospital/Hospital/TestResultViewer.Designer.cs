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
            this.ImageSelectorCB = new System.Windows.Forms.ComboBox();
            this.addImageBtn = new System.Windows.Forms.Button();
            this.addTestResultLinkBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.ImageLocation = "C:\\Users\\chris\\Documents\\xray jpeg test.jpg";
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.MaximumSize = new System.Drawing.Size(600, 400);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ZoomInButton
            // 
            this.ZoomInButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ZoomInButton.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.ZoomInButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ZoomInButton.FlatAppearance.BorderSize = 0;
            this.ZoomInButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZoomInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomInButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ZoomInButton.Location = new System.Drawing.Point(622, 168);
            this.ZoomInButton.Name = "ZoomInButton";
            this.ZoomInButton.Size = new System.Drawing.Size(99, 23);
            this.ZoomInButton.TabIndex = 1;
            this.ZoomInButton.Text = "Zoom In";
            this.ZoomInButton.UseVisualStyleBackColor = true;
            this.ZoomInButton.Click += new System.EventHandler(this.ZoomInButton_Click);
            // 
            // ZoomOutButton
            // 
            this.ZoomOutButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ZoomOutButton.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.ZoomOutButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ZoomOutButton.FlatAppearance.BorderSize = 0;
            this.ZoomOutButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ZoomOutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ZoomOutButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ZoomOutButton.Location = new System.Drawing.Point(622, 197);
            this.ZoomOutButton.Name = "ZoomOutButton";
            this.ZoomOutButton.Size = new System.Drawing.Size(99, 23);
            this.ZoomOutButton.TabIndex = 2;
            this.ZoomOutButton.Text = "Zoom Out";
            this.ZoomOutButton.UseVisualStyleBackColor = true;
            this.ZoomOutButton.Click += new System.EventHandler(this.ZoomOutButton_Click);
            // 
            // RotateLeftButton
            // 
            this.RotateLeftButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RotateLeftButton.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.RotateLeftButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RotateLeftButton.FlatAppearance.BorderSize = 0;
            this.RotateLeftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RotateLeftButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotateLeftButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RotateLeftButton.Location = new System.Drawing.Point(622, 264);
            this.RotateLeftButton.Name = "RotateLeftButton";
            this.RotateLeftButton.Size = new System.Drawing.Size(99, 23);
            this.RotateLeftButton.TabIndex = 3;
            this.RotateLeftButton.Text = "Rotate Left";
            this.RotateLeftButton.UseVisualStyleBackColor = true;
            this.RotateLeftButton.Click += new System.EventHandler(this.RotateLeftButton_Click);
            // 
            // RotateRightButton
            // 
            this.RotateRightButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RotateRightButton.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.RotateRightButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RotateRightButton.FlatAppearance.BorderSize = 0;
            this.RotateRightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RotateRightButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RotateRightButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.RotateRightButton.Location = new System.Drawing.Point(622, 293);
            this.RotateRightButton.Name = "RotateRightButton";
            this.RotateRightButton.Size = new System.Drawing.Size(99, 23);
            this.RotateRightButton.TabIndex = 4;
            this.RotateRightButton.Text = "RotateRight";
            this.RotateRightButton.UseVisualStyleBackColor = true;
            this.RotateRightButton.Click += new System.EventHandler(this.RotateRightButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BackButton.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.BackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BackButton.FlatAppearance.BorderSize = 0;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackButton.Location = new System.Drawing.Point(622, 359);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(99, 23);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ImageSelectorCB
            // 
            this.ImageSelectorCB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ImageSelectorCB.FormattingEnabled = true;
            this.ImageSelectorCB.Location = new System.Drawing.Point(620, 34);
            this.ImageSelectorCB.Name = "ImageSelectorCB";
            this.ImageSelectorCB.Size = new System.Drawing.Size(101, 21);
            this.ImageSelectorCB.TabIndex = 6;
            this.ImageSelectorCB.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // addImageBtn
            // 
            this.addImageBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addImageBtn.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.addImageBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addImageBtn.FlatAppearance.BorderSize = 0;
            this.addImageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addImageBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addImageBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addImageBtn.Location = new System.Drawing.Point(622, 61);
            this.addImageBtn.Name = "addImageBtn";
            this.addImageBtn.Size = new System.Drawing.Size(99, 23);
            this.addImageBtn.TabIndex = 7;
            this.addImageBtn.Text = "View Image";
            this.addImageBtn.UseVisualStyleBackColor = true;
            this.addImageBtn.Click += new System.EventHandler(this.addImageBtn_Click);
            // 
            // addTestResultLinkBTN
            // 
            this.addTestResultLinkBTN.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.addTestResultLinkBTN.BackgroundImage = global::Hospital.Properties.Resources.buttonbackground;
            this.addTestResultLinkBTN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.addTestResultLinkBTN.FlatAppearance.BorderSize = 0;
            this.addTestResultLinkBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addTestResultLinkBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTestResultLinkBTN.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.addTestResultLinkBTN.Location = new System.Drawing.Point(622, 115);
            this.addTestResultLinkBTN.Name = "addTestResultLinkBTN";
            this.addTestResultLinkBTN.Size = new System.Drawing.Size(99, 23);
            this.addTestResultLinkBTN.TabIndex = 8;
            this.addTestResultLinkBTN.Text = "Add new File";
            this.addTestResultLinkBTN.UseVisualStyleBackColor = true;
            this.addTestResultLinkBTN.Click += new System.EventHandler(this.addTestResultLinkBTN_Click);
            // 
            // TestResultViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(255)))), ((int)(((byte)(251)))));
            this.ClientSize = new System.Drawing.Size(733, 418);
            this.Controls.Add(this.addTestResultLinkBTN);
            this.Controls.Add(this.addImageBtn);
            this.Controls.Add(this.ImageSelectorCB);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.RotateRightButton);
            this.Controls.Add(this.RotateLeftButton);
            this.Controls.Add(this.ZoomOutButton);
            this.Controls.Add(this.ZoomInButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TestResultViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test Result";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private System.Windows.Forms.ComboBox ImageSelectorCB;
        private System.Windows.Forms.Button addImageBtn;
        private System.Windows.Forms.Button addTestResultLinkBTN;

    }
}