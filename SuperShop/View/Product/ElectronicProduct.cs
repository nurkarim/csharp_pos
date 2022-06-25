using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.Product
{
    public partial class ElectronicProduct : Form
    {
        public ElectronicProduct()
        {
            InitializeComponent();
            category();
            Brand();
            PDTCODE();
            View();
        }
        Controller.ElectronicProductController _pdtController = new Controller.ElectronicProductController();
        Model.productModel _pdtModel = new Model.productModel();
        DB.query _query = new DB.query();
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;

        public string user { get { return txt_user.Text; } set { txt_user.Text = value; } }

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
        public void PDTCODE()
        {
            try
            {
                int sumId;
                string booth = "P";
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id+1 FROM product order by id desc";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    int getId = dr.GetInt32(0);



                    sumId = Convert.ToInt32(getId);
                    if (0 < sumId)
                    {
                        txt_pdt_code.Text = booth + "00" + sumId.ToString();
                    }
                    else if (10 < sumId)
                    {
                        txt_pdt_code.Text = booth + "00" + sumId.ToString();
                    }
                    else if (99 < sumId && 100 > sumId)
                    {
                        txt_pdt_code.Text = booth + "00" + sumId.ToString();
                    }

                    else if (100 < sumId && 1000 > sumId)
                    {
                        txt_pdt_code.Text = booth + "0" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_pdt_code.Text = booth + "0" + sumId.ToString();

                    }
                    else if (10000 < sumId)
                    {
                        txt_pdt_code.Text = booth + "0" + sumId.ToString();

                    }
                    else
                    {

                        txt_pdt_code.Text = booth + "0" + sumId.ToString();
                    }

                }

                else
                {

                    sumId = Convert.ToInt32(1);
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_pdt_code.Text = booth + "00" + sumId.ToString();
                    }

                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public void genarateId()
        {
            try
            {
                int sumId;
                int booth = Convert.ToInt32(DateTime.Now.ToString("yy"));
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id+1 FROM product order by id desc";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    int getId = dr.GetInt32(0);



                    sumId = Convert.ToInt32(getId);
                    if (0 < sumId )
                    {
                        txtSerialNumber.Text = booth + "0000" + sumId.ToString();
                    }
                    else if (10 < sumId)
                    {
                        txtSerialNumber.Text = booth + "000" + sumId.ToString();
                    }
                    else if (99 < sumId && 100 > sumId)
                    {
                        txtSerialNumber.Text = booth + "000" + sumId.ToString();
                    }

                    else if (100 < sumId && 1000 > sumId)
                    {
                        txtSerialNumber.Text = booth + "000" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txtSerialNumber.Text = booth + "0" + sumId.ToString();

                    }
                    else if (10000 < sumId)
                    {
                        txtSerialNumber.Text = booth + "0" + sumId.ToString();

                    }

                }

                else
                {

                    sumId = Convert.ToInt32(1);
                    if (0 < sumId & 99 > sumId)
                    {
                        txtSerialNumber.Text = booth + "0000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txtSerialNumber.Text = booth + "0000" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txtSerialNumber.Text = booth + "0000" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txtSerialNumber.Text = booth + "0000" + sumId.ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }
        public void View()
        {

            dataGridView1.DataSource = _query.SelectFullTable("select  product.id as 'ID', category.name as 'Product Type',brand_table.Brand_name as 'Brand Name',sub_category.name as 'Category',product.product_name as 'Product Name',product.color as 'Color',product.warrenty as 'Warrenty',product.product_serial_number as 'Serial No',product.rack_no as 'Rack No',product.set_price as 'Price',product.pdt_code as Code from product INNER JOIN category ON product.fk_category_id=category.id INNER JOIN brand_table ON product.fk_brand_id=brand_table.id INNER JOIN sub_category ON product.fk_sub_category_id=sub_category.id group by product.id ");
        }
        private void btnadd_Click(object sender, EventArgs e)
        {
            _pdtController.Brand = Convert.ToString(cmdBrand.SelectedValue);
            _pdtController.Category = Convert.ToString(cmdCategory.SelectedValue);
            _pdtController.Subcategory = Convert.ToString(cmdsubcategory.SelectedValue);
            _pdtController.code = Convert.ToString(txt_pdt_code.Text);
            _pdtController.productName = Convert.ToString(txt_pdt_name.Text);
            _pdtController.productserialcode = Convert.ToString(txtSerialNumber.Text);
            _pdtController.Color = Convert.ToString(txt_color.Text);
            _pdtController.warentiy = Convert.ToString(txt_warrenty.Text);
            _pdtController.RackNo = Convert.ToString(txt_rack.Text);
            _pdtController.purchasePrice = Convert.ToString(txt_price.Text);
            _pdtController.Qty = Convert.ToString(txt_qty.Text);
            if (checkBox1.Checked == true)
            {
                _pdtController.CheckValu = Convert.ToString(checkBox1.Text);

            }
            _pdtModel.saveElectronic(_pdtController);
            View();
            PDTCODE();

            clear();

        }
        public void clear()
        {
            cmdBrand.Text = "";
            cmdCategory.Text = "";
            cmdsubcategory.Text = "";
            txt_color.Text = "";
          
            txt_pdt_name.Text = "";
            txt_qty.Text = "";
            txt_rack.Text = "";
            txt_warrenty.Text = "";
            txt_price.Text = "";
        }
        private void ElectronicProduct_Load(object sender, EventArgs e)
        {
            cmdBrand.Text = "";
            cmdsubcategory.Text = "";
        }

        private void cmdCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmdsubcategory.Text = "";
            SubCategory();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _pdtController.Brand = Convert.ToString(cmdBrand.SelectedValue);
            _pdtController.Category = Convert.ToString(cmdCategory.SelectedValue);
            _pdtController.Subcategory = Convert.ToString(cmdsubcategory.SelectedValue);
            _pdtController.code = Convert.ToString(txt_pdt_code.Text);
            _pdtController.productName = Convert.ToString(txt_pdt_name.Text);
            _pdtController.productserialcode = Convert.ToString(txtSerialNumber.Text);
            _pdtController.Color = Convert.ToString(txt_color.Text);
            _pdtController.warentiy = Convert.ToString(txt_warrenty.Text);
            _pdtController.RackNo = Convert.ToString(txt_rack.Text);
            _pdtController.purchasePrice = Convert.ToString(txt_price.Text);
            _pdtController.productId = Convert.ToString(label12.Text);
            _pdtModel.updateElectronics(_pdtController);
            View();
            clear();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                label12.Text = dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
                cmdCategory.Text = dataGridView1.SelectedRows[0].Cells["Product Type"].Value.ToString();
                cmdBrand.Text = dataGridView1.SelectedRows[0].Cells["Brand Name"].Value.ToString();
                cmdsubcategory.Text = dataGridView1.SelectedRows[0].Cells["Category"].Value.ToString();
                txt_pdt_name.Text = dataGridView1.SelectedRows[0].Cells["Product Name"].Value.ToString();
                txt_color.Text = dataGridView1.SelectedRows[0].Cells["Color"].Value.ToString();
                txt_warrenty.Text = dataGridView1.SelectedRows[0].Cells["Warrenty"].Value.ToString();
                txt_rack.Text = dataGridView1.SelectedRows[0].Cells["Rack No"].Value.ToString();
                txt_price.Text = dataGridView1.SelectedRows[0].Cells["Price"].Value.ToString();
                txt_pdt_code.Text = dataGridView1.SelectedRows[0].Cells["Code"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked==true)
            {
            genarateId();
            }
            else
            {
                txtSerialNumber.Text = "";
            }
            
        }
    }
}
