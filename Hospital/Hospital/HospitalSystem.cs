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
            if(role == "Doctor"){
                Button Surgerybtn = new Button();
                Surgerybtn.Name = "Surgerybtn";
                Surgerybtn.Size = new Size(150, 30);
                Surgerybtn.Text = "Book Surgery";
                Surgerybtn.Location = new Point(700, 400);
                Surgerybtn.Click += new EventHandler(Surgerybtn_Click);
                Controls.Add(Surgerybtn);

                Button Xraybtn = new Button();
                Xraybtn.Name = "Xraybtn";
                Xraybtn.Size = new Size(150, 30);
                Xraybtn.Text = "Book X-Ray";
                Xraybtn.Location = new Point(700, 440);
                Xraybtn.Click += new EventHandler(Xraybtn_Click);
                Controls.Add(Xraybtn);
            }
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

        private void Surgerybtn_Click(object sender, EventArgs e) {
            Facilities fac = new Facilities();

            bool success = fac.bookSurgery(pat);
            if (success == true) {
                MessageBox.Show("Patient: " + pat.getPatient() + " is now booked for surgery.", "Surgery booked",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                int PID = Int32.Parse(Seatxt.Text);
                pat = Patient.Search(PID);

                label1.Text = pat.getRoom();
            } else {
                MessageBox.Show("Patient surgery was not booked.", "Surgery not booked",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Xraybtn_Click(object sender, EventArgs e) {
            Facilities fac = new Facilities();

            bool success = fac.bookImaging(pat);
            if (success == true) {
                MessageBox.Show("Patient: " + pat.getPatient() + " is now booked for Xray.", "Xray booked",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                int PID = Int32.Parse(Seatxt.Text);
                pat = Patient.Search(PID);

                label1.Text = pat.getRoom();
            } else {
                MessageBox.Show("Patient Xray was not booked.", "Xray not booked",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
