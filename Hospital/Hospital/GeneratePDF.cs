using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Hospital {
    class GeneratePDF {

        /*
         called by button on receptionist screen
         
         con database
          
         query based on search text box, may or may not need to run the query/function for populating the
         receptionist screen (to verify that they've searched, or have this call it)
         
         needs to out put to reader (some tabluar method or regular)
         
         output to pdf
         
         This would be extremely messy, barely ordered, huge documentation on how to order and stlye pdfs
         A few paid solutions, not much examples
         
         */

        private SqlConnection con = DBCon.DBConnect();

        public void genPDF() { 
        

        
        
        }
    }
}
