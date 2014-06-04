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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Text.RegularExpressions;

/*
 * Form is used as the main window Reception users log into and all features
 * for a reception branch from this form.
 */
namespace Hospital {
    public partial class Reception : Form {

        private Form home;
        private PatientInfo pat = new PatientInfo();
        private string role = "Reception";
        private string userID;

        /*
         * Sets up form and updates UserID variable with user parameter passed.
         * \param string user - UserID of user logged in
         */
        public Reception(string user) {
            InitializeComponent();
            userID = user;

            //Demo to confirm works by updating label on form
            Welcomelbl.Text = "Welcome User:" + userID;

            ClearFields();
            Admitbtn.Visible = false;
            Newbtn.Visible = true;
            Dischargebtn.Visible = false;
            Savbtn.Visible = false;
            hardCopybtn.Visible = false;
        }

        /*
         * SetHome is used for navigational purposes to and from the
         * Login screen.
         * \param Form logout - provides navigation features back to login screen
         */
        public void SetHome(Form logout) {
            home = logout;
        }

        /*
         * Sets private patient variable and display appropriate
         * information on screen based upon patient details.
         * \param PatientInfo patient - patient to be shown on form
         */
        public void SetPatient(PatientInfo patient) {

            pat = patient;
            PIDtxt.Text = pat.GetPatientId().ToString();
            Surtxt.Text = pat.GetSName();
            Firtxt.Text = pat.GetFName();
            DOBtxt.Text = pat.GetDOB().ToString("dd/MM/yyyy");
            if (pat.GetGender() == "M") {
                GenderCmb.SelectedIndex = 0;
            } else {
                GenderCmb.SelectedIndex = 1;
            }
            NOKtxt.Text = pat.GetNextKin();
            NOKNtxt.Text = pat.GetNextKinPhone().ToString();
            Addtxt.Text = pat.GetAddress();
            Homtxt.Text = pat.GetPhone().ToString();
            Mobtxt.Text = pat.GetMobile().ToString();
            chargeslbl.Text = "$" + pat.GetCharges().ToString();
            covTypeCmb.SelectedIndex = pat.GetCoverType();
            CovNtxt.Text = pat.GetCoverNum().ToString();
            Altxt.Text = pat.GetAllergies();
            CurrentRoomlbl.Text = pat.GetRoom().ToString();

            if (pat.GetRoom() == "Discharged") {
                Admitbtn.Visible = true;
                Dischargebtn.Visible = false;
            } else if (!pat.GetRoom().StartsWith("E")) {
                Admitbtn.Visible = false;
                Dischargebtn.Visible = false;
            } else {
                Admitbtn.Visible = false;
                Dischargebtn.Visible = true;
            }
            Savbtn.Visible = true;
            Newbtn.Visible = false;
            hardCopybtn.Visible = true;
        }

        /*
         * Logout user by returning to login screen
         */
        private void Logoutbtn_Click(object sender, EventArgs e) {
            home.Show();
            Close();
        }

        /*
         * When patient is searched for update user information into
         * text boxes on screen.
         */
        private void Searchbtn_Click(object sender, EventArgs e) {
            //allows lower and upper case english, hypen and space, makes sure user is entering valid name types
            Regex regex = new Regex("^['\\- a-zA-Z]{1,20}$");
            if (regex.IsMatch(Seatxt.Text)) {
                //sets up array of PatientInfo
                PatientInfo[] patients;
                string surname = Seatxt.Text;

                patients = Patient.SearchPatientSurname(surname);

                //If array length is 0, no patients found, generate error message, clear fields and hide admit
                if (patients.Length == 0) {
                    ClearFields();
                    MessageBox.Show("Patient could not be found in system. Please confirm spelling " +
                        "or add a new patient.", "Patient not found.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Admitbtn.Visible = false;
                    //If array length is 1
                } else if (patients.Length == 1) {
                    SetPatient(patients[0]);
                    //Else open ChoosePatient window
                } else {
                    ChoosePatient choosePat = new ChoosePatient(userID, role, home, this, surname, patients);
                    choosePat.Show();
                }
            } else {
                MessageBox.Show("Please input a Surname to search. English aplhabet only with upper and lower case, along with hypen or space with length of 1 to 20.", "Surname must be input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Admitbtn.Visible = false;
            }
        }

        /* Creates new patient record based off of details entered in receptionist form.
         * Matches values in fields to valid datatypes acceptable by database field 
         * Sets defaults in fields where fields cannot accept NULL
         */
        private void Newbtn_Click(object sender, EventArgs e) {
            bool success = true;
            SqlConnection con = DBCon.DBConnect();

            con.Open();

            //insert into query using patientID as scope identity to be returned
            string insertquery = ("INSERT INTO Patient (FirstName, Surname, Gender, DOB," +
            "Address, Phone, Mobile, Allergies, CoverType, CoverNumber, Status, NextOfKin, NextOfKinPhone," +
            "Room, TotalCharges) VALUES (@first, @sur, @gen, @dob, @add, @ph, @mob, @all, @covert, @covern, 0, @nok," +
            " @nokp, @room, 0); SET @PATID = SCOPE_IDENTITY();");

            SqlCommand command = new SqlCommand(insertquery, con);

            //Checks that each text field is not empty
            if (Firtxt.Text != "") {
                //Relates command name to database's field type and soucred text field
                command.Parameters.Add("@first", System.Data.SqlDbType.NVarChar, 20).Value = Firtxt.Text;
                SurErrLbl.Visible = false;
            } else {
                //Makes error label visible
                SurErrLbl.Visible = true;
            }

            if (Surtxt.Text != "") {
                command.Parameters.Add("@sur", System.Data.SqlDbType.NVarChar, 20).Value = Surtxt.Text;
                FnErrLbl.Visible = false;
            } else {
                FnErrLbl.Visible = true;
            }

            if (GenderCmb.SelectedIndex == 0) {
                command.Parameters.Add("@gen", System.Data.SqlDbType.NVarChar, 1).Value = "M";
            } else {
                command.Parameters.Add("@gen", System.Data.SqlDbType.NVarChar, 1).Value = "F";
            }

            DateTime DOB;
            if (DateTime.TryParse(DOBtxt.Text, out DOB)) {
                command.Parameters.Add("@dob", System.Data.SqlDbType.Date).Value = DOB;
                DOBErrLbl.Visible = false;
            } else {
                DOBErrLbl.Visible = true;
            }

            if (Addtxt.Text != "") {
                command.Parameters.Add("@add", System.Data.SqlDbType.NVarChar, 500).Value = Addtxt.Text;
            } else {
                command.Parameters.Add("@add", System.Data.SqlDbType.NVarChar, 500).Value = "Unknown";
            }

            if (Homtxt.Text != "") {
                command.Parameters.AddWithValue("@ph", Homtxt.Text);
            } else {
                command.Parameters.AddWithValue("@ph", "Unknown");
            }

            if (Mobtxt.Text != "") {
                command.Parameters.AddWithValue("@mob", Mobtxt.Text);
            } else {
                command.Parameters.AddWithValue("@mob", "Unknown");
            }

            if (Altxt.Text != "") {
                command.Parameters.Add("@all", System.Data.SqlDbType.NVarChar, 500).Value = Altxt.Text;
            } else {
                command.Parameters.Add("@all", System.Data.SqlDbType.NVarChar, 500).Value = "Unknown";
            }

            if (covTypeCmb.SelectedIndex > 0) {
                command.Parameters.Add("@covert", System.Data.SqlDbType.Int).Value = covTypeCmb.SelectedIndex;
            } else {
                command.Parameters.Add("@covert", System.Data.SqlDbType.Int).Value = 0;
            }

            int covNum;
            if (Int32.TryParse(CovNtxt.Text, out covNum)) {
                command.Parameters.Add("@covern", System.Data.SqlDbType.Int).Value = CovNtxt.Text;
            } else {
                command.Parameters.Add("@covern", System.Data.SqlDbType.Int).Value = 0;
            }

            if (NOKtxt.Text != "") {
                command.Parameters.Add("@nok", System.Data.SqlDbType.NVarChar, 500).Value = NOKtxt.Text;
            } else {
                command.Parameters.Add("@nok", System.Data.SqlDbType.NVarChar, 500).Value = "Unknown";
            }

            if (NOKNtxt.Text != "") {
                command.Parameters.AddWithValue("@nokp", NOKNtxt.Text);
            } else {
                command.Parameters.AddWithValue("@nokp", "Unknown");
            }

            //adds patient to default discharged state
            command.Parameters.Add("@room", System.Data.SqlDbType.NVarChar, 10).Value = "Discharged";

            //Sets directionality of @PATID to be returned after primary/record generation
            command.Parameters.Add("@PATID", SqlDbType.Int).Direction = ParameterDirection.Output;

            //executes command
            try {

                command.ExecuteScalar();

                //Returned value stringed and entered into textbox
                int patientID = Convert.ToInt32(command.Parameters["@PATID"].Value);
                PIDtxt.Text = patientID.ToString();

                con.Close();

            } catch (Exception) {
                success = false;
                MessageBox.Show("Patient details must be valid for each input field.", "Incorrect Patiet Information Layout",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                con.Close();
            }

            if (success == true) {
                SetPatient(Patient.SearchPID(Int32.Parse(PIDtxt.Text)));
                MessageBox.Show("Patient: " + Surtxt.Text + ", " + Firtxt.Text + " is now admitted.", "Patient Admitted",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        /*
         * Clears textboxes and set drop downs to default states, resets button and label visiblity
         */
        private void ClearFields() {
            pat = null;
            Seatxt.Text = "";
            PIDtxt.Text = "";
            Surtxt.Text = "";
            Firtxt.Text = "";
            DOBtxt.Text = "";
            GenderCmb.SelectedIndex = 0;
            NOKtxt.Text = "";
            NOKNtxt.Text = "";
            Addtxt.Text = "";
            Homtxt.Text = "";
            Mobtxt.Text = "";
            covTypeCmb.SelectedIndex = 0;
            CovNtxt.Text = "";
            Altxt.Text = "";
            chargeslbl.Text = "$0";
            CurrentRoomlbl.Text = "";
            Savbtn.Visible = false;
            Newbtn.Visible = true;
            DOBErrLbl.Visible = false;
            SurErrLbl.Visible = false;
            FnErrLbl.Visible = false;
        }

        /*
         * Clears the information displayed on screen.
         */
        private void Clrbtn_Click(object sender, EventArgs e) {
            ClearFields();
        }

        /*
         * Admit patient into Emergency room and display message of confirmation or error.
         */
        private void Admitbtn_Click(object sender, EventArgs e) {
            Facilities fac = new Facilities();

            if (PIDtxt.Text != "" && PIDtxt.Text != "0" && CurrentRoomlbl.Text == "Discharged") {
                bool success = fac.AdmitPatient(pat.GetPatientId());
                if (success == true) {
                    Patient.UpdateAdmitCharge(pat.GetPatientId(), pat.GetCoverType());
                    MessageBox.Show("Patient: " + pat.GetSName() + ", " + pat.GetFName() + " is now admitted.", "Patient Admitted",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    pat = Patient.SearchPID(pat.GetPatientId());
                    CurrentRoomlbl.Text = pat.GetRoom();
                    chargeslbl.Text = "$" + pat.GetCharges().ToString();
                    Admitbtn.Visible = false;
                    Dischargebtn.Visible = true;
                    UpdateHistory("Admitted");
                } else {
                    MessageBox.Show("Patient was not admitted. Emergency room full", "Patient not Admitted",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } else if (PIDtxt.Text != "" && CurrentRoomlbl.Text != "0") {
                MessageBox.Show("Patient is currently admitted to hospital and is in room " + CurrentRoomlbl.Text, "Patient currently in hospital",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                MessageBox.Show("Please search for a patient.", "Search required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * Updates currently present information in text fields corrosponding to ID field.         * 
         */
        private void Savbtn_Click(object sender, EventArgs e) {
            if (pat != null) {
                int patientID = pat.GetPatientId();

                string surname;
                if (Surtxt.Text == "") {
                    surname = pat.GetSName();
                } else {
                    surname = Surtxt.Text;
                }

                string firstname;
                if (Firtxt.Text == "") {
                    firstname = pat.GetFName();
                } else {
                    firstname = Firtxt.Text;
                }

                DateTime DOB;
                if (DateTime.TryParse(DOBtxt.Text, out DOB)) {
                    //Do Nothing
                } else {
                    DOB = pat.GetDOB();
                }

                string gender;
                if (GenderCmb.SelectedIndex == 0) {
                    gender = "M";
                } else {
                    gender = "F";
                }

                string nextofkin = NOKtxt.Text;

                string kinphone = NOKNtxt.Text;

                string address = Addtxt.Text;

                string homePhone = Homtxt.Text;

                string Mobile = Mobtxt.Text;

                int covertype;

                try {
                    covertype = Int32.Parse(covTypeCmb.SelectedText);
                } catch (Exception) {
                    covertype = 0;
                }

                int covernum;
                if (covTypeCmb.SelectedIndex > 0) {
                    covernum = Int32.Parse(CovNtxt.Text);
                } else {
                    covernum = 0;
                }

                string allergies = Altxt.Text;

                bool status = true;

                string room;
                if (CurrentRoomlbl.Text != "") {
                    room = CurrentRoomlbl.Text;
                } else {
                    room = "Discharged";
                }

                SqlConnection con = DBCon.DBConnect();
                con.Open();

                string updatequery = ("UPDATE [Patient] SET FirstName = @first, Surname = @sur, Gender = @gen," +
                "DOB = @dob, Address = @add, Phone = @ph, Mobile = @mob, Allergies = @all, CoverType = @covert," +
                "CoverNumber = @covern, Status = @stat, NextOfKin = @nok, NextOfKinPhone = @nokp, Room = @room WHERE PatientID = @pid");
                SqlCommand command = new SqlCommand(updatequery, con);

                command.Parameters.AddWithValue("@pid", patientID);
                command.Parameters.AddWithValue("@first", firstname);
                command.Parameters.AddWithValue("@sur", surname);
                command.Parameters.AddWithValue("@gen", gender);
                command.Parameters.AddWithValue("@dob", DOB);
                command.Parameters.AddWithValue("@add", address);
                command.Parameters.AddWithValue("@ph", homePhone);
                command.Parameters.AddWithValue("@mob", Mobile);
                command.Parameters.AddWithValue("@all", allergies);
                command.Parameters.AddWithValue("@covert", covertype);
                command.Parameters.AddWithValue("@covern", covernum);
                command.Parameters.AddWithValue("@stat", status);
                command.Parameters.AddWithValue("@nok", nextofkin);
                command.Parameters.AddWithValue("@nokp", kinphone);
                command.Parameters.AddWithValue("@room", room);

                command.ExecuteNonQuery();

                //Update labels on screen
                SetPatient(Patient.SearchPID(pat.GetPatientId()));
                UpdateHistory("Update");
                MessageBox.Show("Update Succesfully");
                con.Close();
            } else {
                MessageBox.Show("Please fill in missing fields.", "Patient update not saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* On Click Discharges patient, checks if current pat object loaded has enough charges to
         * discharge, generates crystal report invoice, resets room and charges of patient.
         */
        private void Dischargebtn_Click(object sender, EventArgs e) {
            pat = Patient.SearchPID(pat.GetPatientId());
            int charges = Patient.DischargePatient(pat);

            if (charges > 0) {
                try {
                    CreateInvoice(charges);
                } catch {
                    MessageBox.Show("Something went wrong. Please make sure any previous invoices are close.", "Patient Invoice not generated.",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Patient: " + pat.GetSName() + ", " + pat.GetFName() + " is now discharged with a final bill of $"
                            + charges, "Patient Discharged", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            pat = Patient.SearchPID(pat.GetPatientId());
            CurrentRoomlbl.Text = pat.GetRoom();
            Dischargebtn.Visible = false;
            Admitbtn.Visible = true;
            chargeslbl.Text = "$0";
            UpdateHistory("Discharged");
            Patient.ClearChargeHistory(pat.GetPatientId());
        }

        /* Query updates patient history based on current patient status as moving through procedures.
         * /param string historyType - the history to be updated into database
         */
        private void UpdateHistory(string historyType) {
            string typedHistory;

            if (historyType == "Admitted") {
                typedHistory = historyType + " to Hospital";
            } else if (historyType == "Discharged") {
                typedHistory = historyType + " from Hospital";
            } else {
                typedHistory = "Patient Details updated";
            }

            SqlConnection con = DBCon.DBConnect();
            con.Open();
            SqlCommand command = new SqlCommand("INSERT INTO History (PatientID, StaffID, History, Date) VALUES (@pid, @userid, @typedhistory, getDate());", con);
            command.Parameters.AddWithValue("@pid", pat.GetPatientId());
            command.Parameters.AddWithValue("@userid", userID);
            command.Parameters.AddWithValue("@typedhistory", typedHistory);
            command.ExecuteNonQuery();
            con.Close();
        }

        /* Generates and outputs Crystral Report Invoice used for discharging a patient.
         * Called by Dischargebtn
         * /param Int charges - charges for patient based on pat object
         */
        private void CreateInvoice(int charges) {

            if (pat.GetPatientId() != -1) {
                //Intantiates new Report Document, loads document based off rpt template.
                ReportDocument cryRpt = new ReportDocument();

                cryRpt.Load(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Hospital\Invoice.rpt");//source file location for the premade report, may need to be manually changed

                cryRpt.SetParameterValue("PatientID", pat.GetPatientId());
                cryRpt.SetParameterValue("charges", charges);

                //Exports generated report to PDF format
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Invoice.pdf"); //output location, may need to be manually changed
                System.Diagnostics.Process.Start(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Invoice.pdf");
            } else {
                MessageBox.Show("Please enter a valid surname/PID into search box before generating PDF.", "Patient Invoice not generated.",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* Function Button click calls relevant crystal report methods for out putting a hard copy
         * of the searched patients personal details and history, based on predefined report structure.
         * Report uses PIDtext.Text as a parameter for filtering in crystal report            
         */
        private void HardCopybtn_Click(object sender, EventArgs e) {
            if (Surtxt.Text != "" && Surtxt.Text != " ") {

                //Intantiates new Report Document, loads document based off rpt template.
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Hospital\ExportPatientRep.rpt");//source file location for the premade report, may need to be manually changed

                //Variable delecaration and assignment
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                //Assigns textbox value to relatable reviving methods in crystal report and assigns values
                crParameterDiscreteValue.Value = PIDtxt.Text;
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["getPID"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                //Exports generated report to PDF format
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\PatientExport.pdf"); //output location, may need to be manually changed
                System.Diagnostics.Process.Start(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\PatientExport.pdf");

            } else {
                MessageBox.Show("Please enter a valid surname/PID into search box before generating PDF.", "Patient details PDF not generated.",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         *Name validation using regex when user leaves element focus
         */
        private void Name_Validating(object sender, CancelEventArgs e) {
            string reg = @"^[a-zA-Z' -]{1,20}$";//regex allows only english characters, spaces, hyphen or apostrophe
            if (!Regex.IsMatch(this.Surtxt.Text.Trim(), reg)) {
                MessageBox.Show("Please input only English characters, spaces, hyphen or apostrophe.");
            }
        }

        /*
         *Number validation using regex when user leaves element focus
         */
        private void CovNum_Validating(object sender, CancelEventArgs e) {
            string reg = @"^[0-9]+$";//regex allows only numbers
            if (!Regex.IsMatch(this.CovNtxt.Text.Trim(), reg) || (int.Parse(CovNtxt.Text) > 1000000)) {
                MessageBox.Show("Please enter a cover number between 1-1000000");
                CovNtxt.Text = "0";
            }
        }

        /*
         *Validation for date entry, cannot be future or over 120 years.
         */
        private void Date_Validating(object sender, CancelEventArgs e) {

            //Try catch for DOB validation
            try {

                DateTime patDate = Convert.ToDateTime(DOBtxt.Text);
                DateTime current = DateTime.Today;
                DateTime past = new DateTime(1894, 1, 1);

                //not future
                if (patDate > current) {
                    MessageBox.Show("Please Enter Date of Birth not in the future.");
                    DOBtxt.Text = "";
                }
                    //not greater than 120 years
                else if (patDate < past) {
                    MessageBox.Show("Please Enter Date of Birth not older than 120 years.");
                    DOBtxt.Text = "";
                }
            }
                //catch for any exception that could be thrown, mostly because of spaces in conversion of string to datetime
            catch (Exception) {
                MessageBox.Show("Please do not leave spaces in date of birth.");
                DOBtxt.Text = "";
            }
        }

        /*
         * Address and allergies validation using regex when user leaves element focus
         */
        private void Add_Validating(object sender, CancelEventArgs e) {
            string reg = @"^[0-9a-zA-Z' ,./-]{1,500}$";//regex allows only select few special characters
            if (!Regex.IsMatch(this.Addtxt.Text.Trim(), reg)) {
                MessageBox.Show("Please enter a valid address.");
            }
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
    }
}
