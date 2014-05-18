using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HospitalUnitTests {
    [TestClass]
    public class FacilitiesTests {
        Hospital.Facilities facilities = new Hospital.Facilities();


        //Ensure Patient 100025 is currently not addmitted before running this test.
        [TestMethod]
        public void TestAdmitPatientFirstTime() {
            bool result = facilities.admitPatient(100025);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestAdmitPatientRepeated() {
            bool result = facilities.admitPatient(100025);
            Assert.IsFalse(result, "False if patient either does not exist in system or is all ready admitted");

        }

        [TestMethod]
        public void TestAdmitPatientWrongId() {
            bool result = facilities.admitPatient(25);
            Assert.IsFalse(result, "False if patient either does not exist in system or is all ready admitted");
        }

        //Test BookSurgery


        //Ensure Patient 100015 is currently addmitted and in room E100 before running this test.
        [TestMethod]
        public void TestBookSurgeryValid() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100015);
            pat.setRoom("E100");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.bookSurgery(pat, typeBooked);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestBookSurgeryInvalidRoomSurgery() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100015);
            pat.setRoom("S100");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.bookSurgery(pat, typeBooked);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestBookSurgeryInvalidRoomImaging() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100015);
            pat.setRoom("I100");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.bookSurgery(pat, typeBooked);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestBookSurgeryNotAdmitted() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100015);
            pat.setRoom("0");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.bookSurgery(pat, typeBooked);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestBookSurgeryInvalidPatientID() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(15);
            pat.setRoom("E100");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.bookSurgery(pat, typeBooked);

            Assert.IsFalse(result);
        }

        // Test bookImaging

        //Ensure Patient 100013 is currently addmitted and in room E100 before running this test.
        [TestMethod]
        public void TestBookImagingValid() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100013);
            pat.setRoom("E100");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.bookImaging(pat, typeBooked);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestBookImagingInvalidRoomSurgery() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100013);
            pat.setRoom("S100");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.bookImaging(pat, typeBooked);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestBookImagingInvalidRoomImaging() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100013);
            pat.setRoom("I100");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.bookImaging(pat, typeBooked);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestBookImagingNotAdmitted() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100013);
            pat.setRoom("E100");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.bookImaging(pat, typeBooked);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestBookImagingInvalidPatientID() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(13);
            pat.setRoom("E100");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.bookImaging(pat, typeBooked);

            Assert.IsFalse(result);
        }

    }
}
