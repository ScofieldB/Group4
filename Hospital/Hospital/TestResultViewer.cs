using System;
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
        private Size multiplier = new Size(2, 2);

        private string imagename;
        private string role;
        private string userID;
        private int patientId;
        private int zoomValue = 0;

        public TestResultViewer(string userID, string role, int patient) {
            patientId = patient;
            this.role = role;
            this.userID = userID;
            InitializeComponent();
            this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            LoadComboBox();
            if (role == "MedTech") {
                addTestResultLinkBTN.Visible = true;
            } else {
                addTestResultLinkBTN.Visible = false;
            }
        }


        private void LoadComboBox() {
            try {
                SqlConnection con = DBCon.DBConnect();
                string query = "SELECT TestOrdered FROM Tests WHERE PatientID ='" + patientId + "' AND TestResults IS NOT NULL";
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

            if (zoomValue < 2) {
                Image myImage = pictureBox1.Image;

                Bitmap myBitMap = new Bitmap(myImage, Convert.ToInt32(myImage.Width * multiplier.Width),
                    Convert.ToInt32(myImage.Height * multiplier.Height));

                Graphics graphic = Graphics.FromImage(myBitMap);

                graphic.InterpolationMode = InterpolationMode.High;

                pictureBox1.Image = myBitMap;

                zoomValue = zoomValue + 1;
            } else {
                MessageBox.Show("Cannot zoom further.", "Zoom Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void ZoomOut() {

            if (zoomValue > -3) {

                Image myImage = pictureBox1.Image;

                Bitmap myBitMap = new Bitmap(myImage, Convert.ToInt32(myImage.Width / multiplier.Width),
                    Convert.ToInt32(myImage.Height / multiplier.Height));

                Graphics graphic = Graphics.FromImage(myBitMap);

                graphic.InterpolationMode = InterpolationMode.High;

                pictureBox1.Image = myBitMap;

                zoomValue = zoomValue - 1;
            } else {
                MessageBox.Show("Cannot zoom further.", "Zoom Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ZoomInButton_Click(object sender, EventArgs e) {
            ZoomIn();
        }

        private void ZoomOutButton_Click(object sender, EventArgs e) {
            ZoomOut();
        }

        private void RotateLeftButton_Click(object sender, EventArgs e) {
            Image image = pictureBox1.Image;
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = image;
        }

        private void RotateRightButton_Click(object sender, EventArgs e) {
            Image image = pictureBox1.Image;
            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = image;
        }

        private void BackButton_Click(object sender, EventArgs e) {
            ActiveForm.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

            if (ImageSelectorCB.SelectedItem != null) {
                imagename = ImageSelectorCB.SelectedValue.ToString();
            }
        }

        private void addImageBtn_Click(object sender, EventArgs e) {
            try {
                zoomValue = 0;
                SqlConnection con = DBCon.DBConnect();
                con.Open();

                //Retrieve BLOB from database into DataSet.
                SqlCommand cmd = new SqlCommand("SELECT TestResults FROM Tests WHERE TestOrdered = @Imagename", con);
                cmd.Parameters.AddWithValue("@Imagename", imagename);
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
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                }
                con.Close();
            } catch {
                MessageBox.Show("Please select a image to display.", "Image Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addTestResultLinkBTN_Click(object sender, EventArgs e) {
            TestResultAdd Tests = new TestResultAdd(userID, patientId);
            Tests.Show();
        }
    }
}
