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
    public partial class incomeRecord : Form
    {
        public incomeRecord()
        {
            InitializeComponent();
            view();
        }
        DB.query _query = new DB.query();
        void view()
        {
            dataGridView1.DataSource = _query.SelectFullTable("SELECT income.date as Date, income_type.name as Income_sourch,income.amount as Amount,income.note as Note ,user.user_name as User_By From income inner join income_type on income.income_sourch=income_type.id inner join user on income.user_id=user.id");
            label3.Text=total().ToString();
        }
        void viewWhere(string field,string date)
        {
            dataGridView1.DataSource = _query.SelectFullTable("SELECT income.date as Date, income_type.name as Income_sourch,income.amount as Amount,income.note as Note ,user.user_name as User_By From income inner join income_type on income.income_sourch=income_type.id inner join user on income.user_id=user.id where "+field+"='"+date+"'");
        }
        void Beetween(string field, string date)
        {
            dataGridView1.DataSource = _query.SelectFullTable("SELECT income.date as Date, income_type.name as Income_sourch,income.amount as Amount,income.note as Note ,user.user_name as User_By From income inner join income_type on income.income_sourch=income_type.id inner join user on income.user_id=user.id where income.date BETWEEN '" + field + "' and '" + date + "'");
        }
        private void incomeRecord_Load(object sender, EventArgs e)
        {
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            if(radioButton1.Checked==true)
            {
                
                    viewWhere("income.date", dateTimePicker1.Text);
                    label3.Text = total().ToString();
              
            }
            else if (radioButton2.Checked == true)
            {
                
                viewWhere("right(income.date,8)", dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8));
                label3.Text = total().ToString();
             
            }
            else if (radioButton3.Checked == true)
            {
            Beetween(dateTimePicker1.Text,dateTimePicker2.Text);
            label3.Text = total().ToString();

            }
               }
                catch(Exception)
                {}
        }

        public double total()
        {
            double k = 0;
            int i=0;
            for (i = 0; i <= dataGridView1.Rows.Count-1;i++ )
            {
                k = k + Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());
            }

      
            return k;
        
        }
    }
}
