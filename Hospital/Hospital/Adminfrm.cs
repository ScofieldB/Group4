using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hospital {
    public partial class Adminfrm : Form {
        private Form home;

        private string userID;

        public Adminfrm(string user) {
            userID = user;
            InitializeComponent();
        }


        // Used to set variable used to go back to login screen
        public void setHome(Form logout) {
            home = logout;
        }

        //Logout and return to login screen
        private void Logoutbtn_Click(object sender, EventArgs e) {
            home.Show();
            Close();
        }

        /*
         * Opens new window with selection of reports for Admin
         * Very crude currently, might need to change to a tabular design like receptionist
         * No logout or back functions implemented yet
         */
        private void reportbtn_Click(object sender, EventArgs e) {
            AdminRepfrm adminrepform = new AdminRepfrm();
            adminrepform.setHome(home, ActiveForm);
            ActiveForm.Hide();
            adminrepform.Show();
        }

        private void usermgmtbtn_Click(object sender, EventArgs e) {
            UserManagement usermgmt = new UserManagement(userID);
            usermgmt.setHome(home, ActiveForm);
            ActiveForm.Hide();
            usermgmt.Show();
        }

    }
}
