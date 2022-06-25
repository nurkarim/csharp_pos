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
    public partial class EmployeeManageSalary : Form
    {
        public EmployeeManageSalary()
        {
            InitializeComponent();
            view();
            employee();
        }
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
      

        public string getUser { get { return user_id.Text; } set { user_id.Text = value; } }
        public void employee()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM employee";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EmployeeManageSalary_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name,desination FROM employee where id='" + comboBox1.SelectedValue + "'";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["desination"].ToString();
                  
                    dr.Close();
                }
                else
                {


                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void clear()
        {

            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            label3.Text = "";
        }
        void view()
        {
            dataGridView1.DataSource = _query.SelectFullTable("select employee_manage_salary.id,employee.name as 'Name',employee.desination as 'Designation',employee_manage_salary.salary as 'Salary',user.user_name as 'User Name' from employee_manage_salary left join employee on employee_manage_salary.employee_id=employee.id left join user on employee_manage_salary.created_by=user.id");
        
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != "" && textBox2.Text!="")
           {
               _query.Insert("employee_manage_salary", "employee_id,salary,created_by", "'"+comboBox1.SelectedValue+"','"+textBox2.Text+"','"+user_id.Text+"'");
               view();
               clear();
           }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["Salary"].Value.ToString();
            label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            view();
            clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(label3.Text!="")
            {
                _query.Update("employee_manage_salary", "employee_id='" + comboBox1.SelectedValue + "',salary='" + textBox2.Text + "'", "id", "'" + label3.Text + "'");
                view();
                clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label3.Text != "")
            {
                _query.Delete("employee_manage_salary", "id", "'" + label3.Text + "'");
                view();
                clear();
            }
        }
    }
}
