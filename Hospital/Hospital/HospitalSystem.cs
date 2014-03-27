using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital {
    public partial class HospitalSystem : Form {
        private Form home;
        private PatientGetSet pat = new PatientGetSet();

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
            int PID = Int32.Parse(Seatxt.Text);
            pat = Patient.Search(PID);
            
            //Blank is used as if empty record then database doesnt return a date as null but
            //returns a date 1/01/0001
            DateTime blank = new DateTime(0001, 1, 01);


            PatInfolbl.Text = "Patient Info: \r\n";
            PatInfolbl.Text += pat.getFN() + " " + pat.getSN() + "\r\n";

            //Check if date is db equivalent of Null
            if (pat.getDOB() != blank) {
                PatInfolbl.Text += pat.getDOB();
            }
        }


    }
}
