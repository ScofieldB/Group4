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
    public partial class Loginfrm : Form {



        public Loginfrm() {
            InitializeComponent();
        }

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
            User user = login.getDetails(Usernametxt.Text, Passwordtxt.Text);

            //Checks to see if Username exists. If it doesnt then username will be blank
            if ((Usernametxt.Text == "") || (user.getUser() == "")) {
                MessageBox.Show("Username or Password is Incorrect. Please try again.", "Login Failed",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {

                if (user.getConfirmed() == true) {
                    //Opens appropriate form depending on which role user is

                    if (user.getRole() == "Admin") {
                        Adminfrm adminform = new Adminfrm();
                        adminform.setHome(ActiveForm);
                        ActiveForm.Hide();
                        adminform.Show();
                    } else if(user.getRole() == "Receptionist") {
                        Reception reception = new Reception(user.getUser(), user.getRole());
                        reception.setHome(ActiveForm);
                        ActiveForm.Hide();
                        reception.Show();
                    } else {
                        HospitalSystem mainprogram = new HospitalSystem(user.getUser(), user.getRole());
                        mainprogram.setHome(ActiveForm);
                        ActiveForm.Hide();
                        mainprogram.Show();

                    }
                } else {
                    NewPasswordfrm newpw = new NewPasswordfrm(user.getUser());
                    newpw.Show();
                }
            }
            //Clear users input
            Usernametxt.Text = "";
            Passwordtxt.Text = "";

        }
    }

}
