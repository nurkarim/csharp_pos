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
namespace SuperShop.View.purchase
{
    public partial class purchaseReturn : Form
    {
        public purchaseReturn()
        {
            InitializeComponent();
            views();
            supplyerName();
            ProducstName();
            category();
            genarateId();
        }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        DB.query _query = new DB.query();
        public string Booth { get { return txt_booth.Text; } set { txt_booth.Text = value; } }
        public string User { get { return txt_user.Text; } set { txt_user.Text = value; } }
        Controller.SaleReturnController _returnController = new Controller.SaleReturnController();

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
                cmd.CommandText = "SELECT id,name FROM supplyer_table where status='1'";
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
        public void views()
        {
            try
            {

                dataGridView1.DataSource = _query.Select("viewstock");
            }
            catch (Exception)
            {

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
                cmd.CommandText = "SELECT id+1 FROM purchase_return order by id desc";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {

                    int getId = dr.GetInt32(0);


                    txt_voucher_no.Text = getId.ToString();
                    sumId = Convert.ToInt32(getId);
                    if (0 < sumId && 10 > sumId)
                    {
                        txt_voucher_no.Text = "PR" + booth + "00" + sumId.ToString();
                    }
                    else if (10 < sumId)
                    {
                        txt_voucher_no.Text = "PR" + booth + "0" + sumId.ToString();
                    }
                    else if (99 < sumId && 100 > sumId)
                    {
                        txt_voucher_no.Text = "PR" + booth + "0" + sumId.ToString();
                    }

                    else if (100 < sumId && 1000 > sumId)
                    {
                        txt_voucher_no.Text = "PR" + booth + "0" + sumId.ToString();

                    }
                    else if (1000 <= sumId)
                    {
                        txt_voucher_no.Text = "PR" + booth + "0" + sumId.ToString();

                    }
                    else
                    {
                        txt_voucher_no.Text = "PR-" + booth + sumId.ToString();

                    }

                }

                else
                {

                    sumId = Convert.ToInt32(1);
                    if (0 < sumId )
                    {
                        txt_voucher_no.Text = "PR" + booth + "00" + sumId.ToString();
                    }

          

                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        private void purchaseReturn_Load(object sender, EventArgs e)
        {
            cmd_product_id.Text = "";
            cmdCustomerId.Text = "";
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
                    txtPrice.Text = dr["sale_price"].ToString();
                    txtProductName.Text = dr["product_name"].ToString();
                    dr.Close();
                }
                else
                {
                    txtPrice.Text = "";
                    txtProductName.Text = "";
                    //txt_weight.Text = "";

                    // cmd_weight_type.Text = "";
                }
            }
            catch (Exception)
            { }
        }
        private void cmd_product_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            productSelectTable();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            supplyerName();
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
                label14.Text = j.ToString();
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
                if (txt_quentity.Text == "")
                {
                    MessageBox.Show("Please enter no. of sale quantity", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_quentity.Focus();
                    return;
                }
                double SaleQty = Convert.ToDouble(txt_quentity.Text);
                if (SaleQty == 0)
                {
                    MessageBox.Show("no. of sale quantity can not be zero", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_quentity.Focus();
                    return;
                }

                if (ListView1.Items.Count == 0)
                {

                    ListViewItem lst = new ListViewItem();
                    lst.SubItems.Add(Convert.ToString(cmd_product_id.SelectedValue));
                    lst.SubItems.Add(txtProductName.Text);
                    lst.SubItems.Add(txtPrice.Text);
                    lst.SubItems.Add(Convert.ToString(txt_quentity.Text));
                    lst.SubItems.Add(txt_sub_unit.Text);

                    ListView1.Items.Add(lst);
                    txtSubTotal.Text = subtot().ToString();
                    txtProductName.Text = "";
                    cmd_product_id.Text = "";
                    txtPrice.Text = "";

                    txt_quentity.Text = "";
                    txt_sub_unit.Text = "";
                    return;
                }

                for (int j = 0; j <= ListView1.Items.Count - 1; j++)
                {
                    if (ListView1.Items[j].SubItems[1].Text == Convert.ToString(cmd_product_id.SelectedValue))
                    {
                        ListView1.Items[j].SubItems[1].Text = Convert.ToString(cmd_product_id.SelectedValue);
                        ListView1.Items[j].SubItems[2].Text = txtProductName.Text;
                        ListView1.Items[j].SubItems[3].Text = txtPrice.Text;
                        ListView1.Items[j].SubItems[4].Text = (Convert.ToDouble(ListView1.Items[j].SubItems[4].Text) + Convert.ToDouble(txt_quentity.Text)).ToString();
                        ListView1.Items[j].SubItems[5].Text = (Convert.ToDouble(ListView1.Items[j].SubItems[5].Text) + Convert.ToDouble(txt_sub_unit.Text)).ToString();
                        // ListView1.Items[j].SubItems[6].Text = Convert.ToString(txt_weight.Text);
                        //ListView1.Items[j].SubItems[7].Text = Convert.ToString(cmd_weight_type.Text);

                        txtSubTotal.Text = subtot().ToString();
                        txtProductName.Text = "";
                        cmd_product_id.Text = "";
                        txtPrice.Text = "";

                        txt_quentity.Text = "";
                        txt_sub_unit.Text = "";
                        return;

                    }
                }

                ListViewItem lst1 = new ListViewItem();

                lst1.SubItems.Add(Convert.ToString(cmd_product_id.SelectedValue));
                lst1.SubItems.Add(txtProductName.Text);
                lst1.SubItems.Add(txtPrice.Text);
                lst1.SubItems.Add(Convert.ToString(txt_quentity.Text));
                lst1.SubItems.Add(txt_sub_unit.Text);

                ListView1.Items.Add(lst1);
                txtSubTotal.Text = subtot().ToString();
                txtProductName.Text = "";
                cmd_product_id.Text = "";
                txtPrice.Text = "";

                txt_quentity.Text = "";
                txt_sub_unit.Text = "";
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_quentity_MouseClick(object sender, MouseEventArgs e)
        {
            txt_quentity.Text = "";
        }

        private void txt_quentity_KeyUp(object sender, KeyEventArgs e)
        {

            if (txt_quentity.Text != "")
            {
                txt_sub_unit.Text = (Convert.ToDouble(txtPrice.Text) * Convert.ToDouble(txt_quentity.Text)).ToString();
            }
            else
            {

            }
        }

        private void txt_total_amount_TextChanged(object sender, EventArgs e)
        {
            txt_due.Text = txt_total_amount.Text;
            if (txt_paid.Text != "")
            {
                txt_due.Text = (Convert.ToDouble(txt_total_amount.Text) - Convert.ToDouble(txt_paid.Text)).ToString();
            }
            else
            {

            }
        }

        private void txt_paid_KeyUp(object sender, KeyEventArgs e)
        {

            if (txt_paid.Text != "")
            {
                txt_due.Text = (Convert.ToDouble(txt_total_amount.Text) - Convert.ToDouble(txt_paid.Text)).ToString();
            }
            else
            {

            }
        }

        private void txt_discount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txt_total_amount.Text = (Convert.ToDouble(txt_total_amount.Text) - Convert.ToDouble(Convert.ToDouble(txt_discount.Text))).ToString();
            }
        }

        private void txt_due_TextChanged(object sender, EventArgs e)
        {
            if (txt_due.Text == "0")
            {
                txt_paid_type.Text = "Paid";

            }
            else if (txt_paid.Text != "0" && txt_due.Text != "0")
            {
                txt_paid_type.Text = "Partial left";
            }
            else if (txt_due.Text != "0")
            {
                txt_paid_type.Text = "Due";

            }
        }

        private void txt_paid_MouseClick(object sender, MouseEventArgs e)
        {
            txt_paid.Text = "";
        }

        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {
            txt_total_amount.Text = txtSubTotal.Text;

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

                crReportDocument = new CrystalReport.purchaseReturn.voucher();

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _returnController.Date = Convert.ToString(dateTimePicker1.Text);
                _returnController.VoucherNo = Convert.ToString(txt_voucher_no.Text);
                _returnController.ReciptNo = Convert.ToString(txt_recipt_no.Text);
                _returnController.CustomerId = Convert.ToString(cmdCustomerId.SelectedValue);
                _returnController.CustomerName = Convert.ToString(txt_customer_Name.Text);
                _returnController.SubTotal = Convert.ToString(txtSubTotal.Text);
                _returnController.Discount = Convert.ToString(txt_discount.Text);
                _returnController.Total = Convert.ToString(txt_total_amount.Text);
                _returnController.Paid = Convert.ToString(txt_paid.Text);
                _returnController.Due = Convert.ToString(txt_due.Text);
                _returnController.Type = Convert.ToString(txt_paid_type.Text);
                _returnController.Note = Convert.ToString(richTextBox1.Text);
                _returnController.Booth = Convert.ToString(txt_booth.Text);
                _returnController.UserID = Convert.ToString(txt_user.Text);
                _returnController.Phone = Convert.ToString(txt_phone.Text);


                if (txt_due.Text != "" && txt_due.Text != "0")
                {
                    if (cmdCustomerId.Text != "")
                    {
                        _query.InsertA("purchase_return", "return_voucher,recipt_no,date,supplier_id,supplier_name,phone,sub_total,discount,total,paid,due,note,type,booth,created_by", "'" + _returnController.VoucherNo + "','" + _returnController.ReciptNo + "','" + _returnController.Date + "','" + _returnController.CustomerId + "','" + _returnController.CustomerName + "','" + _returnController.Phone + "','" + _returnController.SubTotal + "','" + _returnController.Discount + "','" + _returnController.Total + "','" + _returnController.Paid + "','" + _returnController.Due + "','" + _returnController.Note + "','" + _returnController.Type + "','" + _returnController.Booth + "','" + _returnController.UserID + "'");
                        lastGetID.Text = _query.LastId;
                       
                        for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                        {
                            MySqlCommand cmd = new MySqlCommand("insert into purchase_return_cart (fk_sale_return_id,pdt_id,unit_price,qty,sub_unit_price) values ('" + _query.LastId + "','" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[3].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[4].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[5].Text) + "')", conDatabase);
                            cmd.ExecuteNonQuery();

                        }

                        for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                        {
                            MySqlCommand cmd = new MySqlCommand("update stock set qty=qty-'" + Convert.ToDouble(ListView1.Items[i].SubItems[4].Text) + "' where fk_product_id='" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "'", conDatabase);
                            cmd.ExecuteNonQuery();

                        }
                        _query.Insert("supplier_ladger_book", "date,supplier_name,supplier_id,phone,voucher_id,discription,debit_amount,blance", "'" + _returnController.Date + "','" + _returnController.CustomerName + "','" + _returnController.CustomerId + "','" + _returnController.Phone + "','" + _returnController.VoucherNo + "','" + _returnController.Note + "','" + _returnController.Due + "','" + _returnController.Total + "'");

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
                            cmdrdu.CommandText = "update supplier_master_ladger_book set debit_amount=debit_amount+'" + Convert.ToDouble(txt_due.Text) + "' where supplier_id='" + cmdCustomerId.SelectedValue + "'";
                            cmdrdu.ExecuteNonQuery();

                        }
                        else
                        {
                            dr.Close();
                            MySqlCommand cmdrdui = new MySqlCommand();
                            cmdrdui.Connection = conDatabase;
                            cmdrdui.CommandText = "insert into supplier_master_ladger_book  (supplier_id,supplier_name,date,debit_amount) values('" + Convert.ToString(cmdCustomerId.SelectedValue) + "','" + Convert.ToString(cmdCustomerId.Text) + "','" + Convert.ToString(dateTimePicker1.Text) + "','" + Convert.ToString(txt_due.Text) + "')";
                            cmdrdui.ExecuteNonQuery();
                        }


                        genarateId();
                        clear();
                        print();
                    }
                    else { MessageBox.Show("Please Give The Supplier Name"); }
                }

                else
                {
                    _query.InsertA("purchase_return", "return_voucher,recipt_no,date,supplier_id,supplier_name,phone,sub_total,discount,total,paid,due,note,type,booth,created_by", "'" + _returnController.VoucherNo + "','" + _returnController.ReciptNo + "','" + _returnController.Date + "','" + _returnController.CustomerId + "','" + _returnController.CustomerName + "','" + _returnController.Phone + "','" + _returnController.SubTotal + "','" + _returnController.Discount + "','" + _returnController.Total + "','" + _returnController.Paid + "','" + _returnController.Due + "','" + _returnController.Note + "','" + _returnController.Type + "','" + _returnController.Booth + "','" + _returnController.UserID + "'");
                    lastGetID.Text = _query.LastId;
                   
                    for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                    {
                        MySqlCommand cmd = new MySqlCommand("insert into purchase_return_cart (fk_sale_return_id,pdt_id,unit_price,qty,sub_unit_price) values ('" + _query.LastId + "','" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[3].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[4].Text) + "','" + Convert.ToString(ListView1.Items[i].SubItems[5].Text) + "')", conDatabase);
                        cmd.ExecuteNonQuery();

                    }

                    for (int i = 0; i <= ListView1.Items.Count - 1; i++)
                    {
                        MySqlCommand cmd = new MySqlCommand("update stock set qty=qty-'" + Convert.ToDouble(ListView1.Items[i].SubItems[4].Text) + "' where fk_product_id='" + Convert.ToString(ListView1.Items[i].SubItems[1].Text) + "'", conDatabase);
                        cmd.ExecuteNonQuery();

                    }

                    genarateId();
                    clear();
                    print();
                }
            }
            
            catch(Exception)
            {
            }
        }
        void clear()
        {
            txt_recipt_no.Text = "";
            txt_customer_Name.Text = "";
            txt_phone.Text = "";
            txt_customer_Name.Text = "";
            txtSubTotal.Text = "00.00";
            txt_total_amount.Text = "0";
            txt_paid.Text = "0";
            txt_due.Text = "0";
            txt_discount.Text = "";
            label14.Text = "00.00";
            richTextBox1.Text = "";
        }

        private void cmdCustomerId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand("select * from supplyer_table where id='" + cmdCustomerId.SelectedValue + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_phone.Text = dr["phone"].ToString();
                    txt_customer_Name.Text = dr["name"].ToString();
                }
                else
                {
                    txt_phone.Text = "";
                    txt_customer_Name.Text = "";
                }
                dr.Close();
            }
            catch (Exception)
            { }
        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                    txt_total_amount.Text = subtot().ToString();
                }


                if (ListView1.Items.Count == 0)
                {
                    txt_total_amount.Text = "00.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
