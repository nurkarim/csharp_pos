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
    public partial class clothProduct : Form
    {
        public clothProduct()
        {
            InitializeComponent();
            genarateId();
            category();
            Brand();
            View();
            clear();
        }

        Controller.clothProductController _controller = new Controller.clothProductController();
        Model.productModel _model = new Model.productModel();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
        DB.config connect = new DB.config();

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
                cmb_brand.DataSource = ds.Tables[0];
                cmb_brand.ValueMember = "id";
                cmb_brand.DisplayMember = "Brand_name";

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
                cmb_sub_category.Text = "";
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM sub_category where fk_category_id='" + cmb_category.SelectedValue + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmb_sub_category.DataSource = ds.Tables[0];
                cmb_sub_category.ValueMember = "id";
                cmb_sub_category.DisplayMember = "name";

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
                cmb_category.DataSource = ds.Tables[0];
                cmb_category.ValueMember = "id";
                cmb_category.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            _controller.Brand = Convert.ToString(cmb_brand.SelectedValue);
            _controller.Category = Convert.ToString(cmb_category.SelectedValue);
            _controller.SubCategory = Convert.ToString(cmb_sub_category.SelectedValue);
            _controller.Pdt_Code = Convert.ToString(txt_pdt_code.Text);
            _controller.PdtType = Convert.ToString(txt_pdt_type.Text);
            _controller.Pdt_id = Convert.ToString(txt_pdt_id.Text);
            _controller.SerialNo = Convert.ToString(txt_serial_no.Text);
            _controller.RackNo = Convert.ToString(txt_rack_no.Text);
            _controller.PurchasePrice = Convert.ToString(txt_purchase_price.Text);
            _controller.Quentity = Convert.ToString(txt_quentity.Text);
            
            if (checkBox1.Checked == true)
            {
                _controller.CheckValue = Convert.ToString(checkBox1.Text);
            
            }

            _model.saveCloth(_controller);
            genarateId();
            View();
            clear();
        }

        void clear()
        {
            cmb_brand.Text = "";
            cmb_category.Text = "";
            cmb_sub_category.Text = "";

            txt_pdt_code.Text = "";
            txt_pdt_type.Text = "";
            txt_purchase_price.Text = "";
            txt_quentity.Text = "";
            txt_rack_no.Text = "";
            genarateId();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            _controller.Brand = Convert.ToString(cmb_brand.SelectedValue);
            _controller.Category = Convert.ToString(cmb_category.SelectedValue);
            _controller.SubCategory = Convert.ToString(cmb_sub_category.SelectedValue);
            _controller.Pdt_Code = Convert.ToString(txt_pdt_code.Text);
            _controller.PdtType = Convert.ToString(txt_pdt_type.Text);
            _controller.Pdt_id = Convert.ToString(txt_pdt_id.Text);
            _controller.SerialNo = Convert.ToString(txt_serial_no.Text);
            _controller.RackNo = Convert.ToString(txt_rack_no.Text);
            _model.updateCloth(_controller);
            View();
            clear();
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
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_serial_no.Text = booth + "00000000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txt_serial_no.Text = booth + "0000000" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_serial_no.Text = booth + "000000" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_serial_no.Text = booth + "00000" + sumId.ToString();

                    }


                }

                else
                {

                    sumId = Convert.ToInt32(1);
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_serial_no.Text = booth + "00000000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txt_serial_no.Text = booth + "0000000" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_serial_no.Text = booth + "000000" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_serial_no.Text = booth + "00000" + sumId.ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                txt_pdt_id.Text = dataGridView1.SelectedRows[0].Cells["Id"].Value.ToString();
                cmb_category.Text = dataGridView1.SelectedRows[0].Cells["Category"].Value.ToString();
                cmb_brand.Text = dataGridView1.SelectedRows[0].Cells["Brand Name"].Value.ToString();
                cmb_sub_category.Text = dataGridView1.SelectedRows[0].Cells["Sub Category"].Value.ToString();
                txt_pdt_code.Text = dataGridView1.SelectedRows[0].Cells["Product Code"].Value.ToString();
                txt_pdt_type.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                txt_rack_no.Text = dataGridView1.SelectedRows[0].Cells["Rack No"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmb_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategory();
        }
        public void View()
        {
            dataGridView1.DataSource = _query.SelectFullTable("SELECT product.id as'Id', category.name as'Category',brand_table.Brand_name as 'Brand Name',sub_category.name as 'Sub Category',product.pdt_code as 'Product Code',product.product_name as'Name',product.product_serial_number as 'Serial No',product.rack_no as 'Rack No' from product INNER JOIN category ON product.fk_category_id=category.id INNER JOIN brand_table ON product.fk_brand_id=brand_table.id INNER JOIN sub_category ON product.fk_sub_category_id=sub_category.id group by product.id ");
        }
        private void txt_purchase_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {



            }
            else
            {

                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clothProduct_Load(object sender, EventArgs e)
        {
            cmb_brand.Text = "";
            cmb_category.Text = "";
            cmb_sub_category.Text = "";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label6.Visible = true;
                txt_purchase_price.Visible = true;
                label9.Visible = true;
                txt_quentity.Visible = true;
                label10.Visible = true;
                txt_rack_no.Visible = true;
            }
            else { 
            label6.Visible = false;
                txt_purchase_price.Visible = false;
                label9.Visible = false;
                txt_quentity.Visible = false;
                label10.Visible = false;
                txt_rack_no.Visible = false;
            }
            
        }
    }
}
