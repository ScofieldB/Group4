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
    *info, reception can modify and save patient information, forced? (can just make the update command
    *happen at each display/close). Generate new patient Id.
    */
    class Patient {
        

        public static PatientGetSet SearchPID(int PID) { //not sure about void here

            PatientGetSet pat = new PatientGetSet();

            SqlConnection con = DBCon.DBConnect();
            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Patient WHERE PatientID = @id", con);
            command.Parameters.AddWithValue("@id", PID);
            SqlDataReader reader = command.ExecuteReader();

            //Read the whole lot, if 
            while (reader.Read()) {
                pat.setPatient(reader.GetInt32(0));
                pat.setFN(reader.GetString(1));
                pat.setSN(reader.GetString(2));
                pat.setGender(reader.GetString(3));
                pat.setDOB(reader.GetDateTime(4));

                if (!reader.IsDBNull(5)) {
                    pat.setAddress(reader.GetString(5));
                } else {
                    pat.setAddress("");
                }

                if (!reader.IsDBNull(6)) {
                    pat.setPhone(reader.GetInt32(6));
                } else {
                    pat.setPhone(0);
                }

                if (!reader.IsDBNull(7)) {
                    pat.setMobile(reader.GetInt32(7));
                } else {
                    pat.setMobile(0);
                }

                if (!reader.IsDBNull(8)) {
                    pat.setAllergies(reader.GetString(8));
                }

                pat.setCoverT(reader.GetInt32(9));

                if (!reader.IsDBNull(10)) {
                    pat.setCoverN(reader.GetInt32(10));
                }
                pat.setStatus(reader.GetBoolean(11));
                
                if (!reader.IsDBNull(12)) {
                    pat.setNextKin(reader.GetString(12));
                } else {
                    pat.setNextKin("");
                }
                if (!reader.IsDBNull(13)) {
                    pat.setKP(reader.GetInt32(13));
                } else {
                    pat.setKP(0);
                }
                
                pat.setRoom(reader.GetString(14));
                pat.setCharges(reader.GetInt32(15));
            }
            reader.Close();
            con.Close();

            return pat;
        }

        public static PatientGetSet[] searchPatientSurname(string surname) {
            PatientGetSet[] Patients;
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
                Patients = new PatientGetSet[1];

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
                Patients = new PatientGetSet[Patientcount];

                command.CommandText = "SELECT PatientID FROM Patient WHERE Surname = @surname";
                command.Parameters.AddWithValue("@surname", surname);
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    PID[PosInPatients] = reader.GetInt32(0);
                    PosInPatients++;
                }

                for (int i = 0; i < PID.Length; i++) {
                    PatientGetSet pat = SearchPID(PID[i]);
                    Patients[i] = pat;
                }
            }
            
            return Patients;
        }

        public void NewPatient() {

       
        }

        public void UpdatePatient() {

        }


        public static int DischargePatient(PatientGetSet pat) {
            int totalCharges = 0;
            Facilities fac = new Facilities();
            fac.DischargePatient(pat.getPatient());

            SqlConnection con = DBCon.DBConnect();

            con.Open();

            SqlCommand command = new SqlCommand("SELECT TotalCharges FROM Patient WHERE PatientID = @patID", con);
            command.Parameters.AddWithValue("@patID", pat.getPatient());
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                totalCharges = reader.GetInt32(0);
            }

            reader.Close();

            command.Parameters.Clear();
            command.CommandText = "UPDATE Patient SET TotalCharges = 0 WHERE PatientID = @patID";
            command.Parameters.AddWithValue("patID", pat.getPatient());
            command.ExecuteNonQuery();

            con.Close();

            return totalCharges;
        }

        public static void updateAdmitCharge(int patientID, int patientCoverT) {
            int charge = 0;
            SqlConnection con = DBCon.DBConnect();

            con.Open();

            SqlCommand command = new SqlCommand("SELECT CoverSurcharge FROM Cover WHERE CoverType = @coverT", con);
            command.Parameters.AddWithValue("@coverT", patientCoverT);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                charge = reader.GetInt32(0);
            }

            reader.Close();

            command.Parameters.Clear();

            command.CommandText = "UPDATE Patient SET TotalCharges = TotalCharges + @cost WHERE PatientID = @patID";
            command.Parameters.AddWithValue("@cost", charge);
            command.Parameters.AddWithValue("patID", patientID);
            command.ExecuteNonQuery();

            con.Close();

            //
        }
    }
}
