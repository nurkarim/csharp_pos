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
namespace SuperShop.View.report
{
    public partial class income_expense_report : Form
    {
        public income_expense_report()
        {
            InitializeComponent();
        }
        DB.config connect = new DB.config();
        DB.query _query = new DB.query();
        MySqlConnection conDatabase;
     
        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox1.Checked = false;
                if (radioButton1.Checked == true)
                {
                    CrystalReport.incomeExpance.report_v obj = new CrystalReport.incomeExpance.report_v();
                    obj.Type = "daily";
                    obj.DateA = dateTimePicker1.Text;
                    obj.Show();
                }
                else if (radioButton2.Checked == true)
                {
                    CrystalReport.incomeExpance.report_v obj = new CrystalReport.incomeExpance.report_v();
                    obj.Type = "monthly";
                    obj.DateA = dateTimePicker1.Text;
                    obj.DateB = dateTimePicker2.Text;
                    obj.Show();
                }
                else if (radioButton3.Checked == true)
                {
                    CrystalReport.incomeExpance.report_v obj = new CrystalReport.incomeExpance.report_v();
                    obj.Type = "month";
                    obj.DateA = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8);
      
                    obj.Show();
                }
            }
            else if(checkBox1.Checked==true)
            {
                checkBox2.Checked = false;
                if (radioButton1.Checked == true)
                {
                    ViewAuto();
                }
            }
        }

        private void income_expense_report_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void ViewAuto()
        {

            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(70, 70, 70, 70);
            printDocument.DefaultPageSettings.Margins = margins;
            // printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
            PrintPreviewDialog printpreview = new PrintPreviewDialog();

            ((Form)printpreview).WindowState = FormWindowState.Maximized;
            printpreview.PrintPreviewControl.Zoom=1.0;
          
            printpreview.Document = printDocument;
            printpreview.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                PrintDialog printDialog = new PrintDialog();

                PrintDocument printDocument = new PrintDocument();

                printDialog.Document = printDocument; //add the document to the dialog box...        

                printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage); //add an event handler that will do the printing
                //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
                // Create a new instance of Margins with 1-inch margins.
                Margins margins = new Margins(70, 70, 70, 70);
                printDocument.DefaultPageSettings.Margins = margins;
                // printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
                PrintPreviewDialog printpreview = new PrintPreviewDialog();

               
                printpreview.PrintPreviewControl.Zoom = 1.0;

                printpreview.Document = printDocument;
             
                DialogResult result = printDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    printDocument1.PrinterSettings.DefaultPageSettings.PaperSize = new PaperSize("A4", 5, 5);
                    printDocument.Print();

                }
            }
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
           
                string VAt;
               
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
                    string address = dread["address"].ToString();


                    VAt = dread["phone"].ToString();
        

                    graphic.DrawString(companyName, new Font("Gill Sans Ultra", 18, FontStyle.Bold), new SolidBrush(Color.Navy), 350, 10);
                    graphic.DrawString(email + "," + cphoneNo, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 320, 40);
                    graphic.DrawString(address, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 300, 60);
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 70);
                    graphic.DrawString("income && Expense Report", new Font("Arial", 13, FontStyle.Bold), new SolidBrush(Color.Navy), 350, 90);
                    graphic.DrawString("Date : " + dateTimePicker1.Text, new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 90);
                    graphic.DrawString("Income", new Font("Times New Roman", 11, FontStyle.Regular), new SolidBrush(Color.Black), 10, 115);
                    graphic.DrawString("Expense", new Font("Times New Roman", 11, FontStyle.Regular), new SolidBrush(Color.Black), 790, 115);

                    dread.Close();

                    MySqlCommand cmda = new MySqlCommand();
                    cmda.Connection = conDatabase;
                    cmda.CommandText = "select income_expense_temp_table.date, if(income_expense_temp_table.I_title=0,'null',income_type.name) as 'Details',if(income_expense_temp_table.I_amount=0,'0',income_expense_temp_table.I_amount) as 'IAmount',if(income_expense_temp_table.E_title=0,'null',expense_type.name) as 'Expense',if(income_expense_temp_table.E_amount=0,'0',income_expense_temp_table.E_amount) as 'EAmount' FROM income_expense_temp_table left JOIN income_type on income_expense_temp_table.I_title=income_type.id left JOIN expense_type on income_expense_temp_table.E_title=expense_type.id";
                    MySqlDataReader dreada = cmda.ExecuteReader();
                 
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 125);
                 
                    string top = "Details".PadRight(60) + "Amount".PadRight(18) + "Details".PadRight(70) + "Amount".PadRight(40);
                    graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight; //make the spacing consistent
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                    while (dreada.Read())
                    {
                        
                        //create the string to print on the reciept
                        string productDescription = dreada["Details"].ToString();
                        string itemId = dreada["IAmount"].ToString();
                        string qty = dreada["Expense"].ToString();
                        string totals = dreada["EAmount"].ToString();
                      
                        if (productDescription.Contains(" -"))
                        {
                            string productLine = productDescription;
                            string itemsID = itemId;
                            string totalPr = totals;


                            graphic.DrawString(productLine, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), startX, startY + offset);
                            graphic.DrawString(itemsID.PadRight(30).ToString(), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 290, 100 + offset);
                            graphic.DrawString("|", new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 390, 100 + offset);

                            graphic.DrawString(qty.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 400, 100 + offset);
                            graphic.DrawString(totalPr.PadRight(25).ToString(), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 200, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }
                        else
                        {
                            string productLine = productDescription;
                            string itemsID = Convert.ToString(itemId);
                            string QTYS = qty;
                            string TotalP = totals;


                            graphic.DrawString(productDescription, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                            graphic.DrawString(itemsID, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 290, 100 + offset);
                            graphic.DrawString("|", new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 390, 100 + offset);

                            graphic.DrawString(QTYS.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 400, 100 + offset);
                            graphic.DrawString(TotalP.PadRight(20).ToString(), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 700, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }

                    }
                    dreada.Close();
                    offset = offset + 20; //make some room so that the total stands out.
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), 10, 70 + offset);
                    offset = offset + 20; //make some room so that the total stands out.
                    string totalcash;
                    MySqlCommand cmdS = new MySqlCommand();
                    cmdS.Connection = conDatabase;
                    cmdS.CommandText = "select daily_cash_statement.balance from daily_cash_statement where date='" + dateTimePicker1.Text + "'";
                    MySqlDataReader dreadS = cmdS.ExecuteReader();
                    if (dreadS.Read())
                    {
                        totalcash = dreadS["balance"].ToString();
                        dreadS.Close();

                    MySqlCommand cmdt = new MySqlCommand();
                    cmdt.Connection = conDatabase;
                    cmdt.CommandText = "select sum(IAmount) as 'Iamount',sum(EAmount) as 'Eamount' from viewincomeexpensetemp_table where date='" + dateTimePicker1.Text + "'";
                    MySqlDataReader dreadt = cmdt.ExecuteReader();
                    if (dreadt.Read())
                    {
                        graphic.DrawString("".PadRight(40) + "= " + "".PadRight(2) + "Cash Amount" + "".PadRight(4) + "+" + "".PadRight(5) + "Income" + "".PadRight(5) + "-" + "".PadRight(5) + "Expense" + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                    offset = offset + 22;

                    graphic.DrawString("".PadRight(40) + "= " + "".PadRight(2) + totalcash.ToString() + "".PadRight(7) + "+" + "".PadRight(5) + dreadt["Iamount"].ToString() + "".PadRight(7) + "-" + "".PadRight(5) + dreadt["Eamount"].ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                    double cash = Convert.ToDouble(dreadt["Iamount"].ToString()) - Convert.ToDouble(dreadt["Eamount"].ToString());
                    offset = offset + 22;

                    graphic.DrawString("".PadRight(40) + "= " + "".PadRight(2) + totalcash.ToString() + "".PadRight(7) + "+" + "".PadRight(5) + cash.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                    double TotalcashAmount = Convert.ToDouble(totalcash.ToString()) + Convert.ToDouble(cash.ToString());
                    offset = offset + 22;

                    graphic.DrawString("".PadRight(40) + "= " + "".PadRight(2) + TotalcashAmount.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);

                  
                    }
                    
                    dreadt.Close();
                }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
          

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
         
        }
    }
}
