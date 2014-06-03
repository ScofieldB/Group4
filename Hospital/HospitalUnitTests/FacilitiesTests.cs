using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace HospitalUnitTests {
    [TestClass]
    public class FacilitiesTests {
        Hospital.Facilities facilities = new Hospital.Facilities();
        private string UserID = "1006";


        //Ensure Patient 100025 is currently not addmitted before running this test.
        [TestMethod]
        public void TestAdmitPatientValid() {
            bool result = facilities.AdmitPatient(100025);
            Assert.IsTrue(result);
            facilities.DischargePatient(100025);
        }

        [TestMethod]
        public void TestAdmitPatientWrongId() {
            bool result = facilities.AdmitPatient(25);
            Assert.IsFalse(result, "False if patient either does not exist in system or is all ready admitted"); ;
        }


        [TestMethod]
        public void TestDischargePatient() {
            string room = "";
            int patId = 100025;
            bool result = facilities.AdmitPatient(patId);
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

            Assert.AreEqual("Discharged", room, true);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TestDischargePatientInvalidId() {
            int patId = 25;
            facilities.DischargePatient(patId);
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

            Assert.AreEqual("Discharged", room, true);
        }



        //Test BookSurgery

        [TestMethod]
        public void TestBookSurgeryValid() {
            Hospital.PatientInfo pat = new Hospital.PatientInfo();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.SetPatientId(100015);
            facilities.AdmitPatient(pat.GetPatientId());
            pat.SetRoom("E100");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.BookSurgery(pat, typeBooked);

            Assert.IsTrue(result);
            pat = Hospital.Patient.SearchPID(pat.GetPatientId());
            facilities.ReturnPatientToDoctor(pat);
            facilities.DischargePatient(pat.GetPatientId());
        }

        [TestMethod]
        public void TestBookSurgeryInvalidRoomSurgery() {
            Hospital.PatientInfo pat = new Hospital.PatientInfo();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.SetPatientId(100015);
            facilities.AdmitPatient(pat.GetPatientId());
            pat.SetRoom("S100");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.BookSurgery(pat, typeBooked);

            Assert.IsFalse(result);
            facilities.DischargePatient(pat.GetPatientId());
        }

        [TestMethod]
        public void TestBookSurgeryInvalidRoomImaging() {
            Hospital.PatientInfo pat = new Hospital.PatientInfo();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.SetPatientId(100015);
            facilities.AdmitPatient(pat.GetPatientId());
            pat.SetRoom("I100");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.BookSurgery(pat, typeBooked);

            Assert.IsFalse(result);
            facilities.DischargePatient(pat.GetPatientId());
        }

        [TestMethod]
        public void TestBookSurgeryNotAdmitted() {
            Hospital.PatientInfo pat = new Hospital.PatientInfo();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.SetPatientId(100015);
            pat.SetRoom("0");
            typeBooked.Cost = 700;
            typeBooked.Type = "Keyhole Surgery";

            result = facilities.BookSurgery(pat, typeBooked);

            Assert.IsFalse(result);
            facilities.DischargePatient(pat.GetPatientId());
        }


        // Test bookImaging

        [TestMethod]
        public void TestBookImagingValid() {
            Hospital.PatientInfo pat = new Hospital.PatientInfo();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.SetPatientId(100013);
            facilities.AdmitPatient(pat.GetPatientId());

            pat.SetRoom("E100");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.BookImaging(pat, typeBooked, UserID);

            Assert.IsTrue(result);
            pat = Hospital.Patient.SearchPID(pat.GetPatientId());
            facilities.ReturnPatientToDoctor(pat);
            facilities.DischargePatient(pat.GetPatientId());
        }

        [TestMethod]
        public void TestBookImagingInvalidRoomSurgery() {
            Hospital.PatientInfo pat = new Hospital.PatientInfo();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.SetPatientId(100013);
            facilities.AdmitPatient(pat.GetPatientId());

            pat.SetRoom("S100");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.BookImaging(pat, typeBooked, UserID);

            Assert.IsFalse(result);
            facilities.DischargePatient(pat.GetPatientId());
        }

        [TestMethod]
        public void TestBookImagingInvalidRoomImaging() {
            Hospital.PatientInfo pat = new Hospital.PatientInfo();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.SetPatientId(100013);
            facilities.AdmitPatient(pat.GetPatientId());

            pat.SetRoom("I100");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.BookImaging(pat, typeBooked, UserID);

            Assert.IsFalse(result);
            facilities.DischargePatient(pat.GetPatientId());
        }

        [TestMethod]
        public void TestBookImagingNotAdmitted() {
            Hospital.PatientInfo pat = new Hospital.PatientInfo();
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();
            bool result;

            pat.SetPatientId(100013);
            pat.SetRoom("0");
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";

            result = facilities.BookImaging(pat, typeBooked, UserID);

            Assert.IsFalse(result);
            facilities.DischargePatient(pat.GetPatientId());
        }

        [TestMethod]
        public void TestReturnPatientToDoctor() {
            bool success = false;
            string room = "";
            Hospital.PatientInfo pat = Hospital.Patient.SearchPID(100007);
            Hospital.FinanceCmbItem typeBooked = new Hospital.FinanceCmbItem();


            facilities.AdmitPatient(pat.GetPatientId());
            typeBooked.Cost = 200;
            typeBooked.Type = "Xray";
            facilities.BookSurgery(pat, typeBooked);

            SqlConnection con = Hospital.DBCon.DBConnect();
            con.Open();
            SqlCommand command = new SqlCommand(null, con);
            command.CommandText = "SELECT Room FROM Patient WHERE PatientID = @id";
            command.Parameters.AddWithValue("@id", pat.GetPatientId());

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                room = reader.GetString(0);
            }
            reader.Close();

            if (room.StartsWith("S")) {
                success = false;
            }

            facilities.ReturnPatientToDoctor(pat);

            command.Parameters.Clear();
            command.CommandText = "SELECT Room FROM Patient WHERE PatientID = @id";
            command.Parameters.AddWithValue("@id", pat.GetPatientId());

            reader = command.ExecuteReader();
            while (reader.Read()) {
                room = reader.GetString(0);
            }

            reader.Close();
            con.Close();

            //If room room is Emergency
            if (room.StartsWith("E")) {
                success = true;
            }

            facilities.DischargePatient(pat.GetPatientId());

            Assert.IsTrue(success);

        }
    }
}
