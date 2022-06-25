using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SuperShop.CrystalReport.purchaseReturn
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        public string Data { get { return textBox1.Text; } set { textBox1.Text = value; } }
        public string Data1 { get { return textBox2.Text; } set { textBox2.Text = value; } }
        public string Data2 { get { return textBox3.Text; } set { textBox3.Text = value; } }
        private void Report_Load(object sender, EventArgs e)
        {
            if (textBox1.Text == "vouch")
            {
                purchaseReturn.voucher obj = new voucher();
                obj.SetParameterValue("id", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "daily")
            {
                purchaseReturn.dailypurchaseReturn obj = new dailypurchaseReturn();
                obj.SetParameterValue("date", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "month")
            {
                purchaseReturn.monthlypurchaseReturn obj = new monthlypurchaseReturn();
                obj.SetParameterValue("date", textBox2.Text);
                crystalReportViewer1.ReportSource = obj;
            }
            else if (textBox1.Text == "week")
            {
                purchaseReturn.weeklypurchaseReturn obj = new weeklypurchaseReturn();
                obj.SetParameterValue("date", textBox2.Text);
                obj.SetParameterValue("dateA", textBox3.Text);
                crystalReportViewer1.ReportSource = obj;
            }

            else if (textBox1.Text == "monthSupliyer")
            {
                purchaseReturn.suplierMonth obj = new suplierMonth();
                obj.SetParameterValue("id", textBox2.Text);
                obj.SetParameterValue("date", textBox3.Text);
                crystalReportViewer1.ReportSource = obj;

            }
            else if (textBox1.Text == "Supliyer")
            {
                purchaseReturn.suplier obj = new suplier();
                obj.SetParameterValue("id", textBox2.Text);

                crystalReportViewer1.ReportSource = obj;
            }
        }
    }
}
