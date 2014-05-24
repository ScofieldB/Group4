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
            SqlConnection con = new SqlConnection(@"Server=CHRIS-LAPTOP;Integrated Security=true;Database=INB201;");
            return con;
        }
    }
}
