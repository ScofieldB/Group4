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
        public static PatientGetSet Search(int PID) { //not sure about void here

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
                pat.setAddress(reader.GetString(5));
                pat.setPhone(reader.GetInt32(6));
                pat.setMobile(reader.GetInt32(7));

                if (!reader.IsDBNull(8)) {
                    pat.setAllergies(reader.GetString(8));
                }

                pat.setCoverT(reader.GetInt32(9));

                if (!reader.IsDBNull(10)) {
                    pat.setCoverN(reader.GetInt32(10));
                }
                pat.setStatus(reader.GetBoolean(11));
                pat.setNextKin(reader.GetString(12));
                if (!reader.IsDBNull(13)) {
                    pat.setKP(reader.GetInt32(13));
                }
                pat.setRoom(reader.GetString(14));
            }
            reader.Close();
            con.Close();

            return pat;
        }

        public void NewPatient() {

            //Btn click calls


            // SqlConnection con = DBCon.DBConnect();

            //con.Open();

            //Insert into statement for adding to database
            //collate text boxs as inputs for insert into statement, scalar mod to return newly generated ID
            //Mystery method must be made to display full contents of my reader (of the new record) to text boxes
            //Each method does the same display thing
        }

        /*
         Save btn ? magical update method that uses the textboxes as inputs for each col in patients
         * 
         */
    }
}
