using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using CrystalDecisions.CrystalReports.Engine;
namespace SuperShop.View.customer
{
    public partial class ReportFrom : Form
    {
        public ReportFrom()
        {
            InitializeComponent();
            CustomerName();
        }
        DB.config connect = new DB.config();
        MySqlConnection conDatabase;
        DB.query _query = new DB.query();
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
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                string type = "allCustomer";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                View.customer.RecordView obj = new RecordView();
                obj.Type = type.ToString();
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton2.Checked == true)
            {
                string type = "custLadger";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                View.customer.RecordView obj = new RecordView();
                obj.Type = type.ToString();
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton3.Checked == true)
            {
                string type = "dailyLadger";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                View.customer.RecordView obj = new RecordView();
                obj.Type = type.ToString();
                obj.DateA = dateTimePicker1.Text;
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton4.Checked == true)
            {
                string type = "monthlyLadger";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                View.customer.RecordView obj = new RecordView();
                obj.Type = type.ToString();
                obj.DateA = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8);
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton6.Checked == true)
            {
                string type = "yearly";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                View.customer.RecordView obj = new RecordView();
                obj.Type = type.ToString();
                obj.DateA = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 4);
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton7.Checked == true)
            {
                string type = "weekly";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                View.customer.RecordView obj = new RecordView();
                obj.Type = type.ToString();
                obj.DateA = dateTimePicker1.Text;
                obj.DateB = dateTimePicker2.Text;
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton5.Checked == true)
            {
                string type = "custDue";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                View.customer.RecordView obj = new RecordView();
                obj.Type = type.ToString();
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton8.Checked == true)
            {
                if (cmdCustomerId.Text == "")
                {
                    MessageBox.Show("Please Select Customer");
                    cmdCustomerId.Focus();
                    return;
                }
                else
                {
                    string type = "custAccordingLadger";
                    if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                    {
                        Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                    }
                    View.customer.RecordView obj = new RecordView();
                    obj.Type = type.ToString();
                    obj.GlobalData = Convert.ToString(cmdCustomerId.SelectedValue);
                    obj.MdiParent = index.ActiveForm;
                    obj.Show();
                    obj.Focus();
                    obj.StartPosition = FormStartPosition.CenterScreen;
                }
            }

            else if (radioButton9.Checked == true)
            {
                if (cmdCustomerId.Text == "")
                {
                    MessageBox.Show("Please Select Customer");
                    cmdCustomerId.Focus();
                    return;
                }
                else
                {
                    string type = "custAccordingrDue";
                    if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                    {
                        Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                    }
                    View.customer.RecordView obj = new RecordView();
                    obj.Type = type.ToString();
                    obj.GlobalData = Convert.ToString(cmdCustomerId.SelectedValue);
                    obj.MdiParent = index.ActiveForm;
                    obj.Show();
                    obj.Focus();
                    obj.StartPosition = FormStartPosition.CenterScreen;
                }
            }
        }

        private void ReportFrom_Load(object sender, EventArgs e)
        {
            cmdCustomerId.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                string type = "allCustomer";
                if (Application.OpenForms.OfType<CrystalReport.customer.ReportViewer>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.customer.ReportViewer>().First().Close();
                }
                CrystalReport.customer.ReportViewer obj = new CrystalReport.customer.ReportViewer();
                obj.Type = type.ToString();
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton2.Checked == true)
            {
                string type = "custLadger";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
              CrystalReport.customer.ReportViewer obj = new CrystalReport.customer.ReportViewer();
                obj.Type = type.ToString();
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton5.Checked == true)
            {
                string type = "custDueBook";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                CrystalReport.customer.ReportViewer obj = new CrystalReport.customer.ReportViewer();
                obj.Type = type.ToString();
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton7.Checked == true)
            {
                string type = "weekly";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                CrystalReport.customer.ReportViewer obj = new CrystalReport.customer.ReportViewer();
                obj.Type = type.ToString();
                obj.DateA = dateTimePicker1.Text;
                obj.DateB = dateTimePicker2.Text;
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton3.Checked == true)
            {
                string type = "daily";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                CrystalReport.customer.ReportViewer obj = new CrystalReport.customer.ReportViewer();
                obj.Type = type.ToString();
                obj.DateA = dateTimePicker1.Text;
               
                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton4.Checked == true)
            {
                string type = "monthly";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                CrystalReport.customer.ReportViewer obj = new CrystalReport.customer.ReportViewer();
                obj.Type = type.ToString();
                obj.DateA = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8);

                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton6.Checked == true)
            {
                string type = "yearly";
                if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                {
                    Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                }
                CrystalReport.customer.ReportViewer obj = new CrystalReport.customer.ReportViewer();
                obj.Type = type.ToString();
                obj.DateA = dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 4);

                obj.MdiParent = index.ActiveForm;
                obj.Show();
                obj.Focus();
                obj.WindowState = FormWindowState.Maximized;
                obj.StartPosition = FormStartPosition.CenterScreen;
            }
            else if (radioButton8.Checked == true)
            {
                if (cmdCustomerId.Text == "")
                {
                    MessageBox.Show("Please Select Customer");
                    cmdCustomerId.Focus();
                    return;
                }
                else
                {
                    string type = "custAccordingLadger";
                    if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                    {
                        Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                    }
                    CrystalReport.customer.ReportViewer obj = new CrystalReport.customer.ReportViewer();
                    obj.Type = type.ToString();
                    obj.GlobalData = Convert.ToString(cmdCustomerId.SelectedValue);
                    obj.MdiParent = index.ActiveForm;
                    obj.Show();
                    obj.Focus();
                    obj.WindowState = FormWindowState.Maximized;
                    obj.StartPosition = FormStartPosition.CenterScreen;
                }

            }
            else if (radioButton9.Checked == true)
            {
                if (cmdCustomerId.Text == "")
                {
                    MessageBox.Show("Please Select Customer");
                    cmdCustomerId.Focus();
                    return;
                }
                else
                {
                    string type = "cuswiseDueBook";
                    if (Application.OpenForms.OfType<View.customer.RecordView>().Count() == 1)
                    {
                        Application.OpenForms.OfType<View.customer.RecordView>().First().Close();
                    }
                    CrystalReport.customer.ReportViewer obj = new CrystalReport.customer.ReportViewer();
                    obj.Type = type.ToString();
                    obj.GlobalData = Convert.ToString(cmdCustomerId.SelectedValue);
                    obj.MdiParent = index.ActiveForm;
                    obj.Show();
                    obj.Focus();
                    obj.WindowState = FormWindowState.Maximized;
                    obj.StartPosition = FormStartPosition.CenterScreen;
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
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

                    crReportDocument = new CrystalReport.customer.customerInfo();

                  

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
            else if (radioButton2.Checked == true)
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

                    crReportDocument = new CrystalReport.customer.customerLadgerBook();

                    //crReportDocument.SetParameterValue("date", dateTimePicker1.Text);

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

                    crReportDocument = new CrystalReport.customer.customerMasterLadgerBook();

                    //crReportDocument.SetParameterValue("date", dateTimePicker1.Text);

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
            else if (radioButton8.Checked == true)
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

                    crReportDocument = new CrystalReport.customer.coustomerWaisLadgerBook();

                    crReportDocument.SetParameterValue("id", Convert.ToString(cmdCustomerId.SelectedValue));

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

                    crReportDocument = new CrystalReport.customer.customerDueBook();

                    crReportDocument.SetParameterValue("id", Convert.ToString(cmdCustomerId.SelectedValue));

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
            else if (radioButton3.Checked == true)
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

                    crReportDocument = new CrystalReport.customer.DailyCustomerLadgerBook();

                    crReportDocument.SetParameterValue("date",dateTimePicker1.Text);

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

                    crReportDocument = new CrystalReport.customer.monthlyLadgerBook();

                    crReportDocument.SetParameterValue("date", dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length-8));

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

                    crReportDocument = new CrystalReport.customer.yearlyLadgerBook();

                    crReportDocument.SetParameterValue("date", dateTimePicker1.Text.Substring(dateTimePicker1.Text.Length - 4));

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

                    crReportDocument = new CrystalReport.customer.monthlyCustomerLadgerBook();

                    crReportDocument.SetParameterValue("date", dateTimePicker1.Text);
                    crReportDocument.SetParameterValue("dateA", dateTimePicker2.Text);

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

                    crReportDocument = new CrystalReport.customer.monthlyCustomerLadgerBook();

                    crReportDocument.SetParameterValue("id", Convert.ToString(cmdCustomerId.SelectedValue));
                    

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
}
