using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital {
    public class Admin {

        private SqlConnection con = DBCon.DBConnect();

        /*
         * Add user access to system with specified userID and role.
         * Sets default password for new user to their surname.
         * \param string userID - userID to be added to system
         * \param string role - role of the user being added to system
         */
        public string AddUser(string userID, string role) {
            bool userExist = false;
            string surname = "";
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
                    surname = reader.GetString(0);
                }
                reader.Close();
                command.Parameters.Clear();

                //Used for hashing password
                System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] data = System.Text.Encoding.ASCII.GetBytes(surname);
                data = x.ComputeHash(data);
                String md5Hash = System.Text.Encoding.ASCII.GetString(data);

                command.CommandText = "INSERT INTO Users (StaffID, Password, Role, Confirmed) " + "VALUES (@id, @pw, @role, '0')";
                command.Parameters.AddWithValue("@id", userID);
                command.Parameters.AddWithValue("@role", role);
                command.Parameters.AddWithValue("@pw", md5Hash);
                command.ExecuteNonQuery();
                con.Close();
            }

            return surname;
        }


        /*
         * Queries the role of the userID passed as parameter
         * \param string userID - userID being queried
         * \return string - the role of the user being queried
         */
        public string QueryUser(string userID) {
            string role = "";
            con.Open();

            SqlCommand command = new SqlCommand("SELECT Role FROM Users WHERE StaffID = @id", con);
            command.Parameters.AddWithValue("@id", userID);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                role = reader.GetString(0);
            }
            reader.Close();
            con.Close();

            return role;
        }


        /*
         * If the user exists, update teh user with supplied role
         * \param string userID - userID to be updated
         * \param string role - role to update userID to
         */
        public void UpdateUser(string userID, string role) {

            con.Open();

            SqlCommand command = new SqlCommand("SELECT Count(*) FROM Staff WHERE StaffID = @id", con);
            command.Parameters.AddWithValue("@id", userID);
            SqlDataReader reader = command.ExecuteReader();

            int countOfUser = 0;
            while (reader.Read()) {
                countOfUser = Convert.ToInt32(reader.GetInt32(0));
            }
            reader.Close();

            if (countOfUser == 1) {

                command.Parameters.Clear();
                command.CommandText = "UPDATE Users SET Role = @role WHERE StaffID = @id";
                command.Parameters.AddWithValue("@id", userID);
                command.Parameters.AddWithValue("@role", role);
                command.ExecuteNonQuery();
            }

            con.Close();

        }


        /*
         * Remove specified userID from system.
         * \param string userId - userId of the user to be deleted
         */
        public void DeleteUser(string userId) {
            con.Open();
            SqlCommand command = new SqlCommand(null, con);
            command.CommandText = "DELETE FROM [dbo].[Users] WHERE StaffID = @id";
            command.Parameters.AddWithValue("@id", userId);
            command.ExecuteNonQuery();
            con.Close();
        }
    }
}
