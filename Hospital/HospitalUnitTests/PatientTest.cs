using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace HospitalUnitTests {
    [TestClass]
    public class PatientTest {


        /*
         * Test SearchPID will return appropriate patient ID of 100009 entered and
         * correct firstname of Emily which is the appropriate entry stored in the database
         */
        [TestMethod]
        public void TestSearchPIDValid() {
            Hospital.PatientGetSet pat = Hospital.Patient.SearchPID(100009);

            Assert.AreEqual(100009, pat.getPatient());
            Assert.AreEqual("Emily", pat.getFN(), true);

        }


        /*
         * Test SearchPID will return appropriate patient ID of -1 if the patient is not found
         */
        [TestMethod]
        public void TestSearchPIDInvalid() {
            Hospital.PatientGetSet pat = Hospital.Patient.SearchPID(9);

            Assert.AreEqual(-1, pat.getPatient());
            Assert.IsNull(pat.getFN());
        }


        [TestMethod]
        public void TestsearchPatientSurnameOne() {
            Hospital.PatientGetSet[] pat = Hospital.Patient.searchPatientSurname("Segal");

            //Assert that first entry in array has a PatientID appropriate to first Segal in database 
            Assert.AreEqual(100018, pat[0].getPatient());

            //Check only one entry
            Assert.AreEqual(1, pat.Length);
        }

        [TestMethod]
        public void TestsearchPatientInvalidSurname() {
            Hospital.PatientGetSet[] pat = Hospital.Patient.searchPatientSurname("abc");

            //Check no entries are returned as no Surname of abc is in database
            Assert.AreEqual(0, pat.Length);
        }

        [TestMethod]
        public void TestsearchPatientSurnameMultiple() {
            Hospital.PatientGetSet[] pat = Hospital.Patient.searchPatientSurname("Oddo");

            //Assert that first entry in array has a PatientID appropriate to first Oddo in database 
            Assert.AreEqual(100022, pat[0].getPatient());

            //Check that three patients are return as there are three patients with Surname Oddo currently in database
            Assert.AreEqual(3, pat.Length);

            pat = Hospital.Patient.searchPatientSurname("John");

            //Check that six patients are return as there are six patients with Surname John currently in database
            Assert.AreEqual(6, pat.Length);

        }

        /*
         * Test if after admitting patient the room is set to E100 then test that once dischargePatient
         * is called the room will then be changed to 0.
         */
        [TestMethod]
        public void TestDischargePatient() {
            Hospital.PatientGetSet pat = new Hospital.PatientGetSet();
            Hospital.Facilities facilities = new Hospital.Facilities();
            string room = "";
            pat.setPatient(100025);

            Hospital.Patient.DischargePatient(pat);

            bool result = facilities.admitPatient(pat.getPatient());

            SqlConnection con = Hospital.DBCon.DBConnect();

            con.Open();
            SqlCommand command = new SqlCommand(null, con);
            command.CommandText = "SELECT Room FROM Patient WHERE PatientID = @id";
            command.Parameters.AddWithValue("@id", (pat.getPatient()));

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                room = reader.GetString(0);
            }
            reader.Close();

            Assert.AreEqual("E100", room, true);

            int charges = Hospital.Patient.DischargePatient(pat);

            command.Parameters.Clear();
            command.CommandText = "SELECT Room FROM Patient WHERE PatientID = @id";
            command.Parameters.AddWithValue("@id", (pat.getPatient()));

            reader = command.ExecuteReader();
            while (reader.Read()) {
                room = reader.GetString(0);
            }
            reader.Close();
            con.Close();

            Assert.AreEqual("0", room, true);

        }



        [TestMethod]
        public void TestUpdateAdmitChargeValid() {
            int charges = 0;

            Hospital.PatientGetSet pat = Hospital.Patient.SearchPID(100026);
            charges = Hospital.Patient.updateAdmitCharge(100026, 2);

            Assert.AreEqual(200, charges);

            SqlConnection con = Hospital.DBCon.DBConnect();

            con.Open();
            SqlCommand command = new SqlCommand(null, con);
            
            command.Parameters.Clear();
            command.CommandText = "UPDATE Patient SET TotalCharges = @charges WHERE PatientID = @id";
            command.Parameters.AddWithValue("@charges", pat.getCharges());
            command.Parameters.AddWithValue("@id", pat.getPatient());
            command.ExecuteNonQuery();


            con.Close();
        }



        // Test that UpdateAdmitCharge returns -1 if a invalid coverType is input
        [TestMethod]
        public void TestUpdateAdmitChargeInvalidCoverType() {

            int charge = Hospital.Patient.updateAdmitCharge(100026, 5);

            Assert.AreEqual(-1, charge);

        }


        // Test that UpdateAdmitCharge returns -1 if a invalid patientID is input
        [TestMethod]
        public void TestUpdateAdmitChargeInvalidPatientId() {

            int charge = Hospital.Patient.updateAdmitCharge(6, 1);
            Assert.AreEqual(-1, charge);
        }
    }
}
