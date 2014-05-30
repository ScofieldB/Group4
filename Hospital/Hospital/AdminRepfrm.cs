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

namespace Hospital {
    public partial class AdminRepfrm : Form {

        private Form home;
        private Form back;

        public AdminRepfrm() {
            InitializeComponent();
        }

        //On click, generate new instance of AdminReport and exports it.
        private void TestRepbtn_Click(object sender, EventArgs e) {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Hospital\FacilitiesUsedRep.rpt");//source file location for the premade report, may need to be manually changed
            cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\FacilitiesUsedRep.pdf"); //output location, may need to be manually changed

            System.Diagnostics.Process.Start(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\FacilitiesUsedRep.pdf");
        }

        // Used to set variable used to go back to login screen
        public void setHome(Form logout, Form back) {
            home = logout;
            this.back = back;
        }

        private void LogBtn_Click(object sender, EventArgs e) {
            home.Show();
            Close();
        }

        private void BackBtn_Click(object sender, EventArgs e) {
            back.Show();
            Close();
        }

        private void Outstandingbtn_Click(object sender, EventArgs e) {
            //Intantiates new Report Document, loads document based off rpt template.
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Hospital\OutstandingChargesRep.rpt");//source file location for the premade report, may need to be manually changed

            //Exports generated report to PDF format
            cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\OutstandingCharges.pdf"); //output location, may need to be manually changed

            System.Diagnostics.Process.Start(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\OutstandingCharges.pdf");
        }

        private void Roomsbtn_Click(object sender, EventArgs e) {
            //Intantiates new Report Document, loads document based off rpt template.
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Hospital\CurrentPatientsRep.rpt");//source file location for the premade report, may need to be manually changed
            
            //Exports generated report to PDF format
            cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\CurrentPatients.pdf"); //output location, may need to be manually changed
            //MessageBox.Show("Export to PDF Successful.");

            System.Diagnostics.Process.Start(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\CurrentPatients.pdf");
        }

        private void CountStaffBtn_Click(object sender, EventArgs e) {
            //Intantiates new Report Document, loads document based off rpt template.
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Hospital\StaffRep.rpt");//source file location for the premade report, may need to be manually changed


            //Exports generated report to PDF format
            cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\CurrentStaff.pdf"); //output location, may need to be manually changed

            System.Diagnostics.Process.Start(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\CurrentStaff.pdf");
        }

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

            ReportDocument cryRpt = new ReportDocument();

            cryRpt.Load(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Hospital\StaffVsPatientsRep.rpt");

            cryRpt.SetParameterValue("DoctorCount", doctors);
            cryRpt.SetParameterValue("NurseCount", nurses);
            cryRpt.SetParameterValue("PatientCount", patients);
            //source file location for the premade report, may need to be manually changed


            //Exports generated report to PDF format
            cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\StaffVsPatientsRep.pdf"); //output location, may need to be manually changed

            System.Diagnostics.Process.Start(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\StaffVsPatientsRep.pdf");

        }

    }
}
