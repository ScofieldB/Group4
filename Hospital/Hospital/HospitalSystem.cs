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
        private PatientGetSet pat = new PatientGetSet();
        private Facilities fac = new Facilities();

        //Global variables
        string UserID; //String value of the UserID/StaffID
        string Role; //String value of the role User logged in under.
        string TypedHistory;
        int PID;

        public HospitalSystem() {
            InitializeComponent();
        }


        /*
         * Costructor that sets up Hopsital form used by doctors and medical technicians.
         * Will set up different button display based upon which role is passed as parameter.
         * 
         * Paramaters:
         *      string user - sets global variable UserID
         *      string role - sets global variable Role
         */
        public HospitalSystem(string user, string role) {
            InitializeComponent();
            UserID = user;
            Role = role;
            if(role == "Doctor"){
                Button ViewImgbtn = new Button();
                ViewImgbtn.Name = "ViewImgbtn";
                ViewImgbtn.Size = new Size(150, 30);
                ViewImgbtn.Text = "View Image";
                ViewImgbtn.Location = new Point(750, 360);
                ViewImgbtn.Click += new EventHandler(ViewImgbtn_Click);
                Controls.Add(ViewImgbtn);


                Button Surgerybtn = new Button();
                Surgerybtn.Name = "Surgerybtn";
                Surgerybtn.Size = new Size(150, 30);
                Surgerybtn.Text = "Book Surgery";
                Surgerybtn.Location = new Point(750, 400);
                Surgerybtn.Click += new EventHandler(Surgerybtn_Click);
                Controls.Add(Surgerybtn);

                Button Xraybtn = new Button();
                Xraybtn.Name = "Xraybtn";
                Xraybtn.Size = new Size(150, 30);
                Xraybtn.Text = "Book X-Ray";
                Xraybtn.Location = new Point(750, 440);
                Xraybtn.Click += new EventHandler(Xraybtn_Click);
                Controls.Add(Xraybtn);
            } else if (role == "MedTech") {
                Button Finishbtn = new Button();
                Finishbtn.Name = "Fininishbtn";
                Finishbtn.Size = new Size(150, 30);
                Finishbtn.Text = "Finish";
                Finishbtn.Location = new Point(700, 400);
                Finishbtn.Click += new EventHandler(Finishbtn_Click);
                Controls.Add(Finishbtn);
            }
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


        private void ViewImgbtn_Click(object sender, EventArgs e) {
            TestResultViewer Tests = new TestResultViewer();
            Tests.Show();
        }


        
        /*
         * When a search via PatientID is undertaken then a patients first name, 
         * surname, date of birth and current room location are displayed.
         */
        private void Searchbtn_Click(object sender, EventArgs e) 
            {
            try {
                PID = Int32.Parse(Seatxt.Text);
                pat = Patient.Search(PID);


                //Blank is used as if empty record then database doesnt return a date as null but
                //returns a date 1/01/0001
                DateTime blank = new DateTime(0001, 1, 01);

                updateTable(PID);

                PatInfolbl.Text = "Patient Info: \r\n";
                PatInfolbl.Text += pat.getFN() + " " + pat.getSN() + "\r\n";
                currentRoomtxt.Text = "Current Room: " + pat.getRoom();
                //Check if date is db equivalent of Null
                if (pat.getDOB() != blank) {
                    PatInfolbl.Text += pat.getDOB();
                }
            } catch (Exception) {
                MessageBox.Show("Patient ID must be valid number.", "Incorrect Patiet Id",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*
         * Books patient for a Surgery and display message of completion
         * or error.   
         */
        private void Surgerybtn_Click(object sender, EventArgs e) {

            if (pat.getPatient() != -1) {
                bool success = fac.bookSurgery(pat);
                if (success == true) {
                    MessageBox.Show("Patient: " + pat.getPatient() + " is now booked for surgery.", "Surgery booked",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    pat = Patient.Search(pat.getPatient());

                    currentRoomtxt.Text = "Current Room: " + pat.getRoom();
                } else {
                    MessageBox.Show("Patient surgery was not booked.", "Surgery not booked",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Please search for a patient.", "Patient Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*
         * Books patient for a Xray and display message of completion
         * or error.
         */
        private void Xraybtn_Click(object sender, EventArgs e) {

            if(pat.getPatient() != -1){
                bool success = fac.bookImaging(pat);
                if (success == true) {
                    MessageBox.Show("Patient: " + pat.getPatient() + " is now booked for Xray.", "Xray booked",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    pat = Patient.Search(pat.getPatient());

                    currentRoomtxt.Text = "Current Room: " + pat.getRoom();
                } else {
                    MessageBox.Show("Patient Xray was not booked.", "Xray not booked",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Please search for a patient.", "Patient Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*
         * When surgery or xray is complete return patient back to
         * emergency room.
         */
        private void Finishbtn_Click(object sender, EventArgs e) {
            if (pat.getPatient() != -1) {
                fac.returnPatientToDoctor(pat);
                pat = Patient.Search(pat.getPatient());
                currentRoomtxt.Text = "Current Room: " + pat.getRoom(); 
            } else {
                MessageBox.Show("Please search for a patient.", "Patient Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addHistorybtn_Click(object sender, EventArgs e)                //add history
        {
            TypedHistory = addHistorytbx.Text;

            SqlConnection con = DBCon.DBConnect();
            con.Open();
            SqlCommand command = new SqlCommand("INSERT INTO History (PatientID, StaffID, History, Date) VALUES (@pid, @userid, @typedhistory, GetDate());", con);
            command.Parameters.AddWithValue("@pid", PID);
            command.Parameters.AddWithValue("@userid", UserID);
            command.Parameters.AddWithValue("@typedhistory", TypedHistory);
            command.ExecuteNonQuery();
            updateTable(PID);
            con.Close();

        }

        private void updateTable(int PID)                   //view history
        {
            SqlConnection con = DBCon.DBConnect();
            SqlCommand command = new SqlCommand("SELECT * FROM History WHERE PatientID = @pid", con);
            command.Parameters.AddWithValue("@pid", PID);

            SqlDataAdapter DataAdapter = new SqlDataAdapter();
            DataAdapter.SelectCommand = command;
            DataSet ds = new DataSet();
            con.Open();
            DataAdapter.Fill(ds, "History");
            con.Close();
            historyDataGridView.DataSource = ds;
            historyDataGridView.DataMember = "History";
        }
    }
}
