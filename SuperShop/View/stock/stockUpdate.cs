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
    public partial class stockUpdate : Form
    {
        public stockUpdate()
        {
            InitializeComponent();
        }
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection condatabse;
        public string ID { get { return label7.Text; } set { label7.Text = value; } }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void stockUpdate_Load(object sender, EventArgs e)
        {
            try 
            {
                condatabse=connect.connection();
                condatabse.Open();
                MySqlCommand cmd = new MySqlCommand("select product.product_name,stock.barcode_id,stock.net_price,stock.purchase_price,stock.sale_price from stock inner join product on  stock.fk_product_id=product.id where stock.id='" + label7.Text + "'", condatabse);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    textBox1.Text = dr["product_name"].ToString();
                    textBox2.Text = dr["barcode_id"].ToString();
                    textBox3.Text = dr["net_price"].ToString();
                    textBox4.Text = dr["purchase_price"].ToString();
                    textBox5.Text = dr["sale_price"].ToString();
                }
                dr.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _query.Update("stock", "date='" + DateTime.Now.ToString("dd-MMM-yyyy") + "',sale_price='" + Convert.ToString(textBox5.Text) + "',updated_at='"+DateTime.Now.ToString("yyyy-MM-dd H:i:s")+"'", "id", "'" + label7.Text + "'");
        }
    }
}
