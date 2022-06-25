using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.CrystalReport.Supplier
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        public string Type { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string dateA { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string dateB { get { return textBox3.Text; } set { textBox3.Text = value; } }
        private void Report_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == "all")
            {
                CrystalReport.Supplier.supplierReport obj = new supplierReport();
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "ladger")
            {
                CrystalReport.Supplier.supplierLadgerBook obj = new supplierLadgerBook();
                crystalReportViewer1.ReportSource = obj;
            }

            else if (textBox1.Text == "due")
            {
                CrystalReport.Supplier.supplierDueBook obj = new supplierDueBook();
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "his")
            {
                CrystalReport.Supplier.paymentHistory obj = new paymentHistory();
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "hisM")
            {
                CrystalReport.Supplier.MonthlypaymentHistory obj = new MonthlypaymentHistory();
                obj.SetParameterValue("date",textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "supM")
            {
                CrystalReport.Supplier.supplieAccordingLadgerBook obj = new supplieAccordingLadgerBook();
                obj.SetParameterValue("id", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
        }
    }
}
