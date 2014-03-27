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
                command.CommandText = "UPDATE Patient SET Room = 'E100' WHERE PatientID = @id";
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
    }
}
