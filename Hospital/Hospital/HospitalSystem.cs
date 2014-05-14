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
        private Form homeScreen;
        private PatientGetSet pat = new PatientGetSet();
        private Facilities fac = new Facilities();
        private FinanceCmbItem typeBooked;

        //Global variables
        private string UserID; //String value of the UserID/StaffID
        private string Role; //String value of the role User logged in under.

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
            if (role == "Doctor") {
                ViewImgbtn.Visible = false;
                Surgerybtn.Visible = false;
                Imagingbtn.Visible = false;
                Finishbtn.Visible = false;

            } else if (role == "MedTech") {
                ViewImgbtn.Visible = true;
                Surgerybtn.Visible = false;
                Imagingbtn.Visible = false;
                Finishbtn.Visible = true;
            }
        }



        /*
         * setHome is used for navigational purposes to and from the
         * Login screen.
         */
        public void setHome(Form logout) {
            homeScreen = logout;
        }

        public void setPatient(PatientGetSet patient) {
            pat = patient;

            //Blank is used as if empty record then database doesnt return a date as null but
            //returns a date 1/01/0001
            DateTime blank = new DateTime(0001, 1, 01);
            updateTable(pat.getPatient());

            PatInfolbl.Text = "Patient Info: \r\n";
            PatInfolbl.Text += pat.getFN() + " " + pat.getSN() + "\r\n";
            currentRoomtxt.Text = "Current Room: " + pat.getRoom();

            if (pat.getDOB() != blank) {
                PatInfolbl.Text += pat.getDOB();
            }

            if (Role == "Doctor") {
                Finishbtn.Visible = false;
                if (pat.getRoom() == "E100") {
                    Surgerybtn.Visible = true;
                    Imagingbtn.Visible = true;
                    ViewImgbtn.Visible = true;
                } else {
                    Surgerybtn.Visible = false;
                    Imagingbtn.Visible = false;
                    ViewImgbtn.Visible = false;
                }
                
            } else {
                Finishbtn.Visible = true;
            }
        }

        // Logout user by returning to login screen
        private void Logoutbtn_Click(object sender, EventArgs e) {
            homeScreen.Show();
            Close();
        }

        // Allows the user to view images of the selected patient
        private void ViewImgbtn_Click(object sender, EventArgs e) {
            if (pat.getPatient() != -1)
            {
                TestResultViewer Tests = new TestResultViewer();
                Tests.Show();
            }
            else
            {
                MessageBox.Show("Please search for a patient.", "Patient Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * When a search via Surname is undertaken then a patients first name, 
         * surname, date of birth and current room location are displayed.
         */
        private void Searchbtn_Click(object sender, EventArgs e) {
            if (Seatxt.Text != "") {
                PatientGetSet[] patients;
                string Surname = Seatxt.Text;

                patients = Patient.searchPatientSurname(Surname);

                if (patients.Length == 0) {
                    MessageBox.Show("Patient could not be found in system.", "Patient try again.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else if (patients.Length == 1) {
                    setPatient(patients[0]);
                } else {
                    ChoosePatient choosePat = new ChoosePatient(UserID, Role, homeScreen, this, Surname, patients);
                    ActiveForm.Close();
                    choosePat.Show();
                }

            } else {
                MessageBox.Show("Please input a Surname to search.", "Surname must be input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updatePatient() {
            pat = Patient.SearchPID(pat.getPatient());

            currentRoomtxt.Text = "Current Room: " + pat.getRoom();
            addHistory("Patiet is booked for " + typeBooked.ToString());
            Surgerybtn.Visible = false;
            Imagingbtn.Visible = false;
            ViewImgbtn.Visible = true;
        }


        /*
         * Books patient for a Surgery and display message of completion
         * or error.   
         */
        private void Surgerybtn_Click(object sender, EventArgs e) {

            if (pat.getPatient() != -1) {
                Finance finance = new Finance("Surgery", this);
                finance.ShowDialog();
                if (typeBooked != null) {
                    bool success = fac.bookSurgery(pat, typeBooked);
                    if (success == true) {
                        MessageBox.Show("Patient: " + pat.getPatient() + " is now booked for " + typeBooked.ToString(), "Surgery booked",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        updatePatient();
                    } else {
                        MessageBox.Show("Patient surgery was not booked.", "Surgery not booked",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else { //Should never occur.
                    MessageBox.Show("Somethign went wrong. Please try again", "Please try again",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Please search for a patient.", "Patient Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void setBookedType(FinanceCmbItem type) {
            typeBooked = type;
        }


        /*
         * Books patient for a Imaging and display message of completion
         * or error.
         */
        private void Imagingbtn_Click(object sender, EventArgs e) {

            if (pat.getPatient() != -1) {
                Finance finance = new Finance("Imaging", this);
                finance.ShowDialog();
                if (typeBooked != null) {
                    bool success = fac.bookImaging(pat, typeBooked);
                    if (success == true) {
                        MessageBox.Show("Patient: " + pat.getPatient() + " is now booked for Xray.", "Xray booked",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        updatePatient();

                    } else {
                        MessageBox.Show("Patient Xray was not booked.", "Xray not booked",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else { //Should never occur.
                    MessageBox.Show("Somethign went wrong. Please try again", "Please try again",
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
                pat = Patient.SearchPID(pat.getPatient());
                currentRoomtxt.Text = "Current Room: " + pat.getRoom();
            } else {
                MessageBox.Show("Please search for a patient.", "Patient Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addHistorybtn_Click(object sender, EventArgs e) { //add history input via user
            addHistory(addHistorytbx.Text);
        }

        private void addHistory(string history) {
            SqlConnection con = DBCon.DBConnect();
            con.Open();
            SqlCommand command = new SqlCommand("INSERT INTO History (PatientID, StaffID, History, Date) VALUES (@pid, @userid, @typedhistory, GetDate());", con);
            command.Parameters.AddWithValue("@pid", pat.getPatient());
            command.Parameters.AddWithValue("@userid", UserID);
            command.Parameters.AddWithValue("@typedhistory", history);
            command.ExecuteNonQuery();
            con.Close();
            updateTable(pat.getPatient());
        }

        private void updateTable(int PID)                   //view history
        {
            SqlConnection con = DBCon.DBConnect();
            SqlCommand command = new SqlCommand("SELECT StaffID, History, Date FROM History WHERE PatientID = @pid ORDER BY Date DESC", con);
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
