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
    public partial class supplierReport : Form
    {
        public supplierReport()
        {
            InitializeComponent();
            supplyerName();
        }
        DB.config _config = new DB.config();
        MySqlConnection cn;
        public void supplyerName()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                cn = _config.connection();
                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT id,name FROM supplyer_table";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmdCustomerId.DataSource = ds.Tables[0];
                cmdCustomerId.ValueMember = "id";
                cmdCustomerId.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void supplierReport_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                CrystalReport.Supplier.Report obj = new CrystalReport.Supplier.Report();
                obj.Type = "all";
                obj.Show();
            }
            else if (radioButton2.Checked == true)
            {
                CrystalReport.Supplier.Report obj = new CrystalReport.Supplier.Report();
                obj.Type = "ladger";
                obj.Show();
            }
            else if (radioButton3.Checked == true)
            {
                CrystalReport.Supplier.Report obj = new CrystalReport.Supplier.Report();
                obj.Type = "due";
                obj.Show();
            }
            else if (radioButton4.Checked == true)
            {
                CrystalReport.Supplier.Report obj = new CrystalReport.Supplier.Report();
                obj.Type = "his";
                obj.Show();
            }
            else if (radioButton6.Checked == true)
            {
                CrystalReport.Supplier.Report obj = new CrystalReport.Supplier.Report();
                obj.Type = "hisM";
                obj.dateA = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8);
                obj.Show();
            }
            else if (radioButton5.Checked == true)
            {
                CrystalReport.Supplier.Report obj = new CrystalReport.Supplier.Report();
                obj.Type = "supM";
                obj.dateA = cmdCustomerId.SelectedValue.ToString();
                obj.Show();
            }
        }
    }
}
