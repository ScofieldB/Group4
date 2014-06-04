using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

/*
 * Form is responsible for selecting and then adding an image to a patient's file
 * on database.
 */
namespace Hospital {
    public partial class TestResultAdd : Form {

        private string userID;
        private int patient;

        /*
         * Constructor to initialize form
         * \param string userID - userID of user logged in
         * \param int patientnum - patientID of the patient file being added to
         */
        public TestResultAdd(string userID, int patientnum) {
            patient = patientnum;
            this.userID = userID;
            InitializeComponent();
        }

        /*
         * Opens a window for user to select where the image is located on the
         * computer.
         */
        private void Loadbtn_Click(object sender, EventArgs e) {
            OpenFileDialog ofd = new OpenFileDialog();
            System.Windows.Forms.DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK) {
                userSelectedFilePath = ofd.FileName;
            }
        }

        /*
         * Getter/Setter for the userSelectedFilePath variable
         */
        public string userSelectedFilePath {
            get {
                return filePathLbl.Text;
            }
            set {
                filePathLbl.Text = value;
                filePathLbl.Visible = true;
            }
        }

        /*
         * Button to upload the selected image to database that was found 
         * by using the Load button
         */
        private void Uploadbtn_Click(object sender, EventArgs e) {
            DateTime currentDT = DateTime.Now;
            try {
                //Set up connection to be opened.
                SqlConnection con = DBCon.DBConnect();
                SqlCommand cmd = new SqlCommand("UPDATE Tests SET TestResults = @TestResults, UploadedByStaffID = @user, DateUploaded = @date WHERE TestResults IS NULL AND PatientID = @pat", con);

                cmd.Parameters.AddWithValue("@user", userID);
                cmd.Parameters.AddWithValue("@Date", currentDT);
                cmd.Parameters.AddWithValue("@pat", patient);

                string imageFilePath = userSelectedFilePath;
                // string rawImageFilePath = userSelectedFilePath;
                //  string ImageFilePath = rawImageFilePath.Replace(@"\", @"/");
                Cancelbtn.Text = imageFilePath;

                //Read jpg into file stream, and from there into Byte array.
                FileStream imageFileStream = new FileStream(imageFilePath, FileMode.Open, FileAccess.Read);
                Byte[] bytTestResultsImage = new Byte[imageFileStream.Length];
                imageFileStream.Read(bytTestResultsImage, 0, bytTestResultsImage.Length);
                imageFileStream.Close();

                //Create parameter for insert command and add to SqlCommand object.
                SqlParameter prm = new SqlParameter("@TestResults", SqlDbType.VarBinary, bytTestResultsImage.Length, ParameterDirection.Input, false,
                          0, 0, null, DataRowVersion.Current, bytTestResultsImage);
                cmd.Parameters.Add(prm);

                //Open connection, execute query, close connection.
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                ActiveForm.Close();
            } catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /*
         * Cancel the selection of image to upload and closes the form
         */
        private void Cancelbtn_Click(object sender, EventArgs e) {
            ActiveForm.Close();
        }
    }
}
