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


/*
 * Form is used as the main window that doctors, med techs and nurses log into which has
 * all features available to these roles.
 */
namespace Hospital {
    public partial class HospitalSystem : Form {
        private Form homeScreen;
        private PatientInfo pat = new PatientInfo();
        private Facilities fac = new Facilities();
        private FinanceCmbItem typeBooked;

        //Global variables
        private string userID; //String value of the UserID/StaffID
        private string role; //String value of the role User logged in under.


        /*
         * Costructor that sets up Hopsital form used by doctors and medical technicians.
         * Will set up different button display based upon which role is passed as parameter.
         * \param string user - sets global variable UserID
         * \param string role - sets global variable Role
         */
        public HospitalSystem(string user, string role) {
            InitializeComponent();
            userID = user;
            this.role = role;
            ViewImgbtn.Visible = false;
            Surgerybtn.Visible = false;
            Imagingbtn.Visible = false;
            Finishbtn.Visible = false;
        }



        /*
         * Used to set variable used to go back to login screen
         * \param Form logout - set variable home in order for navigation to login screen
         */
        public void SetHome(Form logout) {
            homeScreen = logout;
        }


        /*
         * Sets private patient variable and display appropriate
         * features on screen based upon patient.
         * \param PatientInfo patient - patient to be shown on form
         */
        public void SetPatient(PatientInfo patient) {
            pat = patient;

            //Blank is used as if empty record then database doesnt return a date as null but
            //returns a date 1/01/0001
            DateTime blank = new DateTime(0001, 1, 01);
            UpdateTable(pat.GetPatientId());

            PatInfolbl.Text = "Patient Info: \r\n";
            PatInfolbl.Text += pat.GetFName() + " " + pat.GetSName() + "\r\n";
            currentRoomtxt.Text = "Current Room: " + pat.GetRoom();

            if (pat.GetDOB() != blank) {
                PatInfolbl.Text += pat.GetDOB();
            }

            // Display appropriate button based upon role of user
            if (role == "Doctor") {
                Finishbtn.Visible = false;
                if (pat.GetRoom() == "E100") {
                    Surgerybtn.Visible = true;
                    Imagingbtn.Visible = true;
                    ViewImgbtn.Visible = true;
                } else {
                    Surgerybtn.Visible = false;
                    Imagingbtn.Visible = false;
                    ViewImgbtn.Visible = false;
                }

            } else if (role == "MedTech") {
                if (pat.GetRoom().Contains('I'))
                {
                    Finishbtn.Visible = true;
                    ViewImgbtn.Visible = true;
                }
                else if (pat.GetRoom().Contains('S'))
                {
                    Finishbtn.Visible = true;
                    ViewImgbtn.Visible = true;
                }
                else {
                    Finishbtn.Visible = false;
                    ViewImgbtn.Visible = false;
                }

            } else {
                Surgerybtn.Visible = false;
                Finishbtn.Visible = false;
                Imagingbtn.Visible = false;
                ViewImgbtn.Visible = false;
            }
        }


        /*
         * Logout and return to login screen
         */
        private void Logoutbtn_Click(object sender, EventArgs e) {
            homeScreen.Show();
            Close();
        }


        /*
         * On Click event for button to open TestResultViewer form so
         * user can view images of the selected patient
         */
        private void ViewImgbtn_Click(object sender, EventArgs e) {
            if (pat.GetPatientId() != -1) {
                int patient = pat.GetPatientId();
                TestResultViewer Tests = new TestResultViewer(userID, role, patient);
                Tests.Show();
            } else {
                MessageBox.Show("Please search for a patient.", "Patient Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*
         * On Click event for button to search via Surname. When seartch
         * is undertaken then display appropriate information on form
         */
        private void Searchbtn_Click(object sender, EventArgs e) {
            if (Seatxt.Text != "") {
                PatientInfo[] patients;
                string surname = Seatxt.Text;

                patients = Patient.SearchPatientSurname(surname);

                if (patients.Length == 0) {
                    MessageBox.Show("Patient could not be found in system.", "Patient try again.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else if (patients.Length == 1) {
                    SetPatient(patients[0]);
                } else {
                    ChoosePatient choosePat = new ChoosePatient(userID, role, homeScreen, this, surname, patients);
                    choosePat.Show();
                }

            } else {
                MessageBox.Show("Please input a Surname to search.", "Surname must be input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * Update patient information on form.
         */
        private void UpdatePatient() {
            pat = Patient.SearchPID(pat.GetPatientId());

            currentRoomtxt.Text = "Current Room: " + pat.GetRoom();
            AddHistory("Patient is booked in room " + pat.GetRoom() + " for " + typeBooked.ToString());
            Surgerybtn.Visible = false;
            Imagingbtn.Visible = false;
            ViewImgbtn.Visible = true;
        }


        /*
         * On Click event for button to boook a surgery and 
         * display message of completion or error.   
         */
        private void Surgerybtn_Click(object sender, EventArgs e) {

            if (pat.GetPatientId() != -1) {
                Finance finance = new Finance("Surgery", this);
                finance.ShowDialog();
                if (typeBooked != null) {
                    bool success = fac.BookSurgery(pat, typeBooked);
                    if (success == true) {
                        MessageBox.Show("Patient: " + pat.GetPatientId() + " is now booked for " + typeBooked.ToString(), typeBooked.ToString() + " Surgery booked",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        UpdatePatient();
                    } else {
                        MessageBox.Show("Patient surgery was not booked.", "Surgery not booked",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("Please try again", "Please try again",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Please search for a patient.", "Patient Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void SetBookedType(FinanceCmbItem type) {
            typeBooked = type;
        }


        /*
         * On Click event for button to boook Imaging and 
         * display message of completion or error.   
         */
        private void Imagingbtn_Click(object sender, EventArgs e) {

            if (pat.GetPatientId() != -1) {
                Finance finance = new Finance("Imaging", this);
                finance.ShowDialog();
                if (typeBooked != null) {
                    bool success = fac.BookImaging(pat, typeBooked, userID);
                    if (success == true) {
                        MessageBox.Show("Patient: " + pat.GetPatientId() + " is now booked for " + typeBooked.Type, typeBooked.ToString() + " booked",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        UpdatePatient();

                    } else {
                        MessageBox.Show("Patient " + typeBooked.ToString() + " was not booked.", typeBooked.ToString() + " not booked",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("Please try again", "Please try again",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else {
                MessageBox.Show("Please search for a patient.", "Patient Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /*
         * On Click event for button to return patient back to
         * emergency room. Button used when MedTech is finished with patient.
         */
        private void Finishbtn_Click(object sender, EventArgs e) {
            if (pat.GetPatientId() != -1) {
                fac.ReturnPatientToDoctor(pat);
                pat = Patient.SearchPID(pat.GetPatientId());
                currentRoomtxt.Text = "Current Room: " + pat.GetRoom();
                MessageBox.Show("Procedure completed", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Finishbtn.Visible = false;
                ViewImgbtn.Visible = false;
            } else {
                MessageBox.Show("Please search for a patient.", "Patient Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /*
         * On Click event for button to add content of the 
         * addHistorytbx on form to the users history table.
         */
        private void AddHistorybtn_Click(object sender, EventArgs e) { //add history input via user
            if (pat.GetPatientId() != -1) {
                AddHistory(addHistorytbx.Text);
                addHistorytbx.Text = "";
            }
        }


        /*
         * Add the history passed in paramater to the current patient's
         * history table.
         * \param string history - history being added to the patient's history table
         */
        private void AddHistory(string history) {
            try {
                SqlConnection con = DBCon.DBConnect();
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO History (PatientID, StaffID, History, Date) VALUES (@pid, @userid, @typedhistory, GetDate());", con);
                command.Parameters.AddWithValue("@pid", pat.GetPatientId());
                command.Parameters.AddWithValue("@userid", userID);
                command.Parameters.AddWithValue("@typedhistory", history);
                command.ExecuteNonQuery();
                con.Close();
                UpdateTable(pat.GetPatientId());
            } catch { 
            }
        }


        /*
         * Updates the history displayed in the DataGridView on form   
         */
        private void UpdateTable(int patID) {
            SqlConnection con = DBCon.DBConnect();
            SqlCommand command = new SqlCommand("SELECT StaffID, History, Date FROM History WHERE PatientID = @pid ORDER BY Date DESC", con);
            command.Parameters.AddWithValue("@pid", patID);

            SqlDataAdapter dataAdapter = new SqlDataAdapter();
            dataAdapter.SelectCommand = command;
            DataSet ds = new DataSet();
            con.Open();
            dataAdapter.Fill(ds, "History");
            con.Close();
            historyDataGridView.DataSource = ds;
            historyDataGridView.DataMember = "History";
        }


        /*
         * Pressing the enter key in the surname search textbox
         * does the same function as if the search button was clicked.
         */
        private void Seatxt_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                Searchbtn_Click(sender, e);
            }
        }


        /*
         * Pressing the enter key in the add history textbox
         * does the same function as if the add history button was clicked.
         */
        private void AddHistorytbx_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                AddHistorybtn_Click(sender, e);
            }
        }

    }
}
