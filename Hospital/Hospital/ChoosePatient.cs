using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Form is responsible for selection of patient when multiple
 * patients are returned via a patient surname search.
 */
namespace Hospital {
    public partial class ChoosePatient : Form {

        private static PatientInfo chosen = new PatientInfo();
        private static PatientInfo[] patients;
        private Form homeScreen;
        private Reception previousRecep;
        private HospitalSystem previousHosp;
        private string SurnameSearched;
        private static int chosenIndex;
        private string UserID;
        private string Role;


        /*
         * Constructor to initialize form
         * \param string user - the staffID of user logged in. 
         * \param string role - role of user logged in
         * \param Form home - sets variable in order to return to login screen
         * \param Form previous - enables backwards navigation
         * \param string Surname - Surname being searched
         * \param PatientInfo[] pats - List of patients to choose from
         */
        public ChoosePatient(string User, string role, Form home, Form previous, string Surname, PatientInfo[] pats) {
            homeScreen = home;
            Role = role;
            UserID = User;

            if (role == "Reception") {
                previousRecep = (Reception)previous;
            } else {
                previousHosp = (HospitalSystem)previous;
            }
            patients = pats;
            SurnameSearched = Surname;
            InitializeComponent();
            SearchSurnamelbl.Text += Surname;

            // Fill Choosecmb Combo box with patient details
            for (int i = 0; i < patients.Length; i++) {
                chooseCmb.Items.Add("Firstname: " + patients[i].getFName() + "  --  DOB: " + patients[i].getDOB().ToString() +
                    "  --  Address: " + patients[i].getAddress());
            }
            chooseCmb.SelectedIndex = 0;
        }


        /*
         * When ChooseCmb index change event occurs, updates appropriate variables 
         */
        private void chooseCmb_SelectedIndexChanged(object sender, EventArgs e) {
            chosenIndex = chooseCmb.SelectedIndex;
            chosen = patients[chosenIndex];
        }


        /*
         * On Click event for user to confirm current patient selection
         * and returns user to the previous screen.
         */
        private void Confirmbtn_Click(object sender, EventArgs e) {
            if (Role == "Reception") {
                previousRecep.setPatient(chosen);
                previousRecep.setHome(homeScreen);
                ActiveForm.Close();
            } else {
                previousHosp.setPatient(chosen);
                previousHosp.setHome(homeScreen);
                ActiveForm.Close();
            }

        }
    }
}
