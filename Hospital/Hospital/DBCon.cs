﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Hospital {
    class DBCon {

        public static SqlConnection DBConnect() {
            SqlConnection con = new SqlConnection(@"Server=8isshit;Integrated Security=true;Database=INB201;");
            return con;
        }
    }
}
