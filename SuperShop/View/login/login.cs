using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.Caching;
using System.IO;
using System.Reflection;
namespace SuperShop.View.login
{
    public partial class login : Form
    {
        int togmove;
        int mvqlx;
        int mvalv;
        DB.config connect = new DB.config();
        DB.query _dat = new DB.query();
        MySqlConnection conDatabase;
        MySqlCommand cmd;
        public login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          
          
            conDatabase = connect.connection();
            conDatabase.Open();
            cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "SELECT user.id, user.user_type,user.employee_id,user.user_name,check_run_software.software_type,check_run_software.company_id FROM user INNER JOIN check_run_software ON check_run_software.company_id=user.companyId where user_name='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            MySqlDataReader dread = cmd.ExecuteReader();
            
            if (dread.Read())
            {
                 string type = dread["user_type"].ToString();
                if (type == "own" || type == "admin")
                {
                    string id = dread["id"].ToString();
                    string software_type = dread["software_type"].ToString();
                    index obj = new index(id.ToString(), type.ToString(), software_type.ToString());
                    obj.Show();
                    this.Hide();
                }
                else if (type=="saler")
                {

                    string id = dread["id"].ToString();
                    string software_type = dread["software_type"].ToString();
                    this.Hide();
                    View.salesMenDashboard.slaesManDeashboard child = new salesMenDashboard.slaesManDeashboard(id.ToString(),software_type.ToString());
                    child.Show();
                }
            }
            
            dread.Close();
            MySqlCommand cmda = new MySqlCommand();
            cmda.Connection = conDatabase;
            cmda.CommandText = "SELECT company_register.id,company_register.name,company_register.user_name,company_register.type, check_run_software.software_type FROM company_register INNER JOIN check_run_software ON check_run_software.company_id=company_register.id where user_name='" + textBox1.Text + "' and password='" + textBox2.Text + "'";
            MySqlDataReader dreada = cmda.ExecuteReader();
             if (dreada.Read())
            {
                 string id=dreada["id"].ToString();
                 string type = dreada["type"].ToString();
                 string software_type = dreada["software_type"].ToString();
                index obj = new index(id.ToString(),type.ToString(),software_type.ToString());
                obj.Show();
                this.Hide();
            }
            else if (textBox1.Text == "sbit" && textBox2.Text == "sbit123")
            {
                SoftwareConfig.softwareConfigDashboard sh = new SoftwareConfig.softwareConfigDashboard();
                sh.Show();
                this.Hide();
            }
            else 
            {
              
                label1.Text = "Sorry User Name And Password Not Match";
            }


        }

        private void login_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_MouseUp(object sender, MouseEventArgs e)
        {
            togmove = 0;
        }

        private void login_MouseMove(object sender, MouseEventArgs e)
        {
            if (togmove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - mvqlx, MousePosition.Y - mvalv);

            }
        }

        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            togmove = 1;
            mvqlx = e.X;
            mvalv = e.Y;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ctrl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }
        
        private void login_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.Delete("temp.data");
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
