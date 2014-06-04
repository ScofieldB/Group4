using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Class responsible for all business logic in relation to the 
 * management of the login system.
 */
namespace Hospital {
    public class Login {

        /*
         * Confirms user password matches that on database and if so
         * return the users role and whether user has user generated password.
         * \param string username - username entered by user to be confirmed
         * \param string password - password entered by user to be confirmed
         * \return User - If password does not match one stored on database return empty userID
         *                data contained within User returned otherwise return valid User.
         */
        public User GetDetails(string username, string password) {
            User user = new User();

            password = GetHash(password);
            string checkpw = "";
            SqlConnection con = DBCon.DBConnect();

            con.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE StaffID = @id", con);
            command.Parameters.AddWithValue("@id", username);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                checkpw = reader.GetString(1);
                user.SetRole(reader.GetString(2));
                user.SetConfirmed(reader.GetBoolean(3));
            }
            reader.Close();
            con.Close();

            if (checkpw == password) {
                user.SetUser(username);
                return user;
            } else {
                user.SetUser("");
                return user;
            }
        }

        /*
         * When user updates their password first hash the password and then
         * update database with hashed pw.
         * \param string userID - UserID to update password for.
         * \param string newPw - new Password user wishes to update system with.
         */
        public void NewPassword(string userID, string newPw) {
            string md5Hash = GetHash(newPw);

            SqlConnection con = DBCon.DBConnect();
            con.Open();

            SqlCommand command = new SqlCommand(null, con);

            command.CommandText = "UPDATE [dbo].[Users] SET [Password] = @pw, [Confirmed] = '1' WHERE StaffID = @id";
            command.Parameters.AddWithValue("@pw", md5Hash);
            command.Parameters.AddWithValue("@id", userID);
            command.ExecuteNonQuery();

            con.Close();
        }

        /* 
         * getHash is used to encrypt the string paramater into a md5 hashed string and return the 
         * new encrypted string.
         * \param string password - password wished to be hashed
         * \return string - hashed version of the password
         */
        public string GetHash(string password) {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
            data = x.ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }
    }
}
