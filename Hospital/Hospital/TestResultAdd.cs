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

namespace Hospital {
    public partial class TestResultAdd : Form {

        private string userID;
        private int patient;

        public TestResultAdd(string userID, int patientnum) {
            patient = patientnum;
            this.userID = userID;
            InitializeComponent();
        }

        private void Loadbtn_Click(object sender, EventArgs e) {
            LoadNewFile();
        }

        private void LoadNewFile() {
            OpenFileDialog ofd = new OpenFileDialog();
            System.Windows.Forms.DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK) {
                UserSelectedFilePath = ofd.FileName;
            }
        }

        public string UserSelectedFilePath {
            get {
                return filePathLbl.Text;
            }
            set {
                filePathLbl.Text = value;
                filePathLbl.Visible = true;
            }
        }

        private void Uploadbtn_Click(object sender, EventArgs e) {
            DateTime currentDT = DateTime.Now;
            try {
                //Set up connection to be opened.
                SqlConnection con = DBCon.DBConnect();
                SqlCommand cmd = new SqlCommand("UPDATE Tests SET TestResults = @TestResults, UploadedByStaffID = @user, DateUploaded = @date WHERE TestResults IS NULL AND PatientID = @pat", con);

                cmd.Parameters.AddWithValue("@user", userID);
                cmd.Parameters.AddWithValue("@Date", currentDT);
                cmd.Parameters.AddWithValue("@pat", patient);

                string imageFilePath = UserSelectedFilePath;
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

        private void Cancelbtn_Click(object sender, EventArgs e) {
            ActiveForm.Close();
        }
    }
}
