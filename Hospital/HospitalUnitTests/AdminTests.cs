using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HospitalUnitTests {
    [TestClass]
    public class AdminTests {


        /* 
         * Tests that when a user is added to system via their UserID, returns correct surname.
         * 
         * Returns correct surname if UserId exists in staff table but does not exist in users table,
         * otherwise .........
         */
        //Ensure UserId 1008 is not in the Users Table but does exist in the Staff table before running this test.
        [TestMethod]
        public void TestAddUser() {
            Hospital.Admin admin = new Hospital.Admin();
            string surname = admin.addUser("1008", "Doctor");
            Assert.AreEqual("Burney", surname);
            
            surname = admin.addUser("1008", "Doctor");
            Assert.AreEqual("Bur", surname);
            //hmmn throws error.. not cool
            
        }
    }
}
