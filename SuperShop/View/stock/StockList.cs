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
    public partial class StockList : Form
    {
        public StockList()
        {
            InitializeComponent();
        }

        public string Brand { get { return txt_brand.Text; } set { txt_brand.Text = value; } }
        public string Category { get { return txt_category.Text; } set { txt_category.Text = value; } }
        public string SubCategory { get { return txt_sub_category.Text; } set { txt_sub_category.Text = value; } }
        public string Type { get { return type.Text; } set { type.Text = value; } }
        public string DynamekDate { get { return txt_dynamic_date.Text; } set { txt_dynamic_date.Text = value; } }
        public string Rack { get { return txt_rack.Text; } set { txt_rack.Text = value; } }
        public string ExpDate { get { return txt_expdate.Text; } set { txt_expdate.Text = value; } }
        DB.query _query = new DB.query();
        DB.config connect = new DB.config();
  

        public void view(string whereData, string value)
        {

            dataGridView1.DataSource = _query.SelectFullTable("select  stock.barcode_id as 'Barcode',product.product_name as 'Product Name',stock.net_price as 'Net Price',stock.purchase_price as 'Purchase Price',stock.sale_price as 'Sale Price',stock.vat as 'Vat%',stock.qty as 'Quentity',stock.rack_no as 'Rack No',stock.exp_date as 'Exp-Date',stock.date as 'Store Date',stock.id as 'ID' from stock inner join product on stock.fk_product_id=product.id where " + whereData.ToString() + "='" + value.ToString() + "'");
        }
        private void StockList_Load(object sender, EventArgs e)
        {

            if (type.Text == "brand")
            {
                view("stock.fk_brand_id", " "+ txt_brand.Text + "");
                salePrice();
                netPrice();
                purchasePrice();
                quentity();
            }
            else if (type.Text == "category")
            {
                view("stock.fk_category", " " + txt_category.Text + "");
                salePrice();
                netPrice();
                purchasePrice();
                quentity();
            }
            else if (type.Text == "subcategory")
            {
                view("stock.fk_sub_category_id", " " + txt_sub_category.Text + "");
                salePrice();
                netPrice();
                purchasePrice();
                quentity();
            }
            else if (type.Text == "expDate")
            {
                view("stock.exp_date", ""+txt_expdate.Text+"");
                salePrice();
                netPrice();
                purchasePrice();
                quentity();
            }
            else if (type.Text == "rack")
            {
                view("stock.rack_no", ""+txt_rack.Text+"");
                salePrice();
                netPrice();
                purchasePrice();
                quentity();
            }
            else if (type.Text == "pdtName")
            {
                view("stock.fk_product_id", " " + txt_dynamic_date.Text + "");
                salePrice();
                netPrice();
                purchasePrice();
                quentity();
            }
            else if (type.Text == "barcode")
            {
                view("stock.id", " " + txt_dynamic_date.Text + "");
                salePrice();
                netPrice();
                purchasePrice();
                quentity();
            }
            else 
            
            {
            
            }
        }
    
        void quentity()
        {
            try
            {
                int i = 0;
                int j = 0;
                double l = 0;
                j = dataGridView1.Rows.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    l += Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value.ToString());
                }
                txt_quentity.Text = l.ToString();

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        
        void netPrice()
        {
            try
            {
                int i = 0;
                int j = 0;
                double l = 0;
                j = dataGridView1.Rows.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    l += Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value.ToString());
                }
                txt_net_price.Text = l.ToString();

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        void purchasePrice()
        {
            try
            {
                int i = 0;
                int j = 0;
                double l = 0;
                j = dataGridView1.Rows.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    l += Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value.ToString());
                }
                txt_purchase.Text = l.ToString();

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        void salePrice()
        {
            try
            {
                int i = 0;
                int j = 0;
                double l = 0;
                j = dataGridView1.Rows.Count;
                for (i = 0; i <= j - 1; i++)
                {
                    l += Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value.ToString());
                }
                txt_sale.Text = l.ToString();

            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void txt_pdt_name_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            label9.Text=dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            View.stock.stockUpdate obj = new stockUpdate();
            obj.ID = label9.Text;
            obj.MdiParent = index.ActiveForm;
            obj.StartPosition = FormStartPosition.CenterScreen;
            obj.Show();
        }
    }
}
