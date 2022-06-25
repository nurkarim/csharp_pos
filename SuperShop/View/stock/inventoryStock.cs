using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.stock
{
    public partial class inventoryStock : Form
    {
        public inventoryStock()
        {
            InitializeComponent();
            Brand();
            category();
            SubCategory();
            expDate();
            rack();
            product();
            barcode();
        }
        
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        DB.query _query = new DB.query();
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        public void rack()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT rack_no,rack_no FROM stock group by rack_no";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmd_rack.DataSource = ds.Tables[0];
                cmd_rack.ValueMember = "rack_no";
                cmd_rack.DisplayMember = "rack_no";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
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
        public void product()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,product_name FROM product group by id";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmd_product.DataSource = ds.Tables[0];
                cmd_product.ValueMember = "id";
                cmd_product.DisplayMember = "product_name";

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
                cmd.CommandText = "SELECT id,name FROM category";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmdCategory.DataSource = ds.Tables[0];
                cmdCategory.ValueMember = "id";
                cmdCategory.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void expDate()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT exp_date,exp_date FROM stock group by exp_date";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmdexpdate.DataSource = ds.Tables[0];
                cmdexpdate.ValueMember = "exp_date";
                cmdexpdate.DisplayMember = "exp_date";

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
                cmd.CommandText = "SELECT id,name FROM sub_category where fk_category_id='" + cmdCategory.SelectedValue + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmdsubcategory.DataSource = ds.Tables[0];
                cmdsubcategory.ValueMember = "id";
                cmdsubcategory.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void Brand()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,Brand_name FROM brand_table";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmdBrand.DataSource = ds.Tables[0];
                cmdBrand.ValueMember = "id";
                cmdBrand.DisplayMember = "Brand_name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                View.stock.StockList obj = new StockList();
                if (Application.OpenForms.OfType<View.stock.StockList>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.stock.StockList>().First().Close();
                }
                string type = "brand";
                obj.Type = type.ToString();
                obj.Brand = Convert.ToString(cmdBrand.SelectedValue);
                obj.MdiParent = index.ActiveForm;
                obj.Show();
            }
            else if (radioButton2.Checked == true)
            {
                View.stock.StockList obj = new StockList();
                if (Application.OpenForms.OfType<View.stock.StockList>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.stock.StockList>().First().Close();
                }
                string type = "category";
                obj.Type = type.ToString();
                obj.Category = Convert.ToString(cmdCategory.SelectedValue);
                obj.MdiParent = index.ActiveForm;
                obj.Show();
            }
            else if (radioButton3.Checked == true)
            {
                View.stock.StockList obj = new StockList();
                if (Application.OpenForms.OfType<View.stock.StockList>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.stock.StockList>().First().Close();
                }
                string type = "subcategory";
                obj.Type = type.ToString();
                obj.Category = Convert.ToString(cmdCategory.SelectedValue);
                obj.SubCategory = Convert.ToString(cmdsubcategory.SelectedValue);
                obj.MdiParent = index.ActiveForm;
                obj.Show();
            }
            else if (radioButton4.Checked == true)
            {
                View.stock.StockList obj = new StockList();
                if (Application.OpenForms.OfType<View.stock.StockList>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.stock.StockList>().First().Close();
                }
                string type = "expDate";
                obj.Type = type.ToString();
                obj.ExpDate = Convert.ToString(cmdexpdate.SelectedValue);
                obj.MdiParent = index.ActiveForm;
                obj.Show();
            }
            else if (radioButton5.Checked == true)
            {
                View.stock.StockList obj = new StockList();
                if (Application.OpenForms.OfType<View.stock.StockList>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.stock.StockList>().First().Close();
                }
                string type = "rack";
                obj.Type = type.ToString();
                obj.Rack = Convert.ToString(cmd_rack.SelectedValue);
                obj.MdiParent = index.ActiveForm;
                obj.Show();
            }
            else if (radioButton6.Checked == true)
            {
                View.stock.StockList obj = new StockList();
                if (Application.OpenForms.OfType<View.stock.StockList>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.stock.StockList>().First().Close();
                }
                string type = "pdtName";
                obj.Type = type.ToString();
                obj.DynamekDate = Convert.ToString(cmd_product.SelectedValue);
                obj.MdiParent = index.ActiveForm;
                obj.Show();
            }
            else if (radioButton7.Checked == true)
            {
                View.stock.StockList obj = new StockList();
                if (Application.OpenForms.OfType<View.stock.StockList>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.stock.StockList>().First().Close();
                }
                string type = "barcode";
                obj.Type = type.ToString();
                obj.DynamekDate = Convert.ToString(cmd_barcode.SelectedValue);
                obj.MdiParent = index.ActiveForm;
                obj.Show();
            }

        }

        private void inventoryStock_Load(object sender, EventArgs e)
        {
            cmdsubcategory.Text = "";
            cmdexpdate.Text = "";
            cmdCategory.Text = "";
            cmdBrand.Text = "";
            cmd_rack.Text = "";
            cmd_product.Text = "";
            cmd_barcode.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmd_rack_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmdCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategory();
        }
    }
}
