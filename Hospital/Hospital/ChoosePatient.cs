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
        private Reception previousRecep;
        private HospitalSystem previousHosp;
        private string SurnameSearched;
        private static int chosenIndex;
        private string UserID;
        private string Role;

        public ChoosePatient(string User, string role, Form home, Form previous, string Surname, PatientGetSet[] pats) {
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
