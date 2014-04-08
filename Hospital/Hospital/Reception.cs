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
                Statxt.Text = pat.getStatus().ToString();
                Roomtxt.Text = pat.getRoom().ToString();
            } catch (Exception) {
                MessageBox.Show("Patient ID must be valid number.", "Incorrect Patiet Id",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Newbtn_Click(object sender, EventArgs e) {

            //at some point I need to move this to patient class, also check for input values
            SqlConnection con = DBCon.DBConnect();

            con.Open();
            SqlCommand command = new SqlCommand("INSERT INTO Patient (FirstName, Surname, Gender, DOB," +
            "Address, Phone, Mobile, Allergies, CoverType, CoverNumber, Status, NextOfKin, NextOfKinPhone,"+
            "Room) VALUES (@first, @sur, @gen, @dob, @add, @ph, @mb, @all, @covert, @covern, @stat, @nok,"+
            " @nokp, @room); SELECT scope_identity();", con);

            command.Parameters.Add("@first", System.Data.SqlDbType.NVarChar, 20);
            command.Parameters["@first"].Value = Firtxt.Text;
            command.Parameters.Add("@sur", System.Data.SqlDbType.NVarChar, 20);
            command.Parameters["@sur"].Value = Surtxt.Text;
            command.Parameters.Add("@gen", System.Data.SqlDbType.NVarChar, 1);
            command.Parameters["@gen"].Value = Gentxt.Text;
            command.Parameters.Add("@dob", System.Data.SqlDbType.Date);
            command.Parameters["@dob"].Value = DOBtxt.Text;//Date will need some work to get correct formatting
            command.Parameters.Add("@add", System.Data.SqlDbType.NVarChar, 500);
            command.Parameters["@add"].Value = Addtxt.Text;
            command.Parameters.Add("@ph", System.Data.SqlDbType.Int);
            command.Parameters["@ph"].Value = Homtxt.Text;
            command.Parameters.Add("@mob", System.Data.SqlDbType.Int);
            command.Parameters["@mob"].Value = Mobtxt.Text;
            command.Parameters.Add("@all", System.Data.SqlDbType.NVarChar, 500);
            command.Parameters["@all"].Value = Altxt.Text;
            command.Parameters.Add("@covert", System.Data.SqlDbType.Int);
            command.Parameters["@covert"].Value = CovTtxt.Text;
            command.Parameters.Add("@covern", System.Data.SqlDbType.Int);
            command.Parameters["@covern"].Value = CovNtxt.Text;
            command.Parameters.Add("@stat", System.Data.SqlDbType.Bit);
            command.Parameters["@stat"].Value = Statxt.Text;
            command.Parameters.Add("@nok", System.Data.SqlDbType.NVarChar, 500);
            command.Parameters["@nok"].Value = NOKtxt.Text;
            command.Parameters.Add("@nokp", System.Data.SqlDbType.Int);
            command.Parameters["@nokp"].Value = NOKNtxt.Text;
            command.Parameters.Add("@room", System.Data.SqlDbType.NVarChar, 4);
            command.Parameters["@room"].Value = NOKNtxt.Text;

            
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
            Statxt.Text = "";
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
                } else {
                    MessageBox.Show("Patient was not admitted. Emergency room full", "Patient not Admitted",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if(PIDtxt.Text != "" && Roomtxt.Text != "0"){
                MessageBox.Show("Patient is currently admitted to hospital and is in room " + Roomtxt.Text, "Patient currently in hospital",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                MessageBox.Show("Please search for a patient.", "Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Savbtn_Click(object sender, EventArgs e) {
            //
        }

    }
}
