using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.View.DailyOperation
{
    public partial class ExpenseRecord : Form
    {
        public ExpenseRecord()
        {
            InitializeComponent();
            view();
        }
        DB.query _query = new DB.query();
        private void ExpenseRecord_Load(object sender, EventArgs e)
        {

        }
        void view()
        {
            dataGridView1.DataSource = _query.SelectFullTable("SELECT expense.date as Date, expense_type.name as Expense_sourch,expense.amount as Amount,expense.note as Note ,user.user_name as User_By From expense inner join expense_type on expense.expense_sourche=expense_type.id inner join user on expense.recived_by=user.id");
            label3.Text = total().ToString();
        }
        void viewWhere(string field, string date)
        {
            dataGridView1.DataSource = _query.SelectFullTable("SELECT expense.date as Date, expense_type.name as Expense_sourch,expense.amount as Amount,expense.note as Note ,user.user_name as User_By From expense inner join expense_type on expense.expense_sourche=expense_type.id inner join user on expense.recived_by=user.id where " + field + "='" + date + "'");
        }
        void Beetween(string field, string date)
        {
            dataGridView1.DataSource = _query.SelectFullTable("SELECT expense.date as Date, expense_type.name as Expense_sourch,expense.amount as Amount,expense.note as Note ,user.user_name as User_By From expense inner join expense_type on expense.expense_sourche=expense_type.id inner join user on expense.recived_by=user.id where expense.date BETWEEN '" + field + "' and '" + date + "'");
        }
        public double total()
        {
            double k = 0;
            int i = 0;
            for (i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                k = k + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }


            return k;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {

                    viewWhere("expense.date", dateTimePicker1.Text);
                    label3.Text = total().ToString();

                }
                else if (radioButton2.Checked == true)
                {

                    viewWhere("right(expense.date,8)", dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8));
                    label3.Text = total().ToString();

                }
                else if (radioButton3.Checked == true)
                {
                    Beetween(dateTimePicker1.Text, dateTimePicker2.Text);
                    label3.Text = total().ToString();

                }
            }
            catch (Exception)
            { }
        }
    }
}
