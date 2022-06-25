using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.Transection
{
    public partial class Cash_in : Form
    {
        public Cash_in()
        {
            InitializeComponent();
        }
        DB.query _query = new DB.query();
        MySqlConnection cn;
        DB.config _con = new DB.config();
        private void button1_Click(object sender, EventArgs e)
        {
            cn = _con.connection();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from daily_cash_statement where date='" + Convert.ToString(dateTimePicker1.Text) + "'",cn);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                _query.Update("daily_cash_statement", "balance='" + Convert.ToString(textBox1.Text) + "'", "date", "'" + Convert.ToString(dateTimePicker1.Text) + "'");
            }
            else
            {
                _query.Insert("daily_cash_statement", "balance,date", "'" + Convert.ToString(textBox1.Text) + "','" + Convert.ToString(dateTimePicker1.Text) + "'");
            }
        }

        private void Cash_in_Load(object sender, EventArgs e)
        {
            cn = _con.connection();
            cn.Open();
            MySqlCommand cmd = new MySqlCommand("select * from daily_cash_statement where date='" + Convert.ToString(dateTimePicker1.Text) + "'", cn);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox1.Text = dr["balance"].ToString();
            }
            else
            {
                textBox1.Text = "00.00";
            }
        }
    }
}
