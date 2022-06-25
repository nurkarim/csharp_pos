using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.purchase
{
    public partial class purchase : Form
    {
        public purchase()
        {
            InitializeComponent();
            ProducstName();
            autocomplite();
            supplyerName();
            genarateId();
        }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        DB.query _query = new DB.query();
        Controller.purchaseController _purchaseController = new Controller.purchaseController();
        Model.purchaseModel _purchase_model = new Model.purchaseModel();
        private void purchase_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "";
            comboBox4.Text = "";

            if (software_type.Text == "Electronics")
            {
                label20.Visible = false;
                textBox3.Visible = false;
                txt_qty_type.Visible = false;
                txt_quentity.Size = new Size(140, 26);
            }
            else if (software_type.Text == "Garments")
            {
           
            }
            
        }
        public string getBooth { get { return txt_booth_no.Text; } set { txt_booth_no.Text = value; } }
        public string getUser { get { return txt_user_id.Text; } set { txt_user_id.Text = value; } }
        public string softwareType { get { return software_type.Text; } set { software_type.Text = value; } }
        public void con()
        {

            conDatabase = connect.connection();
            if (conDatabase.State == ConnectionState.Open)
            {
                conDatabase.Close();
            }
            conDatabase.Open();
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
                cmd.CommandText = "SELECT count(id)+1 FROM purchase_table where left(created_at,4)=left(" + DateTime.Now.ToString("yyyy") + ",4) order by id desc";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    int getId = dr.GetInt32(0);


                    txt_voucher_no.Text = getId.ToString();
                    sumId = Convert.ToInt32(getId);
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_voucher_no.Text = booth + "000" + sumId.ToString();
                    }

                    else if (99 < sumId & 100 > sumId)
                    {
                        txt_voucher_no.Text = booth  + "00" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_voucher_no.Text = booth  + "00" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_voucher_no.Text = booth + "0" + sumId.ToString();

                    }

                    dr.Close();
                }

                else
                {

                    sumId = Convert.ToInt32(1);
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_voucher_no.Text = booth  + "000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txt_voucher_no.Text = booth  + "00" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_voucher_no.Text = booth + "00" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_voucher_no.Text = booth  + "0" + sumId.ToString();

                    }

                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        public void ProducstName()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,product_name FROM product";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "product_name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void supplyerName()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM supplyer_table";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox4.DataSource = ds.Tables[0];
                comboBox4.ValueMember = "id";
                comboBox4.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            txt_qty_type.Clear();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void autocomplite()
        {
            conDatabase = connect.connection();
            conDatabase.Open();
            txtScanSearch.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtScanSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection namec = new AutoCompleteStringCollection();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "select product_serial_number,id from product";
            MySqlDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    double code = dr.GetInt64("product_serial_number");
                    double codes = dr.GetInt64("id");
                    namec.Add(code.ToString());
                    namec.Add(codes.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtScanSearch.AutoCompleteCustomSource = namec;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear();
           
        }
        void productSelectserialNumber()
        {
            conDatabase = connect.connection();
            conDatabase.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "select * from product where product_serial_number='" + txtScanSearch.Text + "' or id='" + txtScanSearch.Text + "'";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                comboBox1.Text = dr["product_name"].ToString();
                txt_net_price.Text = dr["set_price"].ToString();
                txt_product_name.Text = dr["product_name"].ToString();
                txt_category.Text = dr["fk_category_id"].ToString();
                txt_subCategory.Text = dr["fk_sub_category_id"].ToString();
                txt_brand.Text = dr["fk_brand_id"].ToString();
                textBox3.Text = dr["net_weight"].ToString();

            }

        }
        void productSelectTable()
        {
            conDatabase = connect.connection();
            conDatabase.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "select * from product where id='"+comboBox1.SelectedValue+"'";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
        if(dr.Read())
        {
            txtScanSearch.Text = dr["product_serial_number"].ToString();
            txt_net_price.Text = dr["set_price"].ToString();
            txt_product_name.Text = dr["product_name"].ToString();
            txt_category.Text = dr["fk_category_id"].ToString();
            txt_subCategory.Text = dr["fk_sub_category_id"].ToString();
            txt_brand.Text = dr["fk_brand_id"].ToString();
            textBox3.Text = dr["net_weight"].ToString();
            

        }
        
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            productSelectTable();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            conDatabase = connect.connection();
            conDatabase.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "select * from supplyer_table where id='" + comboBox4.SelectedValue + "'";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_suplyer_phone.Text = dr["phone"].ToString();
               
            }
        }

        private void textBox15_MouseClick(object sender, MouseEventArgs e)
        {
            txt_purchase_Price.Text = "";
            txt_quentity.Enabled = true;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_quentity.Text))
                {
                    
                    txt_sub_price.Text="00.00";
                    txt_total_amount_cart.Text = "00.00";
                    
                    return;
                }
                txt_sub_price.Text = (Convert.ToDouble(txt_purchase_Price.Text) * Convert.ToDouble(txt_quentity.Text)).ToString();
                txt_total_amount_cart.Text = txt_sub_price.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_vat_price_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_vat_price.Text))
                {
                    txt_total_amount_cart.Text = (Convert.ToDouble(txt_total_amount_cart.Text) - Convert.ToDouble(txt_text_price.Text)).ToString();
                    txt_text_price.Text = "00.00";
                   
                    return;
                }
                txt_text_price.Text = Convert.ToInt32((Convert.ToDouble(txt_sub_price.Text) * Convert.ToDouble(txt_vat_price.Text) / 100)).ToString();
                txt_total_amount_cart.Text = (Convert.ToDouble(txt_sub_price.Text) + Convert.ToDouble(txt_text_price.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_sub_discount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txt_sub_discount.Text))
                {

                    
                    txt_total_amount_cart.Text = (Convert.ToDouble(txt_total_amount_cart.Text) + Convert.ToDouble(textBox1.Text)).ToString();
                    txt_sub_discount.Text = "";
                    return;
                }
                else
                {
                    textBox1.Text = txt_sub_discount.Text;
                    txt_total_amount_cart.Text = (Convert.ToDouble(txt_total_amount_cart.Text) - Convert.ToDouble(txt_sub_discount.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_sub_discount_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_sub_discount_MouseClick(object sender, MouseEventArgs e)
        {
            txt_sub_discount.Clear();
        }

        private void txtScanSearch_TextChanged(object sender, EventArgs e)
        {
            productSelectserialNumber();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            salecart();
        }
        public double subtot()
        {

            int i = 0;
            int j = 0;
            int k = 0;
            i = 0;
            j = 0;
            k = 0;

            try
            {
                j = ListView1.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToInt32(ListView1.Items[i].SubItems[8].Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return k;

        }
        public void salecart()
        {
            try
            {
                if (Convert.ToString(comboBox1.SelectedValue) == "")
                {
                    MessageBox.Show("Please retrieve product name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txt_purchase_Price.Text == "")
                {
                    MessageBox.Show("Please enter no. of purchase price", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_purchase_Price.Focus();
                    return;
                }
                int SaleQty = Convert.ToInt32(txt_quentity.Text);
                if (SaleQty == 0)
                {
                    MessageBox.Show("no. of sale quantity can not be zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_quentity.Focus();
                    return;
                }

                if (ListView1.Items.Count == 0)
                {

                    ListViewItem lst = new ListViewItem();

                    lst.SubItems.Add(Convert.ToString(comboBox1.SelectedValue));
                    lst.SubItems.Add(txt_product_name.Text);
                    lst.SubItems.Add(txt_net_price.Text);
                    lst.SubItems.Add(txt_purchase_Price.Text);
                    lst.SubItems.Add(txt_quentity.Text);
                    lst.SubItems.Add(txt_sub_price.Text);
                    lst.SubItems.Add(txt_vat_price.Text);
                    lst.SubItems.Add(txt_total_amount_cart.Text);
                    lst.SubItems.Add(txt_sub_discount.Text);
                    lst.SubItems.Add(txt_qty_type.Text);
                    lst.SubItems.Add(txt_category.Text);
                    lst.SubItems.Add(txt_subCategory.Text);
                    lst.SubItems.Add(txt_brand.Text);
                    lst.SubItems.Add(textBox3.Text);
                    
                    ListView1.Items.Add(lst);
                    txt_sub_total.Text = subtot().ToString();
                    comboBox1.Text = "";
                    txt_sub_price.Text = "";
                    txtScanSearch.Text = "";
                    txt_total_amount_cart.Text = "00.00";
                    txt_quentity.Text = "";
                    txt_purchase_Price.Text = "";
                    txt_net_price.Text = "";
                    textBox3.Text = "";
                    textBox1.Text = "";
                    return;
                }

                for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                {

                    if (ListView1.Items[j].SubItems[1].Text == Convert.ToString(comboBox1.SelectedValue))
                    {
                        ListView1.Items[j].SubItems[1].Text = Convert.ToString(comboBox1.SelectedValue);
                        ListView1.Items[j].SubItems[2].Text = txt_product_name.Text;
                        ListView1.Items[j].SubItems[3].Text = txt_net_price.Text;
                        ListView1.Items[j].SubItems[4].Text = txt_purchase_Price.Text;
                        ListView1.Items[j].SubItems[5].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[5].Text) + Convert.ToInt32(txt_quentity.Text)).ToString();
                        ListView1.Items[j].SubItems[6].Text = txt_sub_price.Text;
                        ListView1.Items[j].SubItems[7].Text = txt_vat_price.Text;
                        ListView1.Items[j].SubItems[8].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[8].Text) + Convert.ToInt32(txt_total_amount_cart.Text)).ToString();
                        ListView1.Items[j].SubItems[9].Text = Convert.ToString(txt_sub_discount.Text);
                        ListView1.Items[j].SubItems[10].Text = Convert.ToString(txt_qty_type.Text);
                        ListView1.Items[j].SubItems[11].Text = Convert.ToString(txt_category.Text);
                        ListView1.Items[j].SubItems[12].Text = Convert.ToString(txt_subCategory.Text);
                        ListView1.Items[j].SubItems[13].Text = Convert.ToString(txt_brand.Text);
                        ListView1.Items[j].SubItems[14].Text = Convert.ToString(textBox3.Text);                        
                        ListView1.Items[j].SubItems[1].Text = Convert.ToString(comboBox1.SelectedValue);

                        txt_sub_total.Text = subtot().ToString();
                        comboBox1.Text = "";
                        txtScanSearch.Text = "";
                        txt_sub_price.Text = "";
                        txt_quentity.Text = "";
                        txt_purchase_Price.Text = "";
                        txt_net_price.Text = "";
                        txt_total_amount_cart.Text = "00.00";
                        textBox3.Text = "";
                        textBox1.Text = "";
                        return;
                    }


                }

                ListViewItem lst1 = new ListViewItem();


                lst1.SubItems.Add(Convert.ToString(comboBox1.SelectedValue));
                lst1.SubItems.Add(txt_product_name.Text);
                lst1.SubItems.Add(txt_net_price.Text);
                lst1.SubItems.Add(txt_purchase_Price.Text);
                lst1.SubItems.Add(txt_quentity.Text);
                lst1.SubItems.Add(txt_sub_price.Text);
                lst1.SubItems.Add(txt_vat_price.Text);
                lst1.SubItems.Add(txt_total_amount_cart.Text);
                lst1.SubItems.Add(txt_sub_discount.Text);
                lst1.SubItems.Add(txt_qty_type.Text);
                lst1.SubItems.Add(txt_category.Text);
                lst1.SubItems.Add(txt_subCategory.Text);
                lst1.SubItems.Add(txt_brand.Text);
                lst1.SubItems.Add(textBox3.Text);

                ListView1.Items.Add(lst1);
                txt_sub_total.Text = subtot().ToString();
                comboBox1.Text = "";
                txtScanSearch.Text = "";
                txt_sub_price.Text = "";
                txt_quentity.Text = "";
                txt_purchase_Price.Text = "";
                txt_net_price.Text = "";
                txt_total_amount_cart.Text = "00.00";
                textBox1.Text = "";
                textBox3.Text = "";
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void removeCart()
        {
            try
            {
                if (ListView1.Items.Count == 0)
                {
                    MessageBox.Show("No items to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int itmCnt = 0;
                    int i = 0;
                    int t = 0;

                    ListView1.FocusedItem.Remove();
                    itmCnt = ListView1.Items.Count;
                    t = 1;

                    for (i = 1; i <= itmCnt + 1; i++)
                    {
                        //Dim lst1 As New ListViewItem(i)
                        //ListView1.Items(i).SubItems(0).Text = t
                        t = t + 1;

                    }
                    txt_sub_total.Text = subtot().ToString();
                }


                if (ListView1.Items.Count == 0)
                {
                    txt_sub_total.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            removeCart();
        }

        public void clear()
        {
            comboBox4.Text = "";
            txt_suplyer_phone.Text = "";
            txt_vat.Text = "";
            txt_discount.Text = "00.00";
            txt_due_amount.Text = "00.00";
            txt_total_amount.Text = "00.00";
            txt_lable_total_amount.Text = "00.00";
            txt_sub_total.Text = "00.00";
            txt_note.Text = "";
            txt_paid_type.Text = "";
            for (int k = 0; k <= ListView1.Items.Count - 1; k++)
            {
                ListView1.Items[k].Remove();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con();
            try
            {
                DB.query _querys = new DB.query();
               
                _purchaseController.Date = Convert.ToString(dateTimePicker1.Text);
                _purchaseController.VoucherNo = Convert.ToString(txt_voucher_no.Text);
                _purchaseController.Suplyer = Convert.ToString(comboBox4.SelectedValue);
                _purchaseController.phone = Convert.ToString(txt_suplyer_phone.Text);
                _purchaseController.TotalSubAmount = Convert.ToString(txt_sub_total.Text);
                _purchaseController.Total_Vat = Convert.ToString(txt_vat.Text);
                _purchaseController.Total_Discount = Convert.ToString(txt_discount.Text);
                _purchaseController.TotalPurchaseAmount = Convert.ToString(txt_total_amount.Text);
                _purchaseController.Paid_amount = Convert.ToString(txt_paid_amount.Text);
                _purchaseController.Due = Convert.ToString(txt_due_amount.Text);
                _purchaseController.User = Convert.ToString(txt_user_id.Text);
                _purchaseController.Booth = Convert.ToString(txt_booth_no.Text);
                _purchaseController.Note = Convert.ToString(txt_note.Text);
                _purchaseController.PaidType = Convert.ToString(txt_paid_type.Text);

                if (txt_voucher_no.Text == "")
                {

                    return;
                }
                else
                {
                    _query.InsertA("purchase_table", "date,invoice_no,suplyer_id,supplyer_phone,sub_total,vat,discount,total_amount,paid,due,paid_type,user_id,booth,note,bill_no", "'" + _purchaseController.Date + "','" + _purchaseController.VoucherNo + "','" + _purchaseController.Suplyer + "','" + _purchaseController.phone + "','" + _purchaseController.TotalSubAmount + "','" + _purchaseController.Total_Vat + "','" + _purchaseController.Total_Discount + "','" + _purchaseController.TotalPurchaseAmount + "','" + _purchaseController.Paid_amount + "','" + _purchaseController.Due + "','" + _purchaseController.PaidType + "','" + _purchaseController.User + "','" + _purchaseController.Booth + "','" + _purchaseController.Note + "','" + _purchaseController.BillNo + "'");


                    for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                    {


                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conDatabase;
                        cmd.CommandText = "insert into purchase_cart (fk_purchase_id,fk_product_id,net_price,purchase_price,qty,qty_type,sub_price,vat,discount,total_price) values (@fk_purchase_id,@fk_product_id,@net_price,@purchase_price,@qty,@qty_type,@sub_price,@vat,@discount,@total_price)";
                        cmd.Parameters.AddWithValue("fk_purchase_id", _query.LastId);
                        cmd.Parameters.AddWithValue("fk_product_id", Convert.ToString(ListView1.Items[i].SubItems[1].Text));
                        cmd.Parameters.AddWithValue("net_price", Convert.ToString(ListView1.Items[i].SubItems[3].Text));
                        cmd.Parameters.AddWithValue("purchase_price", Convert.ToString(ListView1.Items[i].SubItems[4].Text));
                        cmd.Parameters.AddWithValue("qty", Convert.ToString(ListView1.Items[i].SubItems[5].Text));
                        cmd.Parameters.AddWithValue("qty_type", Convert.ToString(ListView1.Items[i].SubItems[10].Text));
                        cmd.Parameters.AddWithValue("sub_price", Convert.ToString(ListView1.Items[i].SubItems[6].Text));
                        cmd.Parameters.AddWithValue("vat", Convert.ToString(ListView1.Items[i].SubItems[7].Text));
                        cmd.Parameters.AddWithValue("discount", Convert.ToString(ListView1.Items[i].SubItems[9].Text));
                        cmd.Parameters.AddWithValue("total_price", Convert.ToString(ListView1.Items[i].SubItems[8].Text));
                        cmd.ExecuteNonQuery();

                    }
                    for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                    {
                        MySqlCommand cmdC = new MySqlCommand();
                        cmdC.Connection = conDatabase;
                        cmdC.CommandText = "insert into panding_stock (fk_product_id,fk_category_id,fk_brand_id,fk_subcategory_id,net_price,purchase_price,net_weight,weigth_type,stock,vat,discount,fk_purchase_id) values ('" + Convert.ToString(ListView1.Items[j].SubItems[1].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[11].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[13].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[12].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[3].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[4].Text) + "','"+Convert.ToString(ListView1.Items[j].SubItems[14].Text)+"','" + Convert.ToString(ListView1.Items[j].SubItems[10].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[5].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[7].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[9].Text) + "','" + _query.LastId + "') ";
                        cmdC.ExecuteNonQuery();
                        
                    }
                  
                    }
                    genarateId();
                    clear();
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
            

        }

        private void txt_vat_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_vat.Text=="")
                {
                    //txt_total_amount_cart.Text = (Convert.ToDouble(txt_total_amount_cart.Text) - Convert.ToDouble(txt_tax_amount.Text)).ToString();
                    txt_tax_amount.Text = "0";

                    return;
                }
                txt_tax_amount.Text = Convert.ToDouble((Convert.ToDouble(txt_sub_total.Text) * Convert.ToDouble(txt_vat.Text) / 100)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_discount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {

                if (string.IsNullOrEmpty(txt_discount.Text))
                {


                    txt_total_amount.Text = (Convert.ToDouble(txt_sub_total.Text) + Convert.ToDouble(txt_tax_amount.Text)).ToString();
                    txt_sub_discount.Text = "";
                    txt_discount.Text = "0";
                    return;
                }
                else
                {
                    textBox1.Text = txt_discount.Text;
                    txt_total_amount.Text = (Convert.ToDouble(txt_total_amount.Text) - Convert.ToDouble(txt_discount.Text)).ToString();
                }
            }}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_paid_amount_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txt_paid_amount.Text))
                {
                    txt_due_amount.Text = txt_total_amount.Text;

                    return;
                }
                else
                {
                   
                    txt_due_amount.Text = (Convert.ToDouble(txt_total_amount.Text) - Convert.ToDouble(txt_paid_amount.Text)).ToString();
                    if (txt_paid_amount.Text == txt_total_amount.Text)
                    {
                     txt_paid_type.Text = "Paid";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_sub_total_TextChanged(object sender, EventArgs e)
        {
            txt_total_amount.Text = txt_sub_total.Text;
            txt_due_amount.Text = txt_sub_total.Text;
            txt_discount.Text = "";
        }

        private void txt_total_amount_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txt_total_amount_TextChanged(object sender, EventArgs e)
        {
            txt_due_amount.Text = txt_total_amount.Text;
            txt_lable_total_amount.Text = txt_total_amount.Text;
            txt_paid_amount.Text = "";
        }

        private void txt_sub_price_TextChanged(object sender, EventArgs e)
        {
            txt_sub_discount.Text = "0";
        }

        private void txt_discount_MouseClick(object sender, MouseEventArgs e)
        {
            txt_discount.Text = "";
        }

        private void txt_paid_amount_MouseClick(object sender, MouseEventArgs e)
        {
            txt_paid_amount.Text = "";
        }

        private void txt_due_amount_TextChanged(object sender, EventArgs e)
        {
            if (txt_due_amount.Text == "0")
            {
                txt_paid_type.Text = "Paid";
            
            }
            else if (txt_paid_amount.Text != "" && txt_due_amount.Text != "")
            {
                txt_paid_type.Text = "Partial left";
            }
            else if (txt_due_amount.Text != "0") 
            {
                txt_paid_type.Text = "Due";
            
            }
        }

        private void txt_net_price_TextChanged(object sender, EventArgs e)
        {
            txt_qty_type.Text = "";
            txt_purchase_Price.Text = "";
            txt_quentity.Enabled=false;
        }

        private void txt_net_price_MouseClick(object sender, MouseEventArgs e)
        {
            txt_net_price.Text = "";
        }

        private void txt_quentity_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_tax_amount_TextChanged(object sender, EventArgs e)
        {
            txt_total_amount.Text = (Convert.ToDouble(txt_sub_total.Text) + Convert.ToDouble(txt_tax_amount.Text)).ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }
}
