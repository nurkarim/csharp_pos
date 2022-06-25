using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.CrystalReport.Income
{
    public partial class Report_viewr : Form
    {
        public Report_viewr()
        {
            InitializeComponent();
        }

        public string Type { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string DateA { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string DateB { get { return textBox3.Text; } set { textBox3.Text = value; } }
        private void Report_viewr_Load(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "daily")
                {
                    Income.DailyIncome obj = new DailyIncome();
                    obj.SetParameterValue("date", textBox2.Text);
                    crystalReportViewer1.ReportSource = obj;
                }


                else if (textBox1.Text == "monthly")
                {
                    Income.MonthlyIncome obj = new MonthlyIncome();
                    obj.SetParameterValue("date", textBox2.Text);
                    obj.SetParameterValue("dateB", textBox3.Text);
                    crystalReportViewer1.ReportSource = obj;
                }

                else if (textBox1.Text == "month")
                {
                    Income.MonDailyIncome obj = new MonDailyIncome();
                    obj.SetParameterValue("date", textBox2.Text);
                  
                    crystalReportViewer1.ReportSource = obj;
                }
                else if (textBox1.Text == "voucher")
                {
                    Income.voucherIncomeReport obj = new voucherIncomeReport();
                    obj.SetParameterValue("voucherNo", textBox2.Text);
                    crystalReportViewer1.ReportSource = obj;
                }
            }
            catch(Exception)
            {}
        }
    }
}
