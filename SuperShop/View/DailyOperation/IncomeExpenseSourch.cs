using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.DailyOperation
{
    public partial class IncomeExpenseSourch : Form
    {
        public IncomeExpenseSourch()
        {
            InitializeComponent();
            viewIncome();
            viewExpense();
        }
        DB.config connect = new DB.config();
    
        DB.query _query = new DB.query();
        void viewIncome()
        {
            dataGridView1.DataSource = _query.Select("view_income_sourch_type");
        }
        void viewExpense()
        {
            dataGridView2.DataSource = _query.SelectFullTable("SELECT expense_type.id as 'Code',expense_type.name as 'Expense' From expense_type where expense_type.`status`='1' ");
        
        }
        void Saveincome()
        {
            _query.Insert("income_type", "name", "'" + Convert.ToString(richTextBox1.Text) + "'");
            richTextBox1.Text = "";
            viewIncome();
        }

        void SaveExpense()
        {
            _query.Insert("expense_type", "name", "'" + Convert.ToString(richTextBox2.Text) + "'");
            richTextBox2.Text = "";
            viewExpense();
        }
        private void IncomeExpenseSourch_Load(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Saveincome();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveExpense();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                richTextBox1.Text = dataGridView1.SelectedRows[0].Cells["Sourch Name"].Value.ToString();
                label3.Text = dataGridView1.SelectedRows[0].Cells["SL"].Value.ToString();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _query.Update("income_type", "name='" + richTextBox1.Text + "'", "id", "'" + label3.Text + "'");
                richTextBox1.Text = "";
                viewIncome();
            }
            catch(Exception)
            {}
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                _query.Delete("income_type", "id", "'" + label3.Text + "'");
                richTextBox1.Text = "";
                viewIncome();
            }
            catch (Exception)
            { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            viewIncome();
            viewExpense();
            richTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            viewIncome();
            viewExpense();
            richTextBox2.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            _query.Delete("expense_type", "id", "'"+label4.Text+"'");
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                label4.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                richTextBox2.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _query.Update("expense_type", "name='"+richTextBox2.Text+"'", "id", "'"+label4.Text+"'");
        }
    }
}
