using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital {
    class Facilities {

        private SqlConnection con = DBCon.DBConnect();

        public bool admitPatient(int patID){
            bool admitted = false;
            string room = "";
            int capacity = 0;

            con.Open();

            SqlCommand command = new SqlCommand("Select Room, Capacity from Facilities WHERE RoomType = 'Emergency' AND Capacity > 0;", con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                admitted = true;
                room = reader.GetString(0);
                capacity = reader.GetInt32(1);
            }

            reader.Close();

            if (admitted == true) {
                command.CommandText = "UPDATE Patient SET Room = @room WHERE PatientID = @id";
                command.Parameters.AddWithValue("@room", room);
                command.Parameters.AddWithValue("@id", patID);
                command.ExecuteNonQuery();

                command.Parameters.Clear();

                command.CommandText = "UPDATE Facilities SET Capacity = @cap WHERE Room = @room";
                command.Parameters.AddWithValue("@cap", capacity - 1);
                command.Parameters.AddWithValue("@room", room);
                command.ExecuteNonQuery();
            
            }

            con.Close();

            return admitted;
        }

        public bool bookSurgery(PatientGetSet pat) {
            bool success = false;

            string newRoom = "";
            int newRoomCapacity = 0;

            if (!pat.getRoom().StartsWith("S")) {
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

                if (success == true) {
                    updateFacilities(pat, newRoomCapacity, newRoom);
                }

                con.Close();
            }
            return success;
        }

        public bool bookImaging(PatientGetSet pat) {
            bool success = false;

            string newRoom = "";
            int newRoomCapacity = 0;
            if (!pat.getRoom().StartsWith("I")) {
                con.Open();

                SqlCommand command = new SqlCommand("Select Room, Capacity from Facilities WHERE RoomType = 'Imaging' AND Capacity > 0;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    success = true;
                    newRoom = reader.GetString(0);
                    newRoomCapacity = reader.GetInt32(1);
                }

                reader.Close();

                if (success == true) {
                    updateFacilities(pat, newRoomCapacity, newRoom);
                }

                con.Close();
            }
            return success;
        }

        public void returnPatientToDoctor(PatientGetSet pat){
            bool success = false;
            string newRoom = "";
            int newRoomCapacity = 0;

            if (!pat.getRoom().StartsWith("E")) {
                con.Open();

                SqlCommand command = new SqlCommand("Select Room, Capacity from Facilities WHERE RoomType = 'Emergency' AND Capacity > 0;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    success = true;
                    newRoom = reader.GetString(0);
                    newRoomCapacity = reader.GetInt32(1);
                }

                reader.Close();

                if (success == true) {
                    updateFacilities(pat, newRoomCapacity, newRoom);
                }

                con.Close();
            }
        }

        private void updateFacilities(PatientGetSet pat, int newRoomCapacity, string newRoom) {
            int currentRoomCapacity = 0;
            SqlCommand command = new SqlCommand("", con);

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
        }
    }
}
