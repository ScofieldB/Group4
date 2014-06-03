using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital {
    public class DBCon {

        /*
         * Connection and connection string used to connect to database.
         * Returns the connection for use throughout program.
         */
        public static SqlConnection DBConnect() {
<<<<<<< HEAD
            SqlConnection con = new SqlConnection(@"Server=CHRIS-LAPTOP;Integrated Security=true;Database=INB201;");
=======
            SqlConnection con = new SqlConnection(@"Server=Ultrabook;Integrated Security=true;Database=INB201;");
>>>>>>> fdec2ed1a2929ce518ba55187673708e4a1f6f3d
            return con;
        }
    }
}
