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

        public AdminRepfrm() {
            InitializeComponent();
        }

        //On click, generate new instance of AdminReport and exports it.
        private void TestRepbtn_Click(object sender, EventArgs e) {
            ReportDocument cryRpt = new ReportDocument();
            cryRpt.Load(@"C:\Users\Ima\Documents\GitHub\Group4\Hospital\Hospital\AdminReport.rpt");//source file location for the premade report, may need to be manually changed
            cryRpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, @"C:\Users\Ima\Documents\GitHub\Group4\Hospital\AdminTest.pdf"); //output location, may need to be manually changed
            MessageBox.Show("Export to PDF Successful.");
        }
    }
}
