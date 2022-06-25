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
    public partial class Loan : Form
    {
        public Loan()
        {
            InitializeComponent();
            view();
        }
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
        MySqlCommand cmd;
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        void view()
        {
            dataGridView1.DataSource = _query.SelectFullTable("select bank_loan.id as 'Sl', add_bank.bank_name as 'Bank Name',bank_loan.loan_amount as 'Loan Amount',bank_loan.date as 'Date', bank_loan.note as 'Note' from bank_loan inner join add_bank on bank_loan.fk_bank_id = add_bank.id");
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            _query.InsertA("bank_loan", "fk_bank_id,date,loan_amount,note", "'" + comboBox1.SelectedValue + "','" + dateTimePicker1.Text + "','" + textBox1.Text + "','"+richTextBox1.Text+"'");

            _query.EIInsert("bank_ladger_book", "fk_loan_id,fk_bank_id,date,discription,debit_amount", "'" + _query.LastId + "','" + comboBox1.SelectedValue + "','" + dateTimePicker1.Text + "','"+richTextBox1.Text+"','" + textBox1.Text + "'");
         
            view();
            clear();
        }
        void clear()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            richTextBox1.Text = "";
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
        private void Loan_Load(object sender, EventArgs e)
        {
            bank();
            clear();
            view();
            comboBox1.Text = "";
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            label5.Text = dataGridView1.SelectedRows[0].Cells["Sl"].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["Bank Name"].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["Loan Amount"].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells["Date"].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells["Note"].Value.ToString();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _query.Update("bank_loan", "fk_bank_id='"+comboBox1.SelectedValue+"',date='"+dateTimePicker1.Text+"',loan_amount='"+textBox1.Text+"',note='"+richTextBox1.Text+"'", "id", "'"+label5.Text+"'");
            clear();
            view();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (label5.Text != "")
            {
                _query.Delete("bank_loan", "id", "'" + label5.Text + "'");
                _query.Delete("bank_loan", "fk_loan_id", "'" + label5.Text + "'");
                
                clear();
                view();
            }
            else { MessageBox.Show("Please Select Row For Delete"); }
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
