using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.BesicSetup
{
    public partial class Category : Form
    {
        private DB.query _query;
        public Category()
        {
            InitializeComponent();
            _query = new DB.query();
            //items();
            view();

        }


        Model.categoryModel _categoryModel;
        Controller.categoryController _categoryController=new Controller.categoryController();
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        MySqlCommand cmd;

        public void view()
        {

            dataGridView1.DataSource = _query.SelectFullTable("SELECT category.id as 'ID',category.name as 'Name' From category group by id");
        }

        private void Category_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(""+comboBox1.SelectedValue);
        }
        public void items()
        {
            try
            {
               // var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM item";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                //comboBox1.DataSource = ds.Tables[0];
                //comboBox1.ValueMember = "id";
                //comboBox1.DisplayMember = "name";
                  //while (dread.Read())
                //{
                    //data = dread["name"].ToString() + "," + dread["id"].ToString();
                    //data = dread["name"].ToString();
                   
                //} 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("ID"+comboBox1.SelectedValue);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
           //string date= DateTime.Now.AddYears(1).ToString();
           //MessageBox.Show("" + date);
            try
            {
                _categoryModel = new Model.categoryModel();

                _categoryController.categoryName = Convert.ToString(textBox1.Text);
                _categoryModel.save(_categoryController);
                view();
                textBox1.Clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            label2.Text = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please Select The Category");
                return;
            }
            else if(label2.Text==""){MessageBox.Show("please Select Product"); return;}
            else{

                _query.Update("category", "name='" + Convert.ToString(textBox1.Text) + "'", "id", "'" + Convert.ToString(label2.Text) + "'");
                view();
                 textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (label2.Text=="")
            {
                MessageBox.Show("Please Select Rows");
            }
            else
            {
            
         
            _query.Delete("category", "id", "'" + Convert.ToString(label2.Text) + "'");
            view();
            textBox1.Clear();
        }   }

        
    }
}
