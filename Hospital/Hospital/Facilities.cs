using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Class responsible for all business logic in relation to the 
 * management of facilites.
 */
namespace Hospital {
    public class Facilities {

        private SqlConnection con = DBCon.DBConnect();

        /*
         * Update database with patient allocated to Emergency and update
         * the room bed allocations.
         * \param int patID - PatientID to be admitted in system
         * \return bool - value if admitting patient was successful. 
         */
        public bool AdmitPatient(int patID) {
            bool admitted = false;
            bool canAdmit = false;
            string room = "";
            string patRoom = "";
            int capacity = 0;

            con.Open();

            //Check if available bed within emergency room
            SqlCommand command = new SqlCommand("Select Room, Capacity from Facilities WHERE RoomType = 'Emergency' AND Capacity > 0;", con);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                canAdmit = true;
                room = reader.GetString(0);
                capacity = reader.GetInt32(1);
            }

            reader.Close();

            //If available bed within emergency ward continue to admit
            if (canAdmit == true) {
                command.CommandText = "SELECT Room FROM Patient WHERE PatientID = @id";
                command.Parameters.AddWithValue("@id", patID);
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    patRoom = reader.GetString(0);
                }
                reader.Close();

                //Ensure patient is currently not admitted within hospital all ready
                if (patRoom.StartsWith("Discharged")) {
                    admitted = true;
                    command.Parameters.Clear();
                    command.CommandText = "UPDATE Patient SET Room = @room WHERE PatientID = @id";
                    command.Parameters.AddWithValue("@room", room);
                    command.Parameters.AddWithValue("@id", patID);
                    command.ExecuteNonQuery();

                    command.Parameters.Clear();
                    command.CommandText = "UPDATE Facilities SET Capacity = @cap WHERE Room = @room";
                    command.Parameters.AddWithValue("@cap", capacity - 1);
                    command.Parameters.AddWithValue("@room", room);
                    command.ExecuteNonQuery();
                } else {
                    admitted = false;
                }
            }
            con.Close();
            return admitted;
        }

        /*
         * Update database that patient is now moved to Surgery room and update
         * room bed allocations.
         * \param PatientInfo pat - patient that is being booked for surgery
         * \param FinanceCmbItem typeBooked - contains details for type of surgery being booked
         * \return bool - value if booking of surgery was successful. 
         */
        public bool BookSurgery(PatientInfo pat, FinanceCmbItem typeBooked) {
            bool success = false;

            string newRoom = "";
            int newRoomCapacity = 0;

            // Ensure patient currently is in emergency room
            if (pat.GetRoom().StartsWith("E")) {
                con.Open();

                //Find any available Surgery rooms
                SqlCommand command = new SqlCommand("SELECT Room, Capacity FROM Facilities WHERE RoomType = 'Surgery' AND Capacity > 0;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    success = true;
                    newRoom = reader.GetString(0);
                    newRoomCapacity = reader.GetInt32(1);
                }
                reader.Close();

                con.Close();

                if (success == true) {
                    UpdateFacilities(pat, newRoomCapacity, newRoom);
                    CheckCover(pat, typeBooked);
                }
            }
            return success;
        }

        /*
         * Update database that patient is now moved to Imaging room and update
         * room bed allocations.
         * \param PatientInfo pat - patient that is being booked for Imaging
         * \param FinanceCmbItem typeBooked - contains details for type of Imaging being booked
         * \param string UserID - UserID of current user logged in.
         * \return bool - value if booking of imaging was successful. 
         */
        public bool BookImaging(PatientInfo pat, FinanceCmbItem typeBooked, string userID) {
            bool success = false;
            int cost = typeBooked.Cost;

            string newRoom = "";
            int newRoomCapacity = 0;
            if (pat.GetRoom().StartsWith("E")) {
                con.Open();

                SqlCommand command = new SqlCommand("Select Room, Capacity from Facilities WHERE RoomType = 'Imaging' AND Capacity > 0;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    success = true;
                    newRoom = reader.GetString(0);
                    newRoomCapacity = reader.GetInt32(1);
                }

                reader.Close();
                con.Close();
                if (success == true) {
                    UpdateFacilities(pat, newRoomCapacity, newRoom);
                    AddImagingRequest(pat, typeBooked, userID);
                    CheckCover(pat, typeBooked);
                }
            }
            return success;
        }

        /*
         * Inserts values into the NOT NULL columns of the Tests table
         * thus allowing the MedTec to add files.
         * \param PatientInfo pat - patient that is being booked for Imaging
         * \param FinanceCmbItem typeBooked - contains details for type of Imaging being booked
         * \param string UserID - UserID of current user logged in.
         */
        public void AddImagingRequest(PatientInfo pat, FinanceCmbItem typeBooked, string userID) {
            DateTime CurrentDT = DateTime.Now;
            SqlCommand cmd = new SqlCommand("INSERT INTO Tests (PatientID, TestOrdered, OrderedByStaffID, DateOrdered) VALUES (@patient, @test , @user, @date)", con);
            int patient = pat.GetPatientId();
            cmd.Parameters.AddWithValue("@patient", patient);
            cmd.Parameters.AddWithValue("@test", typeBooked.Type);
            cmd.Parameters.AddWithValue("@user", userID);
            cmd.Parameters.AddWithValue("@date", CurrentDT);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        /*
         * Update database when sending patient back to doctor and update
         * room bed allocations.
         * \param PatientInfo pat - contains details of patient to send back to doctor
         */
        public void ReturnPatientToDoctor(PatientInfo pat) {
            bool success = false;
            string newRoom = "";
            int newRoomCapacity = 0;

            if (pat.GetRoom().StartsWith("S") || pat.GetRoom().StartsWith("I")) {
                con.Open();

                SqlCommand command = new SqlCommand("Select Room, Capacity from Facilities WHERE RoomType = 'Emergency' AND Capacity > 0;", con);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    success = true;
                    newRoom = reader.GetString(0);
                    newRoomCapacity = reader.GetInt32(1);
                }

                reader.Close();
                con.Close();

                if (success == true) {
                    UpdateFacilities(pat, newRoomCapacity, newRoom);
                }
            }
        }

        /*
         * Update patient to new room and change room bed allocations within database.
         * \param PatientInfo pat - patient that is changing rooms
         * \param int newRoomCapacity - current capacity of the new room patient moving too
         * \param string newRoom - the new room patient is being moved too
         */
        private void UpdateFacilities(PatientInfo pat, int newRoomCapacity, string newRoom) {
            int currentRoomCapacity = 0;
            SqlCommand command = new SqlCommand("", con);

            con.Open();

            //Find capacity of room patient currently is.
            command.CommandText = "SELECT Capacity FROM Facilities WHERE Room = @room;";
            command.Parameters.AddWithValue("@room", pat.GetRoom());
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                currentRoomCapacity = reader.GetInt32(0);
            }
            reader.Close();

            //Move patient to new bed facility and remove 1 bedding space
            command.Parameters.Clear();
            command.CommandText = "UPDATE Facilities SET Capacity = @cap WHERE Room = @room";
            command.Parameters.AddWithValue("@cap", newRoomCapacity - 1);
            command.Parameters.AddWithValue("@room", newRoom);
            command.ExecuteNonQuery();

            //Update room moved from to have an available bed slot free.
            command.Parameters.Clear();
            command.CommandText = "UPDATE Facilities SET Capacity = @cap WHERE Room = @room";
            command.Parameters.AddWithValue("@cap", currentRoomCapacity + 1);
            command.Parameters.AddWithValue("@room", pat.GetRoom());
            command.ExecuteNonQuery();

            //Update Patient room to new room
            command.Parameters.Clear();
            command.CommandText = "UPDATE Patient SET Room = @room WHERE PatientID = @id";
            command.Parameters.AddWithValue("@room", newRoom);
            command.Parameters.AddWithValue("@id", pat.GetPatientId());
            command.ExecuteNonQuery();

            con.Close();
        }

        /*
         * Discharges patient from the Emergency room.
         * \param int patID - patientID of the patient being discharged
         * \return int - current outstanding charges of patient
         */
        public int DischargePatient(int patId) {
            int capacity = 0;
            int totalCharges = 0;

            PatientInfo pat = Patient.SearchPID(patId);

            if (pat.GetRoom().StartsWith("E")) {

                con.Open();

                SqlCommand command = new SqlCommand(null, con);

                command.Parameters.Clear();
                command.CommandText = "UPDATE Patient SET Room = 'Discharged' WHERE PatientID = @id";
                command.Parameters.AddWithValue("@id", pat.GetPatientId());
                command.ExecuteNonQuery();

                command.Parameters.Clear();

                command.CommandText = "SELECT Capacity FROM Facilities WHERE RoomType = 'Emergency'";
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read()) {
                    capacity = reader.GetInt32(0);
                }
                reader.Close();

                command.Parameters.Clear();
                command.CommandText = "UPDATE Facilities SET Capacity = @cap WHERE RoomType = 'Emergency'";
                command.Parameters.AddWithValue("@cap", capacity + 1);
                command.ExecuteNonQuery();

                command.Parameters.Clear();
                command.CommandText = "SELECT TotalCharges FROM Patient WHERE PatientID = @patID";
                command.Parameters.AddWithValue("@patID", pat.GetPatientId());
                reader = command.ExecuteReader();

                while (reader.Read()) {
                    totalCharges = reader.GetInt32(0);
                }

                reader.Close();

                //Clear the charges from the Patient file.
                command.Parameters.Clear();
                command.CommandText = "UPDATE Patient SET TotalCharges = 0 WHERE PatientID = @patID";
                command.Parameters.AddWithValue("@patID", pat.GetPatientId());
                command.ExecuteNonQuery();

                con.Close();
            }
            return totalCharges;
        }

        /*
         * Checks the patients health cover details and update the outstanding
         * charges of patient as appropriate. Also updates the count of
         * surgery/Imaging undertaken.
         * \param PatientInfo pat - patient that is being booked
         * \param FinanceCmbItem typeBooked - contains details for type of item being booked
         */
        private void CheckCover(PatientInfo pat, FinanceCmbItem typeBooked) {
            SqlCommand command = new SqlCommand("", con);
            
            //If user has no Private cover then charge the patient
            if (pat.GetCoverType() == 0) {
                con.Open();
                command.CommandText = "UPDATE Patient SET TotalCharges = TotalCharges + @cost WHERE PatientID = @patID";
                command.Parameters.AddWithValue("@cost", typeBooked.Cost);
                command.Parameters.AddWithValue("@patID", pat.GetPatientId());
                command.ExecuteNonQuery();
                con.Close();
                UpdateChargeHistory(pat, typeBooked.Type, typeBooked.Cost);                
            }
            con.Open();
            command.Parameters.Clear();
            command.CommandText = "UPDATE Finance SET Counter = Counter + 1 WHERE Type = @type";
            command.Parameters.AddWithValue("@type", typeBooked.Type);
            command.ExecuteNonQuery();

            con.Close();
        }

        /*
         * Updates chargeHistory table to keep a record of patient billable history while admitted.
         * \param PatientInfo pat - the patient being charged
         * \param string chargeType - the type of charge patient acquiring
         * \param int chargeAmount - the dollar value of the new charge
         * \return bool - return true if successful
         */
        public bool UpdateChargeHistory(PatientInfo pat, string chargeType, int chargeAmount) {
            bool success = false;
            SqlCommand command = new SqlCommand("", con);
            con.Open();

            try {
                command.CommandText = "INSERT INTO ChargeHistory (PatientID, TypeCharged, Amount, DateCharged) VALUES (@patID, @type, @charge, GetDate())";
                command.Parameters.AddWithValue("@patID", pat.GetPatientId());
                command.Parameters.AddWithValue("@type", chargeType);
                command.Parameters.AddWithValue("@charge", chargeAmount);
                command.ExecuteNonQuery();
                success = true;
            } catch {
                MessageBox.Show("hmmmn");
            };
            con.Close();
            return success;
        }
    }
}
