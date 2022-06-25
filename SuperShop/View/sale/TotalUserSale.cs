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
    public partial class TotalUserSale : Form
    {
        public TotalUserSale()
        {
            InitializeComponent();
        }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        DB.query _query = new DB.query();
        public string getUser { get { return txt_user_id.Text; } set { txt_user_id.Text = value; } }
        
        private void TotalUserSale_Load(object sender, EventArgs e)
        {
            //string tomorrow = DateTime.Now.AddDays(1).ToString("dd-MMM-yyyy");
            // yesterday = DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy");
           // label1.Text = tomorrow.ToString();
             Today();
             yesterdaySale();
        }
        void con()
        {
            conDatabase = connect.connection();
            if(conDatabase.State==ConnectionState.Open)
            {
                conDatabase.Close();
            }
            conDatabase.Open();
        }
        void Today()
        {
            try
            {
                con();
                MySqlCommand cmd = new MySqlCommand("select sum(paid) as'yTotal' from voucher where user_id='"+txt_user_id.Text+"' and date='" + DateTime.Now.ToString("dd-MMM-yyyy") + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label3.Text = dr["yTotal"].ToString();
                }
                else
                {
                    label3.Text = "00.00";
                }
                dr.Close();
            }
            catch (Exception)
            { }

            conDatabase.Close();
        }
    void yesterdaySale()
        {
            try
            {
                con();
                MySqlCommand cmd = new MySqlCommand("select sum(paid) as'yTotal' from voucher where user_id='" + txt_user_id.Text + "' and date='" + DateTime.Now.AddDays(-1).ToString("dd-MMM-yyyy") + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    label2.Text = dr["yTotal"].ToString();
                }
                else
                {
                    label2.Text = "00.00";
                }
                dr.Close();
            }
        catch(Exception)
            {}
       
        conDatabase.Close();
    }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
