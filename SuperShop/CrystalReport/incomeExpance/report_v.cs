using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.CrystalReport.incomeExpance
{
    public partial class report_v : Form
    {
        public report_v()
        {
            InitializeComponent();
        }
        public string Type { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string DateA { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string DateB { get { return textBox3.Text; } set { textBox3.Text = value; } }
        private void report_v_Load(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "daily")
                {
                    CrystalReport.incomeExpance.incomeExpance objs = new incomeExpance();
                    objs.SetParameterValue("date", textBox2.Text);
                    crystalReportViewer1.ReportSource = objs;
                }


                else if (textBox1.Text == "monthly")
                {
                    CrystalReport.incomeExpance.monthlyIncomeExpenseReport obj = new monthlyIncomeExpenseReport();
                    obj.SetParameterValue("dateA", textBox2.Text);
                    obj.SetParameterValue("dateB", textBox3.Text);
                    crystalReportViewer1.ReportSource = obj;
                }
                else if (textBox1.Text == "month")
                {
                    CrystalReport.incomeExpance.MMonthlyIncomeExpenseReport obj = new MMonthlyIncomeExpenseReport();
                    obj.SetParameterValue("date", textBox2.Text);
                  
                    crystalReportViewer1.ReportSource = obj;
                }
            }
            catch(Exception)
            {}
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

            

            
        }
    }
}
