using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Drawing.Printing;
using System.Runtime.Caching;

namespace SuperShop.View.sale
{
    public partial class Sale : Form
    {
        public Sale()
        {
            InitializeComponent();
            genarateId();
            supplyerName();
            ProducstName();
            category();
            autocomplite();
            views();
        }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        DB.query _query = new DB.query();
        Controller.SaleController _saleController = new Controller.SaleController();
        Model.SaleModel _saleModel = new Model.SaleModel();
        public string Booth { get { return txt_booth_no.Text; } set { txt_booth_no.Text = value; } }
      
        public string getUser { get { return txt_user_id.Text; } set { txt_user_id.Text = value; } }
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
                cmd_product_id.DataSource = ds.Tables[0];
                cmd_product_id.ValueMember = "id";
                cmd_product_id.DisplayMember = "product_name";

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
                cmd.CommandText = "SELECT id,name FROM sub_category where fk_category_id='" + comboBox2.SelectedValue + "'";
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

        public void ProducstNameSubCategory()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,product_name FROM product where fk_sub_category_id='" + comboBox3.SelectedValue + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmd_product_id.DataSource = ds.Tables[0];
                cmd_product_id.ValueMember = "id";
                cmd_product_id.DisplayMember = "product_name";

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
            cmd.CommandText = "select barcode_id from stock";
            MySqlDataReader dr;
            try
            {
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    double code = dr.GetInt64("barcode_id");

                    namec.Add(code.ToString());

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            txtScanSearch.AutoCompleteCustomSource = namec;
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
                cmd.CommandText = "SELECT id,customer_name FROM customer_info where status='1'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmdCustomerId.DataSource = ds.Tables[0];
                cmdCustomerId.ValueMember = "id";
                cmdCustomerId.DisplayMember = "customer_name";

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
                cmd.CommandText = "SELECT count(id)+1 FROM voucher where left(created_at,4)=left(" + DateTime.Now.ToString("yyyy") + ",4) order by id desc";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    int getId = dr.GetInt32(0);


                    txt_voucher_no.Text = getId.ToString();
                    sumId = Convert.ToInt32(getId);
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_voucher_no.Text = "INV-"+booth + "000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + "00" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + "0" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + "0" + sumId.ToString();

                    }

                    
                }

                else
                {

                    sumId = Convert.ToInt32(1);
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + "000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + "000" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_voucher_no.Text = "sl-" + booth + "00" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + "0" + sumId.ToString();

                    }

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        public void Flush()
        {
            List<string> cacheKeys = MemoryCache.Default.Select(kvp => kvp.Key).ToList();
            foreach (string cacheKey in cacheKeys)
            {
                MemoryCache.Default.Remove(cacheKey);
            }
        }

        void currency()
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();

                MySqlCommand cmd = new MySqlCommand("select currency_id from  currency_active", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label17.Text = dr["currency_id"].ToString();
                }
            }
            catch(Exception)
            {
            }
        }
        private void Sale_Load(object sender, EventArgs e)
        {
            Flush();
            cmdCustomerId.Text = "";
            cmd_product_id.Text = "";
            currency();
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
        private void btnadd_Click(object sender, EventArgs e)
        {
            con();
         
            try
            {
               
                _saleController.Date = Convert.ToString(dateTimePicker1.Text);
                _saleController.CustomerId = Convert.ToString(cmdCustomerId.SelectedValue);
                _saleController.CustomerName = Convert.ToString(txt_customer_Name.Text);
                _saleController.CustomerPhone = Convert.ToString(txt_phone.Text);
                _saleController.VoucherId = Convert.ToString(txt_voucher_no.Text);
                _saleController.SubTotal = Convert.ToString(txtSubTotal.Text);
                _saleController.Vat = Convert.ToString(txt_vat.Text);
                _saleController.Discount = Convert.ToString(txt_discount.Text);
                _saleController.TotalAmount = Convert.ToString(txt_total_amount.Text);
                _saleController.Paid = Convert.ToString(txt_paid_amount.Text);
                _saleController.Due = Convert.ToString(txt_due_amount.Text);
                _saleController.Type = Convert.ToString(txt_paid_type.Text);
                _saleController.PaidType = Convert.ToString(txt_check_paid.Text);
                _saleController.CheckNumber = Convert.ToString(txt_check_no.Text);
                _saleController.Note = Convert.ToString(txt_sale_note.Text);
                _saleController.UserName = Convert.ToString(txt_user_id.Text);
                _saleController.Booth = Convert.ToString(txt_booth_no.Text);
                _saleController.Currency = Convert.ToString(label17.Text);
                if (txt_due_amount.Text != "" && txt_due_amount.Text != "0")
                { 
                if(cmdCustomerId.Text!="")
                {
                    _query.InsertA("voucher", "date,customer_id,customer_name,phone,custom_voucher_id,subtotal_amount,vat,discount,total_amount,paid,due,type,paid_type,paid_type_check_number,note,user_id,booth_no,currency_id", "'" + _saleController.Date + "','" + _saleController.CustomerId + "','" + _saleController.CustomerName + "','" + _saleController.CustomerPhone + "','" + _saleController.VoucherId + "','" + _saleController.SubTotal + "','" + _saleController.Vat + "','" + _saleController.Discount + "','" + _saleController.TotalAmount + "','" + _saleController.Paid + "','" + _saleController.Due + "','" + _saleController.Type + "','" + _saleController.PaidType + "','" + _saleController.CheckNumber + "','" + _saleController.Note + "','" + _saleController.UserName + "','" + _saleController.Booth + "','" + _saleController.Currency + "'");
                    
                    for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("insert into sale_cart (voucher_id,fk_product_id,sale_price,qty,sub_total_price,pack) values ('" + _query.LastId + "','" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[3].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[4].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[5].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[6].Text) + "')", conDatabase);
                    cmd.ExecuteNonQuery();
      
                }
                lastGetID.Text = _query.LastId;
                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("update stock set qty=qty-'" + Convert.ToDouble(ListView1.Items[i].SubItems[4].Text) + "' where fk_product_id='" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "'", conDatabase);
                    cmd.ExecuteNonQuery();

                }
                if (txt_due_amount.Text == "0") { } else if (txt_due_amount.Text == "") { }
                else if (txt_due_amount.Text != "0" || txt_due_amount.Text != "")
                {

                    try
                    {
                        _query.Insert("customer_ladger_book", "date,customer_name,customer_id,phone,voucher_id,discription,debit_amount,blance", "'" + _saleController.Date + "','" + _saleController.CustomerName + "','" + _saleController.CustomerId + "','" + _saleController.CustomerPhone + "','" + _saleController.VoucherId + "','Sale','" + _saleController.Due + "','" + _saleController.TotalAmount + "'");

                        MySqlCommand cmdB = new MySqlCommand("select * from customer_master_ladger_book where customer_id='" + cmdCustomerId.SelectedValue + "'", conDatabase);
                        MySqlDataReader drs;

                        drs = cmdB.ExecuteReader();
                        if (drs.Read())
                        {
                            label10.Text = drs["customer_id"].ToString();
                            if (label10.Text == Convert.ToString(cmdCustomerId.SelectedValue))
                            {
                                drs.Close();
                                MySqlCommand cmda = new MySqlCommand("update  customer_master_ladger_book set debit_amount=debit_amount+'" + _saleController.Due + "' where customer_id='" + cmdCustomerId.SelectedValue + "'", conDatabase);
                                cmda.ExecuteNonQuery();

                            }

                        }
                        else
                        {
                            drs.Close();
                            MySqlCommand cmde = new MySqlCommand("insert into customer_master_ladger_book (customer_id,customer_name,date,debit_amount) values('" + _saleController.CustomerId + "','" + _saleController.CustomerName + "','" + _saleController.Date + "','" + _saleController.Due + "')", conDatabase);
                            cmde.ExecuteNonQuery();
                        }

                    }
                    catch (Exception)
                    {

                    }
                }
                else
                { }
                    //end due text amount check
                
                        clear();
                    genarateId();
                    if (checkBox2.Checked == true)
                    {
                        print();
                    }
                
                }
                else
                {
                MessageBox.Show("Please Select The Customer Name");
                }
                }
                    //end text customer name check
                else
                {
                    _query.InsertA("voucher", "date,customer_id,customer_name,phone,custom_voucher_id,subtotal_amount,vat,discount,total_amount,paid,due,type,paid_type,paid_type_check_number,note,user_id,booth_no,currency_id", "'" + _saleController.Date + "','" + _saleController.CustomerId + "','" + _saleController.CustomerName + "','" + _saleController.CustomerPhone + "','" + _saleController.VoucherId + "','" + _saleController.SubTotal + "','" + _saleController.Vat + "','" + _saleController.Discount + "','" + _saleController.TotalAmount + "','" + _saleController.Paid + "','" + _saleController.Due + "','" + _saleController.Type + "','" + _saleController.PaidType + "','" + _saleController.CheckNumber + "','" + _saleController.Note + "','" + _saleController.UserName + "','" + _saleController.Booth + "','" + _saleController.Currency + "'");
                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("insert into sale_cart (voucher_id,fk_product_id,sale_price,qty,sub_total_price,pack) values ('" + _query.LastId + "','" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[3].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[4].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[5].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[6].Text) + "')", conDatabase);
                    cmd.ExecuteNonQuery();
      
                }
                lastGetID.Text = _query.LastId;
                for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                {
                    MySqlCommand cmd = new MySqlCommand("update stock set qty=qty-'" + Convert.ToDouble(ListView1.Items[i].SubItems[4].Text) + "' where fk_product_id='" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "'", conDatabase);
                    cmd.ExecuteNonQuery();

                }
                
              
                clear();
                genarateId();
                if (checkBox2.Checked == true)
                {
                    print();
                }
                }
               
               
            }
            catch(Exception )
            {
            
            }
            
            
            
        }
        void clear()
        {
          
            txtSubTotal.Text = "0";
            txt_vat.Text = "0";
            txt_tax_amount.Text = "0";
            txt_total_amount.Text = "00";
            txt_lable_total_amount.Text = "00";
            txt_phone.Text = "";
            txt_customer_Name.Text = "";
            cmdCustomerId.Text = "";
            txt_discount.Text = "0";
            txt_paid_amount.Text = "";
            txt_check_no.Text = "";
            txt_check_paid.Text = "";
            txt_paid_type.Text = "";
            txt_due_amount.Text = "00";
            for (int k = 0; k <= ListView1.Items.Count - 1; k++)
            {
                ListView1.Items[k].Remove();
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd_product_id.Text = "";
            ProducstNameSubCategory();

            try
            {
                dataGridView1.DataSource = _query.selectWhere("viewstock", "SID='" + comboBox3.SelectedValue + "'");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCategory();
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSaleQty.Text))
                {

                    txtPrice.Text = "00.00";
                    txtTotalAmount.Text = "00.00";

                    return;
                }
                txtTotalAmount.Text = (Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtSaleQty.Text)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox12_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_vat.Text == "")
                {
                    //txt_total_amount_cart.Text = (Convert.ToDouble(txt_total_amount_cart.Text) - Convert.ToDouble(txt_tax_amount.Text)).ToString();
                    txt_tax_amount.Text = "0";

                    return;
                }
                txt_tax_amount.Text = Convert.ToDouble((Convert.ToDouble(txtSubTotal.Text) * Convert.ToDouble(txt_vat.Text) / 100)).ToString();
            }
            catch (Exception )
            {

                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

       

        private void txt_discount_MouseClick(object sender, MouseEventArgs e)
        {
            txt_discount.Text = "";
        }

        private void textBox10_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(txt_paid_amount, true, true, true, true);
            }
            try
            {

                if (string.IsNullOrEmpty(txt_paid_amount.Text))
                {
                    txt_due_amount.Text = txt_total_amount.Text;
                    panel3.Visible = false;

                    return;
                }
                else
                {

                    txt_due_amount.Text = (Convert.ToDouble(txt_total_amount.Text) - Convert.ToDouble(txt_paid_amount.Text)).ToString();
                    if (txt_paid_amount.Text == txt_total_amount.Text)
                    {
                        txt_paid_type.Text = "Paid";
                    }
                    panel3.Visible = true;
                }
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

        private void txt_sub_total_TextChanged(object sender, EventArgs e)
        {

            txt_total_amount.Text = txtSubTotal.Text;
          

            txt_due_amount.Text = txtSubTotal.Text;
            txt_discount.Text = "";
        }

        private void txt_total_amount_TextChanged(object sender, EventArgs e)
        {

            txt_due_amount.Text = txt_total_amount.Text;
            txt_lable_total_amount.Text = txt_total_amount.Text;
            txt_paid_amount.Text = "";

            txt_number_to_word.Text = NumberToWords(Convert.ToInt32(txt_total_amount.Text)).ToString();
        }


        

        private void txt_sub_price_MouseClick(object sender, MouseEventArgs e)
        {
            txtPrice.Text = "";
        }

        void productSelectserialNumber()
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "select product.product_name,stock.qty,stock.sale_price,stock.net_price,product.net_weight,product.weight_type from stock INNER JOIN product ON stock.fk_product_id=product.id where stock.barcode_id='" + txtScanSearch.Text + "'";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    txtPrice.Text = dr["sale_price"].ToString();
                    txtProductName.Text = dr["product_name"].ToString();
                    cmd_product_id.Text = dr["product_name"].ToString();
                    txt_net_price.Text = dr["net_price"].ToString();
                    txtAvailableQty.Text = dr["qty"].ToString();
                    // cmd_weight_type.Text = dr["weight_type"].ToString();

                }
                dr.Close();
            }
            catch(Exception )
            {}

        }
        void productSelectTable()
        {
            try{
            conDatabase = connect.connection();
            conDatabase.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "select product.product_name,stock.barcode_id,stock.net_price,stock.sale_price,stock.qty,product.net_weight,product.weight_type from stock INNER JOIN product ON stock.fk_product_id=product.id where stock.fk_product_id='" + cmd_product_id.SelectedValue + "'";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtScanSearch.Text = dr["barcode_id"].ToString();
                txtPrice.Text = dr["sale_price"].ToString();
                txtProductName.Text = dr["product_name"].ToString();

                txt_net_price.Text = dr["net_price"].ToString();
               
                txtAvailableQty.Text = dr["qty"].ToString();
                //cmd_weight_type.Text = dr["weight_type"].ToString();
                dr.Close();
            }
            else 
            {
                txtPrice.Text = "";
                txtProductName.Text = "";
                //txt_weight.Text = "";
                txtAvailableQty.Text = "";
               // cmd_weight_type.Text = "";
            }
            }
            catch (Exception )
            { }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            productSelectTable();
        }

        private void txtScanSearch_TextChanged(object sender, EventArgs e)
        {
            productSelectserialNumber();
        }


        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
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
                    txtSubTotal.Text = subtot().ToString();
                }


                if (ListView1.Items.Count == 0)
                {
                    txtSubTotal.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            removeCart();
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
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToString(cmd_product_id.SelectedValue) == "")
                {
                    MessageBox.Show("Please retrieve product name", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtSaleQty.Text == "")
                {
                    MessageBox.Show("Please enter no. of sale quantity", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSaleQty.Focus();
                    return;
                }
                double SaleQty = Convert.ToDouble(txtSaleQty.Text);
                if (SaleQty == 0)
                {
                    MessageBox.Show("no. of sale quantity can not be zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSaleQty.Focus();
                    return;
                }

                if (ListView1.Items.Count == 0)
                {

                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(Convert.ToString(cmd_product_id.SelectedValue));
                    lst.SubItems.Add(txtProductName.Text);
                    lst.SubItems.Add(txtPrice.Text);
                    lst.SubItems.Add(Convert.ToString(txtSaleQty.Text));
                    lst.SubItems.Add(txtTotalAmount.Text);
                    lst.SubItems.Add(txt_pack.Text);
                    //lst.SubItems.Add(cmd_weight_type.Text);

                    ListView1.Items.Add(lst);
                    txtSubTotal.Text = subtot().ToString();
                    txtProductName.Text = "";
                    cmd_product_id.Text = "";
                    txtPrice.Text = "";
                    txtAvailableQty.Text = "";
                    txtSaleQty.Text = "";
                    txtTotalAmount.Text = "";
                        txt_net_price.Text="";
                    txtScanSearch.Text="";
                    txt_pack.Text = "";
                   // cmd_weight_type.Text = "";
                    return;
                }

                for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                {
                    if (ListView1.Items[j].SubItems[1].Text == Convert.ToString(cmd_product_id.SelectedValue))
                    {
                        ListView1.Items[j].SubItems[1].Text = Convert.ToString(cmd_product_id.SelectedValue);
                        ListView1.Items[j].SubItems[2].Text = txtProductName.Text;
                        ListView1.Items[j].SubItems[3].Text = txtPrice.Text;
                        ListView1.Items[j].SubItems[4].Text = (Convert.ToDouble(ListView1.Items[j].SubItems[4].Text) + Convert.ToDouble(txtSaleQty.Text)).ToString();
                        ListView1.Items[j].SubItems[5].Text = (Convert.ToDouble(ListView1.Items[j].SubItems[5].Text) + Convert.ToDouble(txtTotalAmount.Text)).ToString();
                        ListView1.Items[j].SubItems[6].Text = Convert.ToString(txt_pack.Text);
                        //ListView1.Items[j].SubItems[7].Text = Convert.ToString(cmd_weight_type.Text);
                       
                        txtSubTotal.Text = subtot().ToString();
                        txtProductName.Text = "";
                        cmd_product_id.Text = "";
                        txtPrice.Text = "";
                        txtAvailableQty.Text = "";
                        txtSaleQty.Text = "";
                        txtTotalAmount.Text = "";
                        txt_net_price.Text = "";
                        txtScanSearch.Text = "";
                        txt_pack.Text = "";
                        //cmd_weight_type.Text = "";
                        return;

                    }
                }

                ListViewItem lst1 = new ListViewItem();

                lst1.SubItems.Add(Convert.ToString(cmd_product_id.SelectedValue));
                lst1.SubItems.Add(txtProductName.Text);
                lst1.SubItems.Add(txtPrice.Text);
                lst1.SubItems.Add(Convert.ToString(txtSaleQty.Text));
                lst1.SubItems.Add(txtTotalAmount.Text);
                lst1.SubItems.Add(txt_pack.Text);
           
                ListView1.Items.Add(lst1);
                txtSubTotal.Text = subtot().ToString();
                txtProductName.Text = "";
                cmd_product_id.Text = "";
                txtPrice.Text = "";
                txtAvailableQty.Text = "";
                txtSaleQty.Text = "";
                txtTotalAmount.Text = "";
                txt_net_price.Text = "";
                txtScanSearch.Text = "";
                txt_pack.Text = "";
                //cmd_weight_type.Text = "";
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
              
                //label27.Text = ListView1.Items.Count.ToString();
                //txt_stock.Text = "0";

        }

        private void txt_tax_amount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txt_total_amount.Text = (Convert.ToDouble(txtSubTotal.Text) + Convert.ToDouble(txt_tax_amount.Text)).ToString();
            }
            catch(Exception )
            {}
        }


        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // To disallow typing in the beginning writing
            if (txt_discount.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txt_discount.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
           
        }



        private void txt_discount_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_discount.Text == "")
                {
                    txt_total_amount.Text = (Convert.ToDouble(txtSubTotal.Text) + Convert.ToDouble(txt_tax_amount.Text)).ToString();

                }
                else if (txt_discount.Text == "0")
                {
                    txt_total_amount.Text = (Convert.ToDouble(txtSubTotal.Text) + Convert.ToDouble(txt_tax_amount.Text)).ToString();

                }
                else
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        txt_total_amount.Text = (Convert.ToDouble(txt_total_amount.Text) - Convert.ToDouble(txt_discount.Text)).ToString();

                    }
                }
            }
            catch(Exception )
            {}

        }

       

        private void txt_discount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(txt_discount,true,true,true,true);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txt_check_paid.Text == "Check")
            {
                txt_check_no.Visible = true;
                label24.Visible = true;
            }
            else
            {
                txt_check_no.Visible = false;
                label24.Visible = false;

            
            }
            
        }
        public void views()
        {
            try
            {

                dataGridView1.DataSource = _query.Select("viewstock");
            }
            catch(Exception )
            {
                
            }
        
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
            txtScanSearch.Text = dataGridView1.SelectedRows[0].Cells["Barcode"].Value.ToString();
            }
        catch (Exception )
        {

        }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand("select * from customer_info where id='" + cmdCustomerId.SelectedValue+ "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_phone.Text = dr["phone"].ToString();
                    txt_customer_Name.Text = dr["customer_name"].ToString();
                }
                else
                {
                    txt_phone.Text = "";
                    txt_customer_Name.Text = "";
                }
                dr.Close();
            }
            catch(Exception )
            { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
           
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
          
           
        }
      
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {    
            try
            {
              

                Graphics graphic = e.Graphics;

                Font font = new Font("Times New Roman", 12); //must use a mono spaced font as the spaces need to line up

                float fontHeight = font.GetHeight();
                int startX = 10;
                int startY = 100;
                int offset = 40;
                string total_amount;
                string Subtotal_amount;
                string VAt;
                string Discount;
                string Paid;
                string Due;
                string User;
                string typePay;
                string voucher;
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "select product.product_name,sale_cart.sale_price,sale_cart.pack,sale_cart.qty,sale_cart.sub_total_price,user.user_name,company_register.name,company_register.email,company_register.phone as 'cPhone',company_register.fax,company_register.address,company_register.logo,currency_type.Name,voucher.* FROM voucher INNER JOIN sale_cart on sale_cart.voucher_id =voucher.id INNER JOIN product on sale_cart.fk_product_id=product.id  INNER JOIN user on voucher.user_id=user.id INNER JOIN company_register on user.companyId=company_register.id INNER JOIN currency_type on voucher.currency_id=currency_type.id  where voucher.id='" + lastGetID.Text + "'";
                MySqlDataReader dread = cmd.ExecuteReader();
                if (dread.Read())
                {
                    string companyName = dread["name"].ToString();
                    string email = dread["email"].ToString();
                    string cphoneNo = dread["cPhone"].ToString();
                    string address = dread["address"].ToString();
                    string date = dread["date"].ToString();
                     voucher = dread["custom_voucher_id"].ToString();
                    string name = dread["customer_name"].ToString();
                    string phone = dread["phone"].ToString();
                    string currncyType = dread["Name"].ToString();
                    Subtotal_amount = dread["subtotal_amount"].ToString();
                    total_amount = dread["total_amount"].ToString();
                     VAt = dread["vat"].ToString();
                     Discount = dread["discount"].ToString();
                     Paid = dread["paid"].ToString();
                     Due = dread["due"].ToString();
                     typePay = dread["type"].ToString();
                     User = dread["user_name"].ToString();

                graphic.DrawString(companyName, new Font("Gill Sans Ultra", 18, FontStyle.Bold), new SolidBrush(Color.Tomato), 10, 10);
                graphic.DrawString(email + "," + cphoneNo, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 40);
                graphic.DrawString(address, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 60);
                graphic.DrawString("-------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 70);
                graphic.DrawString("Date     : " + date, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 90);
                graphic.DrawString("Inv.No  : " + voucher, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 115);
                graphic.DrawString("Cus.Name  : " + name, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 160, 90);
                graphic.DrawString("Cus.Ph       : " + phone, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 160, 115);

                dread.Close();
                
                MySqlCommand cmda = new MySqlCommand();
                cmda.Connection = conDatabase;
                cmda.CommandText = "select product.product_name,sale_cart.sale_price,sale_cart.qty,sale_cart.sub_total_price,sale_cart.voucher_id FROM sale_cart  INNER JOIN product on sale_cart.fk_product_id=product.id   where sale_cart.voucher_id='"+lastGetID.Text+"'";
                MySqlDataReader dreada = cmda.ExecuteReader();
                string top = "Product Name".PadRight(30) + "UnitPrice".PadRight(15) + "Qty".PadRight(5) + "Total Price".PadRight(2);
                graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight; //make the spacing consistent
                graphic.DrawString("----------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + (int)fontHeight + 5; //make the spacing consistent
                while (dreada.Read())
                {
                    //create the string to print on the reciept
                    string productDescription = dreada["product_name"].ToString();
                    string itemId = dreada["sale_price"].ToString();
                    string qty = dreada["qty"].ToString();
                    string totals = dreada["sub_total_price"].ToString();
                    if (productDescription.Contains(" -"))
                    {
                        string productLine = productDescription;
                        string itemsID = itemId;
                        string totalPr = totals;


                        graphic.DrawString(productLine, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), startX, startY + offset);
                        graphic.DrawString(itemsID.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 200, 100 + offset);
                        graphic.DrawString(qty.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 270, 100 + offset);
                        graphic.DrawString(totalPr.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 320, 100 + offset);

                        offset = offset + (int)fontHeight + 5; //make the spacing consistent
                    }
                    else
                    {
                        string productLine = productDescription;
                        string itemsID = itemId;
                        string QTYS = qty;
                        string TotalP= totals;
                        

                        graphic.DrawString(productDescription, font, new SolidBrush(Color.Black), startX, startY + offset);
                        graphic.DrawString(itemsID.PadRight(20), new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Black), 200, 100 + offset);
                        graphic.DrawString(QTYS.PadRight(20), new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Black), 270, 100 + offset);
                        graphic.DrawString(TotalP.PadRight(20), new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Black), 320, 100 + offset);
                        
                        offset = offset + (int)fontHeight + 5; //make the spacing consistent
                    }

                }
                offset = offset + 20; //make some room so that the total stands out.
                graphic.DrawString("----------------------------------------------------------------------", font, new SolidBrush(Color.Black), 10, 70 + offset);
                offset = offset + 20; //make some room so that the total stands out.

                graphic.DrawString("".PadRight(26) + "Sub Total : " + String.Format("{0:c}", Subtotal_amount + " /="), new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);

                offset = offset - 17; //make some room so that the total stands out.
                graphic.DrawString("".PadRight(58)+"Vat         :   "+ String.Format("{0:c}", VAt+" /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 22;
                graphic.DrawString("".PadRight(58) + "Discount :   " + String.Format("{0:c}", Discount+ " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
               
         
                offset = offset + 25;
                graphic.DrawString("".PadRight(24) + "Total : " + String.Format("{0:c}", total_amount + " " + currncyType), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 25;
                graphic.DrawString("".PadRight(58) + "Paid         :   " + String.Format("{0:c}", Paid+" /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 25;
                graphic.DrawString("".PadRight(58) + "Due         :   " + String.Format("{0:c}", Due+" /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 20; //make some room so that the total stands out.
                graphic.DrawString("".PadRight(10) + "Cash Recived", font, new SolidBrush(Color.Black), startX, startY + offset);
              
                offset = offset + 10; //make some room so that the total stands out.
                graphic.DrawString("".PadRight(10) + "----------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 10; //make some room so that the total stands out.
                graphic.DrawString("".PadRight(10) + User, font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset - 140; //make some room so that the total stands out.
                graphic.DrawString("".PadRight(10) + typePay, new Font("Times New Roman", 18, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 32;
               graphic.DrawString("".PadRight(3) + voucher, new Font("IDAutomationHC39M", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 130;
                offset = offset + 10; //make some room so that the total stands out.
                graphic.DrawString("".PadRight(24) + "Thank You  For Shopping", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 17;
                graphic.DrawString("".PadRight(24) + "Please come again", font, new SolidBrush(Color.Black), startX, startY + offset);
                offset = offset + 20;
                graphic.DrawString("".PadRight(14) + "Developed By SBIT http://www.sbit.com.bd/", new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                dreada.Close();
            }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //string line = null;
            //if (line != null)
            //{
            //    e.HasMorePages = true;
            //}
            //else
            //{
            //    e.HasMorePages = false;
            //}

         
        }
        void print()
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = printer;
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(100, 100, 100, 100);
            printDocument.DefaultPageSettings.Margins = margins;
            //on a till you will not want to ask the user where to print but this is fine for the test envoironment.

            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("A4", 5, 5);
                printDocument.Print();

            } 
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
      
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = printer;
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(100, 100, 100, 100);
            printDocument.DefaultPageSettings.Margins = margins;
            PrintPreviewDialog printpreview = new PrintPreviewDialog();
            printpreview.Document = printDocument;
            printpreview.ShowDialog(); 
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            supplyerName();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            View.sale.TotalUserSale obj = new TotalUserSale();
            obj.getUser = txt_user_id.Text;
            obj.Show();
        }

        private void txt_vat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {


            }
            else
            {

                e.Handled = e.KeyChar != (char)Keys.Back;
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_paid_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // To disallow typing in the beginning writing
            if (txt_paid_amount.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txt_paid_amount.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        

      
      
    }
}