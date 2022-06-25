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
    public partial class purchaseReport : Form
    {
        public purchaseReport()
        {
            InitializeComponent();
            supplyerName();
            voucher();
        }
        MySqlConnection conDatabase;
        DB.config connect = new DB.config();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                cmd.CommandText = "SELECT id,invoice_no FROM purchase_table";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox3.DataSource = ds.Tables[0];
                comboBox3.ValueMember = "id";
                comboBox3.DisplayMember = "invoice_no";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void purchaseReport_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked==true)
            {
                CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                obj.Data = "paid";
                obj.Data1 = "Paid";
                obj.Show();
            }
            else if (radioButton2.Checked==true)
            {
                CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                obj.Data = "due";
                obj.Data1 = "Due";
                obj.Show();
            }
            else if (radioButton3.Checked==true)
            {
                CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                obj.Data = "left";
                obj.Data1 = "Partial left";
                obj.Show();
            }
            else if (radioButton10.Checked == true)
            {
                CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                obj.Data = "daily";
                obj.Data1 = dateTimePicker1.Text;
                obj.Show();
            }
            else if (radioButton11.Checked == true)
            {
                CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                obj.Data = "month";
                obj.Data1 = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8);
                obj.Show();
            }
            else if (radioButton9.Checked == true)
            {
                if (cmdCustomerId.Text != "")
                {
                    CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                    obj.Data = "monthSupliyer";
                    obj.Data1 = cmdCustomerId.SelectedValue.ToString();
                    obj.Data2 = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8);
                    obj.Show();
                }
                else
                {

                    MessageBox.Show("Select Suppliyer");
                }
            }
            else if (radioButton7.Checked == true)
            {
                CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                obj.Data = "week";
                obj.Data1 = dateTimePicker1.Text;
                obj.Data2 = dateTimePicker2.Text;
                obj.Show();
            }
            else if (radioButton8.Checked == true)
            {
                CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                obj.Data = "sup";
                obj.Data1 = Convert.ToString(cmdCustomerId.SelectedValue);
              
                obj.Show();
            }
            else if (radioButton4.Checked == true)
            {
                CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                obj.Data = "dailyCash";
                obj.Data2 = "Paid";
                obj.Data1 = dateTimePicker1.Text;
                obj.Show();
            }
            else if (radioButton5.Checked == true)
            {
                CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                obj.Data = "dailyCash";
                obj.Data2 = "Due";
                obj.Data1 = dateTimePicker1.Text;
                obj.Show();
            }
            else if (radioButton6.Checked == true)
            {
                CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                obj.Data = "dailyCash";
                obj.Data2 = "Partial left";
                obj.Data1 = dateTimePicker1.Text;
                obj.Show();
            }

            else if (radioButton14.Checked == true)
            {
                CrystalReport.purchase.Report obj = new CrystalReport.purchase.Report();
                obj.Data = "vouch";
                obj.Data1 = Convert.ToString(comboBox3.SelectedValue);

                obj.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
