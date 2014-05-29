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

namespace Hospital {
    public partial class Reception : Form {

        private Form home;
        private PatientGetSet pat = new PatientGetSet();
        private string Role = "Reception";

        //Global variables
        string UserID; //String value of the UserID/StaffID

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

            clearFields();
            Admitbtn.Visible = false;
            Newbtn.Visible = true;
            Dischargebtn.Visible = false;
            Savbtn.Visible = false;
            hardCopybtn.Visible = false;
        }


        /*
         * setHome is used for navigational purposes to and from the
         * Login screen.
         */
        public void setHome(Form logout) {
            home = logout;
        }


        public void setPatient(PatientGetSet patient) {

            pat = patient;

            PIDtxt.Text = pat.getPatient().ToString();
            Surtxt.Text = pat.getSN();
            Firtxt.Text = pat.getFN();
            DOBtxt.Text = pat.getDOB().ToString("dd/MM/yyyy");
            if (pat.getGender() == "M") {
                GenderCmb.SelectedIndex = 0;
            } else {
                GenderCmb.SelectedIndex = 1;
            }
            NOKtxt.Text = pat.getNextKin();
            NOKNtxt.Text = pat.getKP().ToString();
            Addtxt.Text = pat.getAddress();
            Homtxt.Text = pat.getPhone().ToString();
            Mobtxt.Text = pat.getMobile().ToString();
            covTypeCmb.SelectedIndex = pat.getCoverT();
            CovNtxt.Text = pat.getCoverN().ToString();
            Altxt.Text = pat.getAllergies();
            statusCmb.SelectedIndex = 0;
            CurrentRoomlbl.Text = pat.getRoom().ToString();


            if (pat.getRoom() == "Discharged") {
                Admitbtn.Visible = true;
                Dischargebtn.Visible = false;
            } else if (!pat.getRoom().StartsWith("E")) {
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
            Regex regex = new Regex("^['\\- a-zA-Z]{1,20}$");//allows lower and upper case english, hypen and space
            if (regex.IsMatch(Seatxt.Text)) {
                PatientGetSet[] patients;
                string Surname = Seatxt.Text;

                patients = Patient.searchPatientSurname(Surname);

                if (patients.Length == 0) {
                    clearFields();
                    MessageBox.Show("Patient could not be found in system. Please confirm spelling " +
                        "or add a new patient.", "Patient not found.",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Admitbtn.Visible = false;
                } else if (patients.Length == 1) {
                    setPatient(patients[0]);
                } else {
                    ChoosePatient choosePat = new ChoosePatient(UserID, Role, home, this, Surname, patients);
                    choosePat.Show();
                }
            } else {
                MessageBox.Show("Please input a Surname to search. English aplhabet only with upper and lower case, along with hypen or space with length of 1 to 20.", "Surname must be input",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Admitbtn.Visible = false;
            }
        }

        /*
        *Takes entered details, populates them with new PK, returns new PK
         */
        private void Newbtn_Click(object sender, EventArgs e) {
            bool success = true;
            SqlConnection con = DBCon.DBConnect();

            con.Open();

            string insertquery = ("INSERT INTO Patient (FirstName, Surname, Gender, DOB," +
            "Address, Phone, Mobile, Allergies, CoverType, CoverNumber, Status, NextOfKin, NextOfKinPhone," +
            "Room, TotalCharges) VALUES (@first, @sur, @gen, @dob, @add, @ph, @mob, @all, @covert, @covern, @stat, @nok," +
            " @nokp, @room, 0); SET @PATID = SCOPE_IDENTITY();");

            SqlCommand command = new SqlCommand(insertquery, con);

            //Matching datatype with what is listed in the database, will attempt to find a point of 
            //checking inputs prior to this point, when I move it to a class of it's own
            if (Firtxt.Text != "") {
                command.Parameters.Add("@first", System.Data.SqlDbType.NVarChar, 20).Value = Firtxt.Text;
                SurErrLbl.Visible = false;
            } else {
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

            if (statusCmb.SelectedIndex == 0) {
                command.Parameters.Add("@stat", System.Data.SqlDbType.Bit).Value = 1;
            } else {
                command.Parameters.Add("@stat", System.Data.SqlDbType.Bit).Value = 2;
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

            command.Parameters.Add("@room", System.Data.SqlDbType.NVarChar, 4).Value = "0";


            command.Parameters.Add("@PATID", SqlDbType.Int).Direction = ParameterDirection.Output;


            try {

                command.ExecuteScalar();

                int PID = Convert.ToInt32(command.Parameters["@PATID"].Value);
                PIDtxt.Text = PID.ToString();

                con.Close();

            } catch (Exception) { //this will need to be expanded or changed at somepoint to check each input field
                success = false;
                MessageBox.Show("Patient details must be valid for each input field.", "Incorrect Patiet Information Layout",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                con.Close();
            }

            if (success == true) {
                setPatient(Patient.SearchPID(Int32.Parse(PIDtxt.Text)));
                MessageBox.Show("Patient: " + Surtxt.Text + ", " + Firtxt.Text + " is now admitted.", "Patient Admitted",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void clearFields() {
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
            statusCmb.SelectedIndex = 0;
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
            clearFields();
        }

        /*
         * Admit patient into Emergency room and display message of confirmation or error.
         */
        private void Admitbtn_Click(object sender, EventArgs e) {
            Facilities fac = new Facilities();

            if (PIDtxt.Text != "" && PIDtxt.Text != "0" && CurrentRoomlbl.Text == "0") {
                bool success = fac.admitPatient(pat.getPatient());
                if (success == true) {
                    Patient.updateAdmitCharge(pat.getPatient(), pat.getCoverT());
                    MessageBox.Show("Patient: " + pat.getSN() + ", " + pat.getFN() + " is now admitted. -> " + pat.getCharges(), "Patient Admitted",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    pat = Patient.SearchPID(pat.getPatient());
                    CurrentRoomlbl.Text = pat.getRoom();
                    Admitbtn.Visible = false;
                    Dischargebtn.Visible = true;
                    updateHistory("Admitted");
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
        * Updates currently present information in text fields corrosponding to ID field.
         * 
         * Regex needed in this
         */
        private void Savbtn_Click(object sender, EventArgs e) {
            if (pat != null) {
                int PID = pat.getPatient();

                string surname;
                if (Surtxt.Text == "") {
                    surname = pat.getSN();
                } else {
                    surname = Surtxt.Text;
                }

                string firstname;
                if (Firtxt.Text == "") {
                    firstname = pat.getFN();
                } else {
                    firstname = Firtxt.Text;
                }

                DateTime DOB;
                if (DateTime.TryParse(DOBtxt.Text, out DOB)) {
                    //Do Nothing
                } else {
                    DOB = pat.getDOB();
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

                bool status;
                if (statusCmb.SelectedIndex == 0) {
                    status = true; ;
                } else {
                    status = false;
                }

                string room;
                if (CurrentRoomlbl.Text != "") {
                    room = CurrentRoomlbl.Text;
                } else {
                    room = "0";
                }

                SqlConnection con = DBCon.DBConnect();
                con.Open();

                string updatequery = ("UPDATE [Patient] SET FirstName = @first, Surname = @sur, Gender = @gen," +
                "DOB = @dob, Address = @add, Phone = @ph, Mobile = @mob, Allergies = @all, CoverType = @covert," +
                "CoverNumber = @covern, Status = @stat, NextOfKin = @nok, NextOfKinPhone = @nokp, Room = @room WHERE PatientID = @pid");
                SqlCommand command = new SqlCommand(updatequery, con);

                command.Parameters.AddWithValue("@pid", PID);
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
                setPatient(Patient.SearchPID(pat.getPatient()));
                updateHistory("Update");
                MessageBox.Show("Update Succesfully");
                con.Close();
            } else {
                MessageBox.Show("Please fill in missing fields.", "Patient update not saved",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Dischargebtn_Click(object sender, EventArgs e) {
            int charges = Patient.DischargePatient(pat);
            
            if (charges > 0) {
                createInvoice();
            }

            MessageBox.Show("Patient: " + pat.getSN() + ", " + pat.getFN() + " is now discharged with a final bill of $"
                            + charges, "Patient Discharged", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);


            pat = Patient.SearchPID(pat.getPatient());
            CurrentRoomlbl.Text = pat.getRoom();
            Dischargebtn.Visible = false;
            Admitbtn.Visible = true;
            updateHistory("Discharged");
        }

        private void updateHistory(string historyType) {
            string TypedHistory;

            if (historyType == "Admitted") {
                TypedHistory = historyType + " to Hospital";
            } else if (historyType == "Discharged") {
                TypedHistory = historyType + " from Hospital";
            } else {
                TypedHistory = "Patient Details updated";
            }

            SqlConnection con = DBCon.DBConnect();
            con.Open();
            SqlCommand command = new SqlCommand("INSERT INTO History (PatientID, StaffID, History, Date) VALUES (@pid, @userid, @typedhistory, GetDate());", con);
            command.Parameters.AddWithValue("@pid", pat.getPatient());
            command.Parameters.AddWithValue("@userid", UserID);
            command.Parameters.AddWithValue("@typedhistory", TypedHistory);
            command.ExecuteNonQuery();
            con.Close();
        }


        private void createInvoice() {

            if (pat.getPatient() != -1) {
                //Intantiates new Report Document, loads document based off rpt template.
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Hospital\Invoice.rpt");//source file location for the premade report, may need to be manually changed

                //Variable delecaration and assignment
                ParameterFieldDefinitions crParameterFieldDefinitions;
                ParameterFieldDefinition crParameterFieldDefinition;
                ParameterValues crParameterValues = new ParameterValues();
                ParameterDiscreteValue crParameterDiscreteValue = new ParameterDiscreteValue();

                //Assigns textbox value to relatable reviving methods in crystal report and assigns values
                crParameterDiscreteValue.Value = pat.getPatient();
                crParameterFieldDefinitions = cryRpt.DataDefinition.ParameterFields;
                crParameterFieldDefinition = crParameterFieldDefinitions["PatientID"];
                crParameterValues = crParameterFieldDefinition.CurrentValues;

                crParameterValues.Clear();
                crParameterValues.Add(crParameterDiscreteValue);
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues);

                //Exports generated report to PDF format
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Invoice.pdf"); //output location, may need to be manually changed
                MessageBox.Show("Export to PDF Successful.");
            } else {
                MessageBox.Show("Please enter a valid surname/PID into search box before generating PDF.", "Patient details PDF not generated.",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        /* Function Button click calls relevant crystal report methods for out putting a hard copy
         * of the searched patients personal details and history, based on predefined report structure.
         * Report uses PIDtext.Text as a parameter for filtering in crystal report            
         */
        private void hardCopybtn_Click(object sender, EventArgs e) {
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
                MessageBox.Show("Export to PDF Successful.");
            } else {
                MessageBox.Show("Please enter a valid surname/PID into search box before generating PDF.", "Patient details PDF not generated.",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       //regex validation on leave of textbox test
        private void SurTxt_Validating(object sender, CancelEventArgs e) {
            string reg = @"^[a-zA-Z' -]{1,20}$";
            if (!Regex.IsMatch(this.Surtxt.Text.Trim(), reg)) {
                MessageBox.Show("Please input only English characters, spaces, hyphen or apostrophe.");
                Surtxt.Text = "";
            }        
        }

        //why does this magically work for him but not me
        private void CovNum_Validating(object sender, CancelEventArgs e) {
            string reg = @"^[0-9]+$";
            if (!Regex.IsMatch(this.CovNtxt.Text.Trim(), reg) || (int.Parse(CovNtxt.Text) > 1000000)) {
                MessageBox.Show("Please enter a cover number between 1-1000000");
                CovNtxt.Text = "0";
            }  
        }

        private void Seatxt_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                Searchbtn_Click(sender, e);
            }
        }

    }
}
