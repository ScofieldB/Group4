﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;


namespace Hospital {
    public partial class TestResultViewer : Form {
        private Size Multiplier = new Size(2, 2);

        private PatientGetSet pat = new PatientGetSet();

        private string Imagename;

        public TestResultViewer()
        {
            InitializeComponent();
            LoadComboBox(pat);
        }


        private void LoadComboBox(PatientGetSet pat)
        {
            try {
                SqlConnection con = DBCon.DBConnect();
                string query = "SELECT TestOrdered FROM Tests WHERE PatientID ='" + pat.getPatient() + "' AND TestOrdered IS NOT NULL";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                con.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Test");
                ImageSelectorCB.DisplayMember = "TestOrdered";
                ImageSelectorCB.ValueMember = "TestOrdered";
                ImageSelectorCB.DataSource = ds.Tables["Test"];
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        public void ZoomIn() {

            Image MyImage = pictureBox1.Image;

            Bitmap MyBitMap = new Bitmap(MyImage, Convert.ToInt32(MyImage.Width * Multiplier.Width),
                Convert.ToInt32(MyImage.Height * Multiplier.Height));

            Graphics Graphic = Graphics.FromImage(MyBitMap);

            Graphic.InterpolationMode = InterpolationMode.High;

            pictureBox1.Image = MyBitMap;

        }

        public void ZoomOut() {

            Image MyImage = pictureBox1.Image;

            Bitmap MyBitMap = new Bitmap(MyImage, Convert.ToInt32(MyImage.Width / Multiplier.Width),
                Convert.ToInt32(MyImage.Height / Multiplier.Height));

            Graphics Graphic = Graphics.FromImage(MyBitMap);

            Graphic.InterpolationMode = InterpolationMode.High;

            pictureBox1.Image = MyBitMap;
        }

        private void ZoomInButton_Click(object sender, EventArgs e) {
            ZoomIn();
        }

        private void ZoomOutButton_Click(object sender, EventArgs e) {
            ZoomOut();
        }

        private void RotateLeftButton_Click(object sender, EventArgs e) {
            Image im = pictureBox1.Image;
            im.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = im;
        }

        private void RotateRightButton_Click(object sender, EventArgs e) {
            Image im = pictureBox1.Image;
            im.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = im;
        }

        private void BackButton_Click(object sender, EventArgs e) {
            ActiveForm.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

            if (ImageSelectorCB.SelectedItem != null) {
                Imagename = ImageSelectorCB.SelectedValue.ToString();
            }
        }

        private void addImageBtn_Click(object sender, EventArgs e) {
            try {
                SqlConnection con = DBCon.DBConnect();
                con.Open();

                //Retrieve BLOB from database into DataSet.
                SqlCommand cmd = new SqlCommand("SELECT TestResults FROM Tests WHERE TestOrdered = @Imagename", con);
                cmd.Parameters.AddWithValue("@Imagename", Imagename);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Tests");
                int RowCount = ds.Tables["Tests"].Rows.Count;

                if (RowCount > 0) {   
                    //BLOB is read into Byte array, then used to construct MemoryStream,
                    //then passed to PictureBox.
                    Byte[] byteTestResultsImage = new Byte[0];
                    byteTestResultsImage = (Byte[])(ds.Tables["Tests"].Rows[RowCount - 1]["TestResults"]);
                    MemoryStream ImageMemoryStream = new MemoryStream(byteTestResultsImage);
                    pictureBox1.Image = Image.FromStream(ImageMemoryStream);
                }
                con.Close();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void addTestResultLinkBTN_Click(object sender, EventArgs e) {
            TestResultAdd Tests = new TestResultAdd();
            Tests.Show();
        }
    }
}
