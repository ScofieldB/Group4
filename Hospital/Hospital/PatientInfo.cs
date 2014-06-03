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

        public int getPatientId() {
            return patientId;
        }

        public void setPatientId(int PID) {
            patientId = PID;
        }

        public string getPhone() {
            return phone;
        }

        public void setPhone(string PH) {
            phone = PH;
        }

        public string getMobile() {
            return mobile;
        }

        public void setMobile(string MB) {
            mobile = MB;
        }

        public int getCoverType() {
            return covertype;
        }


        public void setCoverType(int CT) {
            covertype = CT;
        }

        public int getCoverNum() {
            return covernumber;
        }

        public void setCoverNum(int CN) {
            covernumber = CN;
        }

        public string getNextKinPhone() {
            return kinphone;
        }

        public void setNextKinPhone(string KinPh) {
            kinphone = KinPh;
        }

        public int getCharges() {
            return charges;
        }

        public void setCharges(int newCharge) {
            charges = newCharge;
        }

        public string getFName() {
            return firstname;
        }

        public void setFName(string FName) {
            firstname = FName;
        }

        public string getSName() {
            return surname;
        }

        public void setSName(string SName) {
            surname = SName;
        }

        public string getAddress() {
            return address;
        }

        public void setAddress(string Add) {
            address = Add;
        }

        public string getAllergies() {
            return allergies;
        }

        public void setAllergies(string All) {
            allergies = All;
        }

        public string getNextKin() {
            return nextofkin;
        }

        public void setNextKin(string NK) {
            nextofkin = NK;
        }

        public string getGender() {
            return gender;
        }

        public void setGender(string Gen) {
            gender = Gen;
        }

        public string getRoom() {
            return room;
        }

        public void setRoom(string rm) {
            room = rm;
        }

        public DateTime getDOB() {
            return dob;
        }

        public void setDOB(DateTime DOB) {
            dob = DOB;
        }
    }
}
