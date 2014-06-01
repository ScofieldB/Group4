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

namespace Hospital {
    public partial class UserManagement : Form {
        Form home;
        Form back;
        private string userId;
        private Admin admin = new Admin();

        public UserManagement(string user) {
            userId = user;
            InitializeComponent();
        }

        // Used to set variable used to go back to login screen
        public void setHome(Form logout, Form back) {
            home = logout;
            this.back = back;
        }


        private void Querybtn_Click(object sender, EventArgs e) {
            if (Usernametxt.Text != "") {
                string role = admin.queryUser(Usernametxt.Text);

                switch (role) {


                    case "Doctor":
                        Rolecmb.SelectedIndex = 0;
                        break;
                    case "Nurse":
                        Rolecmb.SelectedIndex = 1;
                        break;
                    case "MedTech":
                        Rolecmb.SelectedIndex = 2;
                        break;
                    case "Receptionist":
                        Rolecmb.SelectedIndex = 3;
                        break;
                    case "Admin":
                        Rolecmb.SelectedIndex = 4;
                        break;
                    default:
                        Rolecmb.Text = "Not Found";
                        break;
                }
            } else {
                MessageBox.Show("StaffID: " + Usernametxt.Text + " does not exist in system.", "Invalid user",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        /*
         * Check if username input into username text field allready exists as a staff member.
         * If exists create user in users table and give a default password displayed to screen.
         * If user does not exist then display error message notification.
         */
        private void Newbtn_Click(object sender, EventArgs e) {

            string Surname = "";

            try {
                Surname = admin.addUser(Usernametxt.Text, Rolecmb.SelectedItem.ToString());

                if (Surname == "") {
                    MessageBox.Show("StaffID " + Usernametxt.Text + " is not a valid userame"
                                    + Surname, "User Not Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {
                    MessageBox.Show("StaffID " + Usernametxt.Text + " has now been added to system with password: "
                                    + Surname, "User Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            } catch (Exception) {
                MessageBox.Show("Please input a valid StaffID and select a role", "User Not Added",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        // Delete the User input in Username text field from the database user table.
        private void Deletebtn_Click(object sender, EventArgs e) {
            if (Usernametxt.Text == userId) {
                MessageBox.Show("User can not remove themselves from system. Please contact " +
                    "another Admin if you wish to proceed", "User Not Added",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {

                int CountOfUser = countUsers(userId);

                if (CountOfUser > 0) {

                    try {
                        admin.deleteUser(Usernametxt.Text);

                        MessageBox.Show("StaffID " + Usernametxt.Text + " has now been deleted from system", "User deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Usernametxt.Text = "";
                    } catch {
                        MessageBox.Show("Please input a valid username to be deleted", "User Not Deleted",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("StaffID " + Usernametxt.Text + " is not a valid StaffID in system", "Please Try Again",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LogBtn_Click(object sender, EventArgs e) {
            home.Show();
            Close();
        }

        private void Updatebtn_Click(object sender, EventArgs e) {
            if (Usernametxt.Text == userId) {
                MessageBox.Show("User can not update themselves in system. Please contact " +
                    "another Admin if you wish to proceed", "User Not Updated",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                int CountOfUser = countUsers(userId);

                if (CountOfUser > 0) {

                    if (Rolecmb.SelectedIndex >= 0) {
                        try {
                            admin.updateUser(Usernametxt.Text, Rolecmb.SelectedItem.ToString());

                            MessageBox.Show("StaffID " + Usernametxt.Text + " has now been updated in system " +
                                "to " + Rolecmb.SelectedItem.ToString(), "User deleted",
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            Usernametxt.Text = "";
                            Rolecmb.Text = "";
                        } catch {
                            MessageBox.Show("Please input a valid username to be updated", "User Not Updated",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else {
                        MessageBox.Show("Please choose a valid Role", "User Not Updated",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("StaffID " + Usernametxt.Text + " is not a valid StaffID in system", "Please Try Again",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }


        private int countUsers(string userID) {
            SqlConnection con = DBCon.DBConnect();

            con.Open();

            SqlCommand command = new SqlCommand("SELECT Count(*) FROM Staff WHERE StaffID = @id", con);
            command.Parameters.AddWithValue("@id", Usernametxt.Text);
            SqlDataReader reader = command.ExecuteReader();

            int CountOfUser = 0;
            while (reader.Read()) {
                CountOfUser = Convert.ToInt32(reader.GetInt32(0));
            }
            reader.Close();

            con.Close();

            return CountOfUser;
        }

    }
}
