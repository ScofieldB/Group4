using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace HospitalUnitTests {
    [TestClass]
    public class AdminTests {


        /* 
         * Tests that when a user is added to system via their UserID, returns correct surname 
         */
        [TestMethod]
        public void TestAddUser() {
            Hospital.Admin admin = new Hospital.Admin();
            string surname = admin.addUser("1008", "Doctor");
            Assert.AreEqual("Burney", surname);

            SqlConnection con = Hospital.DBCon.DBConnect();

            con.Open();
            SqlCommand command = new SqlCommand(null, con);
            command.CommandText = "SELECT Role FROM Users WHERE StaffID = @id";
            command.Parameters.AddWithValue("@id", 1008);

            SqlDataReader reader = command.ExecuteReader();
            string result = "";
            while (reader.Read()) {
                result = reader.GetString(0);
            }
            reader.Close();
            con.Close();
            Assert.AreEqual("Doctor", result, true);

        }


        /*
         * Tests add user with a invalid UserId. If user id does not exist
         * addUser will return empty string "".
         */
        [TestMethod]
        public void TestAddUserInvalidId() {
            string userid = "0";
            Hospital.Admin admin = new Hospital.Admin();
            string surname = admin.addUser(userid, "Doctor");
            Assert.AreEqual("", surname);
        }



        /*
         * Tests that when a user is deleted from system a SELECT statement returns correct result.
         */
        [TestMethod]
        public void TestDeleteUser() {
            string result = "";

            Hospital.Admin admin = new Hospital.Admin();

            SqlConnection con = Hospital.DBCon.DBConnect();

            con.Open();
            SqlCommand command = new SqlCommand(null, con);
            command.CommandText = "SELECT Role FROM Users WHERE StaffID = @id";
            command.Parameters.AddWithValue("@id", 1008);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                result = reader.GetString(0);
            }
            reader.Close();

            Assert.AreEqual("Doctor", result, true);

            result = "";
            admin.deleteUser("1008");

            command.Parameters.Clear();
            command.CommandText = "SELECT Role FROM Users WHERE StaffID = @id";
            command.Parameters.AddWithValue("@id", 1008);
            reader = command.ExecuteReader();

            while (reader.Read()) {
                result = reader.GetString(0);
            }
            reader.Close();

            Assert.AreEqual("", result, true);
        }


        [TestMethod]
        public void TestDeleteUserInvalidId() {

            Hospital.Admin admin = new Hospital.Admin();
            admin.deleteUser("1");


        }

    }
}
