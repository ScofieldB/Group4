using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HospitalUnitTests {
    [TestClass]
    public class LoginTest {

        Hospital.Login login = new Hospital.Login();
        Hospital.User user = new Hospital.User();

        [TestMethod]
        public void TestGetDetailsValid() {
            user = login.getDetails("1000", "123abc");
 
            Assert.AreEqual("1000", user.getUser(), true);
        }


        [TestMethod]
        public void TestGetDetailsInvalidId() {
            user = login.getDetails("9", "123abc");

            Assert.AreEqual("", user.getUser(), true);
        }


        [TestMethod]
        public void TestGetDetailsInvalidPassword() {
            user = login.getDetails("1000", "123");

            Assert.AreEqual("", user.getUser(), true);
        }


        [TestMethod]
        public void TestGetDetailsInvalidBoth() {
            user = login.getDetails("9", "123");

            Assert.AreEqual("", user.getUser(), true);
        }
    }
}
