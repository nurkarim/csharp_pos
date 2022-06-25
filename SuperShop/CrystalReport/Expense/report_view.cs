using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.CrystalReport.Expense
{
    public partial class report_view : Form
    {
        public report_view()
        {
            InitializeComponent();
        }

        public string Type { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string DateA { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string DateB { get { return textBox3.Text; } set { textBox3.Text = value; } }
        private void report_view_Load(object sender, EventArgs e)
        {
           
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "voucher")
            {
                CrystalReport.Expense.VoucherExpenseReport obj = new VoucherExpenseReport();
                obj.SetParameterValue("id", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "daily")
            {
                CrystalReport.Expense.DailyExpenseReport obj = new DailyExpenseReport();
                obj.SetParameterValue("date", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "monthly")
            {
                CrystalReport.Expense.MonthlyExpenseReport obj = new MonthlyExpenseReport();
                obj.SetParameterValue("date", textBox2.Text);
                obj.SetParameterValue("dateB", textBox3.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "month")
            {
                CrystalReport.Expense.MonDailyExpenseReport obj = new MonDailyExpenseReport();
                obj.SetParameterValue("date", textBox2.Text);
       
                crystalReportViewer1.ReportSource = obj;
            }
        }
    }
}
