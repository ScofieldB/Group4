using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace HospitalUnitTests {
    [TestClass]
    public class FacilitiesTests {
        Hospital.Facilities facilities = new Hospital.Facilities();


        //Ensure Patient 100025 is currently not addmitted before running this test.
        [TestMethod]
        public void TestAdmitPatientFirstTime() {
            bool result = facilities.admitPatient(100025);
            Assert.IsTrue(result);
            facilities.DischargePatient(100025);
        }

        [TestMethod]
        public void TestAdmitPatientWrongId() {
            bool result = facilities.admitPatient(25);
            Assert.IsFalse(result, "False if patient either does not exist in system or is all ready admitted");;
        }


        [TestMethod]
        public void TestDischargePatient() {
            string room = "";
            int patId = 100025;
            bool result = facilities.admitPatient(patId);
            facilities.DischargePatient(patId);

            SqlConnection con = Hospital.DBCon.DBConnect();

            con.Open();
            SqlCommand command = new SqlCommand(null, con);
            command.CommandText = "SELECT Room FROM Patient WHERE PatientID = @id";
            command.Parameters.AddWithValue("@id", patId);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                room = reader.GetString(0);
            }
            reader.Close();
            con.Close();

            Assert.AreEqual("0", room, true);
        }

        [TestMethod]
        public void TestDischargePatientInvalidId() {
            string room = "";
            int patId = 25;
            facilities.DischargePatient(patId);

            SqlConnection con = Hospital.DBCon.DBConnect();

            con.Open();
            SqlCommand command = new SqlCommand(null, con);
            command.CommandText = "SELECT Room FROM Patient WHERE PatientID = @id";
            command.Parameters.AddWithValue("@id", patId);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                room = reader.GetString(0);
            }
            reader.Close();
            con.Close();

            Assert.AreEqual("", room, true);
        }


        [TestMethod]
        public void TestDischargePatientNotAdmitted() {
            string room = "";
            int patId = 100025;
            facilities.DischargePatient(patId);

            SqlConnection con = Hospital.DBCon.DBConnect();

            con.Open();
            SqlCommand command = new SqlCommand(null, con);
            command.CommandText = "SELECT Room FROM Patient WHERE PatientID = @id";
            command.Parameters.AddWithValue("@id", patId);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                room = reader.GetString(0);
            }
            reader.Close();
            con.Close();

            Assert.AreEqual("0", room, true);
        }



        //Test BookSurgery


        //Ensure Patient 100015 is currently addmitted and in room E100 before running this test.
        [TestMethod]
        public void TestBookSurgeryValid() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100015);
            facilities.admitPatient(pat.getPatient());
            pat.setRoom("E100");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.bookSurgery(pat, typeBooked);

            Assert.IsTrue(result);
            pat = Hospital.Patient.SearchPID(pat.getPatient());
            facilities.returnPatientToDoctor(pat);
            facilities.DischargePatient(pat.getPatient());
        }

        [TestMethod]
        public void TestBookSurgeryInvalidRoomSurgery() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100015);
            facilities.admitPatient(pat.getPatient()); 
            pat.setRoom("S100");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.bookSurgery(pat, typeBooked);

            Assert.IsFalse(result);
            facilities.DischargePatient(pat.getPatient());
        }

        [TestMethod]
        public void TestBookSurgeryInvalidRoomImaging() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100015);
            facilities.admitPatient(pat.getPatient());
            pat.setRoom("I100");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.bookSurgery(pat, typeBooked);

            Assert.IsFalse(result);
            facilities.DischargePatient(pat.getPatient());
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
            facilities.DischargePatient(pat.getPatient());
        }


        // Test bookImaging

        //Ensure Patient 100013 is currently addmitted and in room E100 before running this test.
        [TestMethod]
        public void TestBookImagingValid() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100013);
            facilities.admitPatient(pat.getPatient());

            pat.setRoom("E100");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.bookImaging(pat, typeBooked);

            Assert.IsTrue(result);
            pat = Hospital.Patient.SearchPID(pat.getPatient());
            facilities.returnPatientToDoctor(pat);
            facilities.DischargePatient(pat.getPatient());
        }

        [TestMethod]
        public void TestBookImagingInvalidRoomSurgery() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100013);
            facilities.admitPatient(pat.getPatient());
            
            pat.setRoom("S100");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.bookImaging(pat, typeBooked);

            Assert.IsFalse(result);
            facilities.DischargePatient(pat.getPatient());
        }

        [TestMethod]
        public void TestBookImagingInvalidRoomImaging() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100013);
            facilities.admitPatient(pat.getPatient()); 
            
            pat.setRoom("I100");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.bookImaging(pat, typeBooked);

            Assert.IsFalse(result);
            facilities.DischargePatient(pat.getPatient());
        }

        [TestMethod]
        public void TestBookImagingNotAdmitted() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.setPatient(100013);
            pat.setRoom("0");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.bookImaging(pat, typeBooked);

            Assert.IsFalse(result);
            facilities.DischargePatient(pat.getPatient());
        }

        


    }
}
