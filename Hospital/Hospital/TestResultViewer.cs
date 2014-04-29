﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Hospital
{
    public partial class TestResultViewer : Form
    {
        private Size Multiplier = new Size(2, 2);

        public TestResultViewer()
        {
            InitializeComponent();
        }

        public void ZoomIn()
        {

            Image MyImage = pictureBox1.Image;

            Bitmap MyBitMap = new Bitmap(MyImage, Convert.ToInt32(MyImage.Width * Multiplier.Width),
                Convert.ToInt32(MyImage.Height * Multiplier.Height));

            Graphics Graphic = Graphics.FromImage(MyBitMap);

            Graphic.InterpolationMode = InterpolationMode.High;

            pictureBox1.Image = MyBitMap;

        }

        public void ZoomOut()
        {

            Image MyImage = pictureBox1.Image;

            Bitmap MyBitMap = new Bitmap(MyImage, Convert.ToInt32(MyImage.Width / Multiplier.Width),
                Convert.ToInt32(MyImage.Height / Multiplier.Height));

            Graphics Graphic = Graphics.FromImage(MyBitMap);

            Graphic.InterpolationMode = InterpolationMode.High;

            pictureBox1.Image = MyBitMap;
        }

        private void ZoomInButton_Click(object sender, EventArgs e)
        {
            ZoomIn();
        }

        private void ZoomOutButton_Click(object sender, EventArgs e)
        {
            ZoomOut();
        }

        private void RotateLeftButton_Click(object sender, EventArgs e)
        {
            Image im = pictureBox1.Image;
            im.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = im;
        }

        private void RotateRightButton_Click(object sender, EventArgs e)
        {
            Image im = pictureBox1.Image;
            im.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = im;
        }

        private void BackButton_Click(object sender, EventArgs e) {
            ActiveForm.Close();
        } 
    }
}