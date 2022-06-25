using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.CrystalReport.customer
{
    public partial class ReportViewer : Form
    {
        public ReportViewer()
        {
            InitializeComponent();
        }
        public string Type { get { return txt_type.Text; } set { txt_type.Text = value; } }
        public string GlobalData { get { return txt_global_data.Text; } set { txt_global_data.Text = value; } }
        public string DateA { get { return txt_date.Text; } set { txt_date.Text = value; } }
        public string DateB { get { return txt_date_b.Text; } set { txt_date_b.Text = value; } }
        private void ReportViewer_Load(object sender, EventArgs e)
        {
            if (txt_type.Text == "custLadger")
            {
                if (Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().First().Close();
                }
                CrystalReport.customer.customerLadgerBook obj = new customerLadgerBook();
                crystalReportViewer1.ReportSource = obj;
                obj.Refresh();
            }

            else if (txt_type.Text == "custDueBook")
            {
                if (Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().First().Close();
                }
                CrystalReport.customer.customerMasterLadgerBook obj = new customerMasterLadgerBook();
                crystalReportViewer1.ReportSource = obj;
                obj.Refresh();
            }
            else if (txt_type.Text == "allCustomer")
            {
                if (Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().First().Close();
                }
                CrystalReport.customer.customerInfo obj = new customerInfo();
                crystalReportViewer1.ReportSource = obj;
                obj.Refresh();
            }
            else if (txt_type.Text == "custAccordingLadger")
            {
                if (Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().First().Close();
                }
                CrystalReport.customer.coustomerWaisLadgerBook obj = new coustomerWaisLadgerBook();
                obj.Refresh();
                obj.SetParameterValue("id",txt_global_data.Text);
                crystalReportViewer1.ReportSource = obj;
               
            }
            else if (txt_type.Text == "weekly")
            {
                if (Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().First().Close();
                }
                CrystalReport.customer.monthlyCustomerLadgerBook obj = new monthlyCustomerLadgerBook();
                obj.Refresh();
                obj.SetParameterValue("date", txt_date.Text);
                obj.SetParameterValue("dateA", txt_date_b.Text);
                crystalReportViewer1.ReportSource = obj;

            }
            else if (txt_type.Text == "daily")
            {
                if (Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().First().Close();
                }
                CrystalReport.customer.DailyCustomerLadgerBook obj = new DailyCustomerLadgerBook();
                obj.Refresh();
                obj.SetParameterValue("date", txt_date.Text);
                
                crystalReportViewer1.ReportSource = obj;

            }
            else if (txt_type.Text == "monthly")
            {
                if (Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().First().Close();
                }
                CrystalReport.customer.monthlyLadgerBook obj = new monthlyLadgerBook();
                obj.Refresh();
                obj.SetParameterValue("date", txt_date.Text);

                crystalReportViewer1.ReportSource = obj;

            }
            else if (txt_type.Text == "yearly")
            {
                if (Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().First().Close();
                }
                CrystalReport.customer.yearlyLadgerBook obj = new yearlyLadgerBook();
                obj.Refresh();
                obj.SetParameterValue("date", txt_date.Text);

                crystalReportViewer1.ReportSource = obj;

            }
            else if (txt_type.Text == "cuswiseDueBook")
            {
                if (Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().Count() == 1)
                {
                    Application.OpenForms.OfType<CrystalReport.customer.customerLadgerBook>().First().Close();
                }
                CrystalReport.customer.customerDueBook obj = new customerDueBook();
                obj.Refresh();
                obj.SetParameterValue("id", Convert.ToString(txt_global_data.Text));

                crystalReportViewer1.ReportSource = obj;

            }
        }
    }
}
