using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySqlQuery;
using MySql.Data.MySqlClient;
using System.Drawing.Drawing2D;
namespace SuperShop.View.BesicSetup
{
    public partial class Brand : Form
    {
        public Brand()
        {
            InitializeComponent();
            genarateId();
        }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        Controller.BrandController _brandController = new Controller.BrandController();
        Model.BrandModel _brandModels=new Model.BrandModel();
       
        DB.query query = new DB.query();
        private void Brand_Load(object sender, EventArgs e)
        {
            try
            {

                dataGridView1.DataSource = query.SelectFullTable("SELECT Brand_id as 'Brand Id',Brand_name as 'Brand Name' From brand_table");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void genarateId()
        {try
            {
            int sumId;

            conDatabase = connect.connection();
            conDatabase.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "SELECT count(id) From  brand_table";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                int getId = dr.GetInt32(0);
                string count = getId.ToString();
                sumId = Convert.ToInt32(getId) + 1;
                if (0 < sumId & 99 > sumId)
                {
                    txtBrand_Id.Text = "0000" + sumId.ToString();
                }

                else if (99 < sumId)
                {
                    txtBrand_Id.Text = "000" + sumId.ToString();
                }

                else if (1000 == sumId)
                {
                    txtBrand_Id.Text = "000" + sumId.ToString();

                }
            }
            
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        public void message()
        {
            this.notifyIcon1.BalloonTipText = "Save Success";
            this.notifyIcon1.BalloonTipTitle = "Message";
            ShowInTaskbar = false;
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(1000);
        }
       

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {

                _brandController.BrandId = Convert.ToString(txtBrand_Id.Text);
                _brandController.BrandName = txt_name.Text;
                _brandController.Year = Convert.ToString(dateTimePicker1.Text);
                _brandModels.saveBrand(_brandController);
                dataGridView1.DataSource = query.SelectFullTable("SELECT Brand_id as 'Brand Id',Brand_name as 'Brand Name' From brand_table ");
                message();
                genarateId();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {

                _brandController.BrandId = Convert.ToString(txtBrand_Id.Text);
                _brandController.BrandName = Convert.ToString(txt_name.Text) ;

                if (_brandController.BrandName == "")
                {
                    MessageBox.Show("Please Input Name");
                }
                else if (_brandController.BrandId == "")
                {
                    MessageBox.Show("Please Input Id");
                }
                else
                {
                   
                    query.Update("brand_table", "Brand_name='"+_brandController.BrandName+"'", "Brand_id", "'" + _brandController.BrandId + "'");
                }

                dataGridView1.DataSource = query.SelectFullTable("SELECT Brand_id as 'Brand Id',Brand_name as 'Brand Name' From brand_table ");


                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            txt_name.Clear();
            dataGridView1.DataSource = query.SelectFullTable("SELECT Brand_id as 'Brand Id',Brand_name as 'Brand Name' From brand_table ");
            genarateId();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //txt_name.Text = row.Cells["Brand Name"].Value.ToString();
            ///txtBrand_Id.Text = row.Cells["Brand Id"].Value.ToString();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                txt_name.Text = dataGridView1.SelectedRows[0].Cells["Brand Name"].Value.ToString();
                txtBrand_Id.Text = dataGridView1.SelectedRows[0].Cells["Brand Id"].Value.ToString();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

   

        
    }
}
