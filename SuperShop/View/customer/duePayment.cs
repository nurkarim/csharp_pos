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
namespace SuperShop.View.customer
{
    public partial class duePayment : Form
    {
        public duePayment()
        {
            InitializeComponent();
            CustomerName();
        }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        DB.query _query = new DB.query();
        public string userId { get { return label10.Text; } set { label10.Text = value; } }
        public void CustomerName()
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
        private void duePayment_Load(object sender, EventArgs e)
        {
            cmdCustomerId.Text = "";
        }

        void clear()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            cmdCustomerId.Text = "";
            comboBox1.Text = "";
        }
        private void cmdCustomerId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conDatabase = connect.connection();
                conDatabase.Open();
                if (cmdCustomerId.Text == "")
                {

                }
                else
                {
                    MySqlCommand cmd = new MySqlCommand("select debit_amount,credit_amount from customer_master_ladger_book where customer_id='" + cmdCustomerId.SelectedValue + "'", conDatabase);
                    MySqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (radioButton1.Checked==true)
                        {
                        textBox1.Text = dr["debit_amount"].ToString();
                        }
                        else if (radioButton2.Checked == true)
                        {
                            textBox2.Text = dr["credit_amount"].ToString();

                        }
                        else 
                        {
                            MessageBox.Show("Please Select Type Debit Or Credit");
                        }

                    }
                    else
                    {
                        textBox1.Text = "00";
                        textBox2.Text = "00";
                    }
                    dr.Close();

                    MySqlCommand cmds = new MySqlCommand("select phone from customer_info where id='" + cmdCustomerId.SelectedValue + "'", conDatabase);
                    MySqlDataReader drs;
                    drs = cmds.ExecuteReader();
                    if (drs.Read())
                    {
                        textBox4.Text = drs["phone"].ToString();

                        drs.Close();
                    }
                    conDatabase.Close();

                }
            }
            catch(Exception)
            {}
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    _query.InsertA("customer_payment_history", "date,pay_type,customer_id,phone,paid_amount,balance,note,user_id", "'" + dateTimePicker1.Text + "','" + type.ToString() + "','" + cmdCustomerId.SelectedValue + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + comboBox1.Text + "','" + label10.Text + "'");
                    if (Convert.ToInt32(textBox1.Text) > 0)
                    {
                        double total = Convert.ToDouble(textBox1.Text) - Convert.ToDouble(textBox3.Text);
                        _query.Update("customer_master_ladger_book", "debit_amount='" + total.ToString() + "'", "customer_id", "'" + cmdCustomerId.SelectedValue + "'");
                    }

                }
                else if (radioButton2.Checked == true)
                {
                    _query.InsertA("customer_payment_history", "date,pay_type,customer_id,phone,paid_amount,balance,note,user_id", "'" + dateTimePicker1.Text + "','" + type.ToString() + "','" + cmdCustomerId.SelectedValue + "','" + textBox4.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + comboBox1.Text + "','" + label10.Text + "'");

                    if (Convert.ToInt32(textBox2.Text) > 0)
                    {
                        double totala = Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox3.Text);
                        _query.Update("customer_master_ladger_book", "credit_amount='" + totala.ToString() + "'", "customer_id", "'" + cmdCustomerId.SelectedValue + "'");

                    }
                }

                label11.Text = _query.LastId;
                clear();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        string type;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                type = "Debit";
            }
            else
            {
                type = "Credit";
            
            }
          
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
              
                type = "Credit";
            }
            else
            {
                type = "Debit";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
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

                string Paid;
                string Blance;
                string Due;
                string User;
                string typePay;
                string voucher;
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "select * from company_register";
                MySqlDataReader dread = cmd.ExecuteReader();
                if (dread.Read())
                {
                    string companyName = dread["name"].ToString();
                    string email = dread["email"].ToString();
                    string cphoneNo = dread["phone"].ToString();
                    string address = ""+dread["address"].ToString();
                   
                
           
           

                    graphic.DrawString(companyName, new Font("Gill Sans Ultra", 18, FontStyle.Bold), new SolidBrush(Color.Tomato), 10, 10);
                    graphic.DrawString(email + "," + cphoneNo, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 40);
                    graphic.DrawString(address, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 60);
                    graphic.DrawString("-------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 70);
                    dread.Close();

                    MySqlCommand cmda = new MySqlCommand();
                    cmda.Connection = conDatabase;
                    cmda.CommandText = "select customer_payment_history.id,customer_payment_history.paid_type,customer_payment_history.date,customer_info.customer_name, customer_payment_history.phone,customer_payment_history.paid_amount,customer_payment_history.balance,user.user_name from customer_payment_history inner join customer_info on customer_payment_history.customer_id=customer_info.id inner join user on customer_payment_history.user_id=user.id where customer_payment_history.id='"+label11.Text+"'";
                    MySqlDataReader dreada = cmda.ExecuteReader();
                    if (dreada.Read())
                    {
                        string date = dreada["date"].ToString();
                        voucher = "00"+dreada["id"].ToString();
                        string voucher1 = DateTime.Now.ToString("ddMMMyyyy") + "000" + dreada["id"].ToString();
                        string Cname = dreada["customer_name"].ToString();
                        string Cphone = dreada["phone"].ToString();
                        double Tdue = Convert.ToDouble(dreada["balance"]) - Convert.ToDouble(dreada["paid_amount"]);
                        Paid = dreada["paid_amount"].ToString();
                        Blance = dreada["balance"].ToString();
                        Due = Tdue.ToString();
                        typePay = dreada["paid_type"].ToString();
                        User = dreada["user_name"].ToString();
                   
                    graphic.DrawString("Date     : " + date, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 90);
                    graphic.DrawString("Inv.No  : " + voucher, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 115);
                    graphic.DrawString("Cus.Name  : " + Cname, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 160, 90);
                    graphic.DrawString("Cus.Ph       : " + Cphone, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 160, 115);



                    graphic.DrawString("".PadRight(0) + "Blance     :   " + String.Format("{0:c}", Blance + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 25;
                    graphic.DrawString("".PadRight(0) + "Paid         :   " + String.Format("{0:c}", Paid + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 25; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(0) + "Due         :   " + String.Format("{0:c}", Due + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 20; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(0) + "Type        :   " + String.Format("{0:c}", typePay + " "), font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 25; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(50) + "Cash Recived", font, new SolidBrush(Color.Black), startX, startY + offset);

                    offset = offset + 10; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(50) + "----------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 10; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(50) + User, font, new SolidBrush(Color.Black), startX, startY + offset);
                       offset = offset + 10;
                    graphic.DrawString("".PadRight(0) + voucher1, new Font("IDAutomationHC39M", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 80;
                    offset = offset + 10; //make some room so that the total stands out.
                    graphic.DrawString("".PadRight(24) + "Thank You  For The Payment", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 17;
                    graphic.DrawString("".PadRight(24) + "Please Come Again", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + 20;
                    graphic.DrawString("".PadRight(14) + "Developed By SBIT http://www.sbit.com.bd/", new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                    dreada.Close();
                    }
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

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(70, 70,70, 70);
            printDocument.DefaultPageSettings.Margins = margins;
            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
            PrintPreviewDialog printpreview = new PrintPreviewDialog();
            printpreview.Document = printDocument;
            printpreview.ShowDialog();

            
        }
    }
}
