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

        public Reception(string user, string role) {
            InitializeComponent();
            UserID = user;
            Role = role;

            //Demo to confirm works by updating label on form
            Welcomelbl.Text = "Welcome User:" + UserID + " Role: " + Role;
        }

        public void setHome(Form logout) {
            home = logout;
        }


        // Logout user by returning to login screen
        private void Logoutbtn_Click(object sender, EventArgs e) {
            home.Show();
            Close();
        }

        private void Seabtn_Click(object sender, EventArgs e) {
            //take content of seatxt and make it a varible
            
            //
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
        }

        private void Newbtn_Click(object sender, EventArgs e) {

        }

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

    }
}
