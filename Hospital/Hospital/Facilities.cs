using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital {
    public class Facilities {

        private SqlConnection con = DBCon.DBConnect();


        /*
         * Update database with patient allocated to Emergency and update
         * the room bed allocations.
         */
        public bool admitPatient(int patID) {
            bool admitted = false;
            bool canAdmit = false;
            string room = "";
            string patRoom = "";
            int capacity = 0;

            con.Open();

            SqlCommand command = new SqlCommand("Select Room, Capacity from Facilities WHERE RoomType = 'Emergency' AND Capacity > 0;", con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                canAdmit = true;
                room = reader.GetString(0);
                capacity = reader.GetInt32(1);
            }

            reader.Close();

            if (canAdmit == true) {
                command.CommandText = "SELECT Room FROM Patient WHERE PatientID = @id";
                command.Parameters.AddWithValue("@id", patID);
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    patRoom = reader.GetString(0);
                }
                reader.Close();

                if (patRoom.StartsWith("0")) {
                    admitted = true;
                    command.Parameters.Clear();
                    command.CommandText = "UPDATE Patient SET Room = @room WHERE PatientID = @id";
                    command.Parameters.AddWithValue("@room", room);
                    command.Parameters.AddWithValue("@id", patID);
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    command.CommandText = "UPDATE Facilities SET Capacity = @cap WHERE Room = @room";
                    command.Parameters.AddWithValue("@cap", capacity - 1);
                    command.Parameters.AddWithValue("@room", room);
                    command.ExecuteNonQuery();
                } else {
                    admitted = false;
                }
            }

            con.Close();

            return admitted;
        }


        /*
         * Update database that patient is now moved to Surgery room and update
         * room bed allocations.
         */
        public bool bookSurgery(PatientGetSet pat, FinanceCmbItem typeBooked) {
            bool success = false;

            string newRoom = "";
            int newRoomCapacity = 0;

            if (pat.getRoom().StartsWith("E")) {
                con.Open();

                //Find any available Surgery rooms
                SqlCommand command = new SqlCommand("SELECT Room, Capacity FROM Facilities WHERE RoomType = 'Surgery' AND Capacity > 0;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    success = true;
                    newRoom = reader.GetString(0);
                    newRoomCapacity = reader.GetInt32(1);
                }
                reader.Close();

                con.Close();

                if (success == true) {
                    updateFacilities(pat, newRoomCapacity, newRoom);
                    checkCover(pat, typeBooked);      
                }
                
            }
            return success;
        }


        /*
         * Update database that patient is now moved to Imaging room and update
         * room bed allocations.
         */
        public bool bookImaging(PatientGetSet pat, FinanceCmbItem typeBooked) {
            bool success = false;
            int cost = typeBooked.Cost;

            string newRoom = "";
            int newRoomCapacity = 0;
            if (pat.getRoom().StartsWith("E")) {
                con.Open();

                SqlCommand command = new SqlCommand("Select Room, Capacity from Facilities WHERE RoomType = 'Imaging' AND Capacity > 0;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    success = true;
                    newRoom = reader.GetString(0);
                    newRoomCapacity = reader.GetInt32(1);
                }

                reader.Close();
                con.Close();
                if (success == true) {
                    updateFacilities(pat, newRoomCapacity, newRoom);
                    checkCover(pat, typeBooked);      
                }

            }
            return success;
        }


        /*
         * Update database when sending patient back to doctor and update
         * room bed allocations.
         */
        public void returnPatientToDoctor(PatientGetSet pat) {
            bool success = false;
            string newRoom = "";
            int newRoomCapacity = 0;

            if (pat.getRoom().StartsWith("S") || pat.getRoom().StartsWith("I")) {
                con.Open();

                SqlCommand command = new SqlCommand("Select Room, Capacity from Facilities WHERE RoomType = 'Emergency' AND Capacity > 0;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    success = true;
                    newRoom = reader.GetString(0);
                    newRoomCapacity = reader.GetInt32(1);
                }

                reader.Close();
                con.Close();

                if (success == true) {
                    updateFacilities(pat, newRoomCapacity, newRoom);
                }

            }
        }


        /*
         * Update patient to new room and change room bed allocations within database.
         */
        private void updateFacilities(PatientGetSet pat, int newRoomCapacity, string newRoom) {
            int currentRoomCapacity = 0;
            SqlCommand command = new SqlCommand("", con);

            con.Open();

            //Find capacity of room patient currently is.
            command.CommandText = "SELECT Capacity FROM Facilities WHERE Room = @room;";
            command.Parameters.AddWithValue("@room", pat.getRoom());
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                currentRoomCapacity = reader.GetInt32(0);
            }
            reader.Close();


            //Move patient to new bed facility and remove 1 bedding space
            command.Parameters.Clear();
            command.CommandText = "UPDATE Facilities SET Capacity = @cap WHERE Room = @room";
            command.Parameters.AddWithValue("@cap", newRoomCapacity - 1);
            command.Parameters.AddWithValue("@room", newRoom);
            command.ExecuteNonQuery();


            //Update room moved from to have an available bed slot free.
            command.Parameters.Clear();
            command.CommandText = "UPDATE Facilities SET Capacity = @cap WHERE Room = @room";
            command.Parameters.AddWithValue("@cap", currentRoomCapacity + 1);
            command.Parameters.AddWithValue("@room", pat.getRoom());
            command.ExecuteNonQuery();

            //Update Patient room to new room
            command.Parameters.Clear();
            command.CommandText = "UPDATE Patient SET Room = @room WHERE PatientID = @id";
            command.Parameters.AddWithValue("@room", newRoom);
            command.Parameters.AddWithValue("@id", pat.getPatient());
            command.ExecuteNonQuery();

            con.Close();
        }


        /*
         * Discharges patient from the Emergency room.
         */
        public int DischargePatient(int patId) {
            int capacity = 0;
            int totalCharges = 0;


            PatientGetSet pat = Patient.SearchPID(patId); ;

            if (pat.getRoom().StartsWith("E")) {

                con.Open();
    
                SqlCommand command = new SqlCommand(null, con);

                command.Parameters.Clear();
                command.CommandText = "UPDATE Patient SET Room = '0' WHERE PatientID = @id";
                command.Parameters.AddWithValue("@id", pat.getPatient());
                command.ExecuteNonQuery();

                command.Parameters.Clear();


                command.CommandText = "SELECT Capacity FROM Facilities WHERE RoomType = 'Emergency'";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    capacity = reader.GetInt32(0);
                }
                reader.Close();

                command.Parameters.Clear();
                command.CommandText = "UPDATE Facilities SET Capacity = @cap WHERE RoomType = 'Emergency'";
                command.Parameters.AddWithValue("@cap", capacity + 1);
                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.CommandText = "SELECT TotalCharges FROM Patient WHERE PatientID = @patID";
                command.Parameters.AddWithValue("@patID", pat.getPatient());
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    totalCharges = reader.GetInt32(0);
                }

                reader.Close();


                //Clear the charges from the Patient file.
                command.Parameters.Clear();
                command.CommandText = "UPDATE Patient SET TotalCharges = 0 WHERE PatientID = @patID";
                command.Parameters.AddWithValue("patID", pat.getPatient());
                command.ExecuteNonQuery();

                con.Close();
            }
            
            return totalCharges;
        }



        private void checkCover(PatientGetSet pat, FinanceCmbItem typeBooked) {
            SqlCommand command = new SqlCommand("", con);
            con.Open();
            //If user has no Private cover then charge the patient
            if (pat.getCoverT() == 0) {
                
                command.CommandText = "UPDATE Patient SET TotalCharges = TotalCharges + @cost WHERE PatientID = @patID";
                command.Parameters.AddWithValue("@cost", typeBooked.Cost);
                command.Parameters.AddWithValue("patID", pat.getPatient());
                command.ExecuteNonQuery();
            }

            command.Parameters.Clear();
            command.CommandText = "UPDATE Finance SET Counter = Counter + 1 WHERE Type = @type";
            command.Parameters.AddWithValue("@type", typeBooked.Type);
            command.ExecuteNonQuery();

            con.Close();
        }
    }

}
