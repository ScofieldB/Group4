using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital {
    class Admin {

        private SqlConnection con = DBCon.DBConnect();

        /*
         * Add user access to system with specified userID and role.
         * Sets default password for new user to their surname.
         */
        public string addUser(string userID, string role) {
            bool userExist = false;
            string Surname = "";
            con.Open();

            SqlCommand command = new SqlCommand("SELECT Count(*) FROM Staff WHERE StaffID = @id", con);
            command.Parameters.AddWithValue("@id", userID);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                if (Convert.ToInt32(reader.GetInt32(0)) > 0) {
                    userExist = true;
                }
            }
            reader.Close();
            command.Parameters.Clear();

            if (userExist) {
                command.CommandText = "SELECT Surname FROM [INB201].[dbo].[Staff] WHERE StaffID = @id";
                command.Parameters.AddWithValue("@id", userID);
                reader = command.ExecuteReader();
                while (reader.Read()) {
                    Surname = reader.GetString(0);
                }
                reader.Close();
                command.Parameters.Clear();

                //Used for hasing password
                System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(Surname);
                data = x.ComputeHash(data);
                String md5Hash = System.Text.Encoding.ASCII.GetString(data);

                command.CommandText = "INSERT INTO Users (StaffID, Password, Role, Confirmed) " + "VALUES (@id, @pw, @role, '0')";
                command.Parameters.AddWithValue("@id", userID);
                command.Parameters.AddWithValue("@role", role);
                command.Parameters.AddWithValue("@pw", md5Hash);
                command.ExecuteNonQuery();
                con.Close();
            }

            return Surname;
        }


        /*
         * Remove specified userID from system.
         */
        public void deleteUser(string user) {
            con.Open();
            SqlCommand command = new SqlCommand(null, con);
            command.CommandText = "DELETE FROM [dbo].[Users] WHERE StaffID = @id";
            command.Parameters.AddWithValue("@id", user);
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
