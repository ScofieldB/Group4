using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital
{
    public partial class TestResultAdd : Form
    {
        public TestResultAdd()
        {
            InitializeComponent();
        }

        private void Loadbtn_Click(object sender, EventArgs e) {
            LoadNewFile();
        }

        private void LoadNewFile() {
            OpenFileDialog ofd = new OpenFileDialog();
            System.Windows.Forms.DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                userSelectedFilePath = ofd.FileName;
            }

        }

        public string userSelectedFilePath
        {
            get
            {
                return FilePathtb.Text;
            }
            set
            {
                FilePathtb.Text = value;
            }
        }

        private void Uploadbtn_Click(object sender, EventArgs e) {

        }

        private void Cancelbtn_Click(object sender, EventArgs e) {
            ActiveForm.Close();
        }

    }
}
