using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Object that contains all relevent personal information about a Patient.
 */
namespace Hospital {
    public class PatientInfo {

        private int patientId = -1, covertype, covernumber, charges;

        private string firstname, surname, address, allergies, nextofkin, gender, room, phone, mobile, kinphone;

        private DateTime dob;

        public int GetPatientId() {
            return patientId;
        }

        public void SetPatientId(int PID) {
            patientId = PID;
        }

        public string GetPhone() {
            return phone;
        }

        public void SetPhone(string PH) {
            phone = PH;
        }

        public string GetMobile() {
            return mobile;
        }

        public void SetMobile(string MB) {
            mobile = MB;
        }

        public int GetCoverType() {
            return covertype;
        }


        public void SetCoverType(int CT) {
            covertype = CT;
        }

        public int GetCoverNum() {
            return covernumber;
        }

        public void SetCoverNum(int CN) {
            covernumber = CN;
        }

        public string GetNextKinPhone() {
            return kinphone;
        }

        public void SetNextKinPhone(string KinPh) {
            kinphone = KinPh;
        }

        public int GetCharges() {
            return charges;
        }

        public void SetCharges(int newCharge) {
            charges = newCharge;
        }

        public string GetFName() {
            return firstname;
        }

        public void SetFName(string FName) {
            firstname = FName;
        }

        public string GetSName() {
            return surname;
        }

        public void SetSName(string SName) {
            surname = SName;
        }

        public string GetAddress() {
            return address;
        }

        public void SetAddress(string Add) {
            address = Add;
        }

        public string GetAllergies() {
            return allergies;
        }

        public void SetAllergies(string All) {
            allergies = All;
        }

        public string GetNextKin() {
            return nextofkin;
        }

        public void SetNextKin(string NK) {
            nextofkin = NK;
        }

        public string GetGender() {
            return gender;
        }

        public void SetGender(string Gen) {
            gender = Gen;
        }

        public string GetRoom() {
            return room;
        }

        public void SetRoom(string rm) {
            room = rm;
        }

        public DateTime GetDOB() {
            return dob;
        }

        public void SetDOB(DateTime DOB) {
            dob = DOB;
        }
    }
}
