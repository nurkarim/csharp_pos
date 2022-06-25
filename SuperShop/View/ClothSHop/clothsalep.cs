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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using System.IO;

namespace SuperShop.View.ClothSHop
{
    public partial class clothsalep : Form
    {
        public clothsalep()
        {
            InitializeComponent();
            genarateId();
            supplyerName();
            ProducstName();
            category();
            autocomplite();
        }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        DB.query _query = new DB.query();
        Controller.SaleController _saleController = new Controller.SaleController();
        Model.SaleModel _saleModel = new Model.SaleModel();
        public string Booth { get { return txt_booth_no.Text; } set { txt_booth_no.Text = value; } }

        public string getUser { get { return txt_user_id.Text; } set { txt_user_id.Text = value; } }
        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt_user_id_Click(object sender, EventArgs e)
        {

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
                    if (0 < sumId && 10 > sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + "000" + sumId.ToString();
                    }
                    else if (10 <= sumId && 99 > sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + "00" + sumId.ToString();
                    }
                    else if (99 < sumId && 100 > sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + "0" + sumId.ToString();
                    }

                    else if (100 <= sumId && 1000 > sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + "0" + sumId.ToString();

                    }
                    else if (1000 < sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + sumId.ToString();

                    }
                    else
                    {
                        txt_voucher_no.Text = "INV-" + booth + sumId.ToString();

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
                        txt_voucher_no.Text = "INV-" + booth + "00" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_voucher_no.Text = "INV-" + booth + "00" + sumId.ToString();

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
            catch (Exception)
            {
            }
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

        private void clothsalep_Load(object sender, EventArgs e)
        {
            Flush();
            cmdCustomerId.Text = "";
            cmd_product_id.Text = "";
            currency();
            comboBox2.Text = "";
            comboBox3.Text = "";
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
            catch (Exception)
            { }

        }
        void productSelectTable()
        {
            try
            {
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
            catch (Exception)
            { }
        }

        private void cmd_product_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd_product_id.Text = "";
            productSelectTable();
        }

        private void txtScanSearch_TextChanged(object sender, EventArgs e)
        {
            productSelectserialNumber();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Text = "";
            SubCategory();
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

        private void btnadd_Click(object sender, EventArgs e)
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
                    //lst.SubItems.Add(txt_weight.Text);
                    //lst.SubItems.Add(cmd_weight_type.Text);

                    ListView1.Items.Add(lst);
                    txtSubTotal.Text = subtot().ToString();
                    txtProductName.Text = "";
                    cmd_product_id.Text = "";
                    txtPrice.Text = "";
                    txtAvailableQty.Text = "";
                    txtSaleQty.Text = "";
                    txtTotalAmount.Text = "";
                    txt_net_price.Text = "";
                    txtScanSearch.Text = "";
                    // txt_weight.Text = "";
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
                        // ListView1.Items[j].SubItems[6].Text = Convert.ToString(txt_weight.Text);
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
                        // txt_weight.Text = "";
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
                // txt_weight.Text = "";
                //cmd_weight_type.Text = "";
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

        private void txtSaleQty_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSaleQty.Text))
                {

                    txtPrice.Text = "0.00";
                    txtTotalAmount.Text = "0.00";

                    return;
                }
                txtTotalAmount.Text = (Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txtSaleQty.Text)).ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProducstNameSubCategory();
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            txt_total_amount.Text = txtSubTotal.Text;
            txt_discount.Text = "";
        }

        private void txtSaleQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSaleQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSaleQty.Text.Length == 0)
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
            if (e.KeyChar == '.' && txtSaleQty.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txt_discount_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void txt_discount_KeyUp(object sender, KeyEventArgs e)
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
            catch (Exception)
            { }
        }

        private void txt_vat_KeyUp(object sender, KeyEventArgs e)
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
            catch (Exception)
            {

                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message);

            }
        }

        private void txt_due_amount_TextChanged(object sender, EventArgs e)
        {
            if (txt_due_amount.Text == "0")
            {
                txt_paid_type.Text = "Paid";

            }

            else if (txt_paid_amount.Text == "0")
            {
                txt_paid_type.Text = "Due";

            }
            else if (txt_due_amount.Text != "0" && txt_due_amount.Text != "0")
            {
                txt_paid_type.Text = "Partial left";
            }
            else if (txt_due_amount.Text != "0")
            {
                txt_paid_type.Text = "Due";

            }
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

                printDocument.Print();

            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
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
                cmd.CommandText = "select product.product_name,sale_cart.sale_price,sale_cart.qty,sale_cart.sub_total_price,user.user_name,company_register.name,company_register.email,company_register.phone as 'cPhone',company_register.fax,company_register.address,company_register.logo,currency_type.Name,voucher.* FROM voucher INNER JOIN sale_cart on sale_cart.voucher_id =voucher.id INNER JOIN product on sale_cart.fk_product_id=product.id  INNER JOIN user on voucher.user_id=user.id INNER JOIN company_register on user.companyId=company_register.id INNER JOIN currency_type on voucher.currency_id=currency_type.id  where voucher.id='" + lastGetID.Text + "'";
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
                    graphic.DrawString("Cus.Name  : " + name, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 170, 90);
                    graphic.DrawString("Cus.Ph       : " + phone, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 170, 115);

                    dread.Close();

                    MySqlCommand cmda = new MySqlCommand();
                    cmda.Connection = conDatabase;
                    cmda.CommandText = "select product.product_name,sale_cart.sale_price,sale_cart.qty,sale_cart.sub_total_price,sale_cart.voucher_id FROM sale_cart  INNER JOIN product on sale_cart.fk_product_id=product.id   where sale_cart.voucher_id='" + lastGetID.Text + "'";
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
                            string TotalP = totals;


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
                    graphic.DrawString("".PadRight(58) + "Vat         :   " + String.Format("{0:c}", VAt + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 22;
                    graphic.DrawString("".PadRight(58) + "Discount :   " + String.Format("{0:c}", Discount + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);


                    offset = offset + 25;
                    graphic.DrawString("".PadRight(24) + "Total : " + String.Format("{0:c}", total_amount + " " + currncyType), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 25;
                    graphic.DrawString("".PadRight(58) + "Paid         :   " + String.Format("{0:c}", Paid + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 25;
                    graphic.DrawString("".PadRight(58) + "Due         :   " + String.Format("{0:c}", Due + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 20; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(10) + User, font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + 10; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(10) + "----------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 10; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(10) + "Cash Recived", font, new SolidBrush(Color.Black), startX, startY + offset);
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
                    graphic.DrawString("".PadRight(14) + "2017 © Developed by SBIT http://www.sbit.com.bd", new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                    dreada.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage); //add an event handler that will do the printing
                //printDocument.PrinterSettings.PrinterName = printer;
                // Create a new instance of Margins with 1-inch margins.
                Margins margins = new Margins(100, 100, 100, 100);
                printDocument.DefaultPageSettings.Margins = margins;
                printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 450, 1000);
                printPreviewDialog1.Document = printDocument;
                DialogResult result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {

                    printDocument.Print();

                }
            }
            else if (checkBox4.Checked == true)
            {
                PrintDialog printDialog = new PrintDialog();
                PrintDocument printDocument = new PrintDocument();
                printDialog.Document = printDocument; //add the document to the dialog box...        
                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument2_PrintPage); //add an event handler that will do the printing
                //printDocument.PrinterSettings.PrinterName = printer;
                // Create a new instance of Margins with 1-inch margins.
                Margins margins = new Margins(100, 100, 100, 100);
                printDocument.DefaultPageSettings.Margins = margins;
                printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 550, 1000);
                printPreviewDialog1.Document = printDocument;
                DialogResult result = printDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    printDocument.Print();
                }}else {

                printCry();

            }
        }
        void clear()
        {

            txtSubTotal.Text = "0.00";
            txt_vat.Text = "0.00";
            txt_tax_amount.Text = "0.00";
            txt_total_amount.Text = "0.00";

            txt_phone.Text = "";
            txt_customer_Name.Text = "";
            cmdCustomerId.Text = "";
            txt_discount.Text = "0.00";
            txt_paid_amount.Text = "";

            txt_paid_type.Text = "";
            txt_due_amount.Text = "0.00";

            ListView1.Items[0].Remove();

        }
        void printCry()
        {
            //Open the PrintDialog
            this.printDialog1.Document = this.printDocument1;
            DialogResult drs = this.printDialog1.ShowDialog();
            if (drs == DialogResult.OK)
            {
                //Get the Copy times
                int nCopy = this.printDocument1.PrinterSettings.Copies;
                //Get the number of Start Page
                int sPage = this.printDocument1.PrinterSettings.FromPage;
                //Get the number of End Page
                int ePage = this.printDocument1.PrinterSettings.ToPage;
                string PrinterName = this.printDocument1.PrinterSettings.PrinterName;

                ReportDocument crReportDocument = new ReportDocument();
                //Create an instance of a report

                crReportDocument = new CrystalReport.sale.Clothvoucher();

                crReportDocument.SetParameterValue("voucher", lastGetID.Text);
                
                try
                {
                    crReportDocument.PrintOptions.PrinterName = PrinterName;
                    crReportDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4Small;
                    crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString());
                }
            }
        }


        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
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
                cmd.CommandText = "select product.product_name,sale_cart.sale_price,sale_cart.qty,sale_cart.sub_total_price,user.user_name,company_register.name,company_register.email,company_register.phone as 'cPhone',company_register.fax,company_register.address,company_register.logo,currency_type.Name,voucher.* FROM voucher INNER JOIN sale_cart on sale_cart.voucher_id =voucher.id INNER JOIN product on sale_cart.fk_product_id=product.id  INNER JOIN user on voucher.user_id=user.id INNER JOIN company_register on user.companyId=company_register.id INNER JOIN currency_type on voucher.currency_id=currency_type.id  where voucher.id='" + lastGetID.Text + "'";
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
                    graphic.DrawString("--------------------------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 70);
                    graphic.DrawString("Date     : " + date, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 90);
                    graphic.DrawString("Inv.No  : " + voucher, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 115);
                    graphic.DrawString("Cus.Name  : " + name, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 170, 90);
                    graphic.DrawString("Cus.Ph       : " + phone, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 170, 115);

                    dread.Close();

                    MySqlCommand cmda = new MySqlCommand();
                    cmda.Connection = conDatabase;
                    cmda.CommandText = "select product.product_name,sale_cart.sale_price,sale_cart.qty,sale_cart.sub_total_price,sale_cart.voucher_id FROM sale_cart  INNER JOIN product on sale_cart.fk_product_id=product.id   where sale_cart.voucher_id='" + lastGetID.Text + "'";
                    MySqlDataReader dreada = cmda.ExecuteReader();
                    string top = "Product Name".PadRight(30) + "UnitPrice".PadRight(19) + "Qty".PadRight(9) + "Total Price".PadRight(2);
                    graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight; //make the spacing consistent
                    graphic.DrawString("--------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
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
                            graphic.DrawString(qty.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 300, 100 + offset);
                            graphic.DrawString(totalPr.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 350, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }
                        else
                        {
                            string productLine = productDescription;
                            string itemsID = itemId;
                            string QTYS = qty;
                            string TotalP = totals;


                            graphic.DrawString(productDescription, font, new SolidBrush(Color.Black), startX, startY + offset);
                            graphic.DrawString(itemsID.PadRight(20), new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Black), 200, 100 + offset);
                            graphic.DrawString(QTYS.PadRight(20), new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Black), 300, 100 + offset);
                            graphic.DrawString(TotalP.PadRight(20), new Font("Courier New", 12, FontStyle.Italic), new SolidBrush(Color.Black), 350, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }

                    }
                    offset = offset + 20; //make some room so that the total stands out.
                    graphic.DrawString("--------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), 10, 70 + offset);
                    offset = offset + 20; //make some room so that the total stands out.

                    graphic.DrawString("".PadRight(27) + "Sub Total : " + String.Format("{0:c}", Subtotal_amount + " /="), new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);

                    offset = offset - 17; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(60) + "Vat         :   " + String.Format("{0:c}", VAt + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 22;
                    graphic.DrawString("".PadRight(60) + "Discount :   " + String.Format("{0:c}", Discount + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);


                    offset = offset + 25;
                    graphic.DrawString("".PadRight(25) + "Total : " + String.Format("{0:c}", total_amount + " " + currncyType), new Font("Courier New", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 25;
                    graphic.DrawString("".PadRight(60) + "Paid         :   " + String.Format("{0:c}", Paid + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 25;
                    graphic.DrawString("".PadRight(60) + "Due         :   " + String.Format("{0:c}", Due + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 20; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(10) + User, font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + 10; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(10) + "--------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 10; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(10) + "Cash Recived", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset - 140; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(10) + typePay, new Font("Times New Roman", 18, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 32;
                    graphic.DrawString("".PadRight(3) + voucher, new Font("IDAutomationHC39M", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 130;
                    dreada.Close();

                    MySqlCommand cmdw = new MySqlCommand("select product.model_no,product.product_serial_number from sale_cart inner join product on sale_cart.fk_product_id=product.id where sale_cart.voucher_id='" + lastGetID.Text + "'", conDatabase);
                    MySqlDataReader drsw;
                    drsw = cmdw.ExecuteReader();
                    if (drsw.Read())
                    {




                        graphic.DrawString("".PadRight(0) + "X-------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 25;
                        graphic.DrawString("".PadRight(24) + "WARRANTY INFORMATION", font, new SolidBrush(Color.Black), startX, startY + offset);

                        offset = offset + 25;
                        graphic.DrawString("".PadRight(0) + "Model No" + "  ".PadRight(0) + drsw["model_no"].ToString() + "  ".PadRight(29) + "Serial No" + "  ".PadRight(0) + drsw["product_serial_number"].ToString() + "", font, new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 10;
                        graphic.DrawString("".PadRight(0) + "" + "  ".PadRight(15) + "------------------------------" + "  ".PadRight(9) + "" + "  ".PadRight(0) + "-------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    }
                    drsw.Close();
                    offset = offset + 25;
                    graphic.DrawString("".PadRight(0) + "Date Of Purchase " + "  ".PadRight(0) + date.ToString() + "  ".PadRight(8) + "Invoice No" + "  ".PadRight(0) + voucher.ToString() + "", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 10;
                    graphic.DrawString("".PadRight(0) + "" + "  ".PadRight(25) + "---------------------------" + "  ".PadRight(8) + "" + "  ".PadRight(0) + "---------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);


                    offset = offset + 25;
                    graphic.DrawString("".PadRight(0) + "Customer Name" + "  ".PadRight(0) + name.ToString() + "  ".PadRight(21) + "Phone" + "  ".PadRight(0) + phone.ToString() + "", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 10;
                    graphic.DrawString("".PadRight(0) + "" + "  ".PadRight(25) + "------------------------------" + "  ".PadRight(4) + "" + "  ".PadRight(0) + "---------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + 30; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(5) + "I have read the terms and conditions of warranty and do accept the some", new Font("Times New Roman", 9, FontStyle.Regular), new SolidBrush(Color.Navy), startX, startY + offset);

                    offset = offset + 30; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(24) + "Thank You  For Shopping", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 17;
                    graphic.DrawString("".PadRight(24) + "Please come again", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 20;
                    graphic.DrawString("".PadRight(14) + "2017 © Developed by SBIT http://www.sbit.com.bd", new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage); //add an event handler that will do the printing
                //printDocument.PrinterSettings.PrinterName = printer;
                // Create a new instance of Margins with 1-inch margins.
                Margins margins = new Margins(100, 100, 100, 100);
                printDocument.DefaultPageSettings.Margins = margins;
                printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 450, 1000);
                printPreviewDialog1.Document = printDocument;
                printPreviewDialog1.ShowDialog();
            }
            else if (checkBox4.Checked == true)
            {
                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument2_PrintPage); //add an event handler that will do the printing
                //printDocument.PrinterSettings.PrinterName = printer;
                // Create a new instance of Margins with 1-inch margins.
                Margins margins = new Margins(100, 100, 100, 100);
                printDocument.DefaultPageSettings.Margins = margins;
                printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 550, 1000);
                printPreviewDialog1.Document = printDocument;
                printPreviewDialog1.ShowDialog();
            }
            else
            {

                CrystalReport.sale.ViewReport.VoucherView obj = new CrystalReport.sale.ViewReport.VoucherView();
                obj.type = "Garments";
                obj.vaoucher = lastGetID.Text;
                obj.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListView1.Items[0].Remove();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con();

            try
            {

                _saleController.Date = Convert.ToString(dateTimePicker1.Text);
                _saleController.CustomerId = Convert.ToString(cmdCustomerId.SelectedValue);
                _saleController.CustomerName = Convert.ToString(cmdCustomerId.Text);
                _saleController.CustomerPhone = Convert.ToString(txt_phone.Text);
                _saleController.VoucherId = Convert.ToString(txt_voucher_no.Text);
                _saleController.SubTotal = Convert.ToString(txtSubTotal.Text);
                _saleController.Vat = Convert.ToString(txt_vat.Text);
                _saleController.Discount = Convert.ToString(txt_discount.Text);
                _saleController.TotalAmount = Convert.ToString(txt_total_amount.Text);
                _saleController.Paid = Convert.ToString(txt_paid_amount.Text);
                _saleController.Due = Convert.ToString(txt_due_amount.Text);
                _saleController.Type = Convert.ToString(txt_paid_type.Text);

                _saleController.Note = Convert.ToString(txt_sale_note.Text);
                _saleController.UserName = Convert.ToString(txt_user_id.Text);
                _saleController.Booth = Convert.ToString(txt_booth_no.Text);
                _saleController.Currency = Convert.ToString(label17.Text);
                if (txt_due_amount.Text != "" && txt_due_amount.Text != "0")
                {
                    if (cmdCustomerId.Text != "")
                    {
                        _query.InsertA("voucher", "date,customer_id,customer_name,phone,custom_voucher_id,subtotal_amount,vat,discount,total_amount,paid,due,type,note,user_id,booth_no,currency_id", "'" + _saleController.Date + "','" + _saleController.CustomerId + "','" + _saleController.CustomerName + "','" + _saleController.CustomerPhone + "','" + _saleController.VoucherId + "','" + _saleController.SubTotal + "','" + _saleController.Vat + "','" + _saleController.Discount + "','" + _saleController.TotalAmount + "','" + _saleController.Paid + "','" + _saleController.Due + "','" + _saleController.Type + "','" + _saleController.Note + "','" + _saleController.UserName + "','" + _saleController.Booth + "','" + _saleController.Currency + "'");

                        for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                        {
                            MySqlCommand cmd = new MySqlCommand("insert into sale_cart (voucher_id,fk_product_id,sale_price,qty,sub_total_price) values ('" + _query.LastId + "','" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[3].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[4].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[5].Text) + "')", conDatabase);
                            cmd.ExecuteNonQuery();

                        }
                        lastGetID.Text = _query.LastId;
                        for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                        {
                            MySqlCommand cmd = new MySqlCommand("update stock set qty=qty-'" + Convert.ToDouble(ListView1.Items[i].SubItems[4].Text) + "' where fk_product_id='" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "'", conDatabase);
                            cmd.ExecuteNonQuery();

                        }
                        if (txt_due_amount.Text == "0") { }
                        else if (txt_due_amount.Text == "") { }
                        else if (txt_due_amount.Text != "0" || txt_due_amount.Text != "")
                        {

                            try
                            {
                                _query.EIInsert("customer_ladger_book", "date,customer_name,customer_id,phone,voucher_id,discription,debit_amount,blance", "'" + _saleController.Date + "','" + _saleController.CustomerName + "','" + _saleController.CustomerId + "','" + _saleController.CustomerPhone + "','" + _saleController.VoucherId + "','Sale','" + _saleController.Due + "','" + _saleController.TotalAmount + "'");
                                if (checkBox1.Checked == true)
                                {
                                    _query.EIInsert("loan_waise_product_sale", "date,customer_id,customer_name,invoice_id,paid_amount,due_amount,total_amount", "'" + Convert.ToString(dateTimePicker1.Text) + "','" + Convert.ToString(cmdCustomerId.SelectedValue) + "','" + Convert.ToString(txt_customer_Name.Text) + "','" + Convert.ToString(_query.LastId) + "','" + Convert.ToString(txt_paid_amount.Text) + "','" + Convert.ToString(txt_due_amount.Text) + "','" + Convert.ToString(txt_total_amount.Text) + "'");
                                    _query.EIInsert("loan_paid_role", "loan_type,voucher_id,customer_id,customer_name,to_paid_amount", "'" + comboBox4.Text + "','" + _query.LastId + "','" + cmdCustomerId.SelectedValue + "','" + txt_customer_Name.Text + "','" + textBox17.Text + "'");
                                }
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
                        }else if(checkBox4.Checked==true){

                            PrintDialog printDialog = new PrintDialog();
                            PrintDocument printDocument = new PrintDocument();
                            printDialog.Document = printDocument; //add the document to the dialog box...        
                            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument2_PrintPage); //add an event handler that will do the printing
                            //printDocument.PrinterSettings.PrinterName = printer;
                            // Create a new instance of Margins with 1-inch margins.
                            Margins margins = new Margins(100, 100, 100, 100);
                            printDocument.DefaultPageSettings.Margins = margins;
                            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 550, 1000);
                            printPreviewDialog1.Document = printDocument;
                            DialogResult result = printDialog.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                printDocument.Print();
                            }
                        }
                        else
                        {
                            printCry();
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
                    _query.InsertA("voucher", "date,customer_id,customer_name,phone,custom_voucher_id,subtotal_amount,vat,discount,total_amount,paid,due,type,note,user_id,booth_no,currency_id", "'" + _saleController.Date + "','" + _saleController.CustomerId + "','" + _saleController.CustomerName + "','" + _saleController.CustomerPhone + "','" + _saleController.VoucherId + "','" + _saleController.SubTotal + "','" + _saleController.Vat + "','" + _saleController.Discount + "','" + _saleController.TotalAmount + "','" + _saleController.Paid + "','" + _saleController.Due + "','" + _saleController.Type + "','" + _saleController.Note + "','" + _saleController.UserName + "','" + _saleController.Booth + "','" + _saleController.Currency + "'");

                    for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                    {
                        MySqlCommand cmd = new MySqlCommand("insert into sale_cart (voucher_id,fk_product_id,sale_price,qty,sub_total_price) values ('" + _query.LastId + "','" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[3].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[4].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[5].Text) + "')", conDatabase);
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
                    else if (checkBox4.Checked == true) {
                        PrintDialog printDialog = new PrintDialog();
                        PrintDocument printDocument = new PrintDocument();
                        printDialog.Document = printDocument; //add the document to the dialog box...        
                        printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument2_PrintPage); //add an event handler that will do the printing
                        //printDocument.PrinterSettings.PrinterName = printer;
                        // Create a new instance of Margins with 1-inch margins.
                        Margins margins = new Margins(100, 100, 100, 100);
                        printDocument.DefaultPageSettings.Margins = margins;
                        printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 550, 1000);
                        printPreviewDialog1.Document = printDocument;
                        DialogResult result = printDialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            printDocument.Print();
                        }
                    }
                    else
                    {
                        printCry();
                    }
                }


            }
            catch (Exception)
            {

            }
        }


    }
}
