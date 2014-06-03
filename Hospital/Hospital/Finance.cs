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

namespace Hospital {
    public partial class Finance : Form {

        private SqlConnection con = DBCon.DBConnect();
        private HospitalSystem previousForm = null;

        public Finance(string type, HospitalSystem previous) {
            previousForm = previous;
            InitializeComponent();
            if (type == "Surgery") {
                Choices("SF%");
            } else if (type == "Imaging") {
                Choices("IF%");
            }
        }

        private void Confirmbtn_Click(object sender, EventArgs e) {
            FinanceCmbItem choice = (FinanceCmbItem)Choicescmb.SelectedItem;
            previousForm.SetBookedType(choice);
            Close();
        }

        private void Cancelbtn_Click(object sender, EventArgs e) {
            Close();
        }

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
