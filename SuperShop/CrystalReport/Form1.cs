using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using System.Data;
using MySql.Data.MySqlClient;
namespace SuperShop.CrystalReport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection conn;
                MySqlCommand cmd;
                MySqlDataAdapter adap;

                conn = new MySqlConnection("Server=localhost; Database=inventory_management; " +
                    "User ID=root; Password=; charset=utf8;"); conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT income.`date`, income.amount, income_type.name FROM income, income_type WHERE income.income_sourch = income_type.id";

                adap = new MySqlDataAdapter();
                adap.SelectCommand = cmd;
                DataSet1 custDB = new DataSet1();
                custDB.Clear();
                adap.Fill(custDB, "incomeDataTable");



                CrystalReport1 myReport = new CrystalReport1();
                myReport.SetDataSource(custDB);
                crystalReportViewer1.ReportSource = myReport; 
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Report could not be created",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
