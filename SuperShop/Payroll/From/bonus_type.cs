using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.Payroll.From
{
    public partial class bonus_type : Form
    {
        public bonus_type()
        {
            InitializeComponent();
            view();
        }
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
      
        void view()
        {

          dataGridView1.DataSource = _query.SelectFullTable("select id,type_name as 'Name' from bonus_type");

        }
        private void bonus_type_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="")
            {
            _query.Insert("bonus_type", "type_name", "'"+textBox1.Text+"'");
            view();
            textBox1.Text = "";
        }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            label2.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _query.Update("bonus_type", "type_name='" + textBox1.Text + "'", "id", "'" + label2.Text + "'");
            view();
            textBox1.Text = "";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _query.Delete("bonus_type", "id", "'"+label2.Text+"'");
            view();
            textBox1.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
