using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital {
    class HashPassword {

        /* 
         * getHash is used to encrypt the string paramater into a md5 hashed string and return the 
         * new encrypted string.
         */
        public string getHash(string username) {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(username);
            data = x.ComputeHash(data);
            return System.Text.Encoding.ASCII.GetString(data);
        }
    }
}
