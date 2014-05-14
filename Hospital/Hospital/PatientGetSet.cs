using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital {
    public class PatientGetSet {

        private int patient = -1, covertype, covernumber, charges;

        private string firstname, surname, address, allergies, nextofkin, gender, room, phone, mobile, kinphone;

        private bool status;

        private DateTime dob;

        public int getPatient() {
            return patient;
        }
        public void setPatient(int PID) {
            patient = PID;
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
        public int getCoverT() {
            return covertype;
        }
        public void setCoverT(int CT) {
            covertype = CT;
        }
        public int getCoverN() {
            return covernumber;
        }
        public void setCoverN(int CN) {
            covernumber = CN;
        }
        public string getKP() {
            return kinphone;
        }
        public void setKP(string KP) {
            kinphone = KP;
        }
        public int getCharges() {
            return charges;
        }
        public void setCharges(int newCharge) {
            charges = newCharge;
        }
        public string getFN() {
            return firstname;
        }
        public void setFN(string FN) {
            firstname = FN;
        }
        public string getSN() {
            return surname;
        }
        public void setSN(string SN) {
            surname = SN;
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

        public bool getStatus() {
            return status;
        }
        public void setStatus(bool stat) {
            status = stat;
        }
        public DateTime getDOB() {
            return dob;
        }
        public void setDOB(DateTime DOB) {
            dob = DOB;
        }
    }
}
