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
 * Form is used for when User needs to update their password when
 * current password in system is system generated.
 */
namespace Hospital {
    public partial class NewPasswordfrm : Form {
        private string userID = "";

        public NewPasswordfrm() {
            InitializeComponent();
        }

        /*
         * Constructor that sets global variable.
         */
        public NewPasswordfrm(string user) {
            InitializeComponent();
            userID = user;
        }


        /*
         * Once clicked the new password will be hashed and then stored into database. Also update Confirmed
         * column in database to 1 to show that password is no longer admin generated but is infact a password
         * chosen by the user
         */
        private void NewUserbtn_Click(object sender, EventArgs e) {

            if (NewPwtxt.Text == VerifyPwtxt.Text) {
                Login login = new Login();
                login.NewPassword(userID, NewPwtxt.Text);

                MessageBox.Show("Username: " + userID + " password has now been updated.", "New Password updated",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ActiveForm.Close();
            } else {
                MessageBox.Show("Passwords did not match. Please try again", "New Password fail",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*
         * Cancels the new password setup and returns user to the login screen.
         */
        private void Cancelbtn_Click(object sender, EventArgs e) {
            ActiveForm.Close();
        }
    }
}
