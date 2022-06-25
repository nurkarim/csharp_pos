using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.View.BesicSetup
{
    public partial class currency : Form
    {
        public currency()
        {
            InitializeComponent();
            view();
        }
        DB.query _query = new DB.query();
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                _query.Insert("currency_type", "Name", "'" + textBox1.Text + "'");
                view();
                clear();
            }
            else 
            {
                MessageBox.Show("Please Enter The Currency Name");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                _query.Update("currency_type", "Name='" + textBox1.Text + "'", "id","'"+label2.Text+"'");
                view();
                clear();
            }
            else
            {
                MessageBox.Show("Please Enter The Currency Id");
            }
        }
        void view()
        {
            dataGridView1.DataSource=_query.Select("currency_type");
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text=dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            label2.Text=dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
        }

        void clear()
        {
            textBox1.Text = "";
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (label2.Text != "")
            {
                _query.Delete("currency_type", "id", "'" + label2.Text + "'");
                view();
                clear();
            }
            else
            {
                MessageBox.Show("Please Enter The Currency Id");
            } 
        }
    }
}
