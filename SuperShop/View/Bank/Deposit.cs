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
    public partial class Deposit : Form
    {

        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
        MySqlCommand cmd;
        public Deposit()
        {
            InitializeComponent();
            bank();
            view();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        void view()
        {
            dataGridView1.DataSource = _query.SelectFullTable("SELECT bank_deposit.id as 'SL',add_bank.bank_name as 'Bank Name',bank_deposit.account_no as 'Account No',bank_deposit.date as 'Date',bank_deposit.deposit_amount as 'Deposit Amount',bank_deposit.paid_type as 'Type' from bank_deposit INNER JOIN add_bank ON bank_deposit.bank_name=add_bank.id where bank_deposit.`status`='1' ");
        }
        public void bank()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
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
        private void Deposit_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells["Bank Name"].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells["Account No"].Value.ToString();
                label6.Text = dataGridView1.SelectedRows[0].Cells["SL"].Value.ToString();
                textBox1.Text = dataGridView1.SelectedRows[0].Cells["Deposit Amount"].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedRows[0].Cells["Type"].Value.ToString();
                if (dataGridView1.CurrentRow.Selected)
                {
                    btnDelete.Enabled = true;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    btnDelete.Enabled = false;
                    btnUpdate.Enabled = false;
                }
            }
            catch(Exception)
            {}

        }
        void clear()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="" && comboBox1.Text=="")
            {

                MessageBox.Show("Required Inpute");
                textBox1.Focus();
                return;
            }
                else{

                    _query.InsertA("bank_deposit", "bank_name,account_no,date,deposit_amount,paid_type", "'" + comboBox1.SelectedValue + "','"+textBox2.Text+"','" + dateTimePicker1.Text + "','" + textBox1.Text + "','" + comboBox2.Text + "'");
                    _query.EIInsert("bank_ladger_book", "fk_deposit_id,fk_bank_id,date,discription,debit_amount", "'"+_query.LastId+"','" + comboBox1.SelectedValue + "','" + dateTimePicker1.Text + "','Bank Deposit','" + textBox1.Text + "'");
                view();
            clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && comboBox1.Text == "")
            {

                MessageBox.Show("Required Inpute");
                textBox1.Focus();
                return;
            }
            else
            {

                _query.Update("bank_deposit", "bank_name='" + comboBox1.SelectedValue + "',account_no='"+textBox2.Text+"',date='" + dateTimePicker1.Text + "',deposit_amount='" + textBox1.Text + "',paid_type='" + comboBox2.Text + "'", "id", "'" + label6.Text + "'");
                view();
                clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && comboBox1.Text == "")
            {

                MessageBox.Show("Required Inpute");
                textBox1.Focus();
                return;
            }
            else
            {
                _query.Delete("bank_deposit", "id", "'" + label6.Text + "'");
                _query.Delete("bank_ladger_book", "fk_deposit_id", "'" + label6.Text + "'");

                view();
                clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            view();
            clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
