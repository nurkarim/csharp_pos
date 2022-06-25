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
    public partial class incomeReport : Form
    {
        public incomeReport()
        {
            InitializeComponent();
        }
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {

                CrystalReport.Income.Report_viewr obj = new CrystalReport.Income.Report_viewr();
                obj.Type = "voucher";
                obj.DateA = Convert.ToInt32(comboBox1.SelectedValue).ToString();
               
                obj.Show();
            }

            if(radioButton1.Checked==true)
            {

                CrystalReport.Income.Report_viewr obj = new CrystalReport.Income.Report_viewr();
                obj.Type = "daily";
                obj.DateA = dateTimePicker1.Text;
                obj.Show();
            }

            else if (radioButton5.Checked == true)
            {

                CrystalReport.Income.Report_viewr obj = new CrystalReport.Income.Report_viewr();
                obj.Type = "monthly";
                obj.DateA = dateTimePicker1.Text;
                obj.DateB = dateTimePicker2.Text;
                obj.Show();
            }
            else if (radioButton3.Checked == true)
            {

                CrystalReport.Income.Report_viewr obj = new CrystalReport.Income.Report_viewr();
                obj.Type = "month";
                obj.DateA = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8);
            
                obj.Show();
            }
        }

        public void bank()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
           MySqlCommand     cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,voucher_id FROM income_voucher";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "voucher_id";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void incomeReport_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            bank();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
