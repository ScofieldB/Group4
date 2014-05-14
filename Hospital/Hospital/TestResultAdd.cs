﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

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
            DateTime CurrentDT = DateTime.Now;
            try
            {
                //Set up connection to be opened.
                SqlConnection con = DBCon.DBConnect();
                SqlCommand cmd = new SqlCommand("INSERT INTO [INB201].[dbo].[Tests] ([TestResults], [DateUploaded]) VALUES (@[TestResults], CurrentDT)", con);
                String ImageFilePath = @" + FilePathtb.Text + ";

                //Read jpg into file stream, and from there into Byte array.
                FileStream ImageFileStream = new FileStream(ImageFilePath, FileMode.Open, FileAccess.Read);
                Byte[] bytTestResultsImage = new Byte[ImageFileStream.Length];
                ImageFileStream.Read(bytTestResultsImage, 0, bytTestResultsImage.Length);
                ImageFileStream.Close();

                //Create parameter for insert command and add to SqlCommand object.
                SqlParameter prm = new SqlParameter("@[TestResults]", SqlDbType.VarBinary, bytTestResultsImage.Length, ParameterDirection.Input, false,
                            0, 0, null, DataRowVersion.Current, bytTestResultsImage);
                cmd.Parameters.Add(prm);

                //Open connection, execute query, close connection.
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }

        }

        private void Cancelbtn_Click(object sender, EventArgs e) {
            ActiveForm.Close();
        }

    }
}