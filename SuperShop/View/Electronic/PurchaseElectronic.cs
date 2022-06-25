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
using CrystalDecisions.CrystalReports.Engine;
namespace SuperShop.View.Electronic
{
    public partial class PurchaseElectronic : Form
    {
        public PurchaseElectronic()
        {
            InitializeComponent();
            genarateId();
            supplyerName();
            ProducstName();
           // category();
            autocomplite();
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

        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        DB.query _query = new DB.query();
        Controller.purchaseController _purchaseController = new Controller.purchaseController();
        Model.purchaseModel _purchase_model = new Model.purchaseModel();
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
                //comboBox2.DataSource = ds.Tables[0];
               // comboBox2.ValueMember = "id";
               // comboBox2.DisplayMember = "name";

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
               // cmd.CommandText = "SELECT id,name FROM sub_category where fk_category_id='" + comboBox2.SelectedValue + "'";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                //comboBox3.DataSource = ds.Tables[0];
                //comboBox3.ValueMember = "id";
                //comboBox3.DisplayMember = "name";

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
               // cmd.CommandText = "SELECT id,product_name FROM product where fk_sub_category_id='" + comboBox3.SelectedValue + "'";
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
                cmd.CommandText = "SELECT id,name FROM supplyer_table";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                cmdCustomerId.DataSource = ds.Tables[0];
                cmdCustomerId.ValueMember = "id";
                cmdCustomerId.DisplayMember = "name";

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
                cmd.CommandText = "SELECT count(id)+1 FROM purchase_table where left(created_at,4)=left(" + DateTime.Now.ToString("yyyy") + ",4) order by id desc";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    int getId = dr.GetInt32(0);


                    txt_voucher_no.Text = getId.ToString();
                    sumId = Convert.ToInt32(getId);
                    if (0 < sumId && 10 > sumId)
                    {
                        txt_voucher_no.Text = "PU-" + booth + "00" + sumId.ToString();
                    }
                    else if (10 <= sumId && 99 > sumId)
                    {
                        txt_voucher_no.Text = "PU-" + booth + "0" + sumId.ToString();
                    }

                    else if (99 < sumId && 100 > sumId)
                    {
                        txt_voucher_no.Text = "PU-" + booth + "0" + sumId.ToString();
                    }

                    else if (100 < sumId && 1000 > sumId)
                    {
                        txt_voucher_no.Text = "PU-" + booth + "0" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_voucher_no.Text = "PU-" + booth + sumId.ToString();

                    }
                    else
                    {
                        txt_voucher_no.Text = "PU-" + booth + sumId.ToString();
                    
                    }


                }

                else
                {

                    sumId = Convert.ToInt32(1);
                    if (0 < sumId & 99 > sumId)
                    {
                        txt_voucher_no.Text = "PU-" + booth + "000" + sumId.ToString();
                    }

                    else if (99 < sumId)
                    {
                        txt_voucher_no.Text = "PU-" + booth + "00" + sumId.ToString();
                    }

                    else if (100 < sumId)
                    {
                        txt_voucher_no.Text = "PU-" + booth + "00" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_voucher_no.Text = "PU-" + booth + "0" + sumId.ToString();

                    }

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            SubCategory();
        }
        void productSelectTable()
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "select * from product where id='" + cmd_product_id.SelectedValue + "'";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txtScanSearch.Text = dr["product_serial_number"].ToString();
                    txt_net_price.Text = dr["set_price"].ToString();
                    txtProductName.Text = dr["product_name"].ToString();
                    txt_category.Text = dr["fk_category_id"].ToString();
                    txt_subCategory.Text = dr["fk_sub_category_id"].ToString();
                    txt_brand.Text = dr["fk_brand_id"].ToString();
                   


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


        public double subtot()
        {

            int i = 0;
            int j = 0;
            double k = 0;
            i = 0;
            j = 0;
            k = 0;

            try
            {
                j = listviewpurchase.Items.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    k = k + Convert.ToDouble(listviewpurchase.Items[i].SubItems[8].Text);
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
                if (Convert.ToString(cmd_product_id.SelectedValue) == "")
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

                if (listviewpurchase.Items.Count == 0)
                {

                    ListViewItem lst = new ListViewItem();

                    lst.SubItems.Add(Convert.ToString(cmd_product_id.SelectedValue));
                    lst.SubItems.Add(txtProductName.Text);
                    lst.SubItems.Add(txt_net_price.Text);
                    lst.SubItems.Add(txt_purchase_Price.Text);
                    lst.SubItems.Add(txt_quentity.Text);
                    
                    lst.SubItems.Add(txt_vat_price.Text);

                    lst.SubItems.Add(txt_sub_discount.Text);
                    lst.SubItems.Add(txt_total_amount_cart.Text);
               
                    lst.SubItems.Add(txt_category.Text);
                    lst.SubItems.Add(txt_subCategory.Text);
                    lst.SubItems.Add(txt_brand.Text);
                    lst.SubItems.Add(txt_sub_price.Text);
                  

                    listviewpurchase.Items.Add(lst);
                    txt_sub_total.Text = subtot().ToString();
                    cmd_product_id.Text = "";
               
                    txtScanSearch.Text = "";
                    txt_total_amount_cart.Text = "00.00";
                    txt_quentity.Text = "";
                    txt_purchase_Price.Text = "";
                    txt_net_price.Text = "";
                   
                    txt_vat_price.Text = "";
                    return;
                }

                for (int j = 0; j <= listviewpurchase.Items.Count - 1; j++)
                {

                    if (listviewpurchase.Items[j].SubItems[1].Text == Convert.ToString(cmd_product_id.SelectedValue))
                    {
                        listviewpurchase.Items[j].SubItems[1].Text = Convert.ToString(cmd_product_id.SelectedValue);
                        listviewpurchase.Items[j].SubItems[2].Text = txtProductName.Text;
                        listviewpurchase.Items[j].SubItems[3].Text = txt_net_price.Text;
                        listviewpurchase.Items[j].SubItems[4].Text = txt_purchase_Price.Text;
                        listviewpurchase.Items[j].SubItems[5].Text = (Convert.ToInt32(listviewpurchase.Items[j].SubItems[5].Text) + Convert.ToInt32(txt_quentity.Text)).ToString();
  
                        listviewpurchase.Items[j].SubItems[6].Text = txt_vat_price.Text;
                        listviewpurchase.Items[j].SubItems[7].Text = Convert.ToString(txt_sub_discount.Text);
                        listviewpurchase.Items[j].SubItems[8].Text = (Convert.ToDouble(listviewpurchase.Items[j].SubItems[8].Text) + Convert.ToDouble(txt_total_amount_cart.Text)).ToString();
                        
                        
                        listviewpurchase.Items[j].SubItems[9].Text = Convert.ToString(txt_category.Text);
                        listviewpurchase.Items[j].SubItems[10].Text = Convert.ToString(txt_subCategory.Text);
                        listviewpurchase.Items[j].SubItems[11].Text = Convert.ToString(txt_brand.Text);
                        listviewpurchase.Items[j].SubItems[12].Text = Convert.ToString(txt_sub_price.Text);
                       

                        txt_sub_total.Text = subtot().ToString();
                        cmd_product_id.Text = "";
                        txtScanSearch.Text = "";
                       
                        txt_quentity.Text = "";
                        txt_purchase_Price.Text = "";
                        txt_net_price.Text = "";
                        txt_total_amount_cart.Text = "00.00";
                       
                        txt_vat_price.Text = "";
                        return;
                    }


                }

                ListViewItem lst1 = new ListViewItem();


                lst1.SubItems.Add(Convert.ToString(cmd_product_id.SelectedValue));
                lst1.SubItems.Add(txtProductName.Text);
                lst1.SubItems.Add(txt_net_price.Text);
                lst1.SubItems.Add(txt_purchase_Price.Text);
                lst1.SubItems.Add(txt_quentity.Text);

                lst1.SubItems.Add(txt_vat_price.Text);

                lst1.SubItems.Add(txt_sub_discount.Text);
                lst1.SubItems.Add(txt_total_amount_cart.Text);

                lst1.SubItems.Add(txt_category.Text);
                lst1.SubItems.Add(txt_subCategory.Text);
                lst1.SubItems.Add(txt_brand.Text);
                lst1.SubItems.Add(txt_sub_price.Text);
                listviewpurchase.Items.Add(lst1);
                txt_sub_total.Text = subtot().ToString();
                cmd_product_id.Text = "";
                txtScanSearch.Text = "";
                txt_sub_price.Text = "";
                txt_quentity.Text = "";
                txt_purchase_Price.Text = "";
                txt_net_price.Text = "";
                txt_total_amount_cart.Text = "00.00";
                txt_vat_price.Text = "";
               
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
                if (listviewpurchase.Items.Count == 0)
                {
                    MessageBox.Show("No items to remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int itmCnt = 0;
                    int i = 0;
                    int t = 0;

                    listviewpurchase.FocusedItem.Remove();
                    itmCnt = listviewpurchase.Items.Count;
                    t = 1;

                    for (i = 1; i <= itmCnt + 1; i++)
                    {
                        //Dim lst1 As New ListViewItem(i)
                        //ListView1.Items(i).SubItems(0).Text = t
                        t = t + 1;

                    }
                    txt_sub_total.Text = subtot().ToString();
                }


                if (listviewpurchase.Items.Count == 0)
                {
                    txt_sub_total.Text = "";
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

        private void btnadd_Click(object sender, EventArgs e)
        {
            salecart();
        }

        private void txt_purchase_Price_MouseClick(object sender, MouseEventArgs e)
        {
            txt_purchase_Price.Text = "";
        }

        private void txt_quentity_KeyUp(object sender, KeyEventArgs e)
        {
            double tottal = Convert.ToDouble(txt_purchase_Price.Text) * Convert.ToInt32(txt_quentity.Text);
            txt_sub_price.Text = tottal.ToString();
        }

        private void txt_sub_price_TextChanged(object sender, EventArgs e)
        {
            txt_total_amount_cart.Text = txt_sub_price.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            supplyerName();
        }

        private void cmdCustomerId_SelectedIndexChanged(object sender, EventArgs e)
        {
            conDatabase = connect.connection();
            conDatabase.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conDatabase;
            cmd.CommandText = "select * from supplyer_table where id='" + cmdCustomerId.SelectedValue + "'";
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txt_suplyer_phone.Text = dr["phone"].ToString();

            }
        }

        private void PurchaseElectronic_Load(object sender, EventArgs e)
        {
            cmdCustomerId.Text = "";
            cmd_product_id.Text = "";
        }

        private void txt_vat_price_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txt_vat_price_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_vat_price.Text == "")
                {
                    //txt_total_amount_cart.Text = (Convert.ToDouble(txt_total_amount_cart.Text) - Convert.ToDouble(txt_tax_amount.Text)).ToString();
                    textBox1.Text = "0";

                    return;
                }
                textBox1.Text = Convert.ToDouble((Convert.ToDouble(txt_sub_price.Text) * Convert.ToDouble(txt_vat_price.Text) / 100)).ToString();
                txt_total_amount_cart.Text = (Convert.ToDouble(textBox1.Text) + Convert.ToDouble(txt_sub_price.Text)).ToString();
            
            }
            catch (Exception)
            {

                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_sub_discount_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txt_sub_discount_KeyUp(object sender, KeyEventArgs e)
        {
            if (txt_sub_discount.Text == "")
            {
                //txt_total_amount_cart.Text = (Convert.ToDouble(txt_total_amount_cart.Text) - Convert.ToDouble(txt_tax_amount.Text)).ToString();


                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                string value = (Convert.ToDouble(txt_total_amount_cart.Text) - Convert.ToDouble(txt_sub_discount.Text)).ToString();
                txt_total_amount_cart.Text = value.ToString();
            }
        }

        private void txt_sub_total_TextChanged(object sender, EventArgs e)
        {
            txt_total_amount.Text = txt_sub_total.Text;
        }

        private void txt_vat_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txt_vat.Text == "")
                {
                    txt_tax_amount.Text = "0";

                    return;
                }
                txt_tax_amount.Text = Convert.ToDouble((Convert.ToDouble(txt_sub_price.Text) * Convert.ToDouble(txt_vat_price.Text) / 100)).ToString();
                txt_total_amount.Text = (Convert.ToDouble(txt_tax_amount.Text) + Convert.ToDouble(txt_total_amount.Text)).ToString();

            }
            catch (Exception)
            {

                //MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_vat_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (txt_discount.Text == "")
            {

                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                string value = (Convert.ToDouble(txt_total_amount.Text) - Convert.ToDouble(txt_discount.Text)).ToString();
                txt_total_amount.Text = value.ToString();
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

                if (Convert.ToInt32(txt_total_amount.Text) < Convert.ToInt32(txt_paid_amount.Text))
                {
                    txt_paid_amount.Text = "0";
                    txt_due_amount.Text = txt_total_amount.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void txt_discount_MouseClick(object sender, MouseEventArgs e)
        {
            txt_discount.Text = "";
        }

        private void txt_paid_amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        void clear()
        {
            txt_sub_total.Text = "00.00";
            txt_discount.Text = "00.00";
            txt_tax_amount.Text = "00.00";
            txt_vat.Text = "0";
            txt_total_amount.Text = "00.00";
            txt_paid_amount.Text = "0";
            txt_due_amount.Text = "00.00";
        }
        void print()
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

                crReportDocument = new CrystalReport.purchase.voucherPurchaseReport();

                crReportDocument.SetParameterValue("id", lastGetID.Text);
                PaperSize papersize = new PaperSize();
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
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            con();
            try
            {
                DB.query _querys = new DB.query();

                _purchaseController.Date = Convert.ToString(dateTimePicker1.Text);
                _purchaseController.VoucherNo = Convert.ToString(txt_voucher_no.Text);
                _purchaseController.Suplyer = Convert.ToString(cmdCustomerId.SelectedValue);
                _purchaseController.phone = Convert.ToString(txt_suplyer_phone.Text);
                _purchaseController.TotalSubAmount = Convert.ToString(txt_sub_total.Text);
                _purchaseController.Total_Vat = Convert.ToString(txt_vat.Text);
                _purchaseController.Total_Discount = Convert.ToString(txt_discount.Text);
                _purchaseController.TotalPurchaseAmount = Convert.ToString(txt_total_amount.Text);
                _purchaseController.Paid_amount = Convert.ToString(txt_paid_amount.Text);
                _purchaseController.Due = Convert.ToString(txt_due_amount.Text);
                _purchaseController.User = Convert.ToString(txt_user_id.Text);
                _purchaseController.Booth = Convert.ToString(txt_booth_no.Text);
                _purchaseController.Note = Convert.ToString(txt_sale_note.Text);
                _purchaseController.PaidType = Convert.ToString(txt_paid_type.Text);
                _purchaseController.BillNo = Convert.ToString(txt_bill_no.Text);

                if (txt_voucher_no.Text == "")
                {

                    return;
                }
                else if (txt_total_amount.Text == "")
                {
                    MessageBox.Show("Sorry Total Amount was required");
                    return;
                }
                else if (txt_total_amount.Text == "0.00")
                {
                    MessageBox.Show("Sorry Total Amount was required");

                    return;
                }
                else if (txt_total_amount.Text == "0")
                {
                    MessageBox.Show("Sorry Total Amount was required");

                    return;
                }
                else
                {

                    if (Convert.ToDouble(txt_due_amount.Text) > 0)
                    {
                        if (cmdCustomerId.Text=="")
                        {
                            MessageBox.Show("Please Select Supplier");
                            return;
                        }
                        else
                        {

                            _query.InsertA("purchase_table", "date,invoice_no,suplyer_id,supplyer_phone,sub_total,vat,discount,total_amount,paid,due,paid_type,user_id,booth,note,bill_no", "'" + _purchaseController.Date + "','" + _purchaseController.VoucherNo + "','" + _purchaseController.Suplyer + "','" + _purchaseController.phone + "','" + _purchaseController.TotalSubAmount + "','" + _purchaseController.Total_Vat + "','" + _purchaseController.Total_Discount + "','" + _purchaseController.TotalPurchaseAmount + "','" + _purchaseController.Paid_amount + "','" + _purchaseController.Due + "','" + _purchaseController.PaidType + "','" + _purchaseController.User + "','" + _purchaseController.Booth + "','" + _purchaseController.Note + "','" + _purchaseController.BillNo + "'");

                            lastGetID.Text = _query.LastId;
                            for (int i = 0; i <= listviewpurchase.Items.Count - 1; i++)
                            {


                                MySqlCommand cmd = new MySqlCommand();
                                cmd.Connection = conDatabase;
                                cmd.CommandText = "insert into purchase_cart (fk_purchase_id,fk_product_id,net_price,purchase_price,qty,sub_price,vat,discount,total_price) values (@fk_purchase_id,@fk_product_id,@net_price,@purchase_price,@qty,@sub_price,@vat,@discount,@total_price)";
                                cmd.Parameters.AddWithValue("fk_purchase_id", _query.LastId);
                                cmd.Parameters.AddWithValue("fk_product_id", Convert.ToString(listviewpurchase.Items[i].SubItems[1].Text));
                                cmd.Parameters.AddWithValue("net_price", Convert.ToString(listviewpurchase.Items[i].SubItems[3].Text));
                                cmd.Parameters.AddWithValue("purchase_price", Convert.ToString(listviewpurchase.Items[i].SubItems[4].Text));
                                cmd.Parameters.AddWithValue("qty", Convert.ToString(listviewpurchase.Items[i].SubItems[5].Text));
                                cmd.Parameters.AddWithValue("sub_price", Convert.ToString(listviewpurchase.Items[i].SubItems[12].Text));
                                cmd.Parameters.AddWithValue("vat", Convert.ToString(listviewpurchase.Items[i].SubItems[6].Text));
                                cmd.Parameters.AddWithValue("discount", Convert.ToString(listviewpurchase.Items[i].SubItems[7].Text));
                                cmd.Parameters.AddWithValue("total_price", Convert.ToString(listviewpurchase.Items[i].SubItems[8].Text));
                                cmd.ExecuteNonQuery();

                            }
                            for (int j = 0; j <= listviewpurchase.Items.Count - 1; j++)
                            {
                                MySqlCommand cmdC = new MySqlCommand();
                                cmdC.Connection = conDatabase;
                                cmdC.CommandText = "insert into panding_stock (fk_product_id,fk_category_id,fk_brand_id,fk_subcategory_id,net_price,purchase_price,stock,vat,discount,fk_purchase_id) values ('" + Convert.ToString(listviewpurchase.Items[j].SubItems[1].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[9].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[11].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[10].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[3].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[4].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[5].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[6].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[7].Text) + "','" + _query.LastId + "') ";
                                cmdC.ExecuteNonQuery();

                            }



                        MySqlCommand cmdr = new MySqlCommand();
                        cmdr.Connection = conDatabase;
                        cmdr.CommandText = "insert into supplier_ladger_book (date,supplier_name,supplier_id,phone,voucher_id,discription,credit_amount,blance,created_by) values ('" + dateTimePicker1.Text + "','" + cmdCustomerId.Text + "','" + cmdCustomerId.SelectedValue + "','" + txt_suplyer_phone.Text + "','" + txt_voucher_no.Text + "','purchase','" + txt_due_amount.Text + "','" + txt_total_amount.Text + "','" + txt_user_id.Text + "')";
                        cmdr.ExecuteNonQuery();


                        MySqlCommand cmdrd = new MySqlCommand();
                        cmdrd.Connection = conDatabase;
                        cmdrd.CommandText = "select * from supplier_master_ladger_book where supplier_id='" + cmdCustomerId.SelectedValue + "'";
                        MySqlDataReader dr;

                        dr = cmdrd.ExecuteReader();
                        if (dr.Read())
                        {
                            dr.Close();
                            MySqlCommand cmdrdu = new MySqlCommand();
                            cmdrdu.Connection = conDatabase;
                            cmdrdu.CommandText = "update supplier_master_ladger_book set credit_amount=credit_amount+'" + Convert.ToDouble(txt_due_amount.Text) + "' where supplier_id='" + cmdCustomerId.SelectedValue + "'";
                            cmdrdu.ExecuteNonQuery();
                            
                        }
                        else
                        {
                            dr.Close();
                            MySqlCommand cmdrdui = new MySqlCommand();
                            cmdrdui.Connection = conDatabase;
                            cmdrdui.CommandText = "insert into supplier_master_ladger_book  (supplier_id,supplier_name,date,credit_amount) values('" + Convert.ToString(cmdCustomerId.SelectedValue) + "','" + Convert.ToString(cmdCustomerId.Text) + "','" + Convert.ToString(dateTimePicker1.Text) + "','" + Convert.ToString(txt_due_amount.Text) + "')";
                            cmdrdui.ExecuteNonQuery();
                        }


                        }
                    }
                    else
                    { 
                    
                    
                    

                    _query.InsertA("purchase_table", "date,invoice_no,suplyer_id,supplyer_phone,sub_total,vat,discount,total_amount,paid,due,paid_type,user_id,booth,note,bill_no", "'" + _purchaseController.Date + "','" + _purchaseController.VoucherNo + "','" + _purchaseController.Suplyer + "','" + _purchaseController.phone + "','" + _purchaseController.TotalSubAmount + "','" + _purchaseController.Total_Vat + "','" + _purchaseController.Total_Discount + "','" + _purchaseController.TotalPurchaseAmount + "','" + _purchaseController.Paid_amount + "','" + _purchaseController.Due + "','" + _purchaseController.PaidType + "','" + _purchaseController.User + "','" + _purchaseController.Booth + "','" + _purchaseController.Note + "','" + _purchaseController.BillNo + "'");

                    lastGetID.Text=_query.LastId;
                    for (int i = 0; i <= listviewpurchase.Items.Count - 1; i++)
                    {


                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = conDatabase;
                        cmd.CommandText = "insert into purchase_cart (fk_purchase_id,fk_product_id,net_price,purchase_price,qty,sub_price,vat,discount,total_price) values (@fk_purchase_id,@fk_product_id,@net_price,@purchase_price,@qty,@sub_price,@vat,@discount,@total_price)";
                        cmd.Parameters.AddWithValue("fk_purchase_id", _query.LastId);
                        cmd.Parameters.AddWithValue("fk_product_id", Convert.ToString(listviewpurchase.Items[i].SubItems[1].Text));
                        cmd.Parameters.AddWithValue("net_price", Convert.ToString(listviewpurchase.Items[i].SubItems[3].Text));
                        cmd.Parameters.AddWithValue("purchase_price", Convert.ToString(listviewpurchase.Items[i].SubItems[4].Text));
                        cmd.Parameters.AddWithValue("qty", Convert.ToString(listviewpurchase.Items[i].SubItems[5].Text));
                        cmd.Parameters.AddWithValue("sub_price", Convert.ToString(listviewpurchase.Items[i].SubItems[12].Text));
                        cmd.Parameters.AddWithValue("vat", Convert.ToString(listviewpurchase.Items[i].SubItems[6].Text));
                        cmd.Parameters.AddWithValue("discount", Convert.ToString(listviewpurchase.Items[i].SubItems[7].Text));
                        cmd.Parameters.AddWithValue("total_price", Convert.ToString(listviewpurchase.Items[i].SubItems[8].Text));
                        cmd.ExecuteNonQuery();

                    }
                    for (int j = 0; j <= listviewpurchase.Items.Count - 1; j++)
                    {
                        MySqlCommand cmdC = new MySqlCommand();
                        cmdC.Connection = conDatabase;
                        cmdC.CommandText = "insert into panding_stock (fk_product_id,fk_category_id,fk_brand_id,fk_subcategory_id,net_price,purchase_price,stock,vat,discount,fk_purchase_id) values ('" + Convert.ToString(listviewpurchase.Items[j].SubItems[1].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[9].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[11].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[10].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[3].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[4].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[5].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[6].Text) + "','" + Convert.ToString(listviewpurchase.Items[j].SubItems[7].Text) + "','" + _query.LastId + "') ";
                        cmdC.ExecuteNonQuery();

                    }


                   
                }
                }

                if (checkBox2.Checked == true)
                {
                    print();
                }
                else
                {

                    print();
                }
                genarateId();
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                
            
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtScanSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtScanSearch_KeyUp(object sender, KeyEventArgs e)
        {
            try
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
                    cmd_product_id.Text = dr["product_name"].ToString();
                    txt_net_price.Text = dr["set_price"].ToString();
                    txtProductName.Text = dr["product_name"].ToString();
                    txt_category.Text = dr["fk_category_id"].ToString();
                    txt_subCategory.Text = dr["fk_sub_category_id"].ToString();
                    txt_brand.Text = dr["fk_brand_id"].ToString();



                }

            }
            catch (Exception)
            { }
        }

        private void txt_total_amount_TextChanged(object sender, EventArgs e)
        {
            txt_due_amount.Text = txt_total_amount.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            print();
        }

        private void txt_quentity_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

        }
    }
}
