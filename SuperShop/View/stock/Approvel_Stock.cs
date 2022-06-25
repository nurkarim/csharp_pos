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
    public partial class Approvel_Stock : Form
    {
        public Approvel_Stock()
        {
            InitializeComponent();
            views();
            category();
            Brand();
            stockView();
            sum();
            quentity();
            salePrice();
            count();
            SubCategoryNew();
        }
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        Model.StockModel _stockModel = new Model.StockModel();
        Controller.StockController _stockController = new Controller.StockController();
        MySqlConnection conDatabase;
        public void views()
        {
            dataGridView1.DataSource = _query.Select("viewpandingstock");
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

        public void SubCategoryNew()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM sub_category";
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

        public void Stockcategory()
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
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Approvel_Stock_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            Stockcategory();
            comboBox1.Text = "";
            comboBox2.Text = "";
            cmdBrand.Text = "";
            cmdCategory.Text = "";
            cmdsubcategory.Text = "";
        }

   
        private void cmdCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategory();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                cmdCategory.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                cmdsubcategory.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                cmdBrand.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                txtproductName.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                txtNetPrice.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                txtsubpurchasePrice.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                txtweight.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                txtwightType.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                txtpendingStockId.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
                txtQuentity.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
                txtTaxPer.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[11].Value.ToString();
                txtpdtId.Text = dataGridView1.SelectedRows[0].Cells[12].Value.ToString();
                if (txtTaxPer.Text == "0" && textBox5.Text == "0")
                {
                    txtpurchase.Text = txtsubpurchasePrice.Text;
                }
                MySqlCommand cmd = new MySqlCommand("select product.product_name,product.product_serial_number from panding_stock INNER JOIN product ON panding_stock.fk_product_id=product.id where  panding_stock.fk_product_id='" + txtpdtId.Text + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtBarcode.Text = dr["product_serial_number"].ToString();
                
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            clears();
        }
        public void stockView()
    {
        dataGridView2.DataSource = _query.Select("viewstock");
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
                cmd.CommandText = "SELECT id+1 FROM stock order by id desc";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
               
                    if (dr.Read())
                    {

                        int getId = dr.GetInt32(0);
                      
                       
                            txtmaxId.Text = getId.ToString();
                            sumId = Convert.ToInt32(getId);
                            if (0 < sumId & 99 > sumId)
                            {
                                txtBarcode.Text = booth + "00000000" + sumId.ToString();
                            }

                            else if (99 < sumId)
                            {
                                txtBarcode.Text = booth + "0000000" + sumId.ToString();
                            }

                            else if (100 < sumId)
                            {
                                txtBarcode.Text = booth + "000000" + sumId.ToString();

                            }
                            else if (1000 <= sumId)
                            {
                                txtBarcode.Text = booth + "00000" + sumId.ToString();

                            }

                            dr.Close();

                    }
               
                else 
                {

                    sumId = Convert.ToInt32(txtmaxId.Text);
                    if (0 < sumId & 99 > sumId)
                    {
                        txtBarcode.Text = booth + "00000000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txtBarcode.Text = booth + "0000000" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txtBarcode.Text = booth + "000000" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txtBarcode.Text = booth + "00000" + sumId.ToString();

                    }
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            
            }

        }

        public void sum()
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand("select sum(viewstock.`Purchase Price`) as 'purchase' from viewstock", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label24.Text = dr["purchase"].ToString();
                }
                dr.Close();

            }
            catch (Exception)
            { }
        }
      
        public void count()
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand("select count(*) as 'count' from viewstock", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_total_item.Text = dr["count"].ToString();
                }
                dr.Close();

            }
            catch (Exception)
            { }
        }
        public void salePrice()
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand("select sum(viewstock.`Sale Price`) as 'sale' from viewstock", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label25.Text = dr["sale"].ToString();
                }
                dr.Close();

            }
            catch (Exception)
            { }
        }
        public void quentity()
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand("select sum(viewstock.`Quentity`) as 'Quentity' from viewstock", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label26.Text = dr["Quentity"].ToString();
                }
                dr.Close();

            }
            catch (Exception)
            { }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (txtsalePrice.Text != "0" || txtsalePrice.Text != "")
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                _stockController.Brand = Convert.ToString(cmdBrand.SelectedValue);
                _stockController.Category = Convert.ToString(cmdCategory.SelectedValue);
                _stockController.Subcategory = Convert.ToString(cmdsubcategory.SelectedValue);
                _stockController.productId = Convert.ToString(txtpdtId.Text);
                _stockController.pendingStockId = Convert.ToString(txtpendingStockId.Text);
                _stockController.barcode = Convert.ToString(txtBarcode.Text);
                _stockController.NetPrice = Convert.ToString(txtNetPrice.Text);
                _stockController.purchasePrice = Convert.ToString(txtpurchase.Text);
                _stockController.salePrice = Convert.ToString(txtsalePrice.Text);
                _stockController.quentity = Convert.ToString(txtQuentity.Text);
                _stockController.userId = Convert.ToString(txtuserId.Text);
                _stockController.ReackNo = Convert.ToString(txt_rack_no.Text);
                _stockController.ExpDate = Convert.ToString(dateTimePicker1.Text);
                _stockController.Tax = Convert.ToString(txtTaxPer.Text);
                MySqlCommand cmd = new MySqlCommand("select * from stock where fk_product_id='" + txtpdtId.Text + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    _stockModel.update(_stockController);
                    _stockModel.delete(_stockController);
                    dr.Close();
                }
                else
                {
                    _stockModel.save(_stockController);
                    _stockModel.delete(_stockController);
                }
                stockView();

                views();
                clears();
            }
            else
            {
                MessageBox.Show("Please Input the sale price");
            }

        }
        public void clears()
        {

            txtNetPrice.Clear();
            txtproductName.Clear();
            txtpurchase.Clear();
            txtQuentity.Clear();
            txtsalePrice.Clear();
            txtTaxAmt.Clear();
            txtTaxPer.Clear();
            txtweight.Clear();
            txtwightType.Clear();
            txtSubTotal.Clear();
            textBox5.Clear();
            txtsubpurchasePrice.Clear();
            textBox1.Clear();
            txt_rack_no.Clear();
        }
        public string userId { get { return txtuserId.Text; } set { txtuserId.Text = value; } }
        private void button2_Click(object sender, EventArgs e)
        {
            txtNetPrice.Clear();
            txtproductName.Clear();
            txtpurchase.Clear();
            txtQuentity.Clear();
            txtsalePrice.Clear();
            txtTaxAmt.Clear();
            txtTaxPer.Clear();
            txtweight.Clear();
            txtwightType.Clear();
            txtSubTotal.Clear();
            textBox5.Clear();
            txtsubpurchasePrice.Clear();
            textBox1.Clear();
        }

        private void txtQuentity_TextChanged(object sender, EventArgs e)
        {
            try 
            {
            if(txtsubpurchasePrice.Text!="" && txtQuentity.Text!="")
                {

                    double totalSubPurchase;
                    totalSubPurchase = Convert.ToDouble(txtsubpurchasePrice.Text) * Convert.ToDouble(txtQuentity.Text);
                    txtSubTotal.Text = totalSubPurchase.ToString();
                    txtpurchase.Text = txtsubpurchasePrice.ToString();
                    textBox1.Text = totalSubPurchase.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
             {
                if (string.IsNullOrEmpty(txtTaxPer.Text))
                {
                    txtTaxAmt.Text = "";
                    txtpurchase.Text = "";
                    return;
                }
                txtTaxAmt.Text = Convert.ToInt32((Convert.ToDouble(txtSubTotal.Text) * Convert.ToDouble(txtTaxPer.Text) / 100)).ToString();
                textBox1.Text = (Convert.ToDouble(txtSubTotal.Text) + Convert.ToDouble(txtTaxAmt.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox5.Text))
                {
                    textBox5.Text = "";
                    textBox2.Text = "";
                    return;
                }
                textBox2.Text = (Convert.ToDouble(textBox1.Text) - Convert.ToDouble(textBox5.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox2.Text))
                {
                    textBox2.Text = "";
                    txtpurchase.Text = "";
                    return;
                }
                if (txtTaxPer.Text == "0" && textBox5.Text == "0")
                {
                    txtpurchase.Text = txtsubpurchasePrice.Text;
                }
                else
                {
                    txtpurchase.Text = (Convert.ToDouble(textBox2.Text) / Convert.ToDouble(txtQuentity.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                //genarateId();
                txtBarcode.Enabled = false;
            }
            else
            {
                txtBarcode.Clear();
                txtBarcode.Enabled = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txtpurchase.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpurchase_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtsalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {



            }
            else
            {

                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void txtpurchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {



            }
            else
            {

                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txt_rack_no_TextChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void Add_Enter(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBox2.Text = "";
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM sub_category where fk_category_id='" + comboBox1.SelectedValue + "'";
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

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.DataSource = _query.selectWhere("viewstock", "SID='" + comboBox2.SelectedValue + "'");

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            stockView();
        }
    }
}
