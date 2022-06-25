using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.View.employee
{
    public partial class addNewEmployee : Form
    {
        public addNewEmployee()
        {
            InitializeComponent();
            
        }
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void view()
        {
            dataGridView1.DataSource = _query.SelectFullTable("select id as 'Id', name as 'Name',phone as 'Phone',email as 'E-mail',desination as 'Designation',age as 'Age',gender as 'Gender',qualification as 'Qualification',address as 'Address' from employee");
          
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "")
            {
                MessageBox.Show("Enter The Name");
                txt_name.Focus();
                return;
            }
            else if (txt_phone.Text == "")
            {
                MessageBox.Show("Enter The Phone");
                txt_phone.Focus();
                return;
            }
            else if (txt_designation.Text == "")
            {
                MessageBox.Show("Enter The Designation");
                txt_designation.Focus();
                return;
            }
            else
            {
                _query.Insert("employee", "name,phone,email,desination,age,gender,qualification,address", "'" + txt_name.Text + "','" + txt_phone.Text + "','" + txt_email.Text + "','" + txt_designation.Text + "','" + txt_age.Text + "','" + comboBox1.Text + "','" + txt_education.Text + "','" + richTextBox1.Text + "'");
                view();
                clear();
            }
        }

        private void addNewEmployee_Load(object sender, EventArgs e)
        {
            view();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                label9.Text = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();

                txt_name.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                txt_phone.Text = dataGridView1.SelectedRows[0].Cells["Phone"].Value.ToString();
                txt_email.Text = dataGridView1.SelectedRows[0].Cells["E-mail"].Value.ToString();
                txt_designation.Text = dataGridView1.SelectedRows[0].Cells["Designation"].Value.ToString();
                txt_age.Text = dataGridView1.SelectedRows[0].Cells["Age"].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells["Gender"].Value.ToString();
                txt_education.Text = dataGridView1.SelectedRows[0].Cells["Qualification"].Value.ToString();
                richTextBox1.Text = dataGridView1.SelectedRows[0].Cells["Address"].Value.ToString();
            }
            catch(Exception)
            {}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(label9.Text!="")
            {
            _query.Update("employee", "name='" + txt_name.Text + "',phone='" + txt_phone.Text + "',email='" + txt_email.Text + "',desination='" + txt_designation.Text + "',age='" + txt_age.Text + "',gender='" + comboBox1.Text + "',qualification='" + txt_education.Text + "',address='" + richTextBox1.Text + "'", "Id", "'" + label9.Text + "'");
            clear();
            view(); 
            }}

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void clear()
        {

            txt_name.Text = "";
            txt_phone.Text = "";
            txt_email.Text = "";
            txt_designation.Text = "";
            txt_age.Text = "";
            comboBox1.Text = "";
            txt_education.Text = "";
            richTextBox1.Text = "";
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            view();
            clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _query.Delete("employee", "Id", "'"+label9.Text+"'");
            view();
            clear();
        }
    }
}
