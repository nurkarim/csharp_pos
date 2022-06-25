using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;
using CrystalDecisions.Windows.Forms;
using System.IO;
namespace SuperShop.View.sale
{
    public partial class RecordSale : Form
    {
        public RecordSale()
        {
            InitializeComponent();
            voucher();
        }
        DB.query _query = new DB.query();
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        Route.route _route = new Route.route();

        public string Booth { get { return label11.Text; } set { label11.Text = value; } }
        public string getuser { get { return label12.Text; } set { label12.Text = value; } }
        public string softwareType { get { return label13.Text; } set { label13.Text = value; } }
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
                cmd.CommandText = "SELECT id,custom_voucher_id FROM voucher where status='1'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "custom_voucher_id";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void suppliyer()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,customer_name FROM customer_info where status='1'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox2.DataSource = ds.Tables[0];
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "customer_name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        public void user()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,user_name FROM user where status='1'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox4.DataSource = ds.Tables[0];
                comboBox4.ValueMember = "id";
                comboBox4.DisplayMember = "user_name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void view()
        {

            dataGridView1.DataSource = _query.SelectFullTable("select date as 'Date',custom_voucher_id as 'Voucher',customer_name as 'Client Name',phone as 'Phone',subtotal_amount as 'Sub Unit',vat as 'Vat%',discount as 'Discount',total_amount as 'Total Amount',paid as 'Pay Amount',due as 'Due Amount' from voucher where status='1'");
        }
        void total()
        {
            try
            {
                int i = 0;
                int j = 0;
                decimal l = 0;
                j = dataGridView1.Rows.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    l += Convert.ToDecimal(dataGridView1.Rows[i].Cells[7].Value.ToString());
                }

                txt_total_voucher.Text = l.ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        void paid()
        {
            try
            {
                int i = 0;
                int j = 0;
                double l = 0;
                j = dataGridView1.Rows.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    l += Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                txt_total_paid.Text = l.ToString();

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        void due()
        {
            try
            {
                int i = 0;
                int j = 0;
                double k = 0;
                j = dataGridView1.Rows.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value.ToString());
                }
                txt_totalDu.Text = k.ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void RecordSale_Load(object sender, EventArgs e)
        {
           
            user();
            suppliyer();
            view();
            due();
            paid();
            total();
            comboBox1.Text = "";
            comboBox2.Text = "";
           
            comboBox4.Text = "";
            comboBox5.Text = "";
        }

        void clear()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
           
            comboBox4.Text = "";
            comboBox5.Text = "";

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            user();
            suppliyer();
            view();
            due();
            paid();
            total();
            comboBox1.Text = "";
            comboBox2.Text = "";
           
            comboBox4.Text = "";
            comboBox5.Text = "";
          
            radioButton1.Checked = false;
            radioButton2.Checked = false;
           
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                try
                {
                    dataGridView1.DataSource = _query.SelectFullTable("select date as 'Date',custom_voucher_id as 'Voucher',customer_name as 'Client Name',phone as 'Phone',subtotal_amount as 'Sub Unit',vat as 'Vat%',discount as 'Discount',total_amount as 'Total Amount',paid as 'Pay Amount',due as 'Due Amount' from voucher where date='" + dateTimePicker1.Text + "' and status='1'");
                   
                    due();
                    paid();
                    total();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            else if (radioButton2.Checked == true)
            {
                try
                {

                    dataGridView1.DataSource = _query.SelectFullTable("select date as 'Date',custom_voucher_id as 'Voucher',customer_name as 'Client Name',phone as 'Phone',subtotal_amount as 'Sub Unit',vat as 'Vat%',discount as 'Discount',total_amount as 'Total Amount',paid as 'Pay Amount',due as 'Due Amount' from voucher where status='1' and  date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'");

                    due();
                    paid();
                    total();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            else if (radioButton7.Checked == true)
            {
          
                clear();
                dataGridView1.DataSource = _query.SelectFullTable("select date as 'Date',custom_voucher_id as 'Voucher',customer_name as 'Client Name',phone as 'Phone',subtotal_amount as 'Sub Unit',vat as 'Vat%',discount as 'Discount',total_amount as 'Total Amount',paid as 'Pay Amount',due as 'Due Amount' from voucher where id='" + comboBox1.SelectedValue + "' and status='1'");
                due();
                paid();
                total();
            
            }
            else if(radioButton4.Checked==true)
            {
                clear();
                dataGridView1.DataSource = _query.SelectFullTable("select date as 'Date',custom_voucher_id as 'Voucher',customer_name as 'Client Name',phone as 'Phone',subtotal_amount as 'Sub Unit',vat as 'Vat%',discount as 'Discount',total_amount as 'Total Amount',paid as 'Pay Amount',due as 'Due Amount' from voucher where customer_id='" + comboBox2.SelectedValue + "' and status='1'");
                due();
                paid();
                total();
            }

            else if(radioButton5.Checked==true)
            {
                clear();
                dataGridView1.DataSource = _query.SelectFullTable("select date as 'Date',custom_voucher_id as 'Voucher',customer_name as 'Client Name',phone as 'Phone',subtotal_amount as 'Sub Unit',vat as 'Vat%',discount as 'Discount',total_amount as 'Total Amount',paid as 'Pay Amount',due as 'Due Amount' from voucher where user_id='" + comboBox4.SelectedValue + "' and status='1'");
                due();
                paid();
                total();
            }
            else if (radioButton6.Checked == true)
            {
             clear();
                dataGridView1.DataSource = _query.SelectFullTable("select date as 'Date',custom_voucher_id as 'Voucher',customer_name as 'Client Name',phone as 'Phone',subtotal_amount as 'Sub Unit',vat as 'Vat%',discount as 'Discount',total_amount as 'Total Amount',paid as 'Pay Amount',due as 'Due Amount' from voucher where type='" + comboBox5.Text + "' and status='1'");
                due();
                paid();
                total();
            }
            else if(radioButton3.Checked==true)
            {
                try
                {
                    dataGridView1.DataSource = _query.SelectFullTable("select date as 'Date',custom_voucher_id as 'Voucher',customer_name as 'Client Name',phone as 'Phone',subtotal_amount as 'Sub Unit',vat as 'Vat%',discount as 'Discount',total_amount as 'Total Amount',paid as 'Pay Amount',due as 'Due Amount' from voucher where right(date,8)='" + dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8) + "' and status='1'");

                    due();
                    paid();
                    total();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["Voucher"].Value.ToString();

            View.sale.saleCart obj = new saleCart();
            obj.ID = comboBox1.SelectedValue.ToString();
            obj.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                _query.Update("voucher", "status='2'", "id", "'" + comboBox1.SelectedValue + "'");
            }
            else { MessageBox.Show("Please Select Voucher"); }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
