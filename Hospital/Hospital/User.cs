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

        public string GetUser() {
            return username;
        }

        public void SetUser(string user) {
            username = user;
        }

        public string GetRole() {
            return role;
        }

        public void SetRole(string role) {
            this.role = role;
        }

        public bool GetConfirmed() {
            return confirmed;
        }

        public void SetConfirmed(bool con) {
            confirmed = con;
        }
    }
}
