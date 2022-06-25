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
    public partial class employee_attendance : Form
    {
        public employee_attendance()
        {
            InitializeComponent();
            employee();
        }
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
        string attendace;
        string attendaceText;

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
    void clear()
    {
        comboBox1.Text = "";
        textBox1.Text = "";
        radioButton1.Checked = false;
        radioButton2.Checked =false;
        radioButton3.Checked = false;
        radioButton4.Checked = false;
    }
        private void employee_attendance_Load(object sender, EventArgs e)
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
                    txt_employee_name.Text = dr["name"].ToString();
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

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(comboBox1.SelectedValue) == "")
                {
                    MessageBox.Show("Please retrieve Employee name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
           

                if (listView1.Items.Count == 0)
                {

                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(Convert.ToString(comboBox1.SelectedValue));
                    lst.SubItems.Add(txt_employee_name.Text);
                    lst.SubItems.Add(attendaceText.ToString());
                    lst.SubItems.Add(Convert.ToString(dateTimePicker1.Text));
                    lst.SubItems.Add(dateTimePicker2.Text);
                    lst.SubItems.Add(attendace.ToString());

                    //lst.SubItems.Add(txt_weight.Text);
                    //lst.SubItems.Add(cmd_weight_type.Text);

                    listView1.Items.Add(lst);
                    comboBox1.Text = "";
                    radioButton1.Checked = false;
                    radioButton2.Checked = false;
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    // txt_weight.Text = "";
                    // cmd_weight_type.Text = "";
                    return;
                }

                for (int j = 0; j <= listView1.Items.Count - 1; j++)
                {
                    if (listView1.Items[j].SubItems[1].Text == Convert.ToString(comboBox1.SelectedValue))
                    {
                        listView1.Items[j].SubItems[1].Text = Convert.ToString(comboBox1.SelectedValue);
                        listView1.Items[j].SubItems[2].Text = txt_employee_name.Text;
                        listView1.Items[j].SubItems[3].Text = attendaceText.ToString();
                        listView1.Items[j].SubItems[4].Text = (Convert.ToString(dateTimePicker1.Text)).ToString();
                        listView1.Items[j].SubItems[5].Text = (Convert.ToString(dateTimePicker2.Text)).ToString();
                         listView1.Items[j].SubItems[6].Text = Convert.ToString(attendace.ToString());
                        
                        comboBox1.Text = "";
                        radioButton1.Checked = false;
                        radioButton2.Checked = false;
                        radioButton3.Checked = false;
                        radioButton4.Checked = false;
                        // txt_weight.Text = "";
                        //cmd_weight_type.Text = "";
                        return;

                    }
                }

                ListViewItem lst1 = new ListViewItem();

                lst1.SubItems.Add(Convert.ToString(comboBox1.SelectedValue));
                lst1.SubItems.Add(txt_employee_name.Text);
                lst1.SubItems.Add(attendaceText.ToString());
                lst1.SubItems.Add(Convert.ToString(dateTimePicker1.Text));
                lst1.SubItems.Add(dateTimePicker2.Text);
                lst1.SubItems.Add(attendace.ToString());

                listView1.Items.Add(lst1);

                comboBox1.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                // txt_weight.Text = "";
                //cmd_weight_type.Text = "";
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
              
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                attendace = "1";
                attendaceText = "P";
            }
            else 
            {
                attendace = "0";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                attendace = "2";
                attendaceText = "A";
            }
            else
            {
                attendace = "0";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                attendace = "3";
                attendaceText = "L";

            }
            else
            {
                attendace = "0";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                attendace = "4";
                attendaceText = "H";

            }
            else
            {
                attendace = "0";
            }
        }

        void clearss()
        {
            dateTimePicker3.Text = "";
            comboBox1.Text = "";
            textBox1.Text = "";
            for (int k = 0; k <= listView1.Items.Count - 1; k++)
            {
                listView1.Items[k].Remove();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    if (Convert.ToString(listView1.Items[i].SubItems[1].Text) != "" || Convert.ToString(listView1.Items[i].SubItems[1].Text) != "0")
                    {
                        _query.EIInsert("attendence", "date,fk_employee_id,attendance,in_time,out_time,user_id", "'" + Convert.ToString(dateTimePicker3.Text) + "','" + Convert.ToString(listView1.Items[i].SubItems[1].Text) + "','" + Convert.ToString(listView1.Items[i].SubItems[6].Text) + "','" + Convert.ToString(listView1.Items[i].SubItems[4].Text) + "','" + Convert.ToString(listView1.Items[i].SubItems[5].Text) + "','" + user_id.Text + "'");
                    }
                }
            
                    clearss();
             
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView1.Items.Count == 0)
                {
                    MessageBox.Show("No items to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int itmCnt = 0;
                    int i = 0;
                    int t = 0;

                    listView1.FocusedItem.Remove();
                    itmCnt = listView1.Items.Count;
                    t = 1;

                    for (i = 1; i <= itmCnt + 1; i++)
                    {
                        //Dim lst1 As New ListViewItem(i)
                        //ListView1.Items(i).SubItems(0).Text = t
                        t = t + 1;

                    }
                  
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clearss();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i <= listView1.Items.Count - 1; i++)
                {
                    if (Convert.ToString(listView1.Items[i].SubItems[1].Text) != "" || Convert.ToString(listView1.Items[i].SubItems[1].Text) !="0")
                    {
                        _query.UpdateAndWhere("attendence", "date='" + Convert.ToString(dateTimePicker3.Text) + "',attendance='" + Convert.ToString(listView1.Items[i].SubItems[6].Text) + "',in_time='" + Convert.ToString(listView1.Items[i].SubItems[4].Text) + "',out_time='" + Convert.ToString(listView1.Items[i].SubItems[5].Text) + "',user_id='" + user_id.Text + "'", "fk_employee_id='" + Convert.ToString(listView1.Items[i].SubItems[1].Text) + "' and date='" + dateTimePicker3.Text + "'");
                    }
                }
                clearss();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
