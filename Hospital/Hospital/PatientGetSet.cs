using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital {
    class PatientGetSet {

        private int patient, phone, mobile, covertype, covernumber, kinphone;

        private string firstname, surname, address, allergies, nextofkin, gender;

        private bool status;

        private DateTime dob;

        public int getPatient() {
            return patient;
        }
        public void setPatient(int PID) {
            patient = PID;
        }
        public int getPhone() {
            return phone;
        }
        public void setPhone(int PH) {
            phone = PH;
        }
        public int getMobile() {
            return mobile;
        }
        public void setMobile(int MB) {
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
        public int getKP() {
            return kinphone;
        }
        public void setKP(int KP) {
            kinphone = KP;
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
