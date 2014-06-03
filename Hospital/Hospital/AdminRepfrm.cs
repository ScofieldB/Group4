using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Diagnostics;
using System.Data.SqlClient;
using System.IO;


/*
 * Form is responsible for all printing of reports available
 * to the System Admins.
 */
namespace Hospital {
    public partial class AdminRepfrm : Form {

        private Form home;
        private Form back;


        /*
         * Constructor to initialize form
         */
        public AdminRepfrm() {
            InitializeComponent();
        }


        /*
         * On Click event for button to generate FacilitiesUsed report to show
         * the facilities currently being used by patients.
         */
        private void Facilitiesbtn_Click(object sender, EventArgs e) {
            try {
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@"C:\Users\chris\Documents\GitHub\Group4\Hospital\Hospital\FacilitiesUsedRep.rpt");//source file location for the premade report, may need to be manually changed
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\chris\Documents\GitHub\Group4\Hospital\FacilitiesUsedRep.pdf"); //output location, may need to be manually changed

                System.Diagnostics.Process.Start(@"C:\Users\chris\Documents\GitHub\Group4\Hospital\FacilitiesUsedRep.pdf");
            } catch {
                MessageBox.Show("Something went wrong. Please make sure any previous reports are closed.", "Report was not generated.",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * Used to set variable used to go back to login screen
         * \param Form logout - set variable home in order for navigation to login screen
         */
        public void setHome(Form logout, Form back) {
            home = logout;
            this.back = back;
        }


        /*
         * On Click event for button to log out user.
         */
        private void LogBtn_Click(object sender, EventArgs e) {
            home.Show();
            Close();
        }

        /*
         * On Click event for button to navigate back once.
         */
        private void BackBtn_Click(object sender, EventArgs e) {
            back.Show();
            Close();
        }

        /*
         * On Click event for button to generate Outstanding Charges report to show
         * the current sum of all patients oustanding charges.
         */
        private void Outstandingbtn_Click(object sender, EventArgs e) {
            try {
                //Intantiates new Report Document, loads document based off rpt template.
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@"C:\Users\chris\Documents\GitHub\Group4\Hospital\Hospital\OutstandingChargesRep.rpt");//source file location for the premade report, may need to be manually changed

                //Exports generated report to PDF format
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\chris\Documents\GitHub\Group4\Hospital\OutstandingCharges.pdf"); //output location, may need to be manually changed

                System.Diagnostics.Process.Start(@"C:\Users\chris\Documents\GitHub\Group4\Hospital\OutstandingCharges.pdf");
            } catch {
                MessageBox.Show("Something went wrong. Please make sure any previous reports are closed.", "Report was not generated.",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * On Click event for button to generate Current Patients in system report
         * to show how many patients currently are admitted.
         */
        private void Roomsbtn_Click(object sender, EventArgs e) {
            try {
                //Intantiates new Report Document, loads document based off rpt template.
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@"C:\Users\chris\Documents\GitHub\Group4\Hospital\Hospital\CurrentPatientsRep.rpt");//source file location for the premade report, may need to be manually changed

                //Exports generated report to PDF format
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\chris\Documents\GitHub\Group4\Hospital\CurrentPatients.pdf"); //output location, may need to be manually changed

                System.Diagnostics.Process.Start(@"C:\Users\chris\Documents\GitHub\Group4\Hospital\CurrentPatients.pdf");
            } catch {
                MessageBox.Show("Something went wrong. Please make sure any previous reports are closed.", "Report was not generated.",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * On Click event for button to generate CurrentStaff report to show
         * how many staff are currently within the system.
         */
        private void CountStaffBtn_Click(object sender, EventArgs e) {
            try {
                //Intantiates new Report Document, loads document based off rpt template.
                ReportDocument cryRpt = new ReportDocument();
                cryRpt.Load(@"C:\Users\chris\Documents\GitHub\Group4\Hospital\Hospital\StaffRep.rpt");//source file location for the premade report, may need to be manually changed

                //Exports generated report to PDF format
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\chris\Documents\GitHub\Group4\Hospital\CurrentStaff.pdf"); //output location, may need to be manually changed

                System.Diagnostics.Process.Start(@"C:\Users\chris\Documents\GitHub\Group4\Hospital\CurrentStaff.pdf");
            } catch {
                MessageBox.Show("Something went wrong. Please make sure any previous reports are closed.", "Report was not generated.",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * On Click event for button to generate StaffVsPatient report to
         * show a comparison between amount of patients to amount of staff.
         */
        private void PatToDocBtn_Click(object sender, EventArgs e) {
            SqlConnection con = DBCon.DBConnect();
            int patients = 0;
            int doctors = 0;
            int nurses = 0;

            con.Open();

            SqlCommand command = new SqlCommand("SELECT (SELECT COUNT(*) FROM Users WHERE Role = 'Doctor') AS Doctors, " +
                                                        "(SELECT COUNT(*) FROM Users WHERE Role = 'Nurse') AS Nurses, " +
                                                        "(SELECT COUNT(*) FROM Patient WHERE Room != 'Discharged') as Patients;", con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                doctors = reader.GetInt32(0);
                nurses = reader.GetInt32(1);
                patients = reader.GetInt32(2);
            }
            reader.Close();
            con.Close();

            try {
                ReportDocument cryRpt = new ReportDocument();

                cryRpt.Load(@"C:\Users\chris\Documents\GitHub\Group4\Hospital\Hospital\StaffVsPatientsRep.rpt"); //source file location for the premade report, may need to be manually changed

                cryRpt.SetParameterValue("DoctorCount", doctors);
                cryRpt.SetParameterValue("NurseCount", nurses);
                cryRpt.SetParameterValue("PatientCount", patients);

                //Exports generated report to PDF format
                cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\chris\Documents\GitHub\Group4\Hospital\StaffVsPatientsRep.pdf"); //output location, may need to be manually changed

                System.Diagnostics.Process.Start(@"C:\Users\chris\Documents\GitHub\Group4\Hospital\StaffVsPatientsRep.pdf");
            } catch {
                MessageBox.Show("Something went wrong. Please make sure any previous reports are closed.", "Report was not generated.",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
