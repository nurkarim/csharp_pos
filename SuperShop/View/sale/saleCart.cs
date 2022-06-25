using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.sale
{
    public partial class saleCart : Form
    {
        public saleCart()
        {
            InitializeComponent();
        }
        DB.query _query = new DB.query();
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        public string ID { get { return textBox1.Text; } set { textBox1.Text = value; } }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void check()
        {
            conDatabase = connect.connection();
            conDatabase.Open();
            MySqlCommand cmd = new MySqlCommand("select * from voucher where id='"+textBox1.Text+"'", conDatabase);
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                label21.Text = dr["custom_voucher_id"].ToString();
                label22.Text = dr["date"].ToString();
                label24.Text = dr["customer_name"].ToString();
                label23.Text = dr["phone"].ToString();
                label30.Text = dr["subtotal_amount"].ToString();
                label29.Text = dr["vat"].ToString();
                label28.Text = dr["discount"].ToString();
                label27.Text = dr["total_amount"].ToString();
                label26.Text = dr["paid"].ToString();
                label25.Text = dr["due"].ToString();
            }
            dr.Close();
        }
        private void saleCart_Load(object sender, EventArgs e)
        {
            check();
            dataGridView1.DataSource = _query.SelectFullTable("select product.product_name as Name, sale_cart.sale_price as Price,sale_cart.qty as Qty,sale_cart.sub_total_price as Total from sale_cart inner join product on sale_cart.fk_product_id=product.id where sale_cart.voucher_id='"+textBox1.Text+"' ");
        }
    }
}
