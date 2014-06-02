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
                pat.setPatientId(reader.GetInt32(0));
                pat.setFName(reader.GetString(1));
                pat.setSName(reader.GetString(2));
                pat.setGender(reader.GetString(3));
                pat.setDOB(reader.GetDateTime(4));

                if (!reader.IsDBNull(5)) {
                    pat.setAddress(reader.GetString(5));
                } else {
                    pat.setAddress("");
                }

                if (!reader.IsDBNull(6)) {
                    pat.setPhone(reader.GetString(6));
                } else {
                    pat.setPhone("Unknown");
                }

                if (!reader.IsDBNull(7)) {
                    pat.setMobile(reader.GetString(7));
                } else {
                    pat.setMobile("Unknown");
                }

                if (!reader.IsDBNull(8)) {
                    pat.setAllergies(reader.GetString(8));
                }

                pat.setCoverType(reader.GetInt32(9));

                if (!reader.IsDBNull(10)) {
                    pat.setCoverNum(reader.GetInt32(10));
                }

                if (!reader.IsDBNull(12)) {
                    pat.setNextKin(reader.GetString(12));
                } else {
                    pat.setNextKin("");
                }
                if (!reader.IsDBNull(13)) {
                    pat.setNextKinPhone(reader.GetString(13));
                } else {
                    pat.setNextKinPhone("Unknown");
                }

                pat.setRoom(reader.GetString(14));
                pat.setCharges(reader.GetInt32(15));
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
        public static PatientInfo[] searchPatientSurname(string surname) {
            PatientInfo[] Patients;
            int Patientcount = 0;

            SqlConnection con = DBCon.DBConnect();

            con.Open();

            SqlCommand command = new SqlCommand("SELECT Count(*) FROM Patient WHERE Surname = @surname", con);
            command.Parameters.AddWithValue("@surname", surname);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                Patientcount = reader.GetInt32(0);
            }

            reader.Close();
            command.Parameters.Clear();


            if (Patientcount == 1) {
                Patients = new PatientInfo[1];

                command.CommandText = "SELECT PatientID FROM Patient WHERE Surname = @surname";
                command.Parameters.AddWithValue("@surname", surname);
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    Patients[0] = SearchPID(reader.GetInt32(0));
                }

            } else {
                int PosInPatients = 0;
                int[] PID = new int[Patientcount];
                string[] FirstN = new string[Patientcount];
                DateTime[] DOB = new DateTime[Patientcount];
                string[] Address = new string[Patientcount];
                Patients = new PatientInfo[Patientcount];

                command.CommandText = "SELECT PatientID FROM Patient WHERE Surname = @surname";
                command.Parameters.AddWithValue("@surname", surname);
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    PID[PosInPatients] = reader.GetInt32(0);
                    PosInPatients++;
                }

                for (int i = 0; i < PID.Length; i++) {
                    PatientInfo pat = SearchPID(PID[i]);
                    Patients[i] = pat;
                }
            }

            con.Close();

            return Patients;
        }


        /*
         * Discharge patient from system
         * \param PatientInfo pat - Patient object to be discharged 
         * \return int - tototal outstanding charges patient owes
         */
        public static int DischargePatient(PatientInfo pat) {
            Facilities fac = new Facilities();
            int totalCharges = fac.DischargePatient(pat.getPatientId());

            return totalCharges;
        }


        /*
         * Updates the patients admission fee to outstanding charges based upon 
         * Patients level of hosptial cover
         * \param int patientID - PatientID of patient to be updated
         * \param int patientCoverT - level for the Cover Type of patient
         * \return int - admission fee for patient
         */
        public static int updateAdmitCharge(int patientID, int patientCoverT) {
            int charge = -1;
            string chargeType = "";
            SqlConnection con = DBCon.DBConnect();

            PatientInfo pat = Patient.SearchPID(patientID);

            if (pat.getPatientId() != -1) {

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
                    fac.updateChargeHistory(pat, "Admission", charge);
                }

            }

            return charge;
        }


        public static void clearChargeHistory(int patientID) {
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
