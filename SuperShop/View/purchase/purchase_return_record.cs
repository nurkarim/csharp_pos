using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.purchase
{
    public partial class purchase_return_record : Form
    {
        public purchase_return_record()
        {
            InitializeComponent();
            view();
            supplyerName();
            voucher();
        }
        DB.config _config = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
        public void supplyerName()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = _config.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM supplyer_table where status='1'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                metroComboBox1.DataSource = ds.Tables[0];
                metroComboBox1.ValueMember = "id";
                metroComboBox1.DisplayMember = "name";

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

                conDatabase = _config.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,return_voucher FROM purchase_return where status='1'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                metroComboBox2.DataSource = ds.Tables[0];
                metroComboBox2.ValueMember = "id";
                metroComboBox2.DisplayMember = "return_voucher";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void view()
        {
            try
            {
                dataGridView1.DataSource = _query.SelectFullTable("select purchase_return.id as ID,purchase_return.return_voucher as Vouchers,purchase_return.recipt_no as Bill_No,purchase_return.date as Date,purchase_return.supplier_name as Name,purchase_return.phone as Phone,purchase_return.sub_total as Sub_Total,purchase_return.discount as Discount,purchase_return.total as Total,purchase_return.paid as Paid,purchase_return.due as Due,purchase_return.type as Types,purchase_return.booth as Booth,user.user_name as Users from purchase_return inner join user on purchase_return.created_by=user.id");
                label10.Text = sumTotal().ToString();
                label9.Text = Paid().ToString();
                label8.Text = Due().ToString();
            }
            catch (Exception)
            { }
        }
        void viewWhere(string field, string value)
        {
            try
            {
                dataGridView1.DataSource = _query.SelectFullTable("select purchase_return.id as ID,purchase_return.return_voucher as Vouchers,purchase_return.recipt_no as Bill_No,purchase_return.date as Date,purchase_return.supplier_name as Name,purchase_return.phone as Phone,purchase_return.sub_total as Sub_Total,purchase_return.discount as Discount,purchase_return.total as Total,purchase_return.paid as Paid,purchase_return.due as Due,purchase_return.type as Types,purchase_return.booth as Booth,user.user_name as Users from purchase_return inner join user on purchase_return.created_by=user.id where " + field.ToString() + "='" + value.ToString() + "'");
                label10.Text = sumTotal().ToString();
                label9.Text = Paid().ToString();
                label8.Text = Due().ToString();
            }
            catch (Exception)
            { }
        }
        void Between(string field, string value)
        {
            try
            {
                dataGridView1.DataSource = _query.SelectFullTable("select purchase_return.id as ID,purchase_return.return_voucher as Vouchers,purchase_return.recipt_no as Bill_No,purchase_return.date as Date,purchase_return.supplier_name as Name,purchase_return.phone as Phone,purchase_return.sub_total as Sub_Total,purchase_return.discount as Discount,purchase_return.total as Total,purchase_return.paid as Paid,purchase_return.due as Due,purchase_return.type as Types,purchase_return.booth as Booth,user.user_name as Users from purchase_return inner join user on purchase_return.created_by=user.id where purchase_return.date BETWEEN  '" + field.ToString() + "' and '" + value.ToString() + "'");
                label10.Text = sumTotal().ToString();
                label9.Text = Paid().ToString();
                label8.Text = Due().ToString();
            }
            catch (Exception)
            { }
        }

        public double sumTotal()
        {


            int i = 0;
            double k = 0;
            for (i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                k = k + Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value.ToString());
            }
            return k;


        }
        public double Paid()
        {


            int i = 0;
            double k = 0;
            for (i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                k = k + Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value.ToString());
            }
            return k;


        }
        public double Due()
        {


            int i = 0;
            double k = 0;
            for (i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                k = k + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value.ToString());
            }
            return k;


        }
        private void purchase_return_record_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton2.Checked == true)
                {
                    viewWhere("purchase_return.date", "" + dateTimePicker1.Text + "");
                }
                else if (radioButton4.Checked == true)
                {
                    viewWhere("right(purchase_return.date,8)", "" + dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8) + "");
                }

                else if (radioButton3.Checked == true)
                {
                    Between("" + dateTimePicker1.Text + "", "" + dateTimePicker2.Text + "");
                }
                else if (radioButton5.Checked == true)
                {
                    viewWhere("purchase_return.supplier_id", "" + metroComboBox1.SelectedValue + "");
                }
                else if (radioButton1.Checked == true)
                {
                    viewWhere("purchase_return.id", "" + metroComboBox2.SelectedValue + "");
                }
            }
            catch (Exception)
            { }
        }
    }
}
