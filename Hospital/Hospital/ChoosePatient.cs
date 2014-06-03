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
        private string surnameSearched;
        private static int chosenIndex;
        private string userID;
        private string role;


        /*
         * Constructor to initialize form
         * \param string user - the staffID of user logged in. 
         * \param string role - role of user logged in
         * \param Form home - sets variable in order to return to login screen
         * \param Form previous - enables backwards navigation
         * \param string Surname - Surname being searched
         * \param PatientInfo[] pats - List of patients to choose from
         */
        public ChoosePatient(string user, string role, Form home, Form previous, string surname, PatientInfo[] pats) {
            homeScreen = home;
            this.role = role;
            userID = user;

            if (role == "Reception") {
                previousRecep = (Reception)previous;
            } else {
                previousHosp = (HospitalSystem)previous;
            }
            patients = pats;
            surnameSearched = surname;
            InitializeComponent();
            SearchSurnamelbl.Text += surname;

            // Fill Choosecmb Combo box with patient details
            for (int i = 0; i < patients.Length; i++) {
                chooseCmb.Items.Add("Firstname: " + patients[i].GetFName() + "  --  DOB: " + patients[i].GetDOB().ToString() +
                    "  --  Address: " + patients[i].GetAddress());
            }
            chooseCmb.SelectedIndex = 0;
        }


        /*
         * When ChooseCmb index change event occurs, updates appropriate variables 
         */
        private void ChooseCmb_SelectedIndexChanged(object sender, EventArgs e) {
            chosenIndex = chooseCmb.SelectedIndex;
            chosen = patients[chosenIndex];
        }


        /*
         * On Click event for user to confirm current patient selection
         * and returns user to the previous screen.
         */
        private void Confirmbtn_Click(object sender, EventArgs e) {
            if (role == "Reception") {
                previousRecep.SetPatient(chosen);
                previousRecep.SetHome(homeScreen);
                ActiveForm.Close();
            } else {
                previousHosp.SetPatient(chosen);
                previousHosp.SetHome(homeScreen);
                ActiveForm.Close();
            }

        }
    }
}
