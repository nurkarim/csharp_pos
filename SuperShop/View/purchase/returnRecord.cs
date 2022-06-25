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
    public partial class returnRecord : Form
    {
        public returnRecord()
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
                cmd.CommandText = "SELECT id,customer_name FROM customer_info where status='1'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                metroComboBox1.DataSource = ds.Tables[0];
                metroComboBox1.ValueMember = "id";
                metroComboBox1.DisplayMember = "customer_name";

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
                cmd.CommandText = "SELECT id,return_voucher FROM sale_return where status='1'";
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
            try{
            dataGridView1.DataSource = _query.SelectFullTable("select sale_return.id as ID,sale_return.return_voucher as Vouchers,sale_return.recipt_no as Bill_No,sale_return.date as Date,sale_return.customer_name as Name,sale_return.phone as Phone,sale_return.sub_total as Sub_Total,sale_return.discount as Discount,sale_return.total as Total,sale_return.paid as Paid,sale_return.due as Due,sale_return.type as Types,sale_return.booth as Booth,user.user_name as Users from sale_return inner join user on sale_return.created_by=user.id");
            label10.Text = sumTotal().ToString();
            label9.Text = Paid().ToString();
            label8.Text = Due().ToString();
            }
                catch(Exception)
            {}
        }
        void viewWhere(string field,string value)
        {
            try{
            dataGridView1.DataSource = _query.SelectFullTable("select sale_return.id as ID,sale_return.return_voucher as Vouchers,sale_return.recipt_no as Bill_No,sale_return.date as Date,sale_return.customer_name as Name,sale_return.phone as Phone,sale_return.sub_total as Sub_Total,sale_return.discount as Discount,sale_return.total as Total,sale_return.paid as Paid,sale_return.due as Due,sale_return.type as Types,sale_return.booth as Booth,user.user_name as Users from sale_return inner join user on sale_return.created_by=user.id where "+field.ToString()+"='"+value.ToString()+"'");
            label10.Text = sumTotal().ToString();
            label9.Text = Paid().ToString();
            label8.Text = Due().ToString();
            }
            catch (Exception)
            { }
        }
        void Between(string field, string value)
        {
            try{
            dataGridView1.DataSource = _query.SelectFullTable("select sale_return.id as ID,sale_return.return_voucher as Vouchers,sale_return.recipt_no as Bill_No,sale_return.date as Date,sale_return.customer_name as Name,sale_return.phone as Phone,sale_return.sub_total as Sub_Total,sale_return.discount as Discount,sale_return.total as Total,sale_return.paid as Paid,sale_return.due as Due,sale_return.type as Types,sale_return.booth as Booth,user.user_name as Users from sale_return inner join user on sale_return.created_by=user.id where sale_return.date BETWEEN  '" + field.ToString() + "' and '" + value.ToString() + "'");
            label10.Text = sumTotal().ToString();
            label9.Text = Paid().ToString();
            label8.Text = Due().ToString();
            }
            catch (Exception)
            { }
        }
        private void returnRecord_Load(object sender, EventArgs e)
        {

        }

        public double sumTotal()
        {
           

                int i = 0;
                double k = 0;
                for (i = 0; i <= dataGridView1.Rows.Count-1; i++)
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton2.Checked == true)
                {
                    viewWhere("sale_return.date", "" + dateTimePicker1.Text + "");
                }
                else if (radioButton4.Checked == true)
                {
                    viewWhere("right(sale_return.date,8)", "" + dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8) + "");
                }

                else if (radioButton3.Checked == true)
                {
                    Between(""+dateTimePicker1.Text+"", ""+dateTimePicker2.Text+"");
            }
                else if (radioButton5.Checked == true)
                {
                    viewWhere("sale_return.customer_id", "" + metroComboBox1.SelectedValue + "");
                }
                else if (radioButton1.Checked == true)
                {
                    viewWhere("sale_return.id", "" + metroComboBox2.SelectedValue + "");
                }
            }
            catch(Exception)
            {}
        }
    }
}
