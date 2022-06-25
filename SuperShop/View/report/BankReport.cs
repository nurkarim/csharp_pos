using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.report
{
    public partial class BankReport : Form
    {
        public BankReport()
        {
            InitializeComponent();
            bank();
        }
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
        public void bank()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,bank_name FROM add_bank";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "bank_name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void BankReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked==true)
            {
               CrystalReport.Bank.Bank obj = new CrystalReport.Bank.Bank();
            obj.Type = "week";
            obj.dateA = dateTimePicker1.Text;
            obj.dateB = dateTimePicker2.Text;
            obj.Show();
            }
            else if (radioButton2.Checked == true)
            {
                CrystalReport.Bank.Bank obj = new CrystalReport.Bank.Bank();
                obj.Type = "month";
                obj.dateA = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8);
              
                obj.Show();
            }
            else if (radioButton4.Checked == true)
            {
                CrystalReport.Bank.Bank obj = new CrystalReport.Bank.Bank();
                obj.Type = "bank";
                obj.dateA = comboBox1.SelectedValue.ToString();

                obj.Show();
            }
         
            
        }
    }
}
