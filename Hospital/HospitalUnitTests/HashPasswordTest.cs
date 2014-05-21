using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HospitalUnitTests {
    [TestClass]
    public class HashPasswordTest {   

        // Tests a valid hashed password result
        [TestMethod]
        public void TestGetHashValid() {
            string result = "";
            Hospital.HashPassword hash = new Hospital.HashPassword();
            result = hash.getHash("123abc");
            Assert.AreEqual("?D?Wi?sa?????m(", result, true);

            result = hash.getHash("test123");
            Assert.AreEqual("??G??????vh????", result, true);
        }

        // Tests a invalid hashed password result.
        [TestMethod]
        public void TestGetHashInvalid() {
            string result = "";
            Hospital.HashPassword hash = new Hospital.HashPassword();
            result = hash.getHash("abc123");
            Assert.AreNotEqual("?D?Wi?sa?????m(", result, true);
        }
    }
}
