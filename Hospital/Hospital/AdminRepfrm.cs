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
            cryRpt.Load(@"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\Hospital\AdminReport.rpt");//source file location for the premade report, may need to be manually changed
            cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\BScofield_2\Documents\GitHub\Group4\Hospital\AdminTest.pdf"); //output location, may need to be manually changed
            MessageBox.Show("Export to PDF Successful.");
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
            MessageBox.Show("Export to PDF Successful.");
        }

    }
}
