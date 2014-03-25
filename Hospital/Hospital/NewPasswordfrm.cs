﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital {
    public partial class NewPasswordfrm : Form {
        private string userID = "";

        public NewPasswordfrm() {
            InitializeComponent();
        }

        public NewPasswordfrm(string User) {
            InitializeComponent();
            userID = User;
        }


        /*
         * Once clicked the new password will be hashed and then stored into database. Also update Confirmed
         * column in database to 1 to show that password is no longer admin generated but is infact a password
         * chosen by the user
         */
        private void NewUserbtn_Click(object sender, EventArgs e) {

            if (NewPwtxt.Text == VerifyPwtxt.Text) {
                Login login = new Login();
                login.newPassword(userID, NewPwtxt.Text);

                MessageBox.Show("Username: " + userID + " password has now been updated.", "New Password updated",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                ActiveForm.Close();
            } else {
                MessageBox.Show("Passwords did not match. Please try again", "New Password fail",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cancelbtn_Click(object sender, EventArgs e) {
            ActiveForm.Close();
        }
    }
}
