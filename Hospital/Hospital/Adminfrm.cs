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

        public Adminfrm() {
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
         * Check if username input into username text field allready exists as a staff member.
         * If exists create user in users table and give a default password displayed to screen.
         * If user does not exist then display error message notification.
         */
        private void Newbtn_Click(object sender, EventArgs e) {
            Admin admin = new Admin();
            string Surname = "";

            try {
                Surname = admin.addUser(Usernametxt.Text, Rolecmb.SelectedItem.ToString());


                if (Surname == "") {
                    MessageBox.Show("Username " + Usernametxt.Text + " is not a valid userame"
                                    + Surname, "User Not Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    MessageBox.Show("Username " + Usernametxt.Text + " has now been added to system with password: "
                                    + Surname, "User Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch (Exception) {
                MessageBox.Show("Please input a valid username and select a role", "User Not Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Delete the User input in Username text field from the database user table.
        private void Deletebtn_Click(object sender, EventArgs e) {
            Admin admin = new Admin();

            try {
                admin.deleteUser(Usernametxt.Text);


                MessageBox.Show("UserID " + Usernametxt.Text + " has now been deleted from system", "User deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Usernametxt.Text = "";
            } catch {
                MessageBox.Show("Please input a valid username to be deleted", "User Not Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
