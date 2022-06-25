using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.ClothSHop
{
    public partial class purchaseCloth : Form
    {
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        Controller.purchaseController _purchaseController = new Controller.purchaseController();
        DB.query _query = new DB.query();
        Model.purchaseModel _purchase_model = new Model.purchaseModel();
        public purchaseCloth(string value)
        {
            InitializeComponent();
            ProducstName();
            autocomplite();
            supplyerName();
            genarateId();
        }
        public void con()
        {

            conDatabase = connect.connection();
            if (conDatabase.State == ConnectionState.Open)
            {
                conDatabase.Close();
            }
            conDatabase.Open();
        }
        public string getBooth { get { return txt_booth_no.Text; } set { txt_booth_no.Text = value; } }
        public string getUser { get { return txt_user_id.Text; } set { txt_user_id.Text = value; } }
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
                cmd_suplyer_name.DataSource = ds.Tables[0];
                cmd_suplyer_name.ValueMember = "id";
                cmd_suplyer_name.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            cmd.CommandText = "select product_serial_number from product";
            MySqlDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    double code = dr.GetInt64("product_serial_number");
                    
                    namec.Add(code.ToString());
                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtScanSearch.AutoCompleteCustomSource = namec;
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
                txt_product_id.DataSource = ds.Tables[0];
                txt_product_id.ValueMember = "id";
                txt_product_id.DisplayMember = "product_name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       public  void productSelectserialNumber()
        {
            conDatabase = connect.connection();
            conDatabase.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "select * from product where product_serial_number='" + txtScanSearch.Text + "'";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_product_id.Text = dr["product_name"].ToString();
                txt_product_name.Text = dr["product_name"].ToString();
                txt_category.Text = dr["fk_category_id"].ToString();
                txt_subCategory.Text = dr["fk_sub_category_id"].ToString();
                txt_brand.Text = dr["fk_brand_id"].ToString();
                

            }

        }
        public void productSelectTable()
        {
            conDatabase = connect.connection();
            conDatabase.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "select * from product where id='" + txt_product_id.SelectedValue + "'";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtScanSearch.Text = dr["product_serial_number"].ToString();
                txt_product_name.Text = dr["product_name"].ToString();
                txt_category.Text = dr["fk_category_id"].ToString();
                txt_subCategory.Text = dr["fk_sub_category_id"].ToString();
                txt_brand.Text = dr["fk_brand_id"].ToString();
            }

        }
        private void purchaseCloth_Load(object sender, EventArgs e)
        {
            cmd_suplyer_name.Text = "";
            txt_product_id.Text = "";
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
                    k = k + Convert.ToInt32(ListView1.Items[i].SubItems[5].Text);
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
                if (txt_product_name.Text == "")
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

                    lst.SubItems.Add(Convert.ToString(txt_product_id.SelectedValue));
                    lst.SubItems.Add(txt_product_name.Text);
                    lst.SubItems.Add(txt_purchase_Price.Text);
                    lst.SubItems.Add(txt_quentity.Text);
                    lst.SubItems.Add(txt_total_amount_cart.Text);
                    lst.SubItems.Add(txt_category.Text);
                    lst.SubItems.Add(txt_subCategory.Text);
                    lst.SubItems.Add(txt_brand.Text);
                    ListView1.Items.Add(lst);
                    txt_sub_total.Text = subtot().ToString();
                    txtScanSearch.Text = "";
                    txt_total_amount_cart.Text = "00.00";
                    txt_quentity.Text = "";
                    txt_purchase_Price.Text = "";
                    
                    return;
                }

                for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                {

                    if (ListView1.Items[j].SubItems[1].Text == Convert.ToString(txt_product_id.SelectedValue))
                    {
                        ListView1.Items[j].SubItems[1].Text = Convert.ToString(txt_product_id.SelectedValue);
                        ListView1.Items[j].SubItems[2].Text = Convert.ToString(txt_product_name.Text); ;
                       
                        ListView1.Items[j].SubItems[3].Text = txt_purchase_Price.Text;
                        ListView1.Items[j].SubItems[4].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[4].Text) + Convert.ToInt32(txt_quentity.Text)).ToString();
                       
                        ListView1.Items[j].SubItems[5].Text = (Convert.ToInt32(ListView1.Items[j].SubItems[5].Text) + Convert.ToInt32(txt_total_amount_cart.Text)).ToString();
                       
                        ListView1.Items[j].SubItems[6].Text = Convert.ToString(txt_category.Text);
                        ListView1.Items[j].SubItems[7].Text = Convert.ToString(txt_subCategory.Text);
                        ListView1.Items[j].SubItems[8].Text = Convert.ToString(txt_brand.Text);
                       
                        ListView1.Items[j].SubItems[1].Text = Convert.ToString(txt_product_id.SelectedValue);

                        txt_sub_total.Text = subtot().ToString();
                   
                        txtScanSearch.Text = "";
                       
                        txt_quentity.Text = "";
                        txt_purchase_Price.Text = "";
                      
                        txt_total_amount_cart.Text = "00.00";
                      
                       
                        return;
                    }


                }

                ListViewItem lst1 = new ListViewItem();


                lst1.SubItems.Add(Convert.ToString(txt_product_id.SelectedValue));
                lst1.SubItems.Add(txt_product_name.Text);
                
                lst1.SubItems.Add(txt_purchase_Price.Text);
                lst1.SubItems.Add(txt_quentity.Text);
            
                lst1.SubItems.Add(txt_total_amount_cart.Text);
             
                lst1.SubItems.Add(txt_category.Text);
                lst1.SubItems.Add(txt_subCategory.Text);
                lst1.SubItems.Add(txt_brand.Text);
              

                ListView1.Items.Add(lst1);
                txt_sub_total.Text = subtot().ToString();
                
                txtScanSearch.Text = "";
                
                txt_quentity.Text = "";
                txt_purchase_Price.Text = "";
               
                txt_total_amount_cart.Text = "00.00";
              
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

        private void txt_vat_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_vat.Text))
                {
                    txt_total_amount_cart.Text = (Convert.ToDouble(txt_total_amount_cart.Text) - Convert.ToDouble(txt_tax_amount.Text)).ToString();
                    txt_tax_amount.Text = "00.00";

                    return;
                }
                txt_tax_amount.Text = Convert.ToInt32((Convert.ToDouble(txt_sub_total.Text) * Convert.ToDouble(txt_vat.Text) / 100)).ToString();
                txt_total_amount.Text = (Convert.ToDouble(txt_sub_total.Text) + Convert.ToDouble(txt_tax_amount.Text)).ToString();
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

                if (string.IsNullOrEmpty(txt_discount.Text))
                {


                    txt_total_amount.Text = (Convert.ToDouble(txt_total_amount.Text) + Convert.ToDouble(txt_sub.Text)).ToString();
                   
                    return;
                }
                else
                {
                    txt_sub.Text = txt_discount.Text;
                    txt_total_amount.Text = (Convert.ToDouble(txt_total_amount.Text) - Convert.ToDouble(txt_discount.Text)).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void txt_quentity_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_quentity.Text))
                {

                    txt_total_amount_cart.Text = "00.00";
                    

                    return;
                }
                txt_total_amount_cart.Text = (Convert.ToDouble(txt_purchase_Price.Text) * Convert.ToDouble(txt_quentity.Text)).ToString();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cmd.CommandText = "SELECT id+1 FROM purchase_table order by id desc";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    int getId = dr.GetInt32(0);


                    txt_voucher_no.Text = getId.ToString();
                    sumId = Convert.ToInt32(getId);
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_voucher_no.Text = booth +  "00000000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txt_voucher_no.Text = booth +"0000000" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_voucher_no.Text = booth + "000000" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_voucher_no.Text = booth + "00000" + sumId.ToString();

                    }

                    dr.Close();
                }

                else
                {

                    sumId = Convert.ToInt32(1);
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_voucher_no.Text = booth + "00000000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txt_voucher_no.Text = booth + "0000000" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_voucher_no.Text = booth +  "000000" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_voucher_no.Text = booth +  "00000" + sumId.ToString();

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            productSelectTable();
        }

        private void txtScanSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (string.IsNullOrEmpty(txtScanSearch.Text))
                {
                    txt_product_id.Text = "";
                    txt_product_name.Text = "";
                    return;
                }
                else 
                {
                    productSelectserialNumber();
                
                }
            }
            catch(Exception ex)
            {
            MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            salecart();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            removeCart();
        }

        private void cmd_suplyer_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            conDatabase = connect.connection();
            conDatabase.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "select * from supplyer_table where id='" + cmd_suplyer_name.SelectedValue + "'";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_suplyer_phone.Text = dr["phone"].ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con();
            try
            {
                DB.query _querys = new DB.query();

                _purchaseController.Date = Convert.ToString(dateTimePicker1.Text);
                _purchaseController.VoucherNo = Convert.ToString(txt_voucher_no.Text);
                _purchaseController.Suplyer = Convert.ToString(cmd_suplyer_name.SelectedValue);
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
                        cmd.CommandText = "insert into purchase_cart (fk_purchase_id,fk_product_id,purchase_price,qty,total_price) values (@fk_purchase_id,@fk_product_id,@purchase_price,@qty,@total_price)";
                        cmd.Parameters.AddWithValue("fk_purchase_id", _query.LastId);
                        cmd.Parameters.AddWithValue("fk_product_id", Convert.ToString(ListView1.Items[i].SubItems[1].Text));
                        cmd.Parameters.AddWithValue("purchase_price", Convert.ToString(ListView1.Items[i].SubItems[3].Text));
                        cmd.Parameters.AddWithValue("qty", Convert.ToString(ListView1.Items[i].SubItems[4].Text));
                        cmd.Parameters.AddWithValue("total_price", Convert.ToString(ListView1.Items[i].SubItems[5].Text));
                        cmd.ExecuteNonQuery();

                        //_query.Insert("purchase_cart", "fk_purchase_id,fk_product_id,net_price,purchase_price,qty,qty_type,sub_price,vat,discount,total_price", "'" + _query.LastId + "','" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[3].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[4].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[5].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[10].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[6].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[7].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[9].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[8].Text) + "'");


                    }
                    for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                    {
                        MySqlCommand cmdC = new MySqlCommand();
                        cmdC.Connection = conDatabase;
                        cmdC.CommandText = "insert into panding_stock (fk_product_id,fk_category_id,fk_brand_id,fk_subcategory_id,purchase_price,stock,fk_purchase_id) values ('" + Convert.ToString(ListView1.Items[j].SubItems[1].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[6].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[8].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[7].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[3].Text) + "','" + Convert.ToString(ListView1.Items[j].SubItems[4].Text) + "','" + _query.LastId + "') ";
                        cmdC.ExecuteNonQuery();
                        //fk_product_id,fk_category_id,fk_brand_id,fk_subcategory_id,purchase_price,stock,
                    }

                }
                genarateId();
                clear();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
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

        private void txt_total_amount_TextChanged(object sender, EventArgs e)
        {
            txt_due_amount.Text = txt_total_amount.Text;
            txt_lable_total_amount.Text = txt_total_amount.Text;
        }

        private void txt_discount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_discount_MouseClick(object sender, MouseEventArgs e)
        {
            txt_discount.Text = "";
        }

        private void txt_sub_total_TextChanged(object sender, EventArgs e)
        {
            txt_total_amount.Text = txt_sub_total.Text;
            txt_discount.Text = "0";
            txt_vat.Text = "0";
        }
        public void clear()
        {
            txt_due_amount.Clear();
            txt_note.Clear();
            txt_tax_amount.Text = "00";
            txt_sub_total.Text = "00";
            txt_discount.Text = "00";
            txt_vat.Text = "0";
            txt_total_amount.Text = "00";
            txt_lable_total_amount.Text = "00.00";
            txt_paid_amount.Clear();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            clear();
            for (int k = 0; k <= ListView1.Items.Count - 1; k++)
            {
                ListView1.Items[k].Remove();
            }
        }

        private void txt_quentity_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
