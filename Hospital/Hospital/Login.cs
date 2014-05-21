using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital {
    public class Login {

        /*
         * Confirms user password matches that on database and if so
         * return the users role and whether user has user generated password.
         * If password does not match one stored on database return empty userID
         */
        public User getDetails(string username, string password) {
            User user = new User();

            HashPassword hash = new HashPassword();
            password = hash.getHash(password);
            string checkpw = "";
            SqlConnection con = DBCon.DBConnect();

            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE StaffID = @id", con);
            command.Parameters.AddWithValue("@id", username);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                checkpw = reader.GetString(1);
                user.setRole(reader.GetString(2));
                user.setConfirmed(reader.GetBoolean(3));
            }
            reader.Close();
            con.Close();

            if (checkpw == password) {
                user.setUser(username);
                return user;
            } else {
                user.setUser("");
                return user;
            }
        }


        /*
         * When user updates their password first hash the password and then
         * update database with hashed pw.
         */
        public void newPassword(string userID, string newPw) {
            HashPassword hash = new HashPassword();
            string md5Hash = hash.getHash(newPw);


            SqlConnection con = DBCon.DBConnect();
            con.Open();

            SqlCommand command = new SqlCommand(null, con);

            command.CommandText = "UPDATE [dbo].[Users] SET [Password] = @pw, [Confirmed] = '1' WHERE StaffID = @id";
            command.Parameters.AddWithValue("@pw", md5Hash);
            command.Parameters.AddWithValue("@id", userID);
            command.ExecuteNonQuery();

            con.Close();
        }

    }
}
