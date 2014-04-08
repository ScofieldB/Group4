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

namespace Hospital {
    public partial class Reception : Form {

        private Form home;
        private PatientGetSet pat = new PatientGetSet();

        //Global variables
        string UserID; //String value of the UserID/StaffID
        string Role; //String value of the role User logged in under.

        public Reception() {
            InitializeComponent();
        }


        /*
         * Sets up form and updates UserID variable with user parameter passed.
         */
        public Reception(string user) {
            InitializeComponent();
            UserID = user;

            //Demo to confirm works by updating label on form
            Welcomelbl.Text = "Welcome User:" + UserID;
        }


        /*
         * setHome is used for navigational purposes to and from the
         * Login screen.
         */
        public void setHome(Form logout) {
            home = logout;
        }


        // Logout user by returning to login screen
        private void Logoutbtn_Click(object sender, EventArgs e) {
            home.Show();
            Close();
        }

        /*
         * When patient is searched for update user information into
         * text boxes on screen.
         */
        private void Searchbtn_Click(object sender, EventArgs e) {
            try {
                int PID = Int32.Parse(Seatxt.Text);
                pat = Patient.Search(PID);

                //Test Comment, getset
                PIDtxt.Text = pat.getPatient().ToString();
                Surtxt.Text = pat.getSN();
                Firtxt.Text = pat.getFN();
                DOBtxt.Text = pat.getDOB().ToString();
                Gentxt.Text = pat.getGender();
                NOKtxt.Text = pat.getNextKin();
                NOKNtxt.Text = pat.getKP().ToString();
                Addtxt.Text = pat.getAddress();
                Homtxt.Text = pat.getPhone().ToString();
                Mobtxt.Text = pat.getMobile().ToString();
                CovTtxt.Text = pat.getCoverT().ToString();
                CovNtxt.Text = pat.getCoverN().ToString();
                Altxt.Text = pat.getAllergies();
                Statxt.Text = pat.getStatus().ToString();//dropdown box eventually
                Roomtxt.Text = pat.getRoom().ToString();
            }
            catch (Exception) {
                MessageBox.Show("Patient ID must be valid number.", "Incorrect Patiet Id",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        *Takes entered details, populates them with new PK, returns new PK
         */
        private void Newbtn_Click(object sender, EventArgs e) {

            //at some point I need to move this to patient class, also check for input values (this actually auto checks that)
            //seems the reason I get no error message is due to some datatype issues

            if (string.IsNullOrEmpty(PIDtxt.Text) || string.IsNullOrEmpty(Surtxt.Text) || string.IsNullOrEmpty(Firtxt.Text) ||
                string.IsNullOrEmpty(DOBtxt.Text) || string.IsNullOrEmpty(Gentxt.Text) || string.IsNullOrEmpty(NOKtxt.Text) ||
                string.IsNullOrEmpty(NOKNtxt.Text) || string.IsNullOrEmpty(Addtxt.Text) || string.IsNullOrEmpty(Homtxt.Text) ||
                string.IsNullOrEmpty(Mobtxt.Text) || string.IsNullOrEmpty(CovTtxt.Text) || string.IsNullOrEmpty(CovNtxt.Text) ||
                string.IsNullOrEmpty(Altxt.Text) || string.IsNullOrEmpty(Statxt.Text) || string.IsNullOrEmpty(Roomtxt.Text)) {

                MessageBox.Show("Please insert some patient information into all required fields.", "Incorrect Patiet Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else {
                using (SqlConnection con = DBCon.DBConnect()) {

                    con.Open();

                    string insertquery = ("INSERT INTO Patient (FirstName, Surname, Gender, DOB," +
                    "Address, Phone, Mobile, Allergies, CoverType, CoverNumber, Status, NextOfKin, NextOfKinPhone," +
                    "Room) VALUES (@first, @sur, @gen, @dob, @add, @ph, @mb, @all, @covert, @covern, @stat, @nok," +
                    " @nokp, @room); SET @PAT_ID = SCOPE_IDENTITY();");

                    using (SqlCommand command = new SqlCommand(insertquery, con)) {

                        //Matching datatype with what is listed in the database, will attempt to find a point of 
                        //checking inputs prior to this point, when I move it to a class of it's own
                        command.Parameters.Add("@first", System.Data.SqlDbType.NVarChar, 20).Value = Firtxt.Text;
                        command.Parameters.Add("@sur", System.Data.SqlDbType.NVarChar, 20).Value = Surtxt.Text;
                        command.Parameters.Add("@gen", System.Data.SqlDbType.NVarChar, 1).Value = Gentxt.Text;
                        command.Parameters.Add("@dob", System.Data.SqlDbType.Date).Value = DOBtxt.Text;//Date will need some work to get correct formatting
                        command.Parameters.Add("@add", System.Data.SqlDbType.NVarChar, 500).Value = Addtxt.Text;
                        command.Parameters.Add("@ph", System.Data.SqlDbType.Int).Value = Homtxt.Text;
                        command.Parameters.Add("@mob", System.Data.SqlDbType.Int).Value = Mobtxt.Text;
                        command.Parameters.Add("@all", System.Data.SqlDbType.NVarChar, 500).Value = Altxt.Text;
                        command.Parameters.Add("@covert", System.Data.SqlDbType.Int).Value = CovTtxt.Text;
                        command.Parameters.Add("@covern", System.Data.SqlDbType.Int).Value = CovNtxt.Text;
                        command.Parameters.Add("@stat", System.Data.SqlDbType.Bit).Value = Statxt.Text;
                        command.Parameters.Add("@nok", System.Data.SqlDbType.NVarChar, 500).Value = NOKtxt.Text;
                        command.Parameters.Add("@nokp", System.Data.SqlDbType.Int).Value = NOKNtxt.Text;
                        command.Parameters.Add("@room", System.Data.SqlDbType.NVarChar, 4).Value = Roomtxt.Text;

                        //try {

                        command.ExecuteScalar();

                        int PID = Convert.ToInt32(command.Parameters["@PAT_ID"].Value);
                        PIDtxt.Text = PID.ToString();

                        con.Close();

                        // }
                        // catch (Exception) { //this will need to be expanded or changed at somepoint to check each input field
                        //     MessageBox.Show("Patient details must be valid for each input field.", "Incorrect Patiet Information Layout",
                        //          MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //  }
                        //   finally {
                        //      con.Close();
                        // }
                    }
                }
            }
        }

        /*
         * Clears the information displayed on screen.
         */
        private void Clrbtn_Click(object sender, EventArgs e) {
            PIDtxt.Text = "";
            Surtxt.Text = "";
            Firtxt.Text = "";
            DOBtxt.Text = "";
            Gentxt.Text = "";
            NOKtxt.Text = "";
            NOKNtxt.Text = "";
            Addtxt.Text = "";
            Homtxt.Text = "";
            Mobtxt.Text = "";
            CovTtxt.Text = "";
            CovNtxt.Text = "";
            Altxt.Text = "";
            Statxt.Text = "";//needs to become drop down box
            Roomtxt.Text = "";
        }

        /*
         * Admit patient into Emergency room and display message of confirmation or error.
         */
        private void Admitbtn_Click(object sender, EventArgs e) {
            Facilities fac = new Facilities();

            if (PIDtxt.Text != "" && PIDtxt.Text != "0" && Roomtxt.Text == "0") {
                bool success = fac.admitPatient(pat.getPatient());
                if (success == true) {
                    MessageBox.Show("Patient: " + pat.getPatient() + " is now admitted.", "Patient Admitted",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    int PID = Int32.Parse(Seatxt.Text);
                    pat = Patient.Search(PID);

                    Roomtxt.Text = pat.getRoom();
                }
                else {
                    MessageBox.Show("Patient was not admitted. Emergency room full", "Patient not Admitted",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (PIDtxt.Text != "" && Roomtxt.Text != "0") {
                MessageBox.Show("Patient is currently admitted to hospital and is in room " + Roomtxt.Text, "Patient currently in hospital",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                MessageBox.Show("Please search for a patient.", "Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
        * Updates currently present information in text fields corrosponding to ID field.
         */
        private void Savbtn_Click(object sender, EventArgs e) {
            //update query to push current contents of textboxes to database, spits out a complete message


            //change this later to only include the notnull fields
            if (string.IsNullOrEmpty(PIDtxt.Text) || string.IsNullOrEmpty(Surtxt.Text) || string.IsNullOrEmpty(Firtxt.Text) ||
               string.IsNullOrEmpty(DOBtxt.Text) || string.IsNullOrEmpty(Gentxt.Text) || string.IsNullOrEmpty(NOKtxt.Text) ||
               string.IsNullOrEmpty(NOKNtxt.Text) || string.IsNullOrEmpty(Addtxt.Text) || string.IsNullOrEmpty(Homtxt.Text) ||
               string.IsNullOrEmpty(Mobtxt.Text) || string.IsNullOrEmpty(CovTtxt.Text) || string.IsNullOrEmpty(CovNtxt.Text) ||
               string.IsNullOrEmpty(Altxt.Text) || string.IsNullOrEmpty(Statxt.Text) || string.IsNullOrEmpty(Roomtxt.Text)) {

                MessageBox.Show("Please insert some patient information into all required fields.", "Incorrect Patiet Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else {

                int PID = Int32.Parse(PIDtxt.Text);
                string surname = Surtxt.Text;
                string firstname = Firtxt.Text;
                DateTime DOB = DateTime.Parse(DOBtxt.Text);
                string gender = Gentxt.Text;
                string nextofkin = NOKtxt.Text;
                int kinphone = Int32.Parse(NOKNtxt.Text);
                string address = Addtxt.Text;
                int home = Int32.Parse(Homtxt.Text);
                int mobile = Int32.Parse(Mobtxt.Text);
                int covertype = Int32.Parse(CovTtxt.Text);
                int covernum = Int32.Parse(CovNtxt.Text);
                string allergies = Altxt.Text;
                bool status = Boolean.Parse(Statxt.Text);//needs to be changed to a drop down box
                string room = Roomtxt.Text;

                SqlConnection con = DBCon.DBConnect();
                con.Open();


                string updatequery = ("UPDATE [Patient] SET PatientID = @pid, FirstName = @first, Surname = @sur, Gender = @gen," +
                "DOB = @dob, Address = @add, Phone = @ph, Mobile = @mb, Allergies = @all, CoverType = @covert," +
                "CoverNumber = @covern, Status = @stat, NextOfKin = @nok, NextOfKinPhone = @nokp, Room = @room");
                SqlCommand command = new SqlCommand(updatequery, con);

                command.Parameters.AddWithValue("@pid", PID);
                command.Parameters.AddWithValue("@first", firstname);
                command.Parameters.AddWithValue("@sur", surname);
                command.Parameters.AddWithValue("@gen", gender);
                command.Parameters.AddWithValue("@dob", DOB);
                command.Parameters.AddWithValue("@add", address);
                command.Parameters.AddWithValue("@ph", home);
                command.Parameters.AddWithValue("@mob", mobile);
                command.Parameters.AddWithValue("@all", allergies);
                command.Parameters.AddWithValue("@covert", covertype);
                command.Parameters.AddWithValue("@covern", covernum);
                command.Parameters.AddWithValue("@stat", status);
                command.Parameters.AddWithValue("@nok", nextofkin);
                command.Parameters.AddWithValue("@nokp", kinphone);
                command.Parameters.AddWithValue("@room", room);

                try {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Update Succesfully");
                }
                catch (Exception) {
                    MessageBox.Show("Something shat itself", "Ah crap",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                con.Close();
            }
        }
    }
}
