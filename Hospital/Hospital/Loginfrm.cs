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
 * Form is used as the main entry point into the system and contains features
 * for user to login to system.
 */
namespace Hospital {
    public partial class Loginfrm : Form {

        /*
         * Constructor to initialize form.
         */
        public Loginfrm() {
            InitializeComponent();
        }



        /*
         * Exit the program
         */
        private void Exitbtn_Click(object sender, EventArgs e) {
            Close();
        }


        /*
         * Once login is clicked will hash the password input by user and compare hashed password to that which
         * is stored in the database. If matches then checks what role the user is otherwise display error message
         * to user.
         */
        private void Loginbtn_Click(object sender, EventArgs e) {
            Login login = new Login();
            User user = null;
            try {
                user = login.GetDetails(Usernametxt.Text, Passwordtxt.Text);
            } catch {
                MessageBox.Show("Username is Incorrect. Please try again.", "Login Failed",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (user != null) {
                //Checks to see if Username exists. If it doesnt then username will be blank
                if ((Usernametxt.Text == "") || (user.GetUser() == "")) {
                    MessageBox.Show("Username or Password is Incorrect. Please try again.", "Login Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else {

                    //Check if user has user generated generated password
                    if (user.GetConfirmed() == true) {

                        //Opens appropriate form depending on which role user is
                        if (user.GetRole() == "Admin") {
                            Adminfrm adminform = new Adminfrm(user.GetUser());
                            adminform.SetHome(ActiveForm);
                            ActiveForm.Hide();
                            adminform.Show();
                        } else if (user.GetRole() == "Receptionist") {
                            Reception reception = new Reception(user.GetUser());
                            reception.SetHome(ActiveForm);
                            ActiveForm.Hide();
                            reception.Show();
                        } else {
                            HospitalSystem mainprogram = new HospitalSystem(user.GetUser(), user.GetRole());
                            mainprogram.SetHome(ActiveForm);
                            ActiveForm.Hide();
                            mainprogram.Show();
                        }

                    // If password is not user generated but was System Admin generated then ensure 
                    // user must update password.
                    } else {
                        NewPasswordfrm newpw = new NewPasswordfrm(user.GetUser());
                        newpw.Show();
                    }
                }
            }
            //Clear users input
            Usernametxt.Text = "";
            Passwordtxt.Text = "";
        }

    }
}
