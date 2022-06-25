using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace SuperShop.View.Transection
{
    public partial class transectionSummary : Form
    {
        public transectionSummary()
        {
            InitializeComponent();

            sale();
            saleR();
            purchaseR();
            purchase();
        }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        DB.query _query = new DB.query();
        public string Booth { get { return txt_booth.Text; } set { txt_booth.Text = value; } }
        public string User { get { return txt_user.Text; } set { txt_user.Text = value; } }
        void con()
        {
            conDatabase = connect.connection();
            if (conDatabase.State == ConnectionState.Open)
            {
                conDatabase.Close();
            }
            conDatabase.Open();
        }
        void sale()
        {
            try
            {
                con();
                MySqlCommand cmd = new MySqlCommand("select if(ISNULL(paid),0,sum(paid))as 'sale' from voucher where date='" + dateTimePicker1.Text + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_sale.Text = dr["sale"].ToString();
                }
                else
                {
                    txt_sale.Text = "00";
                }
                dr.Close();
            }
            catch(Exception)
            {}
        }
        void purchase()
        {
            try
            {
                con();
                MySqlCommand cmd = new MySqlCommand("select if(ISNULL(paid),0,sum(paid)) as 'purchase' from purchase_table where date='" + dateTimePicker1.Text + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_purchase.Text = dr["purchase"].ToString();
                }
                else
                {
                    txt_purchase.Text = "00";
                }
                dr.Close();
            }
            catch (Exception)
            { }
        }
        void purchaseR()
        {
            try
            {
                con();
                MySqlCommand cmd = new MySqlCommand("select if(ISNULL(paid),0,sum(paid))as 'purchaser' from purchase_return where date='" + dateTimePicker1.Text + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_purchase_return.Text = dr["purchaser"].ToString();
                }
                else
                {
                    txt_purchase_return.Text = "00";
                }
                dr.Close();
            }
            catch (Exception)
            { }
        }
        void saleR()
        {
            try
            {
                con();
                MySqlCommand cmd = new MySqlCommand("select if(ISNULL(paid),0,sum(paid))as 'saler' from sale_return where date='" + dateTimePicker1.Text + "'", conDatabase);
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    txt_sale_return.Text = dr["saler"].ToString();
                }
                else
                {
                    txt_sale_return.Text = "00";
                }
                dr.Close();
            }
            catch (Exception)
            { }
        }
        private void transectionSummary_Load(object sender, EventArgs e)
        {

        }
        public class AutoClosingMessageBox
        {

            System.Threading.Timer _timeoutTimer;
            string _caption;
            AutoClosingMessageBox(string text, string caption, int timeout)
            {
                _caption = caption;
                _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                    null, timeout, System.Threading.Timeout.Infinite);
                using (_timeoutTimer)
                    MessageBox.Show(text, caption);
            }
            public static void Show(string text, string caption, int timeout)
            {
                new AutoClosingMessageBox(text, caption, timeout);
            }
            void OnTimerElapsed(object state)
            {
                IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
                if (mbWnd != IntPtr.Zero)
                    SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                _timeoutTimer.Dispose();
            }
            const int WM_CLOSE = 0x0010;
            [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
            static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
            [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        }
        private void button3_Click(object sender, EventArgs e)
        {
           //AutoClosingMessageBox.Show("Save Success", "Success", 2000);
            txt_sale.Text = "00";
            txt_sale_return.Text = "00";
            txt_purchase_return.Text = "00";
            txt_purchase.Text = "00";
            this.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            System.Threading.Thread.Sleep(5000);
            label7.Hide();
            
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            sale();
            saleR();
            purchaseR();
            purchase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
               
                _query.Insert("summary_tranjection", "date,purchase,sale,purchase_return,sale_return,user_id,booth", "'" + dateTimePicker1.Text + "','" + txt_purchase.Text + "','" + txt_sale.Text + "','" + txt_purchase_return.Text + "','" + txt_sale_return.Text + "','" + txt_user.Text + "','" + txt_booth.Text + "'");
            if(txt_sale.Text=="")
            {
            
            }
            else if (txt_sale.Text == "0")
            {

            }
            else
            {
                _query.EIInsert("income", "date,income_sourch,amount,note,user_id", "'"+dateTimePicker1.Text+"','2','"+txt_sale.Text+"','Total Sale','"+txt_user.Text+"'");
                _query.EIInsert("temp_income_table", "date,income_sourch_id,amount,income_name", "'" + dateTimePicker1.Text + "','2','" + txt_sale.Text + "','Sale'");

            }
            if (txt_purchase_return.Text == "")
            {

            }
            else if (txt_purchase_return.Text == "0")
            {

            }
            else
            {
                _query.EIInsert("income", "date,income_sourch,amount,note,user_id", "'" + dateTimePicker1.Text + "','2','" + txt_purchase_return.Text + "','Purchase Return','" + txt_user.Text + "'");
                _query.EIInsert("temp_income_table", "date,income_sourch_id,amount,income_name", "'" + dateTimePicker1.Text + "','3','" + txt_purchase_return.Text + "','Purchase Return'");
           
            }

            if (txt_sale_return.Text == "")
            {

            }
            else if (txt_sale_return.Text == "0")
            {

            }
            else
            {
                _query.EIInsert("expense", "date,expense_sourche,amount,note,recived_by", "'" + dateTimePicker1.Text + "','10','" + txt_sale_return.Text + "','Sale Return','" + txt_user.Text + "'");
                _query.EIInsert("temp_expense_table", "date,fk_expense_type_id,amount,expense_name", "'" + dateTimePicker1.Text + "','10','" + txt_sale_return.Text + "','Sale Return'");

            }
            if (txt_purchase.Text == "")
            {

            }
            else if (txt_purchase.Text == "0")
            {

            }
            else
            {
                _query.EIInsert("expense", "date,expense_sourche,amount,note,recived_by", "'" + dateTimePicker1.Text + "','11','" + txt_purchase.Text + "','Purchase','" + txt_user.Text + "'");
                _query.EIInsert("temp_expense_table", "date,fk_expense_type_id,amount,expense_name", "'" + dateTimePicker1.Text + "','11','" + txt_purchase.Text + "','Purchase'");

            }
            }
            catch(Exception)
            {}
            }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
