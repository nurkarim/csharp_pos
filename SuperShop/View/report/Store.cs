using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.report
{
    public partial class Store : Form
    {
        public Store()
        {
            InitializeComponent();
            barcode();
            category();
           
        }
        public string SoftwareType { get { return label7.Text; } set { label7.Text = value; } }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        public void barcode()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,barcode_id FROM stock group by barcode_id";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmd_barcode.DataSource = ds.Tables[0];
                cmd_barcode.ValueMember = "id";
                cmd_barcode.DisplayMember = "barcode_id";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void category()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM category group by id";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox2.DataSource = ds.Tables[0];
                comboBox2.ValueMember = "id";
                comboBox2.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SubCategory()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM sub_category where fk_category_id='" + comboBox2.SelectedValue+ "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox3.DataSource = ds.Tables[0];
                comboBox3.ValueMember = "id";
                comboBox3.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                if (radioButton1.Checked == true)
                {
                    CrystalReport.stock.Report_view obj = new CrystalReport.stock.Report_view();
                    obj.Type = "all";
                    obj.SoftwareType = label7.Text;
                    obj.Show();
                }
                else if (radioButton2.Checked==true)
                {
                    CrystalReport.stock.Report_view obj = new CrystalReport.stock.Report_view();
                    obj.Type = "exp";
                    obj.SoftwareType = label7.Text;
                    obj.Date1 = dateTimePicker1.Text;
                    obj.Show();
                }
                else if (radioButton4.Checked == true)
                {
                    CrystalReport.stock.Report_view obj = new CrystalReport.stock.Report_view();
                    obj.Type = "cat";
                    obj.Date1 = Convert.ToInt32(comboBox2.SelectedValue).ToString();
                    obj.SoftwareType = label7.Text;
                    obj.Show();
                }
                else if (radioButton5.Checked == true)
                {
                    CrystalReport.stock.Report_view obj = new CrystalReport.stock.Report_view();
                    obj.Type = "scat";
                    obj.Date1 = Convert.ToInt32(comboBox3.SelectedValue).ToString();
                    obj.SoftwareType = label7.Text;
                    obj.Show();
                }
                else if (radioButton3.Checked == true)
                {
                    if (textBox1.Text != "")
                    {
                        int a = -1;
                        int b = -1;
                    
                        MySqlCommand cmd = new MySqlCommand("delete from  print_barcode_product", conDatabase);
                        a = cmd.ExecuteNonQuery();
                       
                        if (a>0)
                        {
                            
                            for (int i = 1; i <= Convert.ToInt32(textBox1.Text); i++)
                            {
                                MySqlCommand cmda = new MySqlCommand("insert into print_barcode_product (fk_stock_id) values ('" + cmd_barcode.SelectedValue + "')", conDatabase);
                                b = cmda.ExecuteNonQuery();
                            }

                            CrystalReport.stock.Report_view obj = new CrystalReport.stock.Report_view();
                            obj.Type = "barcode";
                           obj.Date1 = Convert.ToInt32(cmd_barcode.SelectedValue).ToString();
                           obj.SoftwareType = label7.Text;
                           obj.Show();
                           

                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Get The Number Of Input");
                    }


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked==true)
            {
                panel2.Enabled = true;
            }
            else
            {
                panel2.Enabled = false;

            }
        }

        private void Store_Load(object sender, EventArgs e)
        {
            comboBox2.Text = "";
            comboBox3.Text = "";
            cmd_barcode.Text = "";
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategory();
        }
    }
}
