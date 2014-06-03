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


/*
 * Form is used as the main window System Admin users log into and all features
 * for System Admin branch from this form.
 */
namespace Hospital {
    public partial class Adminfrm : Form {
        private Form home;

        private string userID;

        /*
         * Constructor to initialize form
         * \param string user - the staffID of user logged in. 
         */
        public Adminfrm(string user) {
            userID = user;
            InitializeComponent();
        }


        /*
         * Used to set variable used to go back to login screen
        * \param Form logout - set variable home in order for navigation to login screen
         */
        public void SetHome(Form logout) {
            home = logout;
        }

        /*
         * Logout and return to login screen
         */
        private void Logoutbtn_Click(object sender, EventArgs e) {
            home.Show();
            Close();
        }

        /*
         * On Click event for button to open AdminRepfrm form
         */
        private void Reportbtn_Click(object sender, EventArgs e) {
            AdminRepfrm adminrepform = new AdminRepfrm();
            adminrepform.SetHome(home, ActiveForm);
            ActiveForm.Hide();
            adminrepform.Show();
        }


        /*
         * On Click event for button to open the UserManagement form.
         */
        private void Usermgmtbtn_Click(object sender, EventArgs e) {
            UserManagement usermgmt = new UserManagement(userID);
            usermgmt.SetHome(home, ActiveForm);
            ActiveForm.Hide();
            usermgmt.Show();
        }

    }
}
