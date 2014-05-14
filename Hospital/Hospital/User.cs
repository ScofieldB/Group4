using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital {

    /*
     * A object to represent a user, that stores username, role and if password has been confirmed.
     */
    public class User {

        private string username;
        private string role;
        private bool confirmed;

        public string getUser() {
            return username;
        }

        public void setUser(string user) {
            username = user;
        }

        public string getRole() {
            return role;
        }

        public void setRole(string role) {
            this.role = role;
        }

        public bool getConfirmed() {
            return confirmed;
        }

        public void setConfirmed(bool con) {
            confirmed = con;
        }
    }
}
