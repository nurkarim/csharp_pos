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
    public partial class addBank : Form
    {
        public addBank()
        {
            InitializeComponent();
            view();
        }
        DB.query _query = new DB.query();
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (label4.Text == "")
            {
                MessageBox.Show("Please Select The Bank");
                richTextBox1.Focus();
                return;
            }
            else
            {
                _query.Update("add_bank", "bank_name='"+richTextBox1.Text+"',phone='"+textBox1.Text+"',booth_bank='"+richTextBox2.Text+"'", "id", "'"+label4.Text+"'");
                clear();
                view();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void addBank_Load(object sender, EventArgs e)
        {

        }
        void view()
        {
            dataGridView1.DataSource = _query.SelectFullTable("SELECT add_bank.id as 'Bank ID',add_bank.bank_name as 'Bank Name', add_bank.phone as 'Phone',add_bank.booth_bank as 'Booth' from add_bank where add_bank.`status`='1' ");
        }
        void clear()
        {

            richTextBox1.Text = "";
            richTextBox2.Text = "";
            textBox1.Text = "";
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            _query.Insert("add_bank", "bank_name,phone,booth_bank", "'" + Convert.ToString(richTextBox1.Text) + "','" + Convert.ToString(textBox1.Text) + "','" + Convert.ToString(richTextBox2.Text) + "'");
            clear();
            view();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["Phone"].Value.ToString();
            label4.Text = dataGridView1.SelectedRows[0].Cells["Bank ID"].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells["Bank Name"].Value.ToString();
            richTextBox2.Text = dataGridView1.SelectedRows[0].Cells["Booth"].Value.ToString();
            if (dataGridView1.CurrentRow.Selected)
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            
            {
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            view();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _query.Delete("add_bank", "id", "'"+label4.Text+"'");
            clear();
            view();
        }
    }
}
