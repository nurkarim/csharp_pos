using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.Bank
{
    public partial class payBankLoan : Form
    {
        public payBankLoan()
        {
            InitializeComponent();
            view();
            bank();
        }
        DB.config connect = new DB.config();
        MySqlConnection cn;
        DB.query _query = new DB.query();
        public void con()
        {
            cn = connect.connection();
            cn.Open();
        
        }


        public void bank()
        {
            try
            {
                con();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT id,bank_name FROM add_bank";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "bank_name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        void view()
        {
            dataGridView1.DataSource = _query.SelectFullTable("select bank_loan_payment.id as 'ID', bank_loan_payment.date as 'Date',add_bank.bank_name as 'Bank Name',add_bank.phone as 'Phone', bank_loan_payment.loan_amount as 'Loan Amount',bank_loan_payment.payment_amount as 'Payment Amount'  from bank_loan_payment inner join add_bank on bank_loan_payment.bank_id=add_bank.id");
        
        }
        private void payBankLoan_Load(object sender, EventArgs e)
        {

        }

        void clear()
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            view();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _query.Insert("bank_loan_payment", "bank_id,loan_amount,payment_amount,date", "'"+comboBox1.SelectedValue+"','"+textBox1.Text+"','"+textBox2.Text+"','"+dateTimePicker1.Text+"'");
            clear();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells["Bank Name"].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["Loan Amount"].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["Payment Amount"].Value.ToString();
                label5.Text = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            }
            catch (Exception)
            {
            
            
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {

                row = dataGridView1.Rows[i];
                if (Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    string id = Convert.ToString(row.Cells["ID"].Value);
                    MySqlCommand cmd = new MySqlCommand("delete from bank_loan_payment where id='" + id + "'", cn);
                    cmd.ExecuteNonQuery();
                    dataGridView1.Rows.Remove(row);
                    i--;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _query.Update("bank_loan_payment", "bank_id='" + comboBox1.SelectedValue + "',loan_amount='" + textBox1.Text + "',payment_amount='" + textBox2.Text + "'", "id", "'" + label5.Text + "'");
            clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}
