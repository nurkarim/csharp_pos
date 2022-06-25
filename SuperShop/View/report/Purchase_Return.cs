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
    public partial class Purchase_Return : Form
    {
        public Purchase_Return()
        {
            InitializeComponent();
            supplyerName();
            voucher();
        }
        MySqlConnection conDatabase;
        DB.config connect = new DB.config();
        private void button1_Click(object sender, EventArgs e)
        {
         if (radioButton10.Checked == true)
            {
                CrystalReport.purchaseReturn.Report obj = new CrystalReport.purchaseReturn.Report();
                obj.Data = "daily";
                obj.Data1 = dateTimePicker1.Text;
                obj.Show();
            }
         else if (radioButton8.Checked == true)
            {
                CrystalReport.purchaseReturn.Report obj = new CrystalReport.purchaseReturn.Report();
                obj.Data = "Supliyer";
                obj.Data1 = Convert.ToString(cmdCustomerId.SelectedValue);
                obj.Show();
            }
         else if (radioButton1.Checked == true)
         {
             CrystalReport.purchaseReturn.Report obj = new CrystalReport.purchaseReturn.Report();
             obj.Data = "monthSupliyer";
             obj.Data1 = Convert.ToString(cmdCustomerId.SelectedValue);
             obj.Data2 = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8);
             obj.Show();
         }
         else if (radioButton11.Checked == true)
         {
             CrystalReport.purchaseReturn.Report obj = new CrystalReport.purchaseReturn.Report();
             obj.Data = "month";
             obj.Data1 = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8);
             obj.Show();
         }

            else if (radioButton7.Checked == true)
            {
                CrystalReport.purchaseReturn.Report obj = new CrystalReport.purchaseReturn.Report();
                obj.Data = "week";
                obj.Data1 = dateTimePicker1.Text;
                obj.Data2 = dateTimePicker2.Text;
                obj.Show();
            }

            else if (radioButton14.Checked == true)
            {
                CrystalReport.purchaseReturn.Report obj = new CrystalReport.purchaseReturn.Report();
                obj.Data = "vouch";
                obj.Data1 = Convert.ToString(comboBox3.SelectedValue);

                obj.Show();
            }
        }


        public void supplyerName()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
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

        public void voucher()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,return_voucher FROM purchase_return";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox3.DataSource = ds.Tables[0];
                comboBox3.ValueMember = "id";
                comboBox3.DisplayMember = "return_voucher";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
