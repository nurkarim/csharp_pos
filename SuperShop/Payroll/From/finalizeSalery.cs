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
    public partial class finalizeSalery : Form
    {
        public finalizeSalery()
        {
            InitializeComponent();
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
        private void finalizeSalery_Load(object sender, EventArgs e)
        {
            employee();
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {  try
                {
            if (checkBox1.Checked == true)
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
            MySqlCommand cmd2 = new MySqlCommand("select * from employee_manage_salary where employee_id='" + comboBox1.SelectedValue + "'", conDatabase);
            MySqlDataReader dr2;
            dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                textBox2.Text = dr2["salary"].ToString();
                dr2.Close();
            }
            else
            {
                textBox2.Text = "0";
            }
            conDatabase = connect.connection();
            conDatabase.Close();
            conDatabase.Open();
            MySqlCommand cmd2a = new MySqlCommand("select * from bonus_master_table where fk_employee_id='" + comboBox1.SelectedValue + "'", conDatabase);
            MySqlDataReader dr2a;
            dr2a = cmd2a.ExecuteReader();
            if (dr2a.Read())
            {
                textBox3.Text = dr2a["bonus_amount"].ToString();
                dr2a.Close();
            }
            else
            {
                textBox3.Text = "0";
            }
            }

            textBox4.Text = (Convert.ToInt32(textBox2.Text) + Convert.ToInt32(textBox3.Text)).ToString();

          }
        catch (Exception )
        {
           
        }
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
        void clear()
        {
            comboBox1.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
        
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                if (comboBox1.Text != "" && textBox4.Text != "")
                {
                    MySqlCommand cmds = new MySqlCommand("select employee_id,month from employee_finalize_salary where employee_id='" + comboBox1.SelectedValue + "' and month='" + DateTime.Now.ToString("MMM-yyyy") + "'", conDatabase);
                    MySqlDataReader dsr;
                    dsr = cmds.ExecuteReader();

                   if (dsr.Read())
                  {
                      MessageBox.Show("Already Add This Salary");
                      dsr.Close();
                  }
                  else
                  {
                      dsr.Close();
                      conDatabase.Close();
                      conDatabase = connect.connection();
                      conDatabase.Open();
                    _query.Insert("employee_finalize_salary", "employee_id,date,month,year,payable,bonus,total", "'" + comboBox1.SelectedValue + "','" + dateTimePicker1.Text + "','" + DateTime.Now.ToString("MMM-yyy") + "','" + DateTime.Now.ToString("yyyy") + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'");
                    MySqlCommand cmd = new MySqlCommand("select employee_id,balance from employee_master_account where employee_id='" + comboBox1.SelectedValue + "'", conDatabase);
                    MySqlDataReader drr;
                    drr = cmd.ExecuteReader();
                    if (drr.Read())
                    {
                        double total = Convert.ToDouble(drr["balance"].ToString()) + Convert.ToDouble(textBox4.Text);
                        _query.Update("employee_master_account", "balance='" + total.ToString() + "'", "employee_id", "'" + comboBox1.SelectedValue + "'");
                        drr.Close();
                    }
                    else
                    {
                        _query.EIInsert("employee_master_account", "employee_id,employee_name,balance", "'" + comboBox1.SelectedValue + "','" + comboBox1.Text + "','" + Convert.ToInt32(textBox4.Text) + "'");
                    }

                    if (Convert.ToInt32(textBox3.Text) > 0)
                    {

                        _query.Update("bonus_master_table", "bonus_amount='" + 0 + "'", "fk_employee_id", "'" + comboBox1.SelectedValue + "'");

                    }

                    clear();
                }
                }
                else { MessageBox.Show("Input Required"); }
            }
            catch(Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
                e.Handled = true;
        }
    }
}
