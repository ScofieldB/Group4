using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital {
    public partial class ChoosePatient : Form {

        private static PatientGetSet chosen = new PatientGetSet();
        private static PatientGetSet[] patients;
        private Form homeScreen;
        private Form previousForm;
        private string SurnameSearched;
        private static int chosenIndex;
        private string UserID;
        private string Role;

        public ChoosePatient(string User, string role, Form home, Form previous, string Surname, PatientGetSet[] pats) {
            homeScreen = home;
            Role = role;
            UserID = User;
            previousForm = previous;
            patients = pats;
            SurnameSearched = Surname;
            InitializeComponent();
            SearchSurnamelbl.Text += Surname;

            for (int i = 0; i < patients.Length; i++) {
                chooseCmb.Items.Add("Firstname: " + patients[i].getFN() + "  --  DOB: " + patients[i].getDOB().ToString() +
                    "  --  Address: " + patients[i].getAddress());
            }
            chooseCmb.SelectedIndex = 0;
        }


        private void chooseCmb_SelectedIndexChanged(object sender, EventArgs e) {
            chosenIndex = chooseCmb.SelectedIndex;
            chosen = patients[chosenIndex];
        }

        private void Confirmbtn_Click(object sender, EventArgs e) {
            if (previousForm.Name == "Reception") {
                Reception reception = new Reception(UserID);
                reception.setPatient(chosen);
                reception.setHome(homeScreen);
                ActiveForm.Close();
                reception.Show();
            } else {
                HospitalSystem system = new HospitalSystem(UserID, Role);
                system.setPatient(chosen);
                system.setHome(homeScreen);
                ActiveForm.Close();
                system.Show();
            }

        }
    }
}
