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
namespace SuperShop.View.supplier
{
    public partial class suplier_payment : Form
    {
        public suplier_payment()
        {
            InitializeComponent();
            supplyerName();
            //comboBox1.Text = "";
        }

        DB.config _config = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection cn;
        public string userId { get { return label9.Text; } set { label9.Text = value; } }

        public void supplyerName()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                cn = _config.connection();
                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cn = _config.connection();
                cn.Open();
               

                    MySqlCommand cmd = new MySqlCommand("select debit_amount,credit_amount from supplier_master_ladger_book where supplier_id='" + cmdCustomerId.SelectedValue + "'", cn);
                    MySqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        if (radioButton1.Checked == true)
                        {
                            textBox2.Text = dr["debit_amount"].ToString();
                            textBox3.Text = "00.00";
                        }
                        else if (radioButton2.Checked == true)
                        {
                            textBox3.Text = dr["credit_amount"].ToString();
                            textBox2.Text = "00.00";


                        }
                        else
                        {
                            MessageBox.Show("Please Select Type Debit Or Credit");
                        }

                    }
                    else
                    {
                        textBox3.Text = "00";
                        textBox2.Text = "00";
                    }
                    dr.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void suplier_payment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmdCustomerId.Text != "")
            {
                if (radioButton1.Checked == true)
                {
                    _query.InsertA("supplier_payment_history", "suplier_id,date,debit_amount,credit_amount,user_id,balance,due", "'" + cmdCustomerId.SelectedValue + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "','0','" + label9.Text + "','" + textBox4.Text + "','" + textBox5.Text + "'");
                    label10.Text = _query.LastId;
                    _query.Update("supplier_master_ladger_book", "debit_amount='" + textBox5.Text + "'", "supplier_id", "'" + cmdCustomerId.SelectedValue + "'");

                }
                else if (radioButton2.Checked == true)
                {
                    _query.InsertA("supplier_payment_history", "suplier_id,date,debit_amount,credit_amount,user_id,balance,due", "'" + cmdCustomerId.SelectedValue + "','" + dateTimePicker1.Text + "','0','" + textBox3.Text + "','" + label9.Text + "','" + textBox4.Text + "','" + textBox5.Text + "'");
                    label10.Text = _query.LastId;

                    _query.Update("supplier_master_ladger_book", "credit_amount='" + textBox5.Text + "'", "supplier_id", "'" + cmdCustomerId.SelectedValue + "'");

                }
            }
            else
            {
                MessageBox.Show("Please Select Supplier");
            }
            
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                {
                    double due = Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox4.Text);
                    textBox5.Text = due.ToString();
                }
                else if (radioButton2.Checked == true)
                {
                    double due = Convert.ToDouble(textBox3.Text) - Convert.ToDouble(textBox4.Text);
                    textBox5.Text = due.ToString();

                }
            }catch(Exception){}
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
                cn = _config.connection();
                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "select * from company_register";
                MySqlDataReader dread = cmd.ExecuteReader();
                if (dread.Read())
                {
                    string companyName = dread["name"].ToString();
                    string email = dread["email"].ToString();
                    string cphoneNo = dread["phone"].ToString();
                    string address = "" + dread["address"].ToString();





                    graphic.DrawString(companyName, new Font("Gill Sans Ultra", 18, FontStyle.Bold), new SolidBrush(Color.Tomato), 10, 10);
                    graphic.DrawString(email + "," + cphoneNo, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 40);
                    graphic.DrawString(address, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 60);
                    graphic.DrawString("-------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 70);
                    dread.Close();

                    MySqlCommand cmda = new MySqlCommand();
                    cmda.Connection = cn;
                    cmda.CommandText = "select supplier_payment_history.*,supplyer_table.name,supplyer_table.phone,user.user_name from supplier_payment_history inner join supplyer_table on supplier_payment_history.suplier_id=supplyer_table.id inner join user on supplier_payment_history.user_id=user.id where supplier_payment_history.id='" + label10.Text + "'";
                    MySqlDataReader dreada = cmda.ExecuteReader();
                    if (dreada.Read())
                    {
                        string date = dreada["date"].ToString();
                        voucher = "00" + dreada["id"].ToString();
                        string voucher1 = DateTime.Now.ToString("ddMMMyyyy") + "000" + dreada["id"].ToString();
                        string Cname = dreada["name"].ToString();
                        string Cphone = dreada["phone"].ToString();
                        double Tdue = Convert.ToDouble(dreada["debit_amount"]) - Convert.ToDouble(dreada["balance"]);
                        Paid = dreada["balance"].ToString();
                        Blance = dreada["debit_amount"].ToString();
                        Due = Tdue.ToString();
                       
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
                           offset = offset + 25; //make some room so that the total stands out.
                        graphic.DrawString("".PadRight(50) + "Accounts Of", font, new SolidBrush(Color.Black), startX, startY + offset);

                        offset = offset + 10; //make some room so that the total stands out.
                        graphic.DrawString("".PadRight(50) + "----------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 10; //make some room so that the total stands out.
                        graphic.DrawString("".PadRight(50) + User, font, new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 10;
                        graphic.DrawString("".PadRight(0) + voucher1, new Font("IDAutomationHC39M", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 80;
                  
                        graphic.DrawString("".PadRight(14) + "Developed By SBIT http://www.sbit.com.bd/", new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                        dreada.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {

            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(70, 70, 70, 70);
            printDocument.DefaultPageSettings.Margins = margins;
            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
            PrintPreviewDialog printpreview = new PrintPreviewDialog();
            printpreview.Document = printDocument;
            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {

                printDocument.Print();

            }
            }
            else if(radioButton2.Checked==true)
            {

                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument2_PrintPage); //add an event handler that will do the printing
                //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
                // Create a new instance of Margins with 1-inch margins.
                Margins margins = new Margins(70, 70, 70, 70);
                printDocument.DefaultPageSettings.Margins = margins;
                printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
                PrintPreviewDialog printpreview = new PrintPreviewDialog();
                printpreview.Document = printDocument;
                DialogResult result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {

                    printDocument.Print();

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

                string Paid;
                string Blance;
                string Due;
                string User;
                string typePay;
                string voucher;
                cn = _config.connection();
                cn.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "select * from company_register";
                MySqlDataReader dread = cmd.ExecuteReader();
                if (dread.Read())
                {
                    string companyName = dread["name"].ToString();
                    string email = dread["email"].ToString();
                    string cphoneNo = dread["phone"].ToString();
                    string address = "" + dread["address"].ToString();





                    graphic.DrawString(companyName, new Font("Gill Sans Ultra", 18, FontStyle.Bold), new SolidBrush(Color.Tomato), 10, 10);
                    graphic.DrawString(email + "," + cphoneNo, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 40);
                    graphic.DrawString(address, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 60);
                    graphic.DrawString("-------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 70);
                    dread.Close();

                    MySqlCommand cmda = new MySqlCommand();
                    cmda.Connection = cn;
                    cmda.CommandText = "select supplier_payment_history.*,supplyer_table.name,supplyer_table.phone,user.user_name from supplier_payment_history inner join supplyer_table on supplier_payment_history.suplier_id=supplyer_table.id inner join user on supplier_payment_history.user_id=user.id where supplier_payment_history.id='" + label10.Text + "'";
                    MySqlDataReader dreada = cmda.ExecuteReader();
                    if (dreada.Read())
                    {
                        string date = dreada["date"].ToString();
                        voucher = "00" + dreada["id"].ToString();
                        string voucher1 = DateTime.Now.ToString("ddMMMyyyy") + "000" + dreada["id"].ToString();
                        string Cname = dreada["name"].ToString();
                        string Cphone = dreada["phone"].ToString();
                        double Tdue = Convert.ToDouble(dreada["credit_amount"]) - Convert.ToDouble(dreada["balance"]);
                        Paid = dreada["balance"].ToString();
                        Blance = dreada["credit_amount"].ToString();
                        Due = Tdue.ToString();

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
                        offset = offset + 25; //make some room so that the total stands out.
                        graphic.DrawString("".PadRight(50) + "Cash Recived", font, new SolidBrush(Color.Black), startX, startY + offset);

                        offset = offset + 10; //make some room so that the total stands out.
                        graphic.DrawString("".PadRight(50) + "----------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 10; //make some room so that the total stands out.
                        graphic.DrawString("".PadRight(50) + User, font, new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 10;
                        graphic.DrawString("".PadRight(0) + voucher1, new Font("IDAutomationHC39M", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 80;

                        graphic.DrawString("".PadRight(14) + "Developed By SBIT http://www.sbit.com.bd/", new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                        dreada.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {

                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage); //add an event handler that will do the printing
                //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
                // Create a new instance of Margins with 1-inch margins.
                Margins margins = new Margins(70, 70, 70, 70);
                printDocument.DefaultPageSettings.Margins = margins;
                printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
                PrintPreviewDialog printpreview = new PrintPreviewDialog();
                printpreview.Document = printDocument;
                printpreview.ShowDialog();
            }
            else if (radioButton2.Checked == true)
            {

                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument2_PrintPage); //add an event handler that will do the printing
                //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
                // Create a new instance of Margins with 1-inch margins.
                Margins margins = new Margins(70, 70, 70, 70);
                printDocument.DefaultPageSettings.Margins = margins;
                printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
                PrintPreviewDialog printpreview = new PrintPreviewDialog();
                printpreview.Document = printDocument;
                printpreview.ShowDialog();
            }
        }
    }
}
