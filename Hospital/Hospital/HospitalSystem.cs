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
        private PatientGetSet pat = new PatientGetSet();
        private Facilities fac = new Facilities();
        private FinanceCmbItem typeBooked;

        //Global variables
        private string UserID; //String value of the UserID/StaffID
        private string Role; //String value of the role User logged in under.


        /*
         * Costructor that sets up Hopsital form used by doctors and medical technicians.
         * Will set up different button display based upon which role is passed as parameter.
         * \param string user - sets global variable UserID
         * \param string role - sets global variable Role
         */
        public HospitalSystem(string user, string role) {
            InitializeComponent();
            UserID = user;
            Role = role;
                ViewImgbtn.Visible = false;
                Surgerybtn.Visible = false;
                Imagingbtn.Visible = false;
                Finishbtn.Visible = false;

        }



        /*
         * Used to set variable used to go back to login screen
         * \param Form logout - set variable home in order for navigation to login screen
         */
        public void setHome(Form logout) {
            homeScreen = logout;
        }


        /*
         * Sets private patient variable and display appropriate
         * features on screen based upon patient.
         * \param PatientGetSet patient - patient to be shown on form
         */
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

            // Display appropriate button based upon role of user
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

            } else if (Role == "MedTech") {
                if (pat.getRoom().Contains('I'))
                {
                    Finishbtn.Visible = true;
                    ViewImgbtn.Visible = true;
                }
                else if (pat.getRoom().Contains('S'))
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
            if (pat.getPatient() != -1) {
                int patient = pat.getPatient();
                TestResultViewer Tests = new TestResultViewer(UserID, Role, patient);
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
        private void updatePatient() {
            pat = Patient.SearchPID(pat.getPatient());

            currentRoomtxt.Text = "Current Room: " + pat.getRoom();
            addHistory("Patient is booked for " + typeBooked.ToString());
            Surgerybtn.Visible = false;
            Imagingbtn.Visible = false;
            ViewImgbtn.Visible = true;
        }


        /*
         * On Click event for button to boook a surgery and 
         * display message of completion or error.   
         */
        private void Surgerybtn_Click(object sender, EventArgs e) {

            if (pat.getPatient() != -1) {
                Finance finance = new Finance("Surgery", this);
                finance.ShowDialog();
                if (typeBooked != null) {
                    bool success = fac.bookSurgery(pat, typeBooked);
                    if (success == true) {
                        MessageBox.Show("Patient: " + pat.getPatient() + " is now booked for " + typeBooked.ToString(), typeBooked.ToString() + " Surgery booked",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        updatePatient();
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

        public void setBookedType(FinanceCmbItem type) {
            typeBooked = type;
        }


        /*
         * On Click event for button to boook Imaging and 
         * display message of completion or error.   
         */
        private void Imagingbtn_Click(object sender, EventArgs e) {

            if (pat.getPatient() != -1) {
                Finance finance = new Finance("Imaging", this);
                finance.ShowDialog();
                if (typeBooked != null) {
                    bool success = fac.bookImaging(pat, typeBooked, UserID);
                    if (success == true) {
                        MessageBox.Show("Patient: " + pat.getPatient() + " is now booked for " + typeBooked.Type, typeBooked.ToString() + " booked",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        updatePatient();

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
            if (pat.getPatient() != -1) {
                fac.returnPatientToDoctor(pat);
                pat = Patient.SearchPID(pat.getPatient());
                currentRoomtxt.Text = "Current Room: " + pat.getRoom();
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
        private void addHistorybtn_Click(object sender, EventArgs e) { //add history input via user
            if (pat.getPatient() != -1) {
                addHistory(addHistorytbx.Text);
            }
        }


        /*
         * Add the history passed in paramater to the current patient's
         * history table.
         * \param string history - history being added to the patient's history table
         */
        private void addHistory(string history) {
            try {
                SqlConnection con = DBCon.DBConnect();
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO History (PatientID, StaffID, History, Date) VALUES (@pid, @userid, @typedhistory, GetDate());", con);
                command.Parameters.AddWithValue("@pid", pat.getPatient());
                command.Parameters.AddWithValue("@userid", UserID);
                command.Parameters.AddWithValue("@typedhistory", history);
                command.ExecuteNonQuery();
                con.Close();
                updateTable(pat.getPatient());
            } catch { 
            }
        }


        /*
         * Updates the history displayed in the DataGridView on form   
         */
        private void updateTable(int PID) {
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
        private void addHistorytbx_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                addHistorybtn_Click(sender, e);
            }
        }

    }
}
