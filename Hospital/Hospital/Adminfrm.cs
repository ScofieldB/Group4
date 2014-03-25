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

            Surname = admin.addUser(Usernametxt.Text, Rolecmb.SelectedItem.ToString());


            if (Surname == "") {
                MessageBox.Show("Username " + Usernametxt.Text + " is not a valid userame "
                                + Surname, "User Not Added",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                MessageBox.Show("Username " + Usernametxt.Text + " has now been added to system with password: "
                                + Surname, "User Added",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Delete the User input in Username text field from the database user table.
        private void Deletebtn_Click(object sender, EventArgs e) {
            Admin admin = new Admin();

            admin.deleteUser(Usernametxt.Text);


            MessageBox.Show("UserID " + Usernametxt.Text + " has now been deleted from system", "User deleted",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            Usernametxt.Text = "";
        }


        /* This feature will be deleted later. atm only here for me to update plaintext password in db to 
         * a hashed pw
         */
        private void button1_Click_1(object sender, EventArgs e) {
            SqlConnection con = DBCon.DBConnect();

            HashPassword hash = new HashPassword();
            string password = hash.getHash(Passwordtxt.Text);

            con.Open();
            SqlCommand command = new SqlCommand(null, con);
            command.CommandText = "UPDATE [dbo].[Users] SET [Password] = @pw, [Confirmed] = '0' WHERE StaffID = @id";
            command.Parameters.AddWithValue("@id", Usernametxt.Text);
            command.Parameters.AddWithValue("@pw", password);
            command.ExecuteNonQuery();

            con.Close();
        }


    }
}
