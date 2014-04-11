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

        public ChoosePatient() {
            InitializeComponent();
        }


        public ChoosePatient(Form home, Form previous, string Surname, PatientGetSet[] pats) {
            homeScreen = home;
            previousForm = previous;
            patients = pats;
            SurnameSearched = Surname;
            InitializeComponent();
            SearchSurnamelbl.Text += Surname;

            for(int i = 0; i < patients.Length; i++){
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
                Reception reception = new Reception();
                reception.setPatient(chosen);
                reception.setHome(homeScreen);
                ActiveForm.Close();
                reception.Show();
            } else {
                HospitalSystem system = new HospitalSystem();
                system.setPatient(chosen);
                system.setHome(homeScreen);
                ActiveForm.Close();
                system.Show();
            }

        }
    }
}
