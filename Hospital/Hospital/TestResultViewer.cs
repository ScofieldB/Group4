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

/*
 * Form is responsible for all image selection and manipulation features
 */
namespace Hospital {
    public partial class TestResultViewer : Form {
        private Size multiplier = new Size(2, 2);

        private string imagename;
        private string role;
        private string userID;
        private int patientId;
        private int zoomValue = 0;


        /*
         * Constructor to initialize form
         * \param string userID - userID of user logged in
         * \parm string role - role of the user logged in
         * \param int patient - patientID of the patient file being added to
         */
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


        /*
         * Populates the images within the Image selection combo box
         */
        public void LoadComboBox() {
            ImageSelectorCB.Items.Clear();
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


        /*
         * Manipulates the current image displayed to zoom in.
         */
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


        /*
         * Manipulates the current image displayed to zoom out.
         */
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


        /*
         * Button to manipulate the current image displayed to zoom in.
         */
        private void ZoomInButton_Click(object sender, EventArgs e) {
            ZoomIn();
        }


        /*
         * Button to manipulate the current image displayed to zoom out.
         */
        private void ZoomOutButton_Click(object sender, EventArgs e) {
            ZoomOut();
        }


        /*
         * Button to manipulate the current image displayed to rotate let.
         */
        private void RotateLeftButton_Click(object sender, EventArgs e) {
            Image image = pictureBox1.Image;
            image.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = image;
        }


        /*
         * Button to manipulate the current image displayed to rotate right.
         */
        private void RotateRightButton_Click(object sender, EventArgs e) {
            Image image = pictureBox1.Image;
            image.RotateFlip(RotateFlipType.Rotate270FlipNone);
            pictureBox1.Image = image;
        }


        /*
         * On Click event for button to navigate back once.
         */
        private void BackButton_Click(object sender, EventArgs e) {
            ActiveForm.Close();
        }


        /*
         * When ImageSelector combo box index change event occurs, updates appropriate variable 
         */
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

            if (ImageSelectorCB.SelectedItem != null) {
                imagename = ImageSelectorCB.SelectedValue.ToString();
            }
        }

        /*
         * Button to display the chosen image in the image selection combobox.
         */
        private void ViewImageBtn_Click(object sender, EventArgs e) {
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
                    MemoryStream imageMemoryStream = new MemoryStream(byteTestResultsImage);
                    pictureBox1.Image = Image.FromStream(imageMemoryStream);
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                }
                con.Close();
            } catch {
                MessageBox.Show("Please select a image to display.", "Image Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*
         * Button to open the TestResultAdd form in order to choose a new image
         * to be added to patients file.
         */
        private void addTestResultLinkBTN_Click(object sender, EventArgs e) {
            TestResultAdd tests = new TestResultAdd(userID, patientId);
            tests.Show();
        }
    }
}
