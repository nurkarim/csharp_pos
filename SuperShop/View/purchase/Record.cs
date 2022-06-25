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
    public partial class Record : Form
    {
        public Record()
        {
            InitializeComponent();
            view();
        }
        DB.query _query = new DB.query();
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        private void Record_Load(object sender, EventArgs e)
        {
            user();
            due();
            paid();
            total();
            voucher();
            BillNo();
            suppliyer();
            comboBox1.Text = ""; comboBox3.Text = ""; comboBox2.Text = ""; comboBox4.Text = "";
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
                cmd.CommandText = "SELECT id,invoice_no FROM purchase_table where status='1'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "invoice_no";

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
                cmd.CommandText = "SELECT id,name FROM supplyer_table where status='1'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox2.DataSource = ds.Tables[0];
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void BillNo()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,bill_no FROM purchase_table where status='1'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox3.DataSource = ds.Tables[0];
                comboBox3.ValueMember = "id";
                comboBox3.DisplayMember = "bill_no";

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

        dataGridView1.DataSource=_query.Select("viewPurchaseTable");
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
                    l += Convert.ToDecimal(dataGridView1.Rows[i].Cells[8].Value.ToString());
                }
                
                txt_total_voucher.Text = l.ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        void paid()
        {
            try{
            int i = 0;
            int j = 0;
           double   l = 0;
           j = dataGridView1.Rows.Count;
            for (i = 0; i <= j - 1;i++ )
            { 
           l+=Convert.ToDouble(dataGridView1.Rows[i].Cells[9].Value.ToString());
            }
            txt_total_paid.Text = l.ToString();
           
             }
            catch(Exception ex)
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
                    k = k + Convert.ToDouble(dataGridView1.Rows[i].Cells[10].Value.ToString());
                }
                txt_totalDu.Text = k.ToString();
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                comboBox1.Text = "";
                comboBox3.Text = "";
                comboBox2.Text = "";
                if (checkBox1.Checked == true)
                {
                    try
                    {
                        dataGridView1.DataSource = _query.selectWhere("viewpurchasetable", "SL='" + comboBox1.SelectedValue + "'");
                        due();
                        paid();
                        total();
                        
                    }
                    catch (Exception ex)
                    { MessageBox.Show(ex.Message); }
                }
                else 
                {
                    view();
                }
            }
          
        

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
            comboBox1.Text = "";
            comboBox3.Text = "";
            comboBox2.Text = "";
            try
            {
                dataGridView1.DataSource = _query.selectWhere("viewpurchasetable", "BillNo='" + comboBox3.SelectedValue + "'");
                due();
                paid();
                total();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
            }
            else { view(); }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Text = "";
                comboBox3.Text = ""; comboBox2.Text = "";
                try
                {
                    dataGridView1.DataSource = _query.selectWhere("viewpurchasetable", "Name='" + comboBox2.SelectedValue + "'");
                    due();
                    paid();
                    total();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            else { view(); }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                comboBox1.Text = "";
                comboBox3.Text = ""; comboBox2.Text = ""; comboBox4.Text = "";
                try
                {
                    dataGridView1.DataSource = _query.selectWhere("viewpurchasetable", "Recived='" + comboBox4.SelectedValue + "'");
                    due();
                    paid();
                    total();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            else { view(); }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox1.Text = "";
                comboBox3.Text = ""; comboBox2.Text = ""; comboBox4.Text = "";
                try
                {
                    dataGridView1.DataSource = _query.selectWhere("viewpurchasetable", "Type='" + comboBox5.Text + "'");
                    due();
                    paid();
                    total();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            else { view(); }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                try
                {
                    dataGridView1.DataSource = _query.selectWhere("viewpurchasetable", "Date='" + dateTimePicker1.Text + "'");
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
                    dataGridView1.DataSource = _query.SelectFullTable(" select * from viewpurchasetable where Date BETWEEN '"+dateTimePicker1.Text+"' and '"+dateTimePicker2.Text+"'");
                    due();
                    paid();
                    total();
                }
                catch (Exception ex)
                { MessageBox.Show(ex.Message); }
            }
            else 
            {
                MessageBox.Show("Select The Date Type");
            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            view();
        }
         }
}
