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
    public partial class HospitalSystem : Form {
        private Form home;

        //Global variables
        string UserID; //String value of the UserID/StaffID
        string Role; //String value of the role User logged in under.

        public HospitalSystem() {
            InitializeComponent();
        }

        public HospitalSystem(string user, string role) {
            InitializeComponent();
            UserID = user;
            Role = role;

            //Demo to confirm works by updating label on form
            Welcomelbl.Text = "Welcome User:" + UserID + " Role: " + Role;
        }

        public void setHome(Form logout) {
            home = logout;
        }

        /*
         * May no longer be needed
        public void setUser(string User) {
            string name = "";
            string role = "";
            SqlConnection con = DBCon.DBConnect();

            con.Open();
            SqlCommand command = new SqlCommand("SELECT Staff.Role, Staff.Surname FROM Staff, Users WHERE Staff.StaffID = Users.StaffID AND Staff.StaffID = @id", con);
            command.Parameters.AddWithValue("@id", User);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                role = reader.GetString(0);
                name = reader.GetString(1);
            }
            Welcomelbl.Text = "Welcome " + role + " " + name;

            reader.Close();
            con.Close();
        }
         */


        // Logout user by returning to login screen
        private void Logoutbtn_Click(object sender, EventArgs e) {
            home.Show();
            Close();
        }

        private void Seabtn_Click(object sender, EventArgs e) {
            //take content of seatxt and make it a varible
            PatientGetSet pat = new PatientGetSet();
            int PID;

            //
            PID = Int32.Parse(Seatxt.Text);
            pat = Patient.Search(PID);

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
        }

    }
}
