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
    public partial class saleReturnReport : Form
    {
        public saleReturnReport()
        {
            InitializeComponent();
            Voucher();
        }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        public void Voucher()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,return_voucher FROM sale_return";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "return_voucher";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void saleReturnReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked==true)
            {
                CrystalReport.saleReturn.Report obj = new CrystalReport.saleReturn.Report();
                obj.Type = "voucher";
                obj.dateA = comboBox1.SelectedValue.ToString();
                obj.Show();
            }
            else if (radioButton1.Checked == true)
            {
                CrystalReport.saleReturn.Report obj = new CrystalReport.saleReturn.Report();
                obj.Type = "daily";
                obj.dateA = dateTimePicker1.Text;
                obj.Show();
            }
            else if (radioButton2.Checked == true)
            {
                CrystalReport.saleReturn.Report obj = new CrystalReport.saleReturn.Report();
                obj.Type = "month";
                obj.dateA = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8);
                obj.Show();
            }
            else if (radioButton3.Checked == true)
            {
                CrystalReport.saleReturn.Report obj = new CrystalReport.saleReturn.Report();
                obj.Type = "week";
                obj.dateA = dateTimePicker1.Text;
                obj.dateB = dateTimePicker2.Text;
                obj.Show();
            }
        }
    }
}
