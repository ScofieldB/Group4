using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Form is responsible for selection of which Surgery/Imaging procedure
 * to be booked.
 */
namespace Hospital {
    public partial class Finance : Form {

        private SqlConnection con = DBCon.DBConnect();
        private HospitalSystem previousForm = null;


        /*
         * Constructor to initialize form
         * \param string type - type of procedure being booked Surgery or Imaging
         * \param HospitalSystem previous - provides backward navigation
         */
        public Finance(string type, HospitalSystem previous) {
            previousForm = previous;
            InitializeComponent();
            if (type == "Surgery") {
                Choices("SF%");
            } else if (type == "Imaging") {
                Choices("IF%");
            }
        }


        /*
         * Button to confirm selected procedure
         */
        private void Confirmbtn_Click(object sender, EventArgs e) {
            FinanceCmbItem choice = (FinanceCmbItem)Choicescmb.SelectedItem;
            previousForm.SetBookedType(choice);
            Close();
        }

        /*
         * Cancels the selection of a procedure and closes the form
         */
        private void Cancelbtn_Click(object sender, EventArgs e) {
            Close();
        }


        /*
         * Populates the combobox with appropriate procedures options
         */
        private void Choices(string ChoiceType) {
            con.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Finance WHERE FinanceID LIKE @choice;", con);
            command.Parameters.AddWithValue("@choice", ChoiceType);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) {
                FinanceCmbItem item = new FinanceCmbItem();
                item.Type = reader.GetString(1);
                item.Cost = reader.GetInt32(2);
                Choicescmb.Items.Add(item);
            }
        }
    }
}
