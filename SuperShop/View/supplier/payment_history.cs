using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.supplier
{
    public partial class payment_history : Form
    {
        public payment_history()
        {
            InitializeComponent();
            supplyerName();
        }
        DB.query _query = new DB.query();
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
        void view()
        {
            dataGridView1.DataSource = _query.SelectFullTable("select supplier_payment_history.date as Date,supplyer_table.name as Name,supplyer_table.phone as Phone,supplier_payment_history.debit_amount as Debit_Amount,supplier_payment_history.credit_amount as Credit_Amount,supplier_payment_history.balance as Paid,supplier_payment_history.due as Due,user.user_name  as 'User By' from supplier_payment_history inner join supplyer_table on supplier_payment_history.suplier_id=supplyer_table.id inner join user on supplier_payment_history.user_id=user.id");
        }

        void viewwhere(string par)
        {
            dataGridView1.DataSource = _query.SelectFullTable("select supplier_payment_history.date as Date,supplyer_table.name as Name,supplyer_table.phone as Phone,supplier_payment_history.debit_amount as Debit_Amount,supplier_payment_history.credit_amount as Credit_Amount,supplier_payment_history.balance as Paid,supplier_payment_history.due as Due,user.user_name  as 'User By' from supplier_payment_history inner join supplyer_table on supplier_payment_history.suplier_id=supplyer_table.id inner join user on supplier_payment_history.user_id=user.id where "+par+"");
        }
        private void payment_history_Load(object sender, EventArgs e)
        {
            view();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
            
            
            viewwhere("right(supplier_payment_history.date,8)='"+dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8)+"'");
            }
            else if (radioButton1.Checked == true)
            {
                viewwhere("supplier_payment_history.suplier_id='"+cmdCustomerId.SelectedValue+"'");
            }
        }
    }
}
