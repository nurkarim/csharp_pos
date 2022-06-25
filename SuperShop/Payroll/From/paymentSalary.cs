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
namespace SuperShop.Payroll.From
{
    public partial class paymentSalary : Form
    {
        public paymentSalary()
        {
            InitializeComponent();
            employee();
        }
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
        public string getUser { get { return user_id.Text; } set { user_id.Text = value; } }

        public void employee()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,name FROM employee";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void paymentSalary_Load(object sender, EventArgs e)
        {
            clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;

                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT employee.phone,employee.desination,employee_master_account.balance FROM employee inner join employee_master_account on employee.id=employee_master_account.employee_id where employee.id='" + comboBox1.SelectedValue + "'";
                MySqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox1.Text = dr["desination"].ToString();
                    textBox4.Text = dr["phone"].ToString();
                    textBox2.Text = dr["balance"].ToString();

                    dr.Close();
                }
                else
                {


                }
                dataGridView1.DataSource = _query.SelectFullTable("select employee_payment_history.date as 'Date',employee.name as 'Name',employee.phone as 'Phone',employee.desination as 'Desination',employee_payment_history.payable as 'Balance',employee_payment_history.payment as 'Paid' from employee_payment_history inner join employee on employee_payment_history.fk_employee_id=employee.id where employee_payment_history.fk_employee_id='"+comboBox1.SelectedValue+"'");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void clear()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            dataGridView1.DataSource = _query.SelectFullTable("select employee_payment_history.date as 'Date',employee.name as 'Name',employee.phone as 'Phone',employee.desination as 'Desination',employee_payment_history.payable as 'Balance',employee_payment_history.payment as 'Paid' from employee_payment_history inner join employee on employee_payment_history.fk_employee_id=employee.id");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Please Input Data");
                return;
            }
          
            else 
            {
                double total = Convert.ToDouble(textBox2.Text) - Convert.ToDouble(textBox3.Text);
                _query.InsertA("employee_payment_history", "fk_employee_id,payable,payment,date,user_id", "'" + comboBox1.SelectedValue + "','" + Convert.ToDouble(textBox2.Text) + "','" + Convert.ToDouble(textBox3.Text) + "','" + dateTimePicker1.Text + "','" + user_id.Text + "'");
               last_id.Text= _query.LastId.ToString();
                _query.Update("employee_master_account", "balance='" + total.ToString() + "'", "employee_id", "'" + comboBox1.SelectedValue + "'");
                clear();
                if(checkBox1.Checked==true)
                {
                print();
                }
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
                printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("A4", 5, 5);
                printDocument.Print();

            }
        }
        private void button2_Click(object sender, EventArgs e)
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
                    string address = "" + dread["address"].ToString();





                    graphic.DrawString(companyName, new Font("Gill Sans Ultra", 18, FontStyle.Bold), new SolidBrush(Color.Tomato), 10, 10);
                    graphic.DrawString(email + "," + cphoneNo, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 40);
                    graphic.DrawString(address, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 60);
                    graphic.DrawString("-------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 70);
                    dread.Close();

                    MySqlCommand cmda = new MySqlCommand();
                    cmda.Connection = conDatabase;
                    cmda.CommandText = "select employee_payment_history.paid_type,employee_payment_history.id, employee_payment_history.date as 'Date',employee.name as 'Name',employee.phone as 'Phone',employee.desination as 'Desination',employee_payment_history.payable as 'Balance',employee_payment_history.payment as 'Paid',user.user_name from employee_payment_history inner join employee on employee_payment_history.fk_employee_id=employee.id inner join user on employee_payment_history.user_id=user.id where employee_payment_history.id='" + last_id.Text + "'";
                    MySqlDataReader dreada = cmda.ExecuteReader();
                    if (dreada.Read())
                    {
                        string date = dreada["Date"].ToString();
                        voucher = "00" + dreada["id"].ToString();
                        string voucher1 = DateTime.Now.ToString("ddMMMyyyy") + "000" + dreada["id"].ToString();
                        string Cname = dreada["Name"].ToString();
                        string Cphone = dreada["Phone"].ToString();
                        double Tdue = Convert.ToDouble(dreada["Balance"]) - Convert.ToDouble(dreada["Paid"]);
                        Paid = dreada["Paid"].ToString();
                        Blance = dreada["Balance"].ToString();
                        Due = Tdue.ToString();
                        typePay = dreada["paid_type"].ToString();
                        User = dreada["user_name"].ToString();

                        graphic.DrawString("Date     : " + date, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 90);
                        graphic.DrawString("Inv.No  : " + voucher, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 115);
                        graphic.DrawString("Cus.Name  : " + Cname, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 160, 90);
                        graphic.DrawString("Cus.Ph       : " + Cphone, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 160, 115);



                        graphic.DrawString("".PadRight(0) + "Total       :   " + String.Format("{0:c}", Blance + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 25;
                        graphic.DrawString("".PadRight(0) + "Paid        :   " + String.Format("{0:c}", Paid + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
                        offset = offset + 25; //make some room so that the total stands out.
                        graphic.DrawString("".PadRight(0) + "Balance   :   " + String.Format("{0:c}", Due + " /="), font, new SolidBrush(Color.Black), startX, startY + offset);
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

    }
}
