using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.CrystalReport.saleReturn
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
            if(textBox1.Text=="daily")
            {
                CrystalReport.saleReturn.dailySaleReturn obj = new  dailySaleReturn();
                obj.SetParameterValue("date", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "month")
            {
                CrystalReport.saleReturn.monthlySaleReturn obj = new monthlySaleReturn();
                obj.SetParameterValue("date", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "week")
            {
                CrystalReport.saleReturn.weeklySaleReturn obj = new weeklySaleReturn();
                obj.SetParameterValue("date", textBox2.Text);
                obj.SetParameterValue("dateA", textBox3.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "voucher")
            {
                CrystalReport.saleReturn.voucher obj = new voucher();
                obj.SetParameterValue("id",textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
        }
    }
}
