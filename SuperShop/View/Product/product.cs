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
    public partial class product : Form
    {
        public product()
        {
            InitializeComponent();
            view();
            
            genarateId();
            category();
            Brand();
            cmdBrand.Text = "";
            cmdCategory.Text = "";
            cmdsubcategory.Text = "";
        }
        Controller.productController _pdtController = new Controller.productController();
        Model.productModel _pdtModel = new Model.productModel();
        DB.query _query = new DB.query();
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        private void btnadd_Click(object sender, EventArgs e)
        {
            _pdtController.Category = Convert.ToString(cmdCategory.SelectedValue);
            _pdtController.Subcategory = Convert.ToString(cmdsubcategory.SelectedValue);
            _pdtController.Brand = Convert.ToString(cmdBrand.SelectedValue);
            _pdtController.productName = Convert.ToString(txtName.Text);
            _pdtController.Weight = Convert.ToString(txt_weight.Text);
            _pdtController.weightType = Convert.ToString(comboBox1.Text);
            _pdtController.productserialcode = Convert.ToString(txtSerialNumber.Text);
            _pdtController.NetPrice = Convert.ToString(txtNetprice.Text);
            _pdtController.purchasePrice = Convert.ToString(txtPurchase_price.Text);
            _pdtController.Qty = Convert.ToString(txtstock.Text);
            _pdtController.RackNo = Convert.ToString(txt_rack_no.Text);
            if(checkBox1.Checked==true)
            {
            _pdtController.CheckValu = Convert.ToString(checkBox1.Text);
            }
            _pdtModel.save(_pdtController);
            view();
            clear();
        }
        void view()
        {
            dataGridView1.DataSource = _query.Select("viewproduct");
        
        }
        public void clear()
        {
           
            txt_rack_no.Clear();
            txt_weight.Clear();
            txtName.Clear();
            txtNetprice.Clear();
            txtPurchase_price.Clear();
            txtSerialNumber.Clear();
            txtstock.Clear();
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
                cmd.CommandText = "SELECT id,name FROM sub_category where fk_category_id='"+cmdCategory.SelectedValue+"'";
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

        private void cmdCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategory(); 
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        txtSerialNumber.Text = booth + "00000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txtSerialNumber.Text = booth + "0000" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txtSerialNumber.Text = booth + "000" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txtSerialNumber.Text = booth + "00" + sumId.ToString();

                    }


                }

                else
                {

                    sumId = Convert.ToInt32(1);
                    if (0 < sumId & 99 > sumId)
                    {
                        txtSerialNumber.Text = booth + "00000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txtSerialNumber.Text = booth + "0000" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txtSerialNumber.Text = booth + "000" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txtSerialNumber.Text = booth + "00" + sumId.ToString();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void product_Load(object sender, EventArgs e)
        {
           
          
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            cmdBrand.Text = "";
            cmdCategory.Text = "";
            cmdsubcategory.Text = "";
            txt_rack_no.Text = "";
            txt_weight.Text = "";
            txtName.Text = "";
            txtNetprice.Text = "";
            txtPurchase_price.Clear();
            txtstock.Clear();
            genarateId();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                genarateId();
                txtSerialNumber.Enabled = false;
            }
            else
            {
                txtSerialNumber.Clear();
                txtSerialNumber.Enabled = true;
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            txt_pdt_id.Text = dataGridView1.SelectedRows[0].Cells["code"].Value.ToString();
            cmdCategory.Text = dataGridView1.SelectedRows[0].Cells["Product Type"].Value.ToString();
            cmdsubcategory.Text = dataGridView1.SelectedRows[0].Cells["Category"].Value.ToString();
            cmdBrand.Text = dataGridView1.SelectedRows[0].Cells["Brand Name"].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells["Product Name"].Value.ToString();
            txt_weight.Text = dataGridView1.SelectedRows[0].Cells["Weight"].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _pdtController.Category = Convert.ToString(cmdCategory.SelectedValue);
            _pdtController.Subcategory = Convert.ToString(cmdsubcategory.SelectedValue);
            _pdtController.Brand = Convert.ToString(cmdBrand.SelectedValue);
            _pdtController.productName = Convert.ToString(txtName.Text);
            _pdtController.Weight = Convert.ToString(txt_weight.Text);
            _pdtController.weightType = Convert.ToString(comboBox1.Text);
            _pdtController.productserialcode = Convert.ToString(txtSerialNumber.Text);
            _pdtController.NetPrice = Convert.ToString(txtNetprice.Text);
            _pdtController.productId = Convert.ToString(txt_pdt_id.Text);
            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter no. of Product Name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }
            else if (txt_pdt_id.Text == "")
            {
                MessageBox.Show("Please Select The Product", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return;
            }
            else
            {
                _query.Update("product", "fk_brand_id='" + _pdtController.Brand + "',fk_category_id='" + _pdtController.Category + "',fk_sub_category_id='" + _pdtController.Subcategory + "',product_name='" + _pdtController.productName + "',net_weight='" + _pdtController.Weight + "'", "id", "'" + _pdtController.productId + "'");
            }
           // _pdtModel.updateProduct(_pdtController);
            view();
            clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
if(radioButton1.Checked==true)
{
    dataGridView1.DataSource = _query.selectWhere("viewproduct","code='"+richTextBox1.Text+"'");

}
else if (radioButton2.Checked == true)
{
    dataGridView1.DataSource = _query.selectWhere("viewproduct", "Product Name='" + richTextBox1.Text + "'");

}
else
{
    MessageBox.Show("Please Check The Type ");
}
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void txtmaxId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_pdt_id_Click(object sender, EventArgs e)
        {

        }
    }
}
