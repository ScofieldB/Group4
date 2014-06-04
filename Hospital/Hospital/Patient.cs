using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hospital {
    /*
    *Functions for patient/reception tab. Search text bar for finding patient ID, display of patients
    *info, reception can modify and save patient information.
    */
    public class Patient {

        /*
         * Searches database for Patent via patientID
         * \param int PID - patientID to be searched
         * \return PatientInfo - either a valid patient object 
         *                          or a blank patient object
         */
        public static PatientInfo SearchPID(int PID) {

            PatientInfo pat = new PatientInfo();

            SqlConnection con = DBCon.DBConnect();
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Patient WHERE PatientID = @id", con);
            command.Parameters.AddWithValue("@id", PID);
            SqlDataReader reader = command.ExecuteReader();

            //Read the whole lot, if 
            while (reader.Read()) {
                pat.SetPatientId(reader.GetInt32(0));
                pat.SetFName(reader.GetString(1));
                pat.SetSName(reader.GetString(2));
                pat.SetGender(reader.GetString(3));
                pat.SetDOB(reader.GetDateTime(4));

                if (!reader.IsDBNull(5)) {
                    pat.SetAddress(reader.GetString(5));
                } else {
                    pat.SetAddress("");
                }

                if (!reader.IsDBNull(6)) {
                    pat.SetPhone(reader.GetString(6));
                } else {
                    pat.SetPhone("Unknown");
                }

                if (!reader.IsDBNull(7)) {
                    pat.SetMobile(reader.GetString(7));
                } else {
                    pat.SetMobile("Unknown");
                }

                if (!reader.IsDBNull(8)) {
                    pat.SetAllergies(reader.GetString(8));
                }

                pat.SetCoverType(reader.GetInt32(9));

                if (!reader.IsDBNull(10)) {
                    pat.SetCoverNum(reader.GetInt32(10));
                }

                if (!reader.IsDBNull(12)) {
                    pat.SetNextKin(reader.GetString(12));
                } else {
                    pat.SetNextKin("");
                }
                if (!reader.IsDBNull(13)) {
                    pat.SetNextKinPhone(reader.GetString(13));
                } else {
                    pat.SetNextKinPhone("Unknown");
                }

                pat.SetRoom(reader.GetString(14));
                pat.SetCharges(reader.GetInt32(15));
            }
            reader.Close();
            con.Close();

            return pat;
        }

        /*
         * Search for Patient via Patient Surname feature.
         * \param string surname - patient surname to be searched
         * \return PatientInfo - either a valid patient object 
         *                          or a blank patient object
         */
        public static PatientInfo[] SearchPatientSurname(string surname) {
            PatientInfo[] patients;
            int patientcount = 0;

            SqlConnection con = DBCon.DBConnect();

            con.Open();

            SqlCommand command = new SqlCommand("SELECT Count(*) FROM Patient WHERE Surname = @surname", con);
            command.Parameters.AddWithValue("@surname", surname);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                patientcount = reader.GetInt32(0);
            }

            reader.Close();
            command.Parameters.Clear();

            if (patientcount == 1) {
                patients = new PatientInfo[1];

                command.CommandText = "SELECT PatientID FROM Patient WHERE Surname = @surname";
                command.Parameters.AddWithValue("@surname", surname);
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    patients[0] = SearchPID(reader.GetInt32(0));
                }

            } else {
                int posInPatients = 0;
                int[] patientID = new int[patientcount];
                string[] firstN = new string[patientcount];
                DateTime[] DOB = new DateTime[patientcount];
                string[] address = new string[patientcount];
                patients = new PatientInfo[patientcount];

                command.CommandText = "SELECT PatientID FROM Patient WHERE Surname = @surname";
                command.Parameters.AddWithValue("@surname", surname);
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    patientID[posInPatients] = reader.GetInt32(0);
                    posInPatients++;
                }

                for (int i = 0; i < patientID.Length; i++) {
                    PatientInfo pat = SearchPID(patientID[i]);
                    patients[i] = pat;
                }
            }
            con.Close();
            return patients;
        }

        /*
         * Discharge patient from system
         * \param PatientInfo pat - Patient object to be discharged 
         * \return int - tototal outstanding charges patient owes
         */
        public static int DischargePatient(PatientInfo pat) {
            Facilities fac = new Facilities();
            int totalCharges = fac.DischargePatient(pat.GetPatientId());

            return totalCharges;
        }

        /*
         * Updates the patients admission fee to outstanding charges based upon 
         * Patients level of hosptial cover
         * \param int patientID - PatientID of patient to be updated
         * \param int patientCoverT - level for the Cover Type of patient
         * \return int - admission fee for patient
         */
        public static int UpdateAdmitCharge(int patientID, int patientCoverT) {
            int charge = -1;
            string chargeType = "";
            SqlConnection con = DBCon.DBConnect();

            PatientInfo pat = Patient.SearchPID(patientID);

            if (pat.GetPatientId() != -1) {

                con.Open();

                SqlCommand command = new SqlCommand("SELECT [Procedure], CoverSurcharge FROM Cover WHERE CoverType = @coverT", con);
                command.Parameters.AddWithValue("@coverT", patientCoverT);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    chargeType = reader.GetString(0);
                    charge = reader.GetInt32(1);
                }

                reader.Close();
                con.Close();

                command.Parameters.Clear();

                if (charge > -1) {
                    con.Open();
                    command.CommandText = "UPDATE Patient SET TotalCharges = TotalCharges + @cost WHERE PatientID = @patID";
                    command.Parameters.AddWithValue("@cost", charge);
                    command.Parameters.AddWithValue("patID", patientID);
                    command.ExecuteNonQuery();

                    con.Close();

                    Facilities fac = new Facilities();
                    fac.UpdateChargeHistory(pat, "Admission", charge);
                }
            }
            return charge;
        }

        /*
         * Clear all charges patient has accumulated within the ChargeHistory table
         * \param int patientID - patientID of the patient who's charges are being cleared
         */
        public static void ClearChargeHistory(int patientID) {
            SqlConnection con = DBCon.DBConnect();
            SqlCommand command = new SqlCommand("", con);
            con.Open();

            try {
                command.CommandText = "DELETE FROM ChargeHistory WHERE PatientID = @patID";
                command.Parameters.AddWithValue("@patID", patientID);
                command.ExecuteNonQuery();
            } catch {

            };
            con.Close();
        }
    }
}
