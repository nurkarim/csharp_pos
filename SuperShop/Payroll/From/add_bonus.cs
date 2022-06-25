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
    public partial class add_bonus : Form
    {
        public add_bonus()
        {
            InitializeComponent();
            bonusType();
            view();
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

        public void bonusType()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,type_name FROM bonus_type";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox2.DataSource = ds.Tables[0];
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "type_name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void add_bonus_Load(object sender, EventArgs e)
        {
         
            employee();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                try
                {
                    //var category = _categoryModel.dataRead();
                    //comboBox1.DataSource = category;

                    conDatabase = connect.connection();
                    conDatabase.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conDatabase;
                    cmd.CommandText = "select right(attendence.date,8) as 'Month',count(*) as 'total', sum(IF(attendence.`attendance`=1,1,0)) as 'Present',sum(IF(attendence.`attendance`=2,1,0)) as 'Absent',sum(IF(attendence.`attendance`=3,1,0)) as 'Leave',sum(IF(attendence.`attendance`=4,1,0)) as 'Half Leave' from attendence where attendence.fk_employee_id='" + comboBox1.SelectedValue + "' and right(attendence.date,8)='" + dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8) + "'";
                    MySqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        label18.Text = dr["Month"].ToString();
                        txt_present.Text = dr["Present"].ToString();
                        txt_absent.Text = dr["Absent"].ToString();
                        txt_leave.Text = dr["Leave"].ToString();
                        txt_half.Text = dr["Half Leave"].ToString();
                        total_attendance.Text = dr["total"].ToString();
                        label16.Text = comboBox1.Text;
                        dr.Close();
                    }
                    else
                    {
                        txt_present.Text = "0";
                        txt_absent.Text = "0";
                        txt_leave.Text = "0";
                        txt_half.Text = "0";

                    }
                    MySqlCommand cmd1 = new MySqlCommand("select * from employee where id='" + comboBox1.SelectedValue + "'", conDatabase);
                    MySqlDataReader dr1;
                    dr1 = cmd1.ExecuteReader();
                    if (dr1.Read())
                    {
                        textBox1.Text = dr1["desination"].ToString();
                        dr1.Close();
                    }
                    else
                    {
                        textBox1.Text = "";
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else { }
        }

        public void view()
        {

            dataGridView1.DataSource = _query.SelectFullTable("select bonus_history_for_employee.id,bonus_history_for_employee.date as'Date',employee.name as 'Name',bonus_type.type_name as 'Bonus Type',bonus_history_for_employee.bonus_amount as 'Amount' from bonus_history_for_employee left join employee on bonus_history_for_employee.fk_employee_id=employee.id left join bonus_type on bonus_history_for_employee.bonus_type=bonus_type.id ");
        }
        void clear()
        {

            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            txt_present.Text = "0";
            txt_absent.Text = "0";
            txt_leave.Text = "0";
            txt_half.Text = "0";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _query.Insert("bonus_history_for_employee", "date,fk_employee_id,bonus_type,bonus_amount,user_id", "'" + dateTimePicker1.Text + "','" + Convert.ToString(comboBox1.SelectedValue) + "','" + Convert.ToString(comboBox2.SelectedValue) + "','" + Convert.ToString(textBox2.Text) + "','" + Convert.ToString(user_id.Text) + "'");
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand("select * from bonus_master_table where fk_employee_id='" + comboBox1.SelectedValue + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int sum = Convert.ToInt32(dr["bonus_amount"].ToString());
                    int total = sum + Convert.ToInt32(textBox2.Text);
                    _query.Update("bonus_master_table", "bonus_amount='" + total.ToString()+ "'", "fk_employee_id", "'" + comboBox1.SelectedValue + "'");
                    dr.Close();
                }
                else
                {
                    _query.EIInsert("bonus_master_table", "fk_employee_id,bonus_amount", "'" + comboBox1.SelectedValue + "','" + textBox2.Text + "'");
                }
                view();
                clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                _query.Update("bonus_history_for_employee", "date='" + dateTimePicker1.Text + "',fk_employee_id='" + Convert.ToString(comboBox1.SelectedValue) + "',bonus_type='" + Convert.ToString(comboBox2.SelectedValue) + "',bonus_amount='" + Convert.ToString(textBox2.Text) + "',user_id='" + Convert.ToString(user_id.Text) + "'", "id", "'"+label3.Text+"'");
               
                view();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells["Bonus Type"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["Amount"].Value.ToString();
            label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _query.Delete("bonus_history_for_employee", "id", "'"+label3.Text+"'");
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand("select * from bonus_master_table where fk_employee_id='" + comboBox1.SelectedValue + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int sum = Convert.ToInt32(dr["bonus_amount"].ToString());
                    int total = sum - Convert.ToInt32(textBox2.Text);
                    _query.Update("bonus_master_table", "bonus_amount='" + total.ToString() + "'", "fk_employee_id", "'" + comboBox1.SelectedValue + "'");
                    dr.Close();
                }
              
                view();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
