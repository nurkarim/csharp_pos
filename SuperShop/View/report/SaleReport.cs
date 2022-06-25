using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Drawing.Printing;
using CrystalDecisions.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Collections;

namespace SuperShop.View.report
{
    public partial class SaleReport : Form
    {
        public SaleReport()
        {
            InitializeComponent();
            customer();
            Voucher();
        }
        public string SoftwareType { get { return label4.Text; } set { label4.Text = value; } }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        string type;
        private int _Line = 0;
        string currency;
       
        public void customer()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;
             
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,phone FROM customer_info";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox4.DataSource = ds.Tables[0];
                comboBox4.ValueMember = "id";
                comboBox4.DisplayMember = "phone" ;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void Voucher()
        {
            try
            {
                //var category = _categoryModel.dataRead();
                //comboBox1.DataSource = category;
               
                conDatabase = connect.connection();
                conDatabase.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conDatabase;
                cmd.CommandText = "SELECT id,custom_voucher_id FROM voucher";
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                sda.Dispose();
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.ValueMember = "id";
                comboBox1.DisplayMember = "custom_voucher_id";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
        public string userName { get { return txt_user.Text; } set { txt_user.Text = value; } }

        private void SaleReport_Load(object sender, EventArgs e)
        {
            comboBox4.Text = "";
            comboBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cash_sale.Checked==true)
            {
                string cash = "Paid";
                string sl = "typea";
               
                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }
                
                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.Type = cash.ToString();
                //obj.WindowState = FormWindowState.Maximized;

                //obj.Dock = DockStyle.Fill;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;
            }
            else if(due_sale.Checked==true)
            {
                string sl = "typea";
                string cash = "Due";
                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }
                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.Type = cash.ToString();
                //obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;

            }
            else if (cash_Partial_Left_sale.Checked == true)
            {
                string cash = "Partial left";
                string sl = "typea";
                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }
                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.Type = cash.ToString();
                //obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;

            }
            else if (radioButton4.Checked == true)
            {
                string cash = "Paid";
                string sl = "typeAndDate";
                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }
                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.dateA = dateTimePicker1.Text;
                obj.Type = cash.ToString();
                
                //obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;

            }
            else if (radioButton5.Checked == true)
            {
                string sl = "typeAndDate";
                string cash = "Due";
                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }
                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.Type = cash.ToString();
                obj.dateA = dateTimePicker1.Text;
                //obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;

            }
            else if (radioButton6.Checked == true)
            {
                string cash = "Partial left";
                string sl = "typeAndDate";
                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }
                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.Type = cash.ToString();
                obj.dateA = dateTimePicker1.Text;
                //obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;

            }

            else if (radioButton10.Checked == true)
            {
                string cash = "Paid";
                string sl = "typeAndDateToDate";
                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }
                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.Type = cash.ToString();
                obj.dateA = dateTimePicker1.Text;
                obj.dateB = dateTimePicker2.Text;
                //obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;

            }
            else if (radioButton9.Checked == true)
            {
                string cash = "Due";
                string sl = "typeAndDateToDate";
                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }
                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.Type = cash.ToString();
                obj.dateA = dateTimePicker1.Text;
                obj.dateB = dateTimePicker2.Text;
                //obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;

            }
            else if (radioButton7.Checked == true)
            {
                string cash = "Partial left";
                string sl = "typeAndDateToDate";
                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }
                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.Type = cash.ToString();
                obj.dateA = dateTimePicker1.Text;
                obj.dateB = dateTimePicker2.Text;
                //obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;

            }
            else if (radioButton3.Checked == true)
            {
               
                string sl = "dateA";
                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }
                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
               
                obj.dateA = dateTimePicker1.Text;
              
                //obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;

            }
            else if (radioButton11.Checked == true)
            {

                string sl = "dateADateB";
                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }
                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.dateA = dateTimePicker1.Text;
                obj.dateB = dateTimePicker2.Text;

                //obj.WindowState = FormWindowState.Maximized;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;

            }
            else if (radioButton16.Checked == true)
            {
              
                string sl = "month";

                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }

                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.dateA = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8);
                //obj.WindowState = FormWindowState.Maximized;

                //obj.Dock = DockStyle.Fill;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;
            }

            else if (radioButton1.Checked == true)
            {

                string sl = "all";

                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }

                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
             
               
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;
            }
            else if (radioButton8.Checked == true)
            {

                string sl = "customerAcording";

                CrystalReport.sale.ViewReport.saleReportViewer obj = new CrystalReport.sale.ViewReport.saleReportViewer();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.saleReportViewer>().First().Close();
                }

                obj.MdiParent = index.ActiveForm;
                obj.SL = sl.ToString();
                obj.dateA = Convert.ToString(comboBox4.SelectedValue);


                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;
            }
            else if (radioButton14.Checked == true)
            {

              

                CrystalReport.sale.ViewReport.VoucherView obj = new CrystalReport.sale.ViewReport.VoucherView();
                if (Application.OpenForms.OfType<CrystalReport.sale.ViewReport.VoucherView>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.sale.ViewReport.VoucherView>().First().Close();
                }

                obj.MdiParent = index.ActiveForm;
                obj.type = label4.Text;
                obj.vaoucher = Convert.ToString(comboBox1.SelectedValue);


                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;
            }
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {

        }

        //======================Print====================================//

        void printTypeReport()
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
                    DialogResult result = printDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {

                        printDocument.Print();

                    }
    }

        private void button3_Click(object sender, EventArgs e)
        {
            //=====================Custome Report===================================//
            if (checkBox1.Checked == true)
            {
                if (cash_sale.Checked == true)
                {
                    printTypeReport();
                }
                else if (due_sale.Checked == true)
                {
                    printTypeReport();
                }
                else if (cash_Partial_Left_sale.Checked == true)
                {
                    printTypeReport();
                }
                else if (radioButton11.Checked == true)
                {
                    dailytodailySaleReportPrint();
                }
                else if (radioButton4.Checked == true)
                {
                    dateWaiseTypeReportPrint();
                }
                else if (radioButton5.Checked == true)
                {
                    dateWaiseTypeReportPrint();
                }
                else if (radioButton6.Checked == true)
                {
                    dateWaiseTypeReportPrint();
                }
                else if (radioButton10.Checked == true)
                {
                    MonthReportCustomPrint();
                }
                else if (radioButton9.Checked == true)
                {
                    MonthReportCustomPrint();
                }
                else if (radioButton7.Checked == true)
                {
                    MonthReportCustomPrint();
                }
            }
                
            else
            {         
                if(radioButton3.Checked==true)
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

                    crReportDocument = new CrystalReport.sale.DailySaleReport();

                    crReportDocument.SetParameterValue("date", dateTimePicker1.Text);

                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton10.Checked == true)
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

                    crReportDocument = new CrystalReport.sale.MonthlyTypeWiseSaleReport();

                    crReportDocument.SetParameterValue("dateA", dateTimePicker1.Text);
                    crReportDocument.SetParameterValue("dateB", dateTimePicker2.Text);
                    crReportDocument.SetParameterValue("type", "Paid");


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton9.Checked == true)
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

                    crReportDocument = new CrystalReport.sale.MonthlyTypeWiseSaleReport();

                    crReportDocument.SetParameterValue("dateA", dateTimePicker1.Text);
                    crReportDocument.SetParameterValue("dateB", dateTimePicker2.Text);
                    crReportDocument.SetParameterValue("type", "Due");


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton7.Checked == true)
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

                    crReportDocument = new CrystalReport.sale.MonthlyTypeWiseSaleReport();

                    crReportDocument.SetParameterValue("dateA", dateTimePicker1.Text);
                    crReportDocument.SetParameterValue("dateB", dateTimePicker2.Text);
                    crReportDocument.SetParameterValue("type", "Partial left");


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton6.Checked == true)
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

                    crReportDocument = new CrystalReport.sale.dailyTypeWaiseSaleReport();

                    crReportDocument.SetParameterValue("date", dateTimePicker1.Text);
                   
                    crReportDocument.SetParameterValue("type", "Partial left");


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton5.Checked == true)
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

                    crReportDocument = new CrystalReport.sale.dailyTypeWaiseSaleReport();

                    crReportDocument.SetParameterValue("date", dateTimePicker1.Text);

                    crReportDocument.SetParameterValue("type", "Due");


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton4.Checked == true)
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

                    crReportDocument = new CrystalReport.sale.dailyTypeWaiseSaleReport();

                    crReportDocument.SetParameterValue("date", dateTimePicker1.Text);

                    crReportDocument.SetParameterValue("type", "Paid");


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton11.Checked==true)
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
                    crReportDocument = new CrystalReport.sale.MonthlySaleReport();

                    crReportDocument.SetParameterValue("dateA", dateTimePicker1.Text);
                    crReportDocument.SetParameterValue("dateB", dateTimePicker2.Text);

                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (cash_sale.Checked==true)
            {
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
                    crReportDocument = new CrystalReport.sale.CashSaleReport();

                    crReportDocument.SetParameterValue("type", "Paid");
                  

                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (due_sale.Checked == true)
            {
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
                    crReportDocument = new CrystalReport.sale.CashSaleReport();

                    crReportDocument.SetParameterValue("type", "Due");


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (cash_Partial_Left_sale.Checked == true)
            {
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
                    crReportDocument = new CrystalReport.sale.CashSaleReport();

                    crReportDocument.SetParameterValue("type", "Partial left");


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton16.Checked == true)
            {
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
                    crReportDocument = new CrystalReport.sale.onlyMonthlySaleReport();
                    string month = dateTimePicker1.Text;
                    crReportDocument.SetParameterValue("month",month.Substring(month.Length-8));


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton17.Checked == true)
            {
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
                    crReportDocument = new CrystalReport.sale.yearlyTypeSaleReport();
                    string month = dateTimePicker1.Text;
                    
                    crReportDocument.SetParameterValue("year", month.Substring(month.Length - 4));
                    crReportDocument.SetParameterValue("type","Paid");


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton15.Checked == true)
            {
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
                    crReportDocument = new CrystalReport.sale.yearlyTypeSaleReport();
                    string month = dateTimePicker1.Text;

                    crReportDocument.SetParameterValue("year", month.Substring(month.Length - 4));
                    crReportDocument.SetParameterValue("type", "Due");


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton13.Checked == true)
            {
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
                    crReportDocument = new CrystalReport.sale.yearlyTypeSaleReport();
                    string month = dateTimePicker1.Text;

                    crReportDocument.SetParameterValue("year", month.Substring(month.Length - 4));
                    crReportDocument.SetParameterValue("type", "Partial left");


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }
            else if (radioButton13.Checked == true)
            {
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
                    crReportDocument = new CrystalReport.sale.yearlySaleReport();
                    string month = dateTimePicker1.Text;

                    crReportDocument.SetParameterValue("year", month.Substring(month.Length - 4));
                 


                    try
                    {
                        crReportDocument.PrintOptions.PrinterName = PrinterName;
                        crReportDocument.PrintToPrinter(nCopy, false, sPage, ePage);

                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.ToString());
                    }
                }
            }

        }





        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cash_sale.Checked==true)
            {
            ViewAuto();

            }
            else if (due_sale.Checked==true)
            {
                ViewAuto();
            }
            else if (cash_Partial_Left_sale.Checked == true)
            {
                ViewAuto();
            }

            else if (radioButton4.Checked == true)
            {
                dateWaiseTypeReport();
            }

            else if (radioButton5.Checked == true)
            {
                dateWaiseTypeReport();
            }
            else if (radioButton6.Checked == true)
            {
                dateWaiseTypeReport();

            }
            else if (radioButton10.Checked == true)
            {
                MonthReportCustom();

            }
            else if (radioButton9.Checked == true)
            {
                MonthReportCustom();

            }
            else if (radioButton7.Checked == true)
            {
                MonthReportCustom();

            }
              else if (radioButton3.Checked == true)
            {
                dailySaleReport();

            }
            else if (radioButton11.Checked == true)
            {
                dailytodailySaleReport();

            }
           
        }
        public void dateWaiseTypeReportPrint()
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument2_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(70, 70, 70, 70);
            printDocument.DefaultPageSettings.Margins = margins;
            // printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();

            } 
        }
        public void dateWaiseTypeReport()
        {
            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument2_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(70, 70, 70, 70);
            printDocument.DefaultPageSettings.Margins = margins;
            // printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
            PrintPreviewDialog printpreview = new PrintPreviewDialog();

            ((Form)printpreview).WindowState = FormWindowState.Maximized;
            printpreview.PrintPreviewControl.Zoom = 1.0;

            printpreview.Document = printDocument;
            printpreview.ShowDialog();
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
            printpreview.PrintPreviewControl.Zoom = 1.0;

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
                    graphic.DrawString(type+" Sale Report", new Font("Arial", 13, FontStyle.Bold), new SolidBrush(Color.Navy), 350, 90);
              
                    dread.Close();

                    MySqlCommand cmda = new MySqlCommand();
                    cmda.Connection = conDatabase;
                    cmda.CommandText = "select * from voucher where type='" + type.ToString() + "'";
                    MySqlDataReader dreada = cmda.ExecuteReader();

                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 125);
                  
                    string top = "Date".PadRight(20) + "Voucher".PadRight(15) + "Unit Amount".PadRight(17) + "Vat%".PadRight(13) + "Discount".PadRight(15) + "Paid".PadRight(20) + "Due".PadRight(20) + "Total".PadRight(20) + "Booth".PadRight(5);
                    graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight; //make the spacing consistent
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                    while (dreada.Read())
                    {

                        //create the string to print on the reciept
                        string productDescription = dreada["date"].ToString();
                        string itemId = dreada["custom_voucher_id"].ToString();
                        string qty = dreada["subtotal_amount"].ToString();
                        string totals = dreada["vat"].ToString();
                        string discount = dreada["discount"].ToString();
                        string paid = dreada["paid"].ToString();
                        string due = dreada["due"].ToString();
                        string total_blance = dreada["total_amount"].ToString();
                        string booth = dreada["booth_no"].ToString();
                       
                        if (productDescription.Contains(" -"))
                        {
                            string productLine = productDescription;
                            string itemsID = itemId;
                            string totalPr = totals;


                            graphic.DrawString(productLine, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), startX, startY + offset);
                            graphic.DrawString(itemsID.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 100, 100 + offset);
                         
                            graphic.DrawString(qty.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 200, 100 + offset);
                            graphic.DrawString(totalPr.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 320, 100 + offset);
                            graphic.DrawString(discount.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 390, 100 + offset);
                            graphic.DrawString(paid.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 480, 100 + offset);
                            graphic.DrawString(due.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 580, 100 + offset);
                            graphic.DrawString(total_blance.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 680, 100 + offset);
                            graphic.DrawString(booth.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 780, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }
                        else
                        {
                            string productLine = productDescription;
                            string itemsID = itemId;
                            string QTYS = qty;
                            string TotalP = totals;


                            graphic.DrawString(productDescription, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                            graphic.DrawString(itemsID.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 100, 100 + offset);
         
                            graphic.DrawString(QTYS.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 200, 100 + offset);
                            graphic.DrawString(TotalP.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 320, 100 + offset);
                            graphic.DrawString(discount.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 390, 100 + offset);
                            graphic.DrawString(paid.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 480, 100 + offset);
                            graphic.DrawString(due.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 580, 100 + offset);
                            graphic.DrawString(total_blance.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 680, 100 + offset);
                            graphic.DrawString(booth.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 780, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }

                    }
                    dreada.Close();
                    offset = offset + 20; //make some room so that the total stands out.
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), 10, 70 + offset);
                    offset = offset + 20; //make some room so that the total stands out.
                    MySqlCommand cmdtc = new MySqlCommand();
                    cmdtc.Connection = conDatabase;
                    cmdtc.CommandText = "SELECT  currency_type.Name  FROM voucher inner join currency_type on voucher.currency_id=currency_type.id where voucher.type='" + type.ToString() + "'";
                    MySqlDataReader dreadtc = cmdtc.ExecuteReader();
                    if (dreadtc.Read())
                    {
                        currency = dreadtc["Name"].ToString();
                        dreadtc.Close();
                    }
                    MySqlCommand cmdt = new MySqlCommand();
                    cmdt.Connection = conDatabase;
                    cmdt.CommandText = "select sum(total_amount) as 'unit',sum(paid) as 'paid',sum(due) as 'duea' from voucher where type='" + type.ToString() + "'";
                    MySqlDataReader dreadt = cmdt.ExecuteReader();
                    if (dreadt.Read())
                    {


                        graphic.DrawString("Total".PadRight(8) + "= " + "".PadRight(2) + dreadt["unit"].ToString() + " " +currency.ToString()+"", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;

                        graphic.DrawString("Paid".PadRight(8) + "= " + "".PadRight(2) + dreadt["paid"].ToString() + " "+currency.ToString()+"", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;

                        graphic.DrawString("Due".PadRight(8) + "= " + "".PadRight(2) + dreadt["duea"].ToString() + " "+currency.ToString()+"", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;
                        dreadt.Close();
                    }
                 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cash_sale_CheckedChanged(object sender, EventArgs e)
        {
            if (cash_sale.Checked == true)
            {
                type = "Paid";
            }
            else
            {
            }
        }

        private void due_sale_CheckedChanged(object sender, EventArgs e)
        {
            if (due_sale.Checked == true)
            {
                type = "Due";
            }
            else
            {
            }
        }

        private void cash_Partial_Left_sale_CheckedChanged(object sender, EventArgs e)
        {
            if (cash_Partial_Left_sale.Checked == true)
            {
                type = "Partial left";
            }
            else
            {
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
                    graphic.DrawString(type + " Sale Report", new Font("Arial", 13, FontStyle.Bold), new SolidBrush(Color.Navy), 350, 90);

                    dread.Close();

                    MySqlCommand cmda = new MySqlCommand();
                    cmda.Connection = conDatabase;
                    cmda.CommandText = "select * from voucher where type='" + type.ToString() + "' and date='"+dateTimePicker1.Text+"'";
                    MySqlDataReader dreada = cmda.ExecuteReader();

                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 125);

                    string top = "Date".PadRight(20) + "Voucher".PadRight(15) + "Unit Amount".PadRight(17) + "Vat%".PadRight(13) + "Discount".PadRight(15) + "Paid".PadRight(20) + "Due".PadRight(20) + "Total".PadRight(20) + "Booth".PadRight(5);
                    graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight; //make the spacing consistent
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                    while (dreada.Read())
                    {

                        //create the string to print on the reciept
                        string productDescription = dreada["date"].ToString();
                        string itemId = dreada["custom_voucher_id"].ToString();
                        string qty = dreada["subtotal_amount"].ToString();
                        string totals = dreada["vat"].ToString();
                        string discount = dreada["discount"].ToString();
                        string paid = dreada["paid"].ToString();
                        string due = dreada["due"].ToString();
                        string total_blance = dreada["total_amount"].ToString();
                        string booth = dreada["booth_no"].ToString();

                        if (productDescription.Contains(" -"))
                        {
                            string productLine = productDescription;
                            string itemsID = itemId;
                            string totalPr = totals;


                            graphic.DrawString(productLine, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), startX, startY + offset);
                            graphic.DrawString(itemsID.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 100, 100 + offset);

                            graphic.DrawString(qty.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 200, 100 + offset);
                            graphic.DrawString(totalPr.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 320, 100 + offset);
                            graphic.DrawString(discount.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 390, 100 + offset);
                            graphic.DrawString(paid.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 480, 100 + offset);
                            graphic.DrawString(due.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 580, 100 + offset);
                            graphic.DrawString(total_blance.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 680, 100 + offset);
                            graphic.DrawString(booth.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 780, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }
                        else
                        {
                            string productLine = productDescription;
                            string itemsID = itemId;
                            string QTYS = qty;
                            string TotalP = totals;


                            graphic.DrawString(productDescription, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                            graphic.DrawString(itemsID.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 100, 100 + offset);

                            graphic.DrawString(QTYS.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 200, 100 + offset);
                            graphic.DrawString(TotalP.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 320, 100 + offset);
                            graphic.DrawString(discount.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 390, 100 + offset);
                            graphic.DrawString(paid.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 480, 100 + offset);
                            graphic.DrawString(due.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 580, 100 + offset);
                            graphic.DrawString(total_blance.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 680, 100 + offset);
                            graphic.DrawString(booth.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 780, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }

                    }
                    dreada.Close();
                    offset = offset + 20; //make some room so that the total stands out.
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), 10, 70 + offset);
                    offset = offset + 20; //make some room so that the total stands out.
                    MySqlCommand cmdtc = new MySqlCommand();
                    cmdtc.Connection = conDatabase;
                    cmdtc.CommandText = "SELECT  currency_type.Name  FROM voucher inner join currency_type on voucher.currency_id=currency_type.id where voucher.type='" + type.ToString() + "'";
                    MySqlDataReader dreadtc = cmdtc.ExecuteReader();
                    if (dreadtc.Read())
                    {
                        currency = dreadtc["Name"].ToString();
                       
                    }
                    dreadtc.Close();
                    MySqlCommand cmdt = new MySqlCommand();
                    cmdt.Connection = conDatabase;
                    cmdt.CommandText = "select sum(total_amount) as 'unit',sum(paid) as 'paid',sum(due) as 'duea' from voucher where type='" + type.ToString() + "' and date='" + dateTimePicker1.Text + "'";
                    MySqlDataReader dreadt = cmdt.ExecuteReader();
                    if (dreadt.Read())
                    {


                        graphic.DrawString("Total".PadRight(8) + "= " + "".PadRight(2) + dreadt["unit"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;

                        graphic.DrawString("Paid".PadRight(8) + "= " + "".PadRight(2) + dreadt["paid"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;

                        graphic.DrawString("Due".PadRight(8) + "= " + "".PadRight(2) + dreadt["duea"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;
                       
                    }
                    dreadt.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                type = "Paid";
            }
            else
            {
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                type = "Due";
            }
            else
            {
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked == true)
            {
                type = "Partial left";
            }
            else
            {
            }
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton10.Checked == true)
            {
                type = "Paid";
            }
            else
            {
            }
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton9.Checked == true)
            {
                type = "Due";
            }
            else
            {
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton7.Checked == true)
            {
                type = "Partial left";
            }
            else
            {
            }
        }
        void MonthReportCustom()
        {

            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument3_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(70, 70, 70, 70);
            printDocument.DefaultPageSettings.Margins = margins;
            // printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
            PrintPreviewDialog printpreview = new PrintPreviewDialog();

            ((Form)printpreview).WindowState = FormWindowState.Maximized;
            printpreview.PrintPreviewControl.Zoom = 1.0;

            printpreview.Document = printDocument;
            printpreview.ShowDialog();
        }

        void MonthReportCustomPrint()
        {

            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument3_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(70, 70, 70, 70);
            printDocument.DefaultPageSettings.Margins = margins;
            // printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
            DialogResult result = printDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }
        }
        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
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
                    graphic.DrawString(type + " Sale Report", new Font("Arial", 13, FontStyle.Bold), new SolidBrush(Color.Navy), 350, 90);
                    graphic.DrawString("Month  : " + dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8), new Font("Times New Roman", 11, FontStyle.Regular), new SolidBrush(Color.Black), 10, 115);

                    dread.Close();

                    MySqlCommand cmda = new MySqlCommand();
                    cmda.Connection = conDatabase;
                    cmda.CommandText = "select * from voucher where type='" + type.ToString() + "' and RIGHT(date,8)='" + dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8) + "'";
                    MySqlDataReader dreada = cmda.ExecuteReader();

                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 125);

                    string top = "Date".PadRight(20) + "Voucher".PadRight(15) + "Unit Amount".PadRight(17) + "Vat%".PadRight(13) + "Discount".PadRight(15) + "Paid".PadRight(20) + "Due".PadRight(20) + "Total".PadRight(20) + "Booth".PadRight(5);
                    graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight; //make the spacing consistent
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                    while (dreada.Read())
                    {

                        //create the string to print on the reciept
                        string productDescription = dreada["date"].ToString();
                        string itemId = dreada["custom_voucher_id"].ToString();
                        string qty = dreada["subtotal_amount"].ToString();
                        string totals = dreada["vat"].ToString();
                        string discount = dreada["discount"].ToString();
                        string paid = dreada["paid"].ToString();
                        string due = dreada["due"].ToString();
                        string total_blance = dreada["total_amount"].ToString();
                        string booth = dreada["booth_no"].ToString();

                        if (productDescription.Contains(" -"))
                        {
                            string productLine = productDescription;
                            string itemsID = itemId;
                            string totalPr = totals;


                            graphic.DrawString(productLine, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), startX, startY + offset);
                            graphic.DrawString(itemsID.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 100, 100 + offset);

                            graphic.DrawString(qty.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 200, 100 + offset);
                            graphic.DrawString(totalPr.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 320, 100 + offset);
                            graphic.DrawString(discount.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 390, 100 + offset);
                            graphic.DrawString(paid.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 480, 100 + offset);
                            graphic.DrawString(due.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 580, 100 + offset);
                            graphic.DrawString(total_blance.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 680, 100 + offset);
                            graphic.DrawString(booth.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 780, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }
                        else
                        {
                            string productLine = productDescription;
                            string itemsID = itemId;
                            string QTYS = qty;
                            string TotalP = totals;


                            graphic.DrawString(productDescription, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                            graphic.DrawString(itemsID.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 100, 100 + offset);

                            graphic.DrawString(QTYS.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 200, 100 + offset);
                            graphic.DrawString(TotalP.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 320, 100 + offset);
                            graphic.DrawString(discount.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 390, 100 + offset);
                            graphic.DrawString(paid.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 480, 100 + offset);
                            graphic.DrawString(due.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 580, 100 + offset);
                            graphic.DrawString(total_blance.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 680, 100 + offset);
                            graphic.DrawString(booth.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 780, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }

                    }
                    dreada.Close();
                    offset = offset + 20; //make some room so that the total stands out.
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), 10, 70 + offset);
                    offset = offset + 20; //make some room so that the total stands out.
                    MySqlCommand cmdtc = new MySqlCommand();
                    cmdtc.Connection = conDatabase;
                    cmdtc.CommandText = "SELECT  currency_type.Name  FROM voucher inner join currency_type on voucher.currency_id=currency_type.id where voucher.type='" + type.ToString() + "'";
                    MySqlDataReader dreadtc = cmdtc.ExecuteReader();
                    if (dreadtc.Read())
                    {
                        currency = dreadtc["Name"].ToString();

                    }
                    dreadtc.Close();
                    MySqlCommand cmdt = new MySqlCommand();
                    cmdt.Connection = conDatabase;
                    cmdt.CommandText = "select sum(total_amount) as 'unit',sum(paid) as 'paid',sum(due) as 'duea' from voucher where type='" + type.ToString() + "' and RIGHT(date,8)='" + dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 8) + "'";
                    MySqlDataReader dreadt = cmdt.ExecuteReader();
                    if (dreadt.Read())
                    {


                        graphic.DrawString("Total".PadRight(8) + "= " + "".PadRight(2) + dreadt["unit"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;

                        graphic.DrawString("Paid".PadRight(8) + "= " + "".PadRight(2) + dreadt["paid"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;

                        graphic.DrawString("Due".PadRight(8) + "= " + "".PadRight(2) + dreadt["duea"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;

                    }
                    dreadt.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void dailySaleReport()
        {

            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument4_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(70, 70, 70, 70);
            printDocument.DefaultPageSettings.Margins = margins;
            // printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
            PrintPreviewDialog printpreview = new PrintPreviewDialog();

            ((Form)printpreview).WindowState = FormWindowState.Maximized;
            printpreview.PrintPreviewControl.Zoom = 1.0;

            printpreview.Document = printDocument;
            printpreview.ShowDialog();
        }
        private void printDocument4_PrintPage(object sender, PrintPageEventArgs e)
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
                    graphic.DrawString(" Sale Report", new Font("Arial", 13, FontStyle.Bold), new SolidBrush(Color.Navy), 350, 90);
                    graphic.DrawString("Date  : " + dateTimePicker1.Text, new Font("Times New Roman", 11, FontStyle.Regular), new SolidBrush(Color.Black), 10, 115);

                    dread.Close();

                    MySqlCommand cmda = new MySqlCommand();
                    cmda.Connection = conDatabase;
                    cmda.CommandText = "select * from voucher where date='" + dateTimePicker1.Text+ "'";
                    MySqlDataReader dreada = cmda.ExecuteReader();

                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 125);

                    string top = "Date".PadRight(20) + "Voucher".PadRight(15) + "Unit Amount".PadRight(17) + "Vat%".PadRight(13) + "Discount".PadRight(15) + "Paid".PadRight(20) + "Due".PadRight(20) + "Total".PadRight(20) + "Booth".PadRight(5);
                    graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight; //make the spacing consistent
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                    offset = offset + (int)fontHeight + 5; //make the spacing consistent
                    while (dreada.Read())
                    {

                        //create the string to print on the reciept
                        string productDescription = dreada["date"].ToString();
                        string itemId = dreada["custom_voucher_id"].ToString();
                        string qty = dreada["subtotal_amount"].ToString();
                        string totals = dreada["vat"].ToString();
                        string discount = dreada["discount"].ToString();
                        string paid = dreada["paid"].ToString();
                        string due = dreada["due"].ToString();
                        string total_blance = dreada["total_amount"].ToString();
                        string booth = dreada["booth_no"].ToString();

                        if (productDescription.Contains(" -"))
                        {
                            string productLine = productDescription;
                            string itemsID = itemId;
                            string totalPr = totals;


                            graphic.DrawString(productLine, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), startX, startY + offset);
                            graphic.DrawString(itemsID.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 100, 100 + offset);

                            graphic.DrawString(qty.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 200, 100 + offset);
                            graphic.DrawString(totalPr.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 320, 100 + offset);
                            graphic.DrawString(discount.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 390, 100 + offset);
                            graphic.DrawString(paid.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 480, 100 + offset);
                            graphic.DrawString(due.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 580, 100 + offset);
                            graphic.DrawString(total_blance.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 680, 100 + offset);
                            graphic.DrawString(booth.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 780, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }
                        else
                        {
                            string productLine = productDescription;
                            string itemsID = itemId;
                            string QTYS = qty;
                            string TotalP = totals;


                            graphic.DrawString(productDescription, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                            graphic.DrawString(itemsID.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 100, 100 + offset);

                            graphic.DrawString(QTYS.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 200, 100 + offset);
                            graphic.DrawString(TotalP.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 320, 100 + offset);
                            graphic.DrawString(discount.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 390, 100 + offset);
                            graphic.DrawString(paid.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 480, 100 + offset);
                            graphic.DrawString(due.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 580, 100 + offset);
                            graphic.DrawString(total_blance.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 680, 100 + offset);
                            graphic.DrawString(booth.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 780, 100 + offset);

                            offset = offset + (int)fontHeight + 5; //make the spacing consistent
                        }
                       
                    }
                    dreada.Close();
                    offset = offset + 20; //make some room so that the total stands out.
                    graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), 10, 70 + offset);
                    offset = offset + 20; //make some room so that the total stands out.
                    MySqlCommand cmdtc = new MySqlCommand();
                    cmdtc.Connection = conDatabase;
                    cmdtc.CommandText = "SELECT  currency_type.Name  FROM voucher inner join currency_type on voucher.currency_id=currency_type.id";
                    MySqlDataReader dreadtc = cmdtc.ExecuteReader();
                    if (dreadtc.Read())
                    {
                        currency = dreadtc["Name"].ToString();

                    }
                    dreadtc.Close();
                    MySqlCommand cmdt = new MySqlCommand();
                    cmdt.Connection = conDatabase;
                    cmdt.CommandText = "select sum(total_amount) as 'unit',sum(paid) as 'paid',sum(due) as 'duea' from voucher where  date='" + dateTimePicker1.Text+ "'";
                    MySqlDataReader dreadt = cmdt.ExecuteReader();
                    if (dreadt.Read())
                    {


                        graphic.DrawString("Total".PadRight(8) + "= " + "".PadRight(2) + dreadt["unit"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;

                        graphic.DrawString("Paid".PadRight(8) + "= " + "".PadRight(2) + dreadt["paid"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;

                        graphic.DrawString("Due".PadRight(8) + "= " + "".PadRight(2) + dreadt["duea"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                        offset = offset + 22;

                    }
                    dreadt.Close();
                }
                e.HasMorePages = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void dailytodailySaleReport()
        {

            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument5_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(100,100,100,100);
            printDocument.DefaultPageSettings.Margins = margins;
            // printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
            PrintPreviewDialog printpreview = new PrintPreviewDialog();

            ((Form)printpreview).WindowState = FormWindowState.Maximized;
            printpreview.PrintPreviewControl.Zoom = 1.0;
          
            printpreview.Document = printDocument;
            printpreview.ShowDialog();
        }

        void dailytodailySaleReportPrint()
        {

            PrintDialog printDialog = new PrintDialog();

            PrintDocument printDocument = new PrintDocument();

            printDialog.Document = printDocument; //add the document to the dialog box...        

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument5_PrintPage); //add an event handler that will do the printing
            //printDocument.PrinterSettings.PrinterName = "HP LaserJet Professional P1102";
            // Create a new instance of Margins with 1-inch margins.
            Margins margins = new Margins(100, 100, 100, 100);
            printDocument.DefaultPageSettings.Margins = margins;
            // printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("PaperA4", 366, 432);
          DialogResult result = printDialog.ShowDialog();

          if (result == DialogResult.OK)
          {
              printDocument.Print();
          }
        }
        private void printDocument5_PrintPage(object sender, PrintPageEventArgs e)
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
                             graphic.DrawString(" Sale Report", new Font("Arial", 13, FontStyle.Bold), new SolidBrush(Color.Navy), 350, 90);
                             graphic.DrawString("Date  : " + dateTimePicker1.Text + "  To  " + dateTimePicker2.Text, new Font("Times New Roman", 11, FontStyle.Regular), new SolidBrush(Color.Black), 10, 115);

                             dread.Close();

                             MySqlCommand cmda = new MySqlCommand();
                             cmda.Connection = conDatabase;
                             cmda.CommandText = "select * from voucher where date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
                             MySqlDataReader dreada = cmda.ExecuteReader();

                             graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", new Font("Arial", 10, FontStyle.Regular), new SolidBrush(Color.Black), 10, 125);

                             string top = "Date".PadRight(20) + "Voucher".PadRight(15) + "Unit Amount".PadRight(17) + "Vat%".PadRight(13) + "Discount".PadRight(15) + "Paid".PadRight(20) + "Due".PadRight(20) + "Total".PadRight(20) + "Booth".PadRight(5);
                             graphic.DrawString(top, font, new SolidBrush(Color.Black), startX, startY + offset);
                             offset = offset + (int)fontHeight; //make the spacing consistent
                             graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), startX, startY + offset);
                             offset = offset + (int)fontHeight + 5; //make the spacing consistent
                             while (dreada.Read())
                             {

                                 //create the string to print on the reciept
                                 string productDescription = dreada["date"].ToString();
                                 string itemId = dreada["custom_voucher_id"].ToString();
                                 string qty = dreada["subtotal_amount"].ToString();
                                 string totals = dreada["vat"].ToString();
                                 string discount = dreada["discount"].ToString();
                                 string paid = dreada["paid"].ToString();
                                 string due = dreada["due"].ToString();
                                 string total_blance = dreada["total_amount"].ToString();
                                 string booth = dreada["booth_no"].ToString();

                                 if (productDescription.Contains(" -"))
                                 {
                                     string productLine = productDescription;
                                     string itemsID = itemId;
                                     string totalPr = totals;


                                     graphic.DrawString(productLine, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), startX, startY + offset);
                                     graphic.DrawString(itemsID.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 100, 100 + offset);

                                     graphic.DrawString(qty.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 200, 100 + offset);
                                     graphic.DrawString(totalPr.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 320, 100 + offset);
                                     graphic.DrawString(discount.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 390, 100 + offset);
                                     graphic.DrawString(paid.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 480, 100 + offset);
                                     graphic.DrawString(due.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 580, 100 + offset);
                                     graphic.DrawString(total_blance.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 680, 100 + offset);
                                     graphic.DrawString(booth.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Red), 780, 100 + offset);

                                     offset = offset + (int)fontHeight + 5; //make the spacing consistent
                                 }
                                 else
                                 {
                                     string productLine = productDescription;
                                     string itemsID = itemId;
                                     string QTYS = qty;
                                     string TotalP = totals;


                                     graphic.DrawString(productDescription, new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), startX, startY + offset);
                                     graphic.DrawString(itemsID.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 100, 100 + offset);

                                     graphic.DrawString(QTYS.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 200, 100 + offset);
                                     graphic.DrawString(TotalP.PadRight(20), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 320, 100 + offset);
                                     graphic.DrawString(discount.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 390, 100 + offset);
                                     graphic.DrawString(paid.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 480, 100 + offset);
                                     graphic.DrawString(due.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 580, 100 + offset);
                                     graphic.DrawString(total_blance.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 680, 100 + offset);
                                     graphic.DrawString(booth.PadRight(25), new Font("Times New Roman", 10, FontStyle.Regular), new SolidBrush(Color.Black), 780, 100 + offset);

                                     offset = offset + (int)fontHeight + 5; //make the spacing consistent
                                 }
                                
                             }
                             dreada.Close();
                             offset = offset + 20; //make some room so that the total stands out.
                             graphic.DrawString("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------", font, new SolidBrush(Color.Black), 10, 70 + offset);
                             offset = offset + 20; //make some room so that the total stands out.
                             MySqlCommand cmdtc = new MySqlCommand();
                             cmdtc.Connection = conDatabase;
                             cmdtc.CommandText = "SELECT  currency_type.Name  FROM voucher inner join currency_type on voucher.currency_id=currency_type.id";
                             MySqlDataReader dreadtc = cmdtc.ExecuteReader();
                             if (dreadtc.Read())
                             {
                                 currency = dreadtc["Name"].ToString();

                             }
                             dreadtc.Close();
                             MySqlCommand cmdt = new MySqlCommand();
                             cmdt.Connection = conDatabase;
                             cmdt.CommandText = "select sum(total_amount) as 'unit',sum(paid) as 'paid',sum(due) as 'duea' from voucher where  date BETWEEN '" + dateTimePicker1.Text + "' and '" + dateTimePicker2.Text + "'";
                             MySqlDataReader dreadt = cmdt.ExecuteReader();
                             if (dreadt.Read())
                             {


                                 graphic.DrawString("Total".PadRight(8) + "= " + "".PadRight(2) + dreadt["unit"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                                 offset = offset + 22;

                                 graphic.DrawString("Paid".PadRight(8) + "= " + "".PadRight(2) + dreadt["paid"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                                 offset = offset + 22;

                                 graphic.DrawString("Due".PadRight(8) + "= " + "".PadRight(2) + dreadt["duea"].ToString() + " " + currency.ToString() + "", new Font("Courier New", 10, FontStyle.Bold), new SolidBrush(Color.Black), startX, 70 + offset);
                                 offset = offset + 22;

                             }
                             dreadt.Close();
                         }

 
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                btnCryReport.Enabled = false;
            }
            else
            {
                btnCryReport.Enabled = true;
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
